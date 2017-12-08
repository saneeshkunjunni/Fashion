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
    public class CommonServices : ICommonServices
    {

        UnitOfWork unitOfwork = new UnitOfWork();
        public Guid AddCommon(CommonRegisterModel model)
        {
            try
            {
                var result = new Common()
                {
                    Code = model.Code,
                    CreatedBy = model.CreatedBy,
                    Description = model.Description,
                    IsActive = true,
                    IsDeleted = false,
                    Title = model.Title,
                    ModifiedBy = model.CreatedBy,
                };
                unitOfwork.CommonRepo.Insert(result);
                unitOfwork.Save();
                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditCommon(CommonEditModel model)
        {
            try
            {

                var result = unitOfwork.CommonRepo.Get(x => x.Id.Equals(model.CommonId)).FirstOrDefault();
                if (result != null)
                {
                    result.Code = model.Code;
                    result.Description = model.Description;
                    result.IsActive = model.IsActive;
                    result.IsDeleted = model.IsDeleted;
                    result.ModifiedBy = model.ModifiedBy;
                    result.Title = model.Title;
                    unitOfwork.CommonRepo.Update(result);
                    return unitOfwork.Save() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CommonListModel GetCommon(int page, int pageSize, string filter)
        {
            throw new NotImplementedException();
        }

        public CommonDetailsModel GetCommonDetails(object id)
        {
            var result = unitOfwork.CommonRepo.Get(x => x.Id.Equals(id));
            if (result.Count() > 0)
            {
                return result.Select(x =>
                   new CommonDetailsModel()
                   {
                       Code = x.Code,
                       CommonId = x.Id,
                       CreatedBy = x.CreatedBy,
                       CreatedUTCDate = x.CreatedUTCDate,
                       Description = x.Description,
                       IsActive = x.IsActive,
                       ModifiedBy = x.ModifiedBy,
                       ModifiedUTCDate = x.ModifiedUTCDate,
                       Title = x.Title
                   }).FirstOrDefault(); 
            }

            return null;
        }

        public CommonEditModel GetCommonEdit(object id)
        {
            throw new NotImplementedException();
        }
    }
}
