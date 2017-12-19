using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class JobApplicationMapping:EntityTypeConfiguration<JobApplications>
    {
        public JobApplicationMapping()
        {
            this.ToTable("JobApplications");
            this.HasKey(x => x.Id).Property(x => x.Id).IsRequired();
            this.Property(x => x.AboutApplicant).IsRequired();
            this.Property(x => x.AppliedFor).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedUTCDate).IsRequired();
            this.Property(x => x.IsSelected).IsRequired();
            this.Property(x => x.ModifiedBy).IsOptional();
            this.Property(x => x.ModifiedUTCDate).IsRequired();     
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.JobApplications).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedJobApplications).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
