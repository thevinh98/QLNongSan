using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class SlideDao
    {
        QLNSDbContext db = null;
        public SlideDao()
        {
            db = new QLNSDbContext();
        }
        public slide_anh GetImage()
        {
            return db.slide_anh.SingleOrDefault(x => x.tinh_trang == true);
        }
    }
}