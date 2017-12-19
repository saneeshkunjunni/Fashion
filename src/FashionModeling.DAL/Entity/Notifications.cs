using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Notifications:BaseEntity
    {
        public string PageName { get; set; }
        public string Subject { get; set; }
        public string EmailTo { get; set; }

        public string SubId1 { get; set; }
        public string SubId2 { get; set; }
        public string SubId3 { get; set; }
        public bool Send { get; set; }
    }
}
