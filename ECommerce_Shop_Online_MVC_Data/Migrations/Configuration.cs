using System.Collections.Generic;
using ECommerce_Shop_Online_MVC_Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;

namespace ECommerce_Shop_Online_MVC_Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerce_Shop_Online_MVC_Data.ECommerceShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerce_Shop_Online_MVC_Data.ECommerceShopDbContext context)
        {
          //  CreateProductCategorySample(context);
          // // This method will be called after migrating to the latest version.

          //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ECommerceShopDbContext()));

          //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ECommerceShopDbContext()));

          //  var user = new ApplicationUser()
          //  {
          //      UserName = "tedu",
          //      Email = "tedu.international@gmail.com",
          //      EmailConfirmed = true,
          //      BirthDay = DateTime.Now,
          //      FullName = "Technology Education"

          //  };

          //  manager.Create(user, "123654$");

          //  if (!roleManager.Roles.Any())
          //  {
          //      roleManager.Create(new IdentityRole { Name = "Admin" });
          //      roleManager.Create(new IdentityRole { Name = "User" });
          //  }

          //  var adminUser = manager.FindByEmail("tedu.international@gmail.com");

          //  manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(ECommerceShopDbContext context)
        {
            if (!context.ProductCategories.Any())
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status = Status.Active },
                    new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status = Status.Active },
                    new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status = Status.Active },
                    new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status = Status.Active }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }
}
