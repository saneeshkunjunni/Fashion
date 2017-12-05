using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class TagMapping: EntityTypeConfiguration<Tags>
    {
        public TagMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.CreatedBy);
            this.Property(x => x.CreatedUTCDate);
            this.Property(x => x.Id);
            this.Property(x => x.IsActive);
            this.Property(x => x.ModifiedUTCDate);
            this.Property(x => x.ModifiedBy);
            this.Property(x => x.TagName);
            this.Property(x => x.TagType);

            this.HasRequired(x => x.CreatedUser).WithMany(p => p.Tags).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedTags).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
