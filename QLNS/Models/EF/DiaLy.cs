namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaLy")]
    public partial class DiaLy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaLy()
        {
            NongSans = new HashSet<NongSan>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Mã địa lý:")]
        [Required(ErrorMessage = "Vui lòng nhập mã địa lý!")]
        public string ma_vi_tri { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên địa lý:")]
        [Required(ErrorMessage = "Vui lòng nhập tên địa lý!")]
        public string dia_chi { get; set; }

        [StringLength(2000)]
        [Display(Name = "Mô tả:")]
        public string mo_ta { get; set; }

        [StringLength(2000)]
        [Display(Name = "Chi tiết:")]
        public string chi_tiet { get; set; }
        


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NongSan> NongSans { get; set; }
    }
}
