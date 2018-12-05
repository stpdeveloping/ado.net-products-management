namespace CRUD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sl_Magazyn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mag_Id { get; set; }

        [Required]
        [StringLength(3)]
        public string mag_Symbol { get; set; }

        [Required]
        [StringLength(30)]
        public string mag_Nazwa { get; set; }

        public int mag_Status { get; set; }

        [StringLength(30)]
        public string mag_Opis { get; set; }

        [StringLength(30)]
        public string mag_Analityka { get; set; }

        public bool mag_Glowny { get; set; }

        public bool mag_POS { get; set; }

        public Guid? mag_POSIdent { get; set; }

        [StringLength(30)]
        public string mag_POSNazwa { get; set; }

        [StringLength(30)]
        public string mag_POSAdres { get; set; }
    }
}
