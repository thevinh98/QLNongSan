namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(50)]
        [Display(Name = "UserName:")]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản người dùng!")]

        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name = "PassWord:")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]

        public string PassWord { get; set; }

        [StringLength(50)]
        [Display(Name = "Email:")]
        public string email { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date = DateTime.Now;
        [Display(Name = "Ngày tạo:")]
        public DateTime ngay_tao { get { return _date; } set { _date = value; } }


        [StringLength(50)]
        [Display(Name = "Người tạo:")]
        public string nguoi_tao { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date1 = DateTime.Now;
        [Display(Name = "Ngày sửa:")]
        public DateTime ngay_sua { get { return _date1; } set { _date1 = value; } }



        [StringLength(50)]
        [Display(Name = "Người sửa:")]
        public string nguoi_sua { get; set; }
        [Display(Name = "Phân quyền:")]
        public bool? tinh_trang { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}
