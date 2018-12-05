namespace CRUD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
        }

        public virtual DbSet<sl_Magazyn> sl_Magazyn { get; set; }
        public virtual DbSet<tw__Towar> tw__Towar { get; set; }
        public virtual DbSet<tw_Stan> tw_Stan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sl_Magazyn>()
                .Property(e => e.mag_Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<sl_Magazyn>()
                .Property(e => e.mag_Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<sl_Magazyn>()
                .Property(e => e.mag_Opis)
                .IsUnicode(false);

            modelBuilder.Entity<sl_Magazyn>()
                .Property(e => e.mag_Analityka)
                .IsUnicode(false);

            modelBuilder.Entity<sl_Magazyn>()
                .Property(e => e.mag_POSNazwa)
                .IsUnicode(false);

            modelBuilder.Entity<sl_Magazyn>()
                .Property(e => e.mag_POSAdres)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Opis)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_JednMiary)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_PKWiU)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_SWW)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_DostSymbol)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_UrzNazwa)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_PodstKodKresk)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_StanMin)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_JednStanMin)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_WWW)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole1)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole2)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole3)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole4)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole5)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole6)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole7)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Pole8)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Uwagi)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Logo)
                .IsFixedLength();

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Objetosc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Masa)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Charakter)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_JednMiaryZak)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_KodTowaru)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_JednMiarySprz)
                .IsUnicode(false);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Wysokosc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Szerokosc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_Glebokosc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_StanMaks)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw__Towar>()
                .Property(e => e.tw_AkcyzaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw_Stan>()
                .Property(e => e.st_Stan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw_Stan>()
                .Property(e => e.st_StanMin)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw_Stan>()
                .Property(e => e.st_StanRez)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tw_Stan>()
                .Property(e => e.st_StanMax)
                .HasPrecision(19, 4);
        }
    }
}
