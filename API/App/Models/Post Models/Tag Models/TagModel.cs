using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Models.PostModels
{
    public class TagModel
    {
        [Key]
        [Column(nameof(Tag_Id))]
        public int Tag_Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public List<PostHaveTagRelation> TagPosts {get;set;} = new();
    }
}
