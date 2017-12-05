using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class JobsMapping: EntityTypeConfiguration<Jobs>
    {
        public JobsMapping()
        {
            this.ToTable("Jobs");
            this.HasKey(x => x.Id).Property(x=>x.Id).IsRequired();
            this.Property(x => x.CastingExpiryDateUtc).IsRequired();
            this.Property(x => x.CastingFromDateUtc).IsRequired();
            this.Property(x => x.CastingToDateUtc).IsRequired();
            this.Property(x => x.ContactEmail).IsRequired();
            this.Property(x => x.ContactNumbers).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedUTCDate).IsRequired();
            this.Property(x => x.Description).IsRequired();
            this.Property(x => x.JobTitle).IsRequired();
            this.Property(x => x.ModifiedBy).IsRequired();
            this.Property(x => x.ModifiedUTCDate).IsRequired();
            this.Property(x => x.ShootingAddressId).IsRequired();
            this.Property(x => x.ShootingDateUTC).IsRequired();

            this.HasRequired(x => x.CreatedUser).WithMany(p => p.Jobs).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(true);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedJobs).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.Address).WithMany(p => p.Jobs).HasForeignKey(x => x.ShootingAddressId).WillCascadeOnDelete(false);

        }
    }
}
