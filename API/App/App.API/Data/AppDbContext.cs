using App.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.API.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _Configuration { get; set; }
        public AppDbContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostHaveTag> PostsHaveTags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
