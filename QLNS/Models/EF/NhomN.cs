namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomNS")]
    public partial class NhomN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomN()
        {
            NongSans = new HashSet<NongSan>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Mã nhóm nông sản:")]
        [Required(ErrorMessage = "Vui lòng nhập mã nhóm nông sản!")]
        public string ma_nhom_ns { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên nhóm nông sản:")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhóm nông sản!")]
        public string ten_nhom_ns { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề URL:")]
        public string tieu_de_url { get; set; }

        [StringLength(50)]
        [Display(Name = "ID cha:")]
        public string ID_cha { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề tìm kiếm:")]
        public string tieu_de_tk { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date = DateTime.Now;
        [Display(Name = "Ngày tạo:")]
        public DateTime ngay_tao { get { return _date; } set { _date = value; } }

        [StringLength(500)]
        [Display(Name = "Người tạo:")]
        public string nguoi_tao { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date1 = DateTime.Now;
        [Display(Name = "Ngày sửa:")]
        public DateTime ngay_sua { get { return _date1; } set { _date1 = value; } }

        [StringLength(500)]
        [Display(Name = "Người cập nhật:")]
        public string nguoi_sua { get; set; }

        [Display(Name = "Sử dụng:")]
        public int? tinh_trang { get; set; }

        [StringLength(500)]
        [Display(Name = "Từ khóa tìm kiếm:")]
        public string tu_khoa_tk { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NongSan> NongSans { get; set; }
    }
}


