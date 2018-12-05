using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FAddProduct : Form
    {
        FProductsCrud pf;
        public FAddProduct(FProductsCrud parentForm)
        {
            InitializeComponent();
            pf = parentForm;
            List<ExtendedProduct> productTemplate = new List<ExtendedProduct>();
            productTemplate.Add(new ExtendedProduct());
            dataGridView1.DataSource = productTemplate;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            pf.Enabled = true;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ExtendedProduct product = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Select(row => new ExtendedProduct {
                    tw_Zablokowany = Convert.ToBoolean(row.Cells["tw_Zablokowany"].Value),
                    tw_Symbol = row.Cells["tw_Symbol"].FormattedValue.ToString(),
                    tw_Nazwa = row.Cells["tw_Nazwa"].FormattedValue.ToString(),
                    tw_JednMiary = row.Cells["tw_JednMiary"].FormattedValue.ToString(),
                    tw_UrzNazwa = row.Cells["tw_UrzNazwa"].FormattedValue.ToString(),
                    tw_JednMiaryZak = row.Cells["tw_JednMiaryZak"].FormattedValue.ToString(),
                    tw_JednMiarySprz = row.Cells["tw_JednMiarySprz"].FormattedValue.ToString(),
                    mag_Nazwa = row.Cells["mag_Nazwa"].FormattedValue.ToString(),
                    mag_Symbol = row.Cells["mag_Symbol"].FormattedValue.ToString(),
                    st_Stan = Convert.ToDecimal(row.Cells["st_Stan"].Value)
                }).First();
            if (ServerProducts.CreateNewProduct(product))
            {
                Close();
                pf.Enabled = true;
                pf.ViewUpdate();
            }
            else MessageBox.Show("Error!");

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if (colName.Equals("tw_Zablokowany"))
                return;
            if (colName.Equals("tw_Symbol"))
            {
                if(String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = colName + " value cannot be empty!";
                    e.Cancel = true;
                }
                if (e.FormattedValue.ToString().Length > 3)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = colName + " value is too long!";
                    e.Cancel = true;
                }
            }
            else if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = colName + " cannot be empty!";
                e.Cancel = true;
            } 
            else if (e.FormattedValue.ToString().Length > 30)
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = colName + " value is too long!";
                e.Cancel = true;
            }
        }
    }
}
