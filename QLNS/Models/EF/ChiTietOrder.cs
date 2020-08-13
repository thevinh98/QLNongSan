namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietOrder")]
    public partial class ChiTietOrder
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ma_ns { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_id { get; set; }

        public int? so_luong { get; set; }

        public decimal? gia { get; set; }

        public virtual NongSan NongSan { get; set; }

        public virtual tblOrder tblOrder { get; set; }
    }
}
