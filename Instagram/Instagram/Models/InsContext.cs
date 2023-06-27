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
        public DbSet<Userz> Users { get; set; }
        public DbSet<Imagez> Images { get; set; }
        public DbSet<ImagesPost> imagesPosts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;port=3306;username=root;Password=123456;Database=dbinstagram;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Userz>().HasData
                 (new Userz { UserId = 1, UserName = "tanphat", Password = "123456", ConfirmPassword = "123456", Avatar = "https://res.cloudinary.com/dqnsplymn/image/upload/v1687771994/pp_kgahaq.png" },
                  new Userz { UserId = 2, UserName = "congminh", Password = "123456", ConfirmPassword = "123456",Avatar = "https://res.cloudinary.com/dqnsplymn/image/upload/v1687771724/CM_o4utih.png" },
                  new Userz { UserId = 3, UserName = "quocname", Password = "123456", ConfirmPassword = "123456", Avatar = "https://res.cloudinary.com/dqnsplymn/image/upload/v1687771676/QNAvartatsgd_bjye0p.png" }
                 );

            base.OnModelCreating(modelBuilder);
        }
    
    }
    
}
