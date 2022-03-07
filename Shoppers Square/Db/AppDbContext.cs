using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Helpers;
using Shoppers_Square.Models;

namespace Shoppers_Square.Db
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<SubCategoryModel> Subcategory { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<ShoppingCartItemModel> ShoppingCartItems { get; set; }
        public DbSet<OrderStatusModel> OrderEnquiry { get; set; }
        public DbSet<ProductDescriptionModel> ProductDescription { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
