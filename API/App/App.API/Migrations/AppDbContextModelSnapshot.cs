﻿// <auto-generated />
using System;
using App.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.API.Entities.Post", b =>
                {
                    b.Property<int>("Post_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Post_Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.HasKey("Post_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("App.API.Entities.PostHaveTag", b =>
                {
                    b.Property<int>("PostHaveTag_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostHaveTag_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostHaveTag_Id"));

                    b.Property<int>("Post_Id")
                        .HasColumnType("int")
                        .HasColumnName("Post_Id");

                    b.Property<int>("Tag_Id")
                        .HasColumnType("int")
                        .HasColumnName("Tag_Id");

                    b.HasKey("PostHaveTag_Id");

                    b.HasIndex("Post_Id");

                    b.HasIndex("Tag_Id");

                    b.ToTable("PostsHaveTags");
                });

            modelBuilder.Entity("App.API.Entities.Tag", b =>
                {
                    b.Property<int>("Tag_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Tag_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tag_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Tag_Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("App.API.Entities.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("User_Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.API.Entities.Post", b =>
                {
                    b.HasOne("App.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.API.Entities.PostHaveTag", b =>
                {
                    b.HasOne("App.API.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("Post_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.API.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("Tag_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
