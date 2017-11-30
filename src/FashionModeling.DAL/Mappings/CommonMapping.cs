using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class CommonMapping:EntityTypeConfiguration<Common>
    {
        public CommonMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Code);
            this.Property(x => x.CreatedBy);
            this.Property(x => x.CreatedDate);
            this.Property(x => x.Description);
            this.Property(x => x.Id);
            this.Property(x => x.IsActive);
            this.Property(x => x.IsDeleted);            
            this.Property(x => x.ModifiedBy);
            this.Property(x => x.ModifiedDate);
            this.Property(x => x.Title);
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.Commons).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(true);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedCommons).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
