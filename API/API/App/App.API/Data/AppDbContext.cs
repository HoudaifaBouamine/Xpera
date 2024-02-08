using App.API.Models;
using App.API.Models.Post_Models.Comment_Models;
using App.API.Models.PostModels;
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


        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<PostHaveTagRelation> PostsHaveTags { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
