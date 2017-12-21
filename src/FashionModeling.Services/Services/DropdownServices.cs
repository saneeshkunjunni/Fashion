using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FashionModeling.Services.Services
{
    public class DropdownServices : IDropdownServices
    {
        UnitOfWork unitOfWork = new UnitOfWork();        

        public IEnumerable<SelectListItem> GetCategories()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("CATEGORY")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetChestSize()
        {
            return Enumerable.Range(46, 250).Select(i => new SelectListItem() { Text = string.Format("{0} cm", i), Value = string.Format("{0} cm", i) });
        }

        public IEnumerable<SelectListItem> GetEthnicities()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("ETHNICITY")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetExperiences()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("EXPERIENCE")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetEyeColors()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("EYECOLOR")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }        

        public IEnumerable<SelectListItem> GetFluentLanguages()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("LANGUAGE")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetHairColors()
        {
             return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("HAIRCOLOR")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetHeights()
        {
            return Enumerable.Range(20, 220).Select(i => new SelectListItem() { Text = string.Format("{0} cm", i), Value= string.Format("{0} cm", i)});
        }

        public IEnumerable<SelectListItem> GetHipSize()
        {
            return Enumerable.Range(45, 250).Select(i => new SelectListItem() { Text = string.Format("{0} cm", i), Value = string.Format("{0} cm", i) });
        }

        public IEnumerable<SelectListItem> GetJacketSize()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("FITSIZE")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetNationalities()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("NATIONALITY")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetPantSize()
        {
            return Enumerable.Range(46, 250).Select(i => new SelectListItem() { Text = string.Format("{0} cm", i), Value = string.Format("{0} cm", i) });
        }

        public IEnumerable<SelectListItem> GetShoeSize()
        {
            return Enumerable.Range(15, 48).Select(i => new SelectListItem() { Text = string.Format("{0} EU", i), Value = string.Format("{0} EU", i) });
        }

        public IEnumerable<SelectListItem> GetSpecialFeatures()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("SPECIALFEATURES")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetTags()
        {
            return unitOfWork.TagRepo.Get(x => x.IsActive == true).OrderBy(x => x.TagName).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.TagName
            });
        }

        public IEnumerable<SelectListItem> GetTshirtSizes()
        {
            return unitOfWork.CommonRepo.Get(x => x.IsActive == true && x.Code.Equals("FITSIZE")).OrderBy(x => x.Title).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public IEnumerable<SelectListItem> GetWaistSize()
        {
            return Enumerable.Range(45, 250).Select(i => new SelectListItem() { Text = string.Format("{0} cm", i), Value = string.Format("{0} cm", i) });
        }          
    }
}
