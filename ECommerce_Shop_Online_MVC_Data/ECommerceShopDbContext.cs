using System.Data.Entity;
using ECommerce_Shop_Online_MVC_Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerce_Shop_Online_MVC_Data
{
    public class ECommerceShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceShopDbContext() : base("ECommerceShopConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { get; set; }

        public DbSet<Menu> Menus { set; get; }

        public DbSet<MenuGroup> MenuGroups { set; get; }

        public DbSet<Order> Orders { set; get; }

        public DbSet<OrderDetail> OrderDetails { set; get; }

        public DbSet<Page> Pages { set; get; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<Slide> Slides { get; set; }

        public DbSet<SupportOnline> SupportOnlines { get; set; }

        public DbSet<SystemConfig> SystemConfigs { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<VisitorStaticstic> VisitorStaticstics { get; set; }

        public DbSet<Error> Errors { get; set; }

        public static ECommerceShopDbContext Create()
        {
            return new ECommerceShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}