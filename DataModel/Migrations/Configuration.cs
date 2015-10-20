namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.DAL.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataModel.DAL.ProductContext";
        }

        protected override void Seed(DataModel.DAL.ProductContext context)
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

            context.Products.AddOrUpdate(
                p=>p.ProductName,
                new Entity.Product { ProductId =1, ProductName="Zid"},
                new Entity.Product { ProductId=2, ProductName="Ziya"},
                new Entity.Product { ProductId = 3, ProductName = "peace" },
                new Entity.Product { ProductId = 4, ProductName = "Pace" },
                new Entity.Product { ProductId = 5, ProductName = "Face" },
                new Entity.Product { ProductId = 6, ProductName = "Force" }
                );
        }
    }
}
