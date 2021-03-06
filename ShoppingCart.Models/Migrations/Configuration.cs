namespace ShoppingCart.Models.Migrations
{
    using ShoppingCart.Models.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingCart.Models.ShoppingCartDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShoppingCart.Models.ShoppingCartDbContext context)
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

           /* context.Products.AddOrUpdate(
                    new Product { Name = "Produit1" },
                    new Product { Name = "Produit1" },
                    new Product { Name = "Produit3" }
                );*/

            context.Categories.AddOrUpdate(
                    new Category { Id = Guid.NewGuid(), Name = "Category1" },
                    new Category { Id = Guid.NewGuid(), Name = "Category2" },
                    new Category { Id = Guid.NewGuid(), Name = "Category3" }
                );
        }
    }
}
