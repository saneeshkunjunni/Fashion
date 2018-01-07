using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class JobRoleRegisterModel
    {
        public JobRoleRegisterModel()
        {
            this.ProfessionList = new List<System.Web.Mvc.SelectListItem>();
            this.GenderList = new List<System.Web.Mvc.SelectListItem>();
            this.CountryList = new List<System.Web.Mvc.SelectListItem>();
        }
        [Required,StringLength(512), Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [Required,Display(Name = "Professions")]
        public List<string> Professions { get; set; }
        public List<System.Web.Mvc.SelectListItem> ProfessionList { get; set; }
        [Required]
        public Guid Gender { get; set; }
        public List<System.Web.Mvc.SelectListItem> GenderList { get; set; }
        [Required, Display(Name = "Age From"), Range(1, Int32.MaxValue, ErrorMessage = "{0}'s value should be greater than or equal to 1")]
        public int AgeFrom { get; set; }
        [NumericGreaterThan("AgeFrom", AllowEquality = true)]
        [Required, Display(Name = "Age To"), Range(1, Int32.MaxValue, ErrorMessage = "{0}'s value should be greater than or equal to 1")]
        public int AgeTo { get; set; }
        [Required]
        public List<string> BasedIn { get; set; }
        public List<System.Web.Mvc.SelectListItem> CountryList { get; set; }
    }
}
