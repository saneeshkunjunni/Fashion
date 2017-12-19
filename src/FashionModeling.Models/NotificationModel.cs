using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class NotificationRegisterModel
    {
        public string PageName { get; set; }
        public string Subject { get; set; }
        public string EmailTo { get; set; }

        public string SubId1 { get; set; }
        public string SubId2 { get; set; }
        public string SubId3 { get; set; }
        public bool Send { get; set; }
    }
    public class NotificationDetailsModel: NotificationRegisterModel
    {
        public Guid NotificationId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class NotificationEditModel: NotificationRegisterModel
    {
        public Guid NotificationId { get; set; }
    }
    public class NotificationListModel
    {
        public PagedList<NotificationDetailsModel> NotificationList { get; set; }
    }
}
