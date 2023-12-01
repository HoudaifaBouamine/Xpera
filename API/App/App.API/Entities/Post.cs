using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace App.API.Entities
{
    public class Post
    {
        [Key]
        [Column(nameof(Post_Id))]
        public int Post_Id { get; set; }

        [ForeignKey(nameof(User))]
        [Column(nameof(User_Id))]
        public int User_Id { get; set; }
        public User User { get; set; } = null!;


        [Column(TypeName ="nvarchar(100)")]
        [MinLength(1)]
        public string Title { get; set; } = string.Empty;

        
        [Column(TypeName ="nvarchar(max)")]
        [MinLength(1)]
        public string Body { get; set; } = string.Empty;


        public DateTime PublishDateTime { get; set; }
    }
}
