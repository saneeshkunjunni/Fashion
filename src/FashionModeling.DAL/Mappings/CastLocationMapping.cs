using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class CastLocationMapping:EntityTypeConfiguration<CastLocations>
    {
        public CastLocationMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.AddressId);
            this.Property(x => x.CreatedBy);
            this.Property(x => x.CreatedUTCDate);
            this.Property(x => x.Id);
            this.Property(x => x.ModifiedBy).IsOptional();
            this.Property(x => x.ModifiedUTCDate);
            this.Property(x => x.JobId);
            
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.CastLocations).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedCastLocations).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
