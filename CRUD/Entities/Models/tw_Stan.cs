namespace CRUD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tw_Stan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int st_TowId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int st_MagId { get; set; }

        [Column(TypeName = "money")]
        public decimal st_Stan { get; set; }

        [Column(TypeName = "money")]
        public decimal st_StanMin { get; set; }

        [Column(TypeName = "money")]
        public decimal st_StanRez { get; set; }

        [Column(TypeName = "money")]
        public decimal st_StanMax { get; set; }
    }
}
