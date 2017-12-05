using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class SubscriptionMapping:EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMapping()
        {
            this.ToTable("Subscription");
            this.HasKey(x => x.Id).Property(x => x.Id).IsRequired();
            this.Property(x => x.EmailAddress).IsRequired();
            this.Property(x => x.Status).IsRequired();
        }
    }
}
