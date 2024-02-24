using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace App.API.Models.PostModels
{
    public class PostModel
    {
        [Key]
        [Column(nameof(Post_Id))]
        public int Post_Id { get; set; }

        [ForeignKey(nameof(User))]
        [Column(nameof(User_Id))]
        public Guid User_Id { get; set; }
        public UserModel User { get; set; } = null!;


        [MinLength(1)]
        public string Title { get; set; } = string.Empty;

        
        [MinLength(1)]
        public string Body { get; set; } = string.Empty;


        public DateTime PublishDateTime { get; set; }

        public List<PostHaveTagRelation> PostTags {get;set;} = new ();

        public int CommentsNumber { get; set; } = 0;
    }
}
