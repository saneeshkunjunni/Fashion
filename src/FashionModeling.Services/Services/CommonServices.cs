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
                    Description = model.Description,
                    FreeText1 = model.FreeText1,
                    FreeText2 = model.FreeText2,
                    FreeText3 = model.FreeText3,
                    IsSelected = false,
                    IsActive = true,
                    IsDeleted = false,
                    Title = model.Title,
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

        public bool DeleteCommon(Guid id)
        {
            try
            {
                unitOfwork.CommonRepo.Delete(id);
                return unitOfwork.Save() > 0;
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

        public CommonListModel GetCommon(string type, int page, int pageSize, string filter)
        {
            var result = unitOfwork.CommonRepo.Get(x => x.Code.Equals(type, StringComparison.CurrentCultureIgnoreCase));
            if (result.Count() > 0)
            {
                var data = new CommonListModel();
                data.CommonList = result.Select(x =>
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
                }).OrderBy(x=>x.Title).ToPagedList(page, pageSize);
                return data;
            }

            return null;
        }

        public CommonDetailsModel GetCommonDetails(Guid id)
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

        public CommonEditModel GetCommonEdit(Guid id)
        {
            var result = unitOfwork.CommonRepo.Get(x => x.Id.Equals(id));
            if (result.Count() > 0)
            {
                return result.Select(x =>
                   new CommonEditModel()
                   {
                       Code = x.Code,
                       CommonId = x.Id,
                       Description = x.Description,
                       IsActive = x.IsActive,
                       Title = x.Title,
                       IsDeleted = x.IsDeleted
                   }).FirstOrDefault();
            }
            return null;
        }
    }
}
