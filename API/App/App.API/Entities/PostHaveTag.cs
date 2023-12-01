using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Entities
{
    public class PostHaveTag
    {
        [Key]
        [Column(nameof(PostHaveTag_Id))]
        public int PostHaveTag_Id { get; set; }

        
        [ForeignKey(nameof(Post))]
        [Column(nameof(Post_Id))]
        public int Post_Id { get; set; }
        public Post Post { get; set; } = null!;

        
        [ForeignKey(nameof(Tag))]
        [Column(nameof(Tag_Id))]
        public int Tag_Id { get; set; }
        public Tag Tag { get; set; }   = null!;

    }
}
