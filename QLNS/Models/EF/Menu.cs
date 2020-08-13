namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [StringLength(500)]
        [Display(Name = "Tiêu đề:")]
        public string tieu_de_menu { get; set; }

        [StringLength(500)]
        [Display(Name = "Link:")]
        public string link { get; set; }
        [Display(Name = "Loại menu:")]
        public int? ID_loai_menu { get; set; }

        public virtual LoaiMenu LoaiMenu { get; set; }
    }
}

