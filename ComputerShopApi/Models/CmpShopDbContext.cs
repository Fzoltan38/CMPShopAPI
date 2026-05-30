using Microsoft.EntityFrameworkCore;

namespace ComputerShopApi.Models
{
    public class CmpShopDbContext : DbContext
    {
        public CmpShopDbContext()
        {
        }

        public CmpShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Computers> computers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("SERVER=localhost;DATABASE=CmpShop;UID=root;PASSWORD=");
        }
    }
}
