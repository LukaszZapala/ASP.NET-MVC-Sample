using Microsoft.AspNet.Identity.EntityFramework;
using Sklep.Models;

namespace Sklep.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sklep.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sklep.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var products = new List<Product>
            {
                new Product {Id = Guid.NewGuid().ToString(),InStock = false, Name = "Cat", Price = 12.95M},
                new Product {Id = Guid.NewGuid().ToString(),InStock = true, Name = "Dog", Price = 69.95M},
                new Product {Id = Guid.NewGuid().ToString(),InStock = true, Name = "Fish", Price = 3.95M}
            };

           
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var discountCode = new DiscountCode();
                discountCode.Id = Guid.NewGuid().ToString();
                discountCode.Code = Guid.NewGuid();
                discountCode.Used = false;
                discountCode.Discount = random.Next(0, 100);
                context.DiscountCodes.Add(discountCode);
            }

            context.SaveChanges();

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}
