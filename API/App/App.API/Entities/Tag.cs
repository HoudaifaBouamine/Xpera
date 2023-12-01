using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Entities
{
    public class Tag
    {
        [Key]
        [Column(nameof(Tag_Id))]
        public int Tag_Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
    }
}
