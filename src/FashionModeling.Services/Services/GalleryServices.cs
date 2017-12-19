using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionModeling.Models;
using FashionModeling.DAL.Entity;

namespace FashionModeling.Services.Services
{
    public class GalleryServices : IGalleryServices
    {
        UnitOfWork unitOfwork = new UnitOfWork();
        public Guid AddGallery(GalleryRegisterModel model)
        {
            try
            {
                var result = new Gallery()
                {
                    Description = model.Description,
                    IsActive = true,
                    IsImage = model.IsImage,
                    Url = model.Url,
                };
                unitOfwork.GalleriesRepo.Insert(result);
                unitOfwork.Save();
                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditGallery(GalleryEditModel model)
        {
            try
            {
                var result = unitOfwork.GalleriesRepo.Get(filter: x => x.Id == (Guid)model.Id).FirstOrDefault();
                result.Url = model.Url;
                result.IsImage = model.IsImage;
                result.IsFeatured = model.IsFeatured;
                result.IsActive = model.IsActive;
                result.IsSlider = model.IsSlider;
                result.Description = model.Description;
                unitOfwork.GalleriesRepo.Update(result);
                return unitOfwork.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GalleryListModel GetGallery(int page, int pageSize)
        {
            try
            {
                var result = unitOfwork.GalleriesRepo.Get()
                    .Select(x => new GalleryDetailsModel()
                    {
                        CreatedDate = x.CreatedUTCDate,
                        Description = x.Description,
                        Id = x.Id,
                        IsActive = x.IsActive,
                        ModifiedDate = x.ModifiedUTCDate,
                        Url = x.Url,
                        IsFeatured = x.IsFeatured,
                        IsImage = x.IsImage,
                        IsSlider = x.IsSlider,
                    }).OrderByDescending(x => x.CreatedDate).ToPagedList<GalleryDetailsModel>(page, pageSize);

                return new GalleryListModel() { GalleriesList = result };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GalleryDetailsModel GetGalleryDetails(object id)
        {
            try
            {
                var result = unitOfwork.GalleriesRepo.Get(filter: x => x.Id == (Guid)id)
                    .Select(x => new GalleryDetailsModel()
                    {
                        CreatedDate = x.CreatedUTCDate,
                        Description = x.Description,
                        Id = x.Id,
                        IsActive = x.IsActive,
                        ModifiedDate = x.ModifiedUTCDate,
                        Url = x.Url,
                        IsFeatured = x.IsFeatured,
                        IsImage = x.IsImage,
                        IsSlider = x.IsSlider,
                    }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GalleryEditModel GetGalleryEdit(object id)
        {
            try
            {
                var result = unitOfwork.GalleriesRepo.Get(filter: x => x.Id == (Guid)id)
                    .Select(x => new GalleryEditModel()
                    {
                        Description = x.Description,
                        Id = x.Id,
                        IsActive = x.IsActive,
                        Url = x.Url,
                        IsFeatured = x.IsFeatured,
                        IsImage = x.IsImage,
                        IsSlider = x.IsSlider,
                    }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
