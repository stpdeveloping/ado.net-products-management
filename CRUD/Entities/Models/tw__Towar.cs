namespace CRUD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tw__Towar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tw_Id { get; set; }

        public bool tw_Zablokowany { get; set; }

        public int tw_Rodzaj { get; set; }

        [Required]
        [StringLength(30)]
        public string tw_Symbol { get; set; }

        [Required]
        [StringLength(30)]
        public string tw_Nazwa { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Opis { get; set; }

        public int? tw_IdVatSp { get; set; }

        public int? tw_IdVatZak { get; set; }

        public bool tw_JakPrzySp { get; set; }

        [Required]
        [StringLength(30)]
        public string tw_JednMiary { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_PKWiU { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_SWW { get; set; }

        public int? tw_IdRabat { get; set; }

        public int? tw_IdOpakowanie { get; set; }

        public bool tw_PrzezWartosc { get; set; }

        public int? tw_IdPodstDostawca { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_DostSymbol { get; set; }

        public int? tw_CzasDostawy { get; set; }

        [Required]
        [StringLength(30)]
        public string tw_UrzNazwa { get; set; }

        public int? tw_PLU { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_PodstKodKresk { get; set; }

        public int? tw_IdTypKodu { get; set; }

        public bool tw_CenaOtwarta { get; set; }

        public bool? tw_WagaEtykiet { get; set; }

        public bool tw_KontrolaTW { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_StanMin { get; set; }

        [StringLength(30)]
        public string tw_JednStanMin { get; set; }

        public int? tw_DniWaznosc { get; set; }

        public int? tw_IdGrupa { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_WWW { get; set; }

        public bool tw_SklepInternet { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole1 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole2 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole3 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole4 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole5 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole6 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole7 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Pole8 { get; set; }

        //[Required]
        [StringLength(30)]
        public string tw_Uwagi { get; set; }

        [MaxLength(50)]
        public byte[] tw_Logo { get; set; }

        public bool tw_Usuniety { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_Objetosc { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_Masa { get; set; }

        [Column(TypeName = "text")]
        public string tw_Charakter { get; set; }

        [Required]
        [StringLength(30)]
        public string tw_JednMiaryZak { get; set; }

        public bool tw_JMZakInna { get; set; }

        [StringLength(30)]
        public string tw_KodTowaru { get; set; }

        public int? tw_IdKrajuPochodzenia { get; set; }

        public int? tw_IdUJM { get; set; }

        [Required]
        [StringLength(30)]
        public string tw_JednMiarySprz { get; set; }

        public bool tw_JMSprzInna { get; set; }

        public bool tw_SerwisAukcyjny { get; set; }

        public int? tw_IdProducenta { get; set; }

        public bool tw_SprzedazMobilna { get; set; }

        public bool? tw_IsFundPromocji { get; set; }

        public int? tw_IdFundPromocji { get; set; }

        public int? tw_DomyslnaKategoria { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_Wysokosc { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_Szerokosc { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_Glebokosc { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_StanMaks { get; set; }

        public bool tw_Akcyza { get; set; }

        public bool tw_AkcyzaZaznacz { get; set; }

        [Column(TypeName = "money")]
        public decimal? tw_AkcyzaKwota { get; set; }

        public bool tw_ObrotMarza { get; set; }

        public bool tw_OdwrotneObciazenie { get; set; }

        public int tw_ProgKwotowyOO { get; set; }

        public bool tw_DodawalnyDoZW { get; set; }
    }
}
