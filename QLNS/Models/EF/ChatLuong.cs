namespace QLNS.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChatLuong")]
    public partial class ChatLuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatLuong()
        {
            NongSans = new HashSet<NongSan>();
        }

        [Key]
        [StringLength(50)]
        public string ma_chat_luong { get; set; }

        [StringLength(2000)]
        public string ten_chat_luong { get; set; }

        [StringLength(2000)]
        public string PP_SX { get; set; }

        [StringLength(2000)]
        public string KT_dong_goi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NongSan> NongSans { get; set; }
    }
}
