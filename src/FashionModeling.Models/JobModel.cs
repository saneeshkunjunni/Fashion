using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FashionModeling.Models
{
    public class JobRegisterModel
    {
        public JobRegisterModel()
        {
            AddressList = new List<System.Web.Mvc.SelectListItem>();
        }
        [Required, Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required, Display(Name = "Shooting Address")]
        public Guid ShootingAddressId { get; set; }
        [Required, Display(Name = "Upload", Prompt = "Upload")]
        public HttpPostedFileBase ImageFile { get; set; } 
        public string Url { get; set; }
        public List<System.Web.Mvc.SelectListItem> AddressList { get; set; }
        [Required, Display(Name = "Shooting Date")]
        public string ShootingDateUTC { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string ContactNumbers { get; set; }
        [Required, Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [Required, Display(Name = "Casting From Date")]
        public string CastingFromDateUtc { get; set; }
        [Required, Display(Name = "Casting To Date")]
        public string CastingToDateUtc { get; set; }
        [Required, Display(Name = "Casting Expiry Date")]
        public string CastingExpiryDateUtc { get; set; }
        [Required, Display(Name = "Description")]
        [AllowHtml]
        public string Description { get; set; }
        [Required, Display(Name = "Number Of Roles"),Range(1, Int32.MaxValue, ErrorMessage = "{0}'s value should be greater than or equal to 1")]
        public int NumberOfRoles { get; set; }
        public string UserId { get; set; }
    }
    public class JobRegisterWithRole
    {
        public JobRegisterWithRole()
        {
            this.JobRoles = new List<JobRoleRegisterModel>();
        }
        [Required, Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required, Display(Name = "Image", Prompt = "Image")]
        public string Url { get; set; }
        [Required, Display(Name = "Shooting Address")]
        public Guid ShootingAddressId { get; set; }
        [Required, Display(Name = "Shooting Date")]
        public string ShootingDateUTC { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string ContactNumbers { get; set; }
        [Required, Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [Required, Display(Name = "Casting From Date")]
        public string CastingFromDateUtc { get; set; }
        [Required, Display(Name = "Casting To Date")]
        public string CastingToDateUtc { get; set; }
        [Required, Display(Name = "Casting Expiry Date")]
        public string CastingExpiryDateUtc { get; set; }
        [Required, Display(Name = "Description")]
        [AllowHtml]
        public string Description { get; set; }
        [Required, Display(Name = "Number Of Roles"), Range(1, Int32.MaxValue, ErrorMessage = "{0}'s value should be greater than or equal to 1")]
        public int NumberOfRoles { get; set; }
        public string UserId { get; set; }
        public List<JobRoleRegisterModel> JobRoles { get; set; }
    }
    public class JobDetailsModel : JobRegisterModel
    {
        public Guid JobId { get; set; }
        [Display(Name = "Address Line1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Map")]
        public string AddressMap { get; set; }
        [Display(Name = "ModifiedBy")]
        public string ModifiedBy { get; set; }
    }
    public class JobEditModel
    {
        [Required]
        public Guid JobId { get; set; }
        [Required, Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required, Display(Name = "Shooting Address")]
        public Guid ShootingAddressId { get; set; }
        public List<System.Web.Mvc.SelectListItem> AddressList { get; set; }
        [Required, Display(Name = "Shooting Date")]
        public string ShootingDateUTC { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string ContactNumbers { get; set; }
        [Required, Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [Required, Display(Name = "Casting From Date")]
        public string CastingFromDateUtc { get; set; }
        [Required, Display(Name = "Casting To Date")]
        public string CastingToDateUtc { get; set; }
        [Required, Display(Name = "Casting Expiry Date")]
        public string CastingExpiryDateUtc { get; set; }
        [Required, Display(Name = "Description")]
        public string Description { get; set; }
        public string UserId { get; set; }
    }
    public class JobListModel
    {
        public PagedList<JobDetailsModel> Jobslist { get; set; }
    }
}
