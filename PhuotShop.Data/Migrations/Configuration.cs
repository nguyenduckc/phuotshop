namespace PhuotShop.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhuotShop.Data.PhuotShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhuotShop.Data.PhuotShopDbContext context)
        {
            CreateProductCategoryExample(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PhuotShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new PhuotShopDbContext()));
            //var user = new ApplicationUser()
            //{
            //    UserName = "ducnv",
            //    Email = "ducnv@phuot.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Phuot Shop"
            //};

            //manager.Create(user, "123654$");
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("ducnv@phuot.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategoryExample(PhuotShop.Data.PhuotShopDbContext context)
        {
            if (context.ProductCategories.Count()==0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() {Name ="Action cam", Alias ="action-cam", Status=true },
                new ProductCategory() {Name ="Bó gối", Alias ="bo-goi", Status=true },
                new ProductCategory() {Name ="Áo giáp", Alias ="ao-giap", Status=true },
                new ProductCategory() {Name ="Quần giáp", Alias ="quan-giap", Status=true },
                new ProductCategory() {Name ="Lều cắm trại", Alias ="leu-cam-trai", Status=true },
                new ProductCategory() {Name ="Đèn pin", Alias ="den-pin", Status=true }
            };

                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }            
        }

        //public void CreateFooter(PhuotShopDbContext context)
        //{
        //    if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId)==0)
        //    {
        //        string content "";
        //    }
        //}
    }
}
