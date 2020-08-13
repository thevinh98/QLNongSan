
using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class FooterDao
    {
        QLNSDbContext db = null;
        public FooterDao()
        {
            db = new QLNSDbContext();
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.tinh_trang == true);
        }
    }
}