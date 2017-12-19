using FashionModeling.DAL.Entity;
using FashionModeling.Models;
using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Services
{
    public class NotificationServices : INotificationServices
    {

        UnitOfWork unitOfwork = new UnitOfWork();
        public Guid AddNotification(NotificationRegisterModel model)
        {
            try
            {
                var result = new Notifications()
                {
                    EmailTo = model.EmailTo,
                    PageName= model.PageName,
                    Send=false,
                    SubId1 = model.SubId1,
                    SubId2 = model.SubId2,
                    SubId3=model.SubId3,
                    Subject = model.Subject,                    
                };
                unitOfwork.NotificationRepo.Insert(result);
                unitOfwork.Save();
                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditNotification(NotificationEditModel model)
        {
            try
            {
                var result = unitOfwork.NotificationRepo.Get(filter: x => x.Id == (Guid)model.NotificationId).FirstOrDefault();
                result.EmailTo = model.EmailTo;
                result.PageName = model.PageName;
                result.Send = model.Send;
                result.SubId1 = model.SubId1;
                result.SubId2 = model.SubId2;
                result.SubId3 = model.SubId3;
                result.Subject = model.Subject;
                unitOfwork.NotificationRepo.Update(result);
                return unitOfwork.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NotificationDetailsModel GetDetails(object id)
        {
            try
            {
                var result = unitOfwork.NotificationRepo.Get()
                    .Select(x => new NotificationDetailsModel()
                    {
                        CreatedDate=x.CreatedUTCDate,
                        EmailTo =x.EmailTo,
                        NotificationId= x.Id,
                        PageName=x.PageName,
                        Send=x.Send,
                        SubId1=x.SubId1,
                        SubId2=x.SubId2,
                        SubId3=x.SubId3,
                        Subject=x.Subject,
                    }).FirstOrDefault();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NotificationListModel GetNotification(int page, int pageSize)
        {
            try
            {
                var result = unitOfwork.NotificationRepo.Get()
                    .Select(x => new NotificationDetailsModel()
                    {
                        CreatedDate=x.CreatedUTCDate,
                        EmailTo = x.EmailTo,
                        NotificationId = x.Id,
                        PageName = x.PageName,
                        Send = x.Send,
                        SubId1 = x.SubId1,
                        SubId2 = x.SubId2,
                        SubId3 = x.SubId3,
                        Subject = x.Subject,
                    }).OrderByDescending(x => x.CreatedDate).ToPagedList<NotificationDetailsModel>(page, pageSize);

                return new NotificationListModel() { NotificationList = result };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NotificationEditModel GetNotificationEdit(object id)
        {
            throw new NotImplementedException();
        }
    }
}
