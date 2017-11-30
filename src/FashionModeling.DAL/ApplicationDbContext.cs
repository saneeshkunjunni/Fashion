using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using FashionModeling.DAL.Entity;
using FashionModeling.DAL.Mappings;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace FashionModeling.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { 
        }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Common> Common { get; set; }
        public DbSet<CastLocations> CastLocations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Gallery>(new GalleryMapping());
            modelBuilder.Configurations.Add<Tags>(new TagMapping());
            modelBuilder.Configurations.Add<Address>(new AddressMapping());
            modelBuilder.Entity<Gallery>()
               .HasMany<Tags>(s => s.Tags)
               .WithMany(c => c.Galleries)
               .Map(cs =>
               {

                   cs.MapRightKey("GalleryRefId");
                   cs.MapLeftKey("TagRefId");                   
                   cs.ToTable("GalleryTags");
               });
            //    modelBuilder.Entity<Gallery>().Property(t => t.ModifiedDate).HasComputedColumnSql("GetUtcDate()");
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(UserEntity).IsAssignableFrom(e.Entity.GetType())
                select e;

            var currentTime = DateTime.UtcNow;

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as UserEntity;

                if (entry.State == EntityState.Added)
                {
                    entityBase.CreatedDate = currentTime;
                }

                entityBase.ModifiedDate = currentTime;
            }

            return base.SaveChanges();
        }
    }
}
