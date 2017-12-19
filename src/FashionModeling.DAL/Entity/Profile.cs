using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Profile
    {
        public Profile()
        {
            this.Galleries = new HashSet<Gallery>();
        }
        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        public string ProfileUrl { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<Guid> CategoryId { get; set; }
        public Nullable<Guid> NationalityByBirth { get; set; }
        public Nullable<Guid> NationalityByPassport { get; set; }
        public bool IsWillingToTravel { get; set; }
        public string Ethnicity { get; set; }
        public string FluentLanguage { get; set; }
        public Nullable<Guid> EyeColor { get; set; }
        public Nullable<Guid> HairColor { get; set; }
        public string Height { get; set; }
        public string ShoeSize { get; set; }
        public string WaistSise { get; set; }
        public string HipSize { get; set; }
        public Nullable<Guid> TshirtSize { get; set; }
        public Nullable<Guid> PantSize { get; set; }
        public Nullable<Guid> JacketSize { get; set; }
        public string SpecialFeatures { get; set; }
        public bool Status { get; set; }

        public Nullable<Guid> Experience { get; set; }
        public Nullable<Guid> AddressId { get; set; }
        public string FacebookLink { get; set; }
        public string Instagramlink { get; set; }
        [StringLength(60)]
        public string MetaTitle { get; set; }
        [StringLength(200)]
        public string MetaKeywords { get; set; }
        [StringLength(100)]
        public string MetaSubject { get; set; }
        [StringLength(160)]
        public string MetaDescription { get; set; }
        public DateTime CreatedUTCDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedUTCDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Tags> Tags { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual ApplicationUser ProfileUser { get; set; }
    }
}
