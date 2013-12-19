namespace ProductManagement.Migrations
{
    using ProductManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductManagement.Models.ProductManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductManagement.Models.ProductManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Products.AddOrUpdate(
            //    new List<Product>() { 
            //  new Product { },
            //  new Product { },
            //  new Product { }
            //});
            

            context.Categories.AddOrUpdate(new Category[] { new Category() { ID = 1, Name = "Apparel" }, new Category() { ID = 2, Name = "Toys" } });
            context.Suppliers.AddOrUpdate(new Supplier[] { new Supplier() { Key = "WalMart", Name = "WalMart" }});

            context.Products.AddOrUpdate(new Product[] { 
                new Product() {ID=1, Name="Hat", Price=15, CategoryId=1, SupplierId="WalMart" },
                new Product() {ID=2, Name="Socks", Price=5, CategoryId=1, SupplierId="WalMart" },
                new Product() {ID=3, Name="Scarf", Price=12, CategoryId=1, SupplierId="WalMart" },
                new Product() {ID=4, Name="Yo-Yo", Price=4.95M, CategoryId=2, SupplierId="WalMart" },
                new Product() {ID=5, Name="Puzzle", Price=8, CategoryId=2, SupplierId="WalMart" },
                new Product() {ID=6, Name="Uno Cards", Price=5, CategoryId=2, SupplierId="WalMart" },
                new Product() {ID=7, Name="Long-Sleeve Dress", Price=52, CategoryId=1, SupplierId="WalMart" },
                new Product() {ID=8, Name="Short-Sleeve Dress", Price=42, CategoryId=1, SupplierId="WalMart" }
            });
        }
    }
}
