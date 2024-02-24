using App.API.Models.PostModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Models.Post_Models.Comment_Models
{
    public class CommentModel
    {
        [Key]
        [Column(name:"Comment_Id")]
        public int Comment_Id { get; set; }

        [Required]
        [MaxLength(2000)]
        [MinLength(1)]
        public string Text { get; set; } = "Empty Comment";


        [Required]
        [ForeignKey(nameof(User))]
        [Column(nameof(User_Id))]
        public Guid User_Id { get; set; }
        public UserModel User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Post))]
        [Column(nameof(Post_Id))]
        public int Post_Id { get; set; }
        public PostModel Post { get; set; } = null!;

        [Required]
        public DateTime PublishDateTime { get; set; }
    }
}
