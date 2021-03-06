﻿using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class AddressMapping: EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            this.HasKey(x => x.Id).Property(x => x.Id).IsRequired();
            this.Property(x => x.AddressLine1);
            this.Property(x => x.AddressLine2);
            this.Property(x => x.AddressMap);
            this.Property(x => x.AreaCode);
            this.Property(x => x.CreatedBy);
            this.Property(x => x.CreatedUTCDate);                        
            this.Property(x => x.ModifiedBy).IsOptional();
            this.Property(x => x.ModifiedUTCDate); 
            this.Property(x => x.State);            
            this.Property(x => x.Status);
            this.Property(x => x.Suburb);
            this.HasRequired(x => x.CreatedUser).WithMany(p => p.Address).HasForeignKey(x => x.CreatedBy).WillCascadeOnDelete(false);
            this.HasRequired(x => x.ModifiedUser).WithMany(p => p.ModifiedAddress).HasForeignKey(x => x.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
