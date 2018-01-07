using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class JobRolesMapping:EntityTypeConfiguration<JobRoles>
    {
        public JobRolesMapping()
        {
            this.ToTable("JobRoles");
            this.HasKey(x => x.Id).Property(x => x.Id).IsRequired();
            this.Property(x => x.AgeFrom).IsRequired();
            this.Property(x => x.AgeTo).IsRequired();
            this.Property(x => x.BasedIn).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedUTCDate).IsRequired();
            this.Property(x => x.Gender).IsRequired();
            this.Property(x => x.JobId).IsRequired();
            this.Property(x => x.ModifiedBy).IsOptional();
            this.Property(x => x.ModifiedUTCDate).IsRequired();
            this.Property(x => x.Professions).IsRequired();
            this.Property(x => x.RoleName).IsRequired();
            this.Property(x => x.Status).IsRequired();
            this.HasRequired(x => x.Job).WithMany(p => p.JobRoles).HasForeignKey(x => x.JobId).WillCascadeOnDelete(true);
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.JobRoles).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedJobRoles).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);

        }
    }
}
