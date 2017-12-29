using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class JobRegisterModel
    {
        public string JobTitle { get; set; }
        public bool IsNewShootingAddress { get; set; }
        [RequiredIf("IsNewShootingAddress", false)]
        public Guid ShootingAddressId { get; set; }
        public DateTime ShootingDateUTC { get; set; }
        public string ContactNumbers { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CastingFromDateUtc { get; set; }
        public DateTime CastingToDateUtc { get; set; }
        public DateTime CastingExpiryDateUtc { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        [RequiredIf("IsNewShootingAddress", true)]
        public string AddressLine1 { get; set; }
        [RequiredIf("IsNewShootingAddress", true)]
        public string AddressLine2 { get; set; }
        public string AddressMap { get; set; }
        [RequiredIf("IsNewShootingAddress", true)]
        public string AreaCode { get; set; }
        [RequiredIf("IsNewShootingAddress", true)]
        public string State { get; set; }
        [RequiredIf("IsNewShootingAddress", true)]
        public string Suburb { get; set; }
    }
    public class JobDetailsModel : JobRegisterModel
    {
        public Guid JobId { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class JobEditModel
    {
        [Required]
        public Guid JobId { get; set; }
        [Required]
        public string JobTitle { get; set; } 
        [Required]
        public Guid ShootingAddressId { get; set; }
        [Required]
        public DateTime ShootingDateUTC { get; set; }
        [Required]
        public string ContactNumbers { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public DateTime CastingFromDateUtc { get; set; }
        [Required]
        public DateTime CastingToDateUtc { get; set; }
        [Required]
        public DateTime CastingExpiryDateUtc { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
    }
    public class JobListModel
    {
        public PagedList<JobDetailsModel> Jobslist { get; set; }
    }
}
