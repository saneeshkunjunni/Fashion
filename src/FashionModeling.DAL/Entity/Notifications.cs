using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Notifications:BaseEntity
    {
        [StringLength(255)]
        public string PageName { get; set; }
        [StringLength(255)]
        public string Subject { get; set; }
        [StringLength(1024)]
        public string EmailTo { get; set; }
        [StringLength(255)]
        public string SubId1 { get; set; }
        [StringLength(255)]
        public string SubId2 { get; set; }
        [StringLength(255)]
        public string SubId3 { get; set; }
        public bool Send { get; set; }
    }
}
