namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string ma_ns { get; set; }

        [Column("BinhLuan", TypeName = "ntext")]
        public string BinhLuan1 { get; set; }

        public virtual account account { get; set; }

        public virtual NongSan NongSan { get; set; }
    }
}
