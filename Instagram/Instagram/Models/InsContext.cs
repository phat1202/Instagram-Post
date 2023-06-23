using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Instagram.Models
{
    public class InsContext : DbContext
    {
        public InsContext() { }

        public InsContext(DbContextOptions<InsContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;port=3306;username=root;Password=123456;Database=instagram;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
                 (new User { UserId = 1, UserName = "TanPhat", Password = "tp1202", ConfirmPassword= "tp1202", });
            base.OnModelCreating(modelBuilder);
        }
    
    }
    
}
