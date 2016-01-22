using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sklep.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Orders = new List<Order>();
        }
        public IList<Order> Orders { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<DiscountCode> DiscountCodes { get; set; }

        public DbSet<OrderAddress> OrderAddresses { get; set; }

        public DbSet<OrderProducts> OrderProductses { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderAddress>().HasKey<string>(x => x.OrderId);
            modelBuilder.Entity<Product>().HasKey<string>(x => x.Id);
            modelBuilder.Entity<DiscountCode>().HasKey<string>(x => x.Id);
            modelBuilder.Entity<OrderProducts>().HasKey(x => x.Id);

            modelBuilder.Entity<OrderAddress>()
                .Property(x => x.OrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Order>().HasOptional(x => x.OrderAddress).WithRequired(x => x.Order);
            modelBuilder.Entity<OrderProducts>().HasRequired(x=>x.Order).WithMany(x=>x.ProductOrders).WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}