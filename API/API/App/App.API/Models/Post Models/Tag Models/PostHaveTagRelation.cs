using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Models.PostModels
{
    public class PostHaveTagRelation
    {
        [Key]
        [Column(nameof(PostHaveTag_Id))]
        public int PostHaveTag_Id { get; set; }

        
        [ForeignKey(nameof(Post))]
        [Column(nameof(Post_Id))]
        public int Post_Id { get; set; }
        public PostModel Post { get; set; } = null!;

        
        [ForeignKey(nameof(Tag))]
        [Column(nameof(Tag_Id))]
        public int Tag_Id { get; set; }
        public TagModel Tag { get; set; }   = null!;

    }
}
