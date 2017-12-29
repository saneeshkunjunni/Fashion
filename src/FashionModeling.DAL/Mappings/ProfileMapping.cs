using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class ProfileMapping:EntityTypeConfiguration<Profile>
    {
        public ProfileMapping()
        {
            this.ToTable("Profile");
            this.HasKey(x => x.Id).Property(x => x.Id).IsRequired();
            this.Property(x => x.AboutMe);
            this.Property(x => x.AddressId);
            this.Property(x => x.CategoryId);
            this.Property(x => x.CreatedUTCDate);
            this.Property(x => x.DateOfBirth);
            this.Property(x => x.Ethnicity);
            this.Property(x => x.Experience);
            this.Property(x => x.EyeColor);
            this.Property(x => x.FacebookLink);
            this.Property(x => x.FluentLanguage);
            this.Property(x => x.HairColor);
            this.Property(x => x.Height);
            this.Property(x => x.HipSize);
            this.Property(x => x.Instagramlink);
            this.Property(x => x.IsWillingToTravel);
            this.Property(x => x.JacketSize);
            this.Property(x => x.MetaDescription);
            this.Property(x => x.MetaKeywords);
            this.Property(x => x.MetaSubject);
            this.Property(x => x.MetaTitle);
            this.Property(x => x.ModifiedUTCDate);
            this.Property(x => x.NationalityByBirth);
            this.Property(x => x.NationalityByPassport);
            this.Property(x => x.PantSize);
            this.Property(x => x.ProfilePic);
            this.Property(x => x.ProfileUrl);
            this.Property(x => x.ShoeSize);
            this.Property(x => x.SpecialFeatures);
            this.Property(x => x.Status);
            this.Property(x => x.TshirtSize);
            this.Property(x => x.WaistSise);
            this.Property(x => x.WhatsAppNumber);
        }
    }
}
