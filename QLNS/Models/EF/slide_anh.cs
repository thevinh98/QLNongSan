namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class slide_anh
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string hinh_anh { get; set; }

        public bool? tinh_trang { get; set; }
    }
}
