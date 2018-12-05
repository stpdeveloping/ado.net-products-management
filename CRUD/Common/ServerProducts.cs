using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace CRUD
{
    static class ServerProducts
    {
        private enum WarehouseId
        {
            main = 1,
            alt = 2
        }
        public static List<Product> LoadProducts()
        {
            using (ProductsContext ctx = new ProductsContext())
            {
                DbSet<tw__Towar> towary = ctx.tw__Towar;
                DbSet<tw_Stan> stany = ctx.tw_Stan;
                DbSet<sl_Magazyn> magazyny = ctx.sl_Magazyn;
                var query = magazyny.SelectMany(magazyn => towary.SelectMany(towar => stany
                .Where(stan => stan.st_TowId == towar.tw_Id)
                .Where(stan => stan.st_MagId == magazyn.mag_Id)
                .Select(stan => new Product
                {
                    productId = towar.tw_Id,
                    productSymbol = towar.tw_Symbol,
                    productName = towar.tw_Nazwa,
                    productQuantity = stan.st_Stan,
                    productMagName = magazyn.mag_Nazwa
                })));
                return new List<Product>(query);
            }

        }
        public static bool UpdateProductProperty(DataGridView dgv, int rowIdx, int colIdx)
        {
            string columnName = dgv.Columns.Cast<DataGridViewColumn>()
            .Where(col => col.Index == colIdx).First().Name;
            int id = (int) dgv.Rows.Cast<DataGridViewRow>().Where(row => row.Index == rowIdx)
                .First().Cells["productId"].Value;
            var value = dgv.Rows.Cast<DataGridViewRow>().Where(row => row.Index == rowIdx)
                .First().Cells[columnName].Value;
            int warehouseId = dgv.Rows.Cast<DataGridViewRow>().Where(row => row.Index == rowIdx)
                .First().Cells["productMagName"].FormattedValue.Equals("Główny") ?
                (int)WarehouseId.main : (int)WarehouseId.alt; /*można było uwzględnić id magazynu w tabeli,
            ale z racji niewielkiej liczby magazynów zrobiłem to w ten sposób*/
            using (ProductsContext ctx = new ProductsContext())
            {
                try
                {
                    switch (columnName)
                    {
                        case "productSymbol":
                            ctx.tw__Towar.Where(towar => towar.tw_Id == id)
                                .First().tw_Symbol = Convert.ToString(value).ToUpper();
                            break;
                        case "productName":
                            ctx.tw__Towar.Where(towar => towar.tw_Id == id)
                                .First().tw_Nazwa = Convert.ToString(value);
                            break;
                        case "productQuantity":
                            //ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                            var query = ctx.tw_Stan.Where(stan => stan.st_TowId == id && stan.st_MagId == warehouseId)
                                .First().st_Stan = Convert.ToDecimal(value); 
                            break;
                        default:
                            return false;
                    }
                    ctx.SaveChanges();
                }
                catch(DbEntityValidationException e)
                {
                    return false;
                }
                return true;
            }
        }
        public static bool CreateNewProduct(ExtendedProduct product)
        {
            //nie używam autogenerowanego id, ponieważ usunąłem na początku tabelę i założyłem na nowo - żeby dodać autogenerację,
            //musiałbym na nowo zintegrować tabele z EF
            using(ProductsContext ctx = new ProductsContext())
            {
                int magId = int.MinValue;
                ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                try
                {
                    if (ctx.sl_Magazyn
                    .Where(magazyn => magazyn.mag_Nazwa.Equals(product.mag_Nazwa) || magazyn.mag_Symbol.Equals(product.mag_Symbol))
                    .FirstOrDefault() == null)
                    {
                        int newmagId = ctx.sl_Magazyn.Select(magazyn => magazyn.mag_Id).Max() + 1;
                        magId = newmagId;
                        ctx.sl_Magazyn.Add(new sl_Magazyn
                        {
                            mag_Id = newmagId,
                            mag_Nazwa = product.mag_Nazwa,
                            mag_Symbol = product.mag_Symbol
                        });
                    } else
                        magId = ctx.sl_Magazyn.Where(magazyn => magazyn.mag_Nazwa.Equals(product.mag_Nazwa)
                    && magazyn.mag_Symbol.Equals(product.mag_Symbol)).First().mag_Id;
                    ctx.SaveChanges();
                    int newtwId = ctx.tw__Towar.Select(towar => towar.tw_Id).Max() + 1;
                    ctx.tw__Towar.Add(new tw__Towar
                    {
                        tw_Id = newtwId,
                        tw_Zablokowany = product.tw_Zablokowany,
                        tw_Symbol = product.tw_Symbol.ToUpper(),
                        tw_Nazwa = product.tw_Nazwa,
                        tw_JednMiary = product.tw_JednMiary,
                        tw_UrzNazwa = product.tw_UrzNazwa,
                        tw_JednMiaryZak = product.tw_JednMiaryZak,
                        tw_JednMiarySprz = product.tw_JednMiarySprz
                    });
                    ctx.sl_Magazyn.ForEachAsync(magazyn => ctx.tw_Stan.Add(new tw_Stan
                    {
                        st_TowId = newtwId,
                        st_Stan = 0,
                        st_MagId = magazyn.mag_Id
                    }));
                    ctx.SaveChanges();
                    ctx.tw_Stan.Where(stan => stan.st_TowId == newtwId && stan.st_MagId == magId).First()
                        .st_Stan = product.st_Stan;
                    ctx.SaveChanges();
                }
                catch(DbEntityValidationException e)
                {
                    return false;
                }
                return true;
            }
        }
        public static void RemoveProducts(List<int> productsIds)
        {
            using (ProductsContext ctx = new ProductsContext())
            {
                productsIds.ForEach(i => ctx.tw__Towar.Remove(ctx.tw__Towar.Where(towar => towar.tw_Id == i).First()));
                productsIds.ForEach(i => ctx.tw_Stan.Remove(ctx.tw_Stan.Where(stan => stan.st_TowId == i).First()));
                ctx.SaveChanges();
            }
        }

    }
}
