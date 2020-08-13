namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nhap_Xuat_ThuHoach
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã Xuất/Nhập_ThuHoach:")]
        [Required(ErrorMessage = "Vui lòng nhập mã Xuất/Nhập_ThuHoach!")]
        public string ma_nx_th { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã nông sản:")]
        [Required(ErrorMessage = "Vui lòng nhập mã nông sản!")]
        public string ma_ns { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date = DateTime.Now;
        [Display(Name = "Thời gian nhập:")]
        public DateTime tg_nhap { get { return _date; } set { _date = value; } }

        [Display(Name = "Số lượng nhập:")]
        public int sl_nhap { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Đơn giá nhập:")]
        public decimal? don_gia_nhap { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date1 = DateTime.Now;
        [Display(Name = "Thời gian xuất:")]
        public DateTime tg_xuat { get { return _date1; } set { _date1 = value; } }

        [Display(Name = "Số lượng xuất:")]
        public int sl_xuat { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Đơn giá xuất:")]
        public decimal? don_gia_xuat { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date5 = DateTime.Now;
        [Display(Name = "Ngày tạo:")]
        public DateTime tao_ngay { get { return _date5; } set { _date5 = value; } }

        [StringLength(500)]
        [Display(Name = "Người tạo:")]
        public string tao_boi { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date6 = DateTime.Now;
        [Display(Name = "Ngày sửa:")]
        public DateTime sua_ngay { get { return _date6; } set { _date6 = value; } }

        [StringLength(500)]
        [Display(Name = "Người cập nhật:")]
        public string sua_boi { get; set; }
        [Display(Name = "Loại:")]
        public bool? loai { get; set; }
        public virtual NongSan NongSan { get; set; }

    }
}


