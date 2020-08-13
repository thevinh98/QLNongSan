using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Function
{
    [Serializable]
    public class TpGioHang
    {
        public NongSan nongsan { set; get; }
        public int so_luong { set; get; }
    }
}