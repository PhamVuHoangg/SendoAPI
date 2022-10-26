using LazadaAPITest.Models;
using Microsoft.EntityFrameworkCore;

namespace LazadaAPITest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<ProductOverView> ProductOverView { get; set; }
        public DbSet<ShopInfo> ShopInfo { get; set; }
        public DbSet<CategoryInfo> CategoryInfo { get; set; }
        public DbSet<DescriptionInfo> DescriptionInfo { get; set; }
        public DbSet<RatingInfo> RatingInfo { get; set; }
    }
}
