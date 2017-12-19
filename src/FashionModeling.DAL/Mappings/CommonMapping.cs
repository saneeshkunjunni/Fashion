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
            this.Property(x => x.Code).IsRequired();
            this.Property(x => x.CreatedBy);
            this.Property(x => x.CreatedUTCDate);
            this.Property(x => x.Description);
            this.Property(x => x.FreeText1);
            this.Property(x => x.FreeText2);
            this.Property(x => x.FreeText3);
            this.Property(x => x.Id);
            this.Property(x => x.IsActive);
            this.Property(x => x.IsDeleted);
            this.Property(x => x.IsSelected);
            this.Property(x => x.ModifiedBy).IsOptional();
            this.Property(x => x.ModifiedUTCDate);
            this.Property(x => x.Title).IsRequired();
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.Commons).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(true);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedCommons).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
