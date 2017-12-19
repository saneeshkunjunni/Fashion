using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Mappings
{
    public class NotificationMapping : EntityTypeConfiguration<Notifications>
    {
        public NotificationMapping()
        {
            this.ToTable("Notifications");
            this.HasKey(x => x.Id).Property(x => x.Id).IsRequired();
            this.Property(x => x.CreatedUTCDate).IsRequired();
            this.Property(x => x.EmailTo).IsRequired();
            this.Property(x => x.PageName).IsRequired();
            this.Property(x => x.ModifiedUTCDate).IsOptional();
            this.Property(x => x.Send).IsRequired();
            this.Property(x => x.SubId1).IsRequired();
            this.Property(x => x.SubId2).IsRequired();
            this.Property(x => x.SubId3).IsRequired();
            this.Property(x => x.Subject).IsRequired();
        }
    }
}
