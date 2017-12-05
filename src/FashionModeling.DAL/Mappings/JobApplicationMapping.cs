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
            this.Property(x => x.CreatedDate).IsRequired();
            this.Property(x => x.ModifiedBy).IsRequired();
            this.Property(x => x.ModifiedDate).IsRequired();            

            this.HasRequired(x => x.CreatedUser).WithMany(p => p.JobApplications).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(true);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedJobApplications).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
