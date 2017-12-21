using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FashionModeling.Services.Interfaces
{
    public interface IDropdownServices
    {
        IEnumerable<SelectListItem> GetTags();
        IEnumerable<SelectListItem> GetCategories();
        IEnumerable<SelectListItem> GetHairColors();
        IEnumerable<SelectListItem> GetEyeColors();
        IEnumerable<SelectListItem> GetFluentLanguages();
        IEnumerable<SelectListItem> GetExperiences();
        IEnumerable<SelectListItem> GetSpecialFeatures();
        IEnumerable<SelectListItem> GetNationalities();
        IEnumerable<SelectListItem> GetEthnicities();
        IEnumerable<SelectListItem> GetTshirtSizes();
        IEnumerable<SelectListItem> GetHeights();
        IEnumerable<SelectListItem> GetChestSize();
        IEnumerable<SelectListItem> GetShoeSize();
        IEnumerable<SelectListItem> GetWaistSize();
        IEnumerable<SelectListItem> GetHipSize();
        IEnumerable<SelectListItem> GetPantSize();
        IEnumerable<SelectListItem> GetJacketSize();

    }
}
