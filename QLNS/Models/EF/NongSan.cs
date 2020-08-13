namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NongSan")]
    public partial class NongSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NongSan()
        {
            BinhLuans = new HashSet<BinhLuan>();
            ChiTietOrders = new HashSet<ChiTietOrder>();
            Nhap_Xuat_ThuHoach = new HashSet<Nhap_Xuat_ThuHoach>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Mã nông sản:")]
        [Required(ErrorMessage = "Vui lòng nhập mã nông sản!")]
        public string ma_ns { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên nông sản:")]
        [Required(ErrorMessage = "Vui lòng nhập tên nông sản!")]
        public string ten_ns { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả:")]
        public string mo_ta { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string hinh_anh { get; set; }

        [Display(Name = "Giá gốc:")]
        public decimal? gia_goc { get; set; }

        [Display(Name = "Giá khuyến mãi:")]
        public decimal? gia_km { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết:")]
        public string chi_tiet { get; set; }

        [Display(Name = "Số lượng trong kho:")]
        public int? sl_trong_kho { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã nhóm NS:")]
        public string ma_nhom_ns { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã chất lượng:")]
        public string ma_chat_luong { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã vị trí:")]
        public string ma_vi_tri { get; set; }


        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date = DateTime.Now;
        [Display(Name = "Ngày tạo:")]
        public DateTime tao_ngay { get { return _date; } set { _date = value; } }


        [StringLength(50)]
        [Display(Name = "Người tạo:")]
        public string tao_boi { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date1 = DateTime.Now;
        [Display(Name = "Ngày sửa:")]
        public DateTime sua_ngay { get { return _date1; } set { _date1 = value; } }



        [StringLength(50)]
        [Display(Name = "Người sửa:")]
        public string sua_boi { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date2 = DateTime.Now;
        [Display(Name = "Ngày bán:")]
        public DateTime top_hot { get { return _date2; } set { _date2 = value; } }

        [Column(TypeName = "ntext")]
        [Display(Name = "Hình ảnh vị trí:")]
        public string hinh_anh_vt { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Link ảnh vị trí:")]
        public string link_anh { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Link chi tiết nông sản:")]
        public string link_chi_tiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual ChatLuong ChatLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; }

        public virtual DiaLy DiaLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhap_Xuat_ThuHoach> Nhap_Xuat_ThuHoach { get; set; }

        public virtual NhomN NhomN { get; set; }
    }
}

