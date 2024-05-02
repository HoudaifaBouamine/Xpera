using App.API.Models;
using App.API.Models.Post_Models.Comment_Models;
using App.API.Models.PostModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace App.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }


        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<PostHaveTagRelation> PostsHaveTags { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PostModel>()
                .HasOne(P=>P.User)
                .WithMany(u=>u.Posts);

            modelBuilder.Entity<UserModel>()
                .HasMany(u=>u.LikedPosts)
                .WithMany(p=>p.UsersWhoLikedThisPost)
                .UsingEntity(
                    "Favorit",

                    l=>l.HasOne(typeof(PostModel))
                            .WithMany()
                            .HasForeignKey("Post_Id")
                            .HasPrincipalKey(nameof(PostModel.Post_Id)),

                    r=> r.HasOne(typeof(UserModel)).WithMany()
                            .HasForeignKey("User_Id")
                            .HasPrincipalKey(nameof(UserModel.User_Id)),

                    j=> j.HasKey("Post_Id","User_Id")
                );

        }
    }
}
