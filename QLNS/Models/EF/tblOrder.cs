namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrder")]
    public partial class tblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOrder()
        {
            ChiTietOrders = new HashSet<ChiTietOrder>();
        }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _date = DateTime.Now;
        [Display(Name = "Ngày tạo:")]
        public DateTime ngay_tao { get { return _date; } set { _date = value; } }


        [StringLength(500)]
        public string ten_kh { get; set; }

        [StringLength(50)]
        public string sdt_kh { get; set; }

        [StringLength(500)]
        public string dia_chi_kh { get; set; }

        [StringLength(50)]
        public string email_kh { get; set; }

        public bool? tinh_trang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; }
    }
}
