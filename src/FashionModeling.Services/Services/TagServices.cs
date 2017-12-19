using FashionModeling.DAL.Entity;
using FashionModeling.Models;
using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Services
{
    public class TagServices : ITagServices
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public Guid AddTag(TagRegisterModel model)
        {
            try
            {
                var result = new Tags()
                {
                   TagName = model.TagName,
                   TagType=model.TagType,
                   IsActive=true,
                };
                unitOfWork.TagRepo.Insert(result);
                if (unitOfWork.Save() > 0)
                {
                    return result.Id;
                }
                return Guid.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTag(Guid id)
        {
            try
            {
                unitOfWork.TagRepo.Delete(id);
                return unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditTag(TagEditModel model)
        {
            try
            {
                var entity = unitOfWork.TagRepo.Get(x => x.Id.Equals(model.TagId)).FirstOrDefault();
                entity.TagName = model.TagName;
                entity.TagType = model.TagType;
                entity.IsActive = model.IsActive; 
                unitOfWork.TagRepo.Update(entity);
                return unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TagDetailsModel GetTagDetails(Guid id)
        {
            try
            {
                var result = unitOfWork.TagRepo.Get(x=>x.Id.Equals(id)).Select(x => new TagDetailsModel()
                {
                    TagId = x.Id,
                    TagName = x.TagName,
                    TagType = x.TagType,
                    IsActive = x.IsActive,
                    CreatedDate = x.CreatedUTCDate,
                }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TagEditModel GetTagEdit(Guid id)
        {
            try
            {
                var result = unitOfWork.TagRepo.Get(x=>x.Id.Equals(id)).Select(x => new TagEditModel()
                {
                    TagId = x.Id,
                    TagName = x.TagName,
                    TagType = x.TagType,
                    IsActive = x.IsActive, 
                }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TagListModel GetTags(int page, int pageSize, string filter)
        {
            try
            {
                var result = unitOfWork.TagRepo.Get().Select(x => new TagDetailsModel()
                {
                    TagId = x.Id,
                    TagName = x.TagName,
                    TagType = x.TagType,
                    IsActive = x.IsActive,
                    CreatedDate = x.CreatedUTCDate,
                }).OrderBy(x => x.CreatedDate).ToPagedList(page, pageSize);

                return new TagListModel() { TagLists = result };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TagDetailsModel> GetTags(Expression<Func<TagDetailsModel, bool>> filter = null)
        {
            try
            {
                var result = unitOfWork.TagRepo.Get().Select(x => new TagDetailsModel()
                {
                    TagId = x.Id,
                    TagName = x.TagName,
                    TagType = x.TagType,
                    IsActive = x.IsActive,
                    CreatedDate = x.CreatedUTCDate,
                });
                if (filter != null)
                {
                    result = result.Where(filter);
                }
                return result.OrderBy(x => x.CreatedDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
