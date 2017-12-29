using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }        
        public DateTime CreateDateUTC { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
        public virtual ICollection<Gallery> ModifiedGalleries { get; set; }
        public virtual ICollection<Tags> ModifiedTags { get; set; }
        public virtual ICollection<Address> ModifiedAddress { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<CastLocations> CastLocations { get; set; }
        public virtual ICollection<CastLocations> ModifiedCastLocations { get; set; }
        public virtual ICollection<Common> Commons { get; set; }
        public virtual ICollection<Common> ModifiedCommons { get; set; }
        public virtual ICollection<Jobs> Jobs { get; set; }
        public virtual ICollection<Jobs> ModifiedJobs { get; set; }

        public virtual ICollection<JobApplications> JobApplications { get; set; }
        public virtual ICollection<JobApplications> ModifiedJobApplications { get; set; }

        public virtual ICollection<JobRoles> JobRoles { get; set; }
        public virtual ICollection<JobRoles> ModifiedJobRoles { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
