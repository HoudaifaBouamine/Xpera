using App.API.Models.PostModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace App.API.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserModel
    {

        [Key]
        [Column(nameof(User_Id))]
        public Guid User_Id { get; set; }

        [MinLength(1)]
        public string FirstName { get; set; } = string.Empty;

        [MinLength(1)]
        public string LastName { get; set; } = string.Empty;
        
        [MinLength(1)]
        public string Email { get; set; } = string.Empty;

        [MinLength(1)]
        public string HashedPassword { get; set; } = string.Empty;

        [MinLength(1)]
        public string? PictureUrl { get; set; } = null;

        public List<PostModel> LikedPosts { get; set; } = new();
        
        public List<PostModel> Posts {get;set;} = new();
    }
}
