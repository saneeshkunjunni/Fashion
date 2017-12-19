using FashionModeling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface INotificationServices
    {
        Guid AddNotification(NotificationRegisterModel model);
        NotificationDetailsModel GetDetails(object id);
        NotificationEditModel GetNotificationEdit(object id);
        bool EditNotification(NotificationEditModel model);
        NotificationListModel GetNotification(int page, int pageSize);
    }
}
