using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration; 

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class GalleryMapping:EntityTypeConfiguration<Gallery>
    {
        public GalleryMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.CreatedBy);
            this.Property(x => x.CreatedUTCDate);
            this.Property(x => x.Description);
            this.Property(x => x.Id);
            this.Property(x => x.IsActive);
            this.Property(x => x.IsFeatured);
            this.Property(x => x.IsImage);
            this.Property(x => x.IsSlider);
            this.Property(x => x.ModifiedBy).IsOptional();
            this.Property(x => x.ModifiedUTCDate);
            this.Property(x => x.Url);
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.Galleries).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedGalleries).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
