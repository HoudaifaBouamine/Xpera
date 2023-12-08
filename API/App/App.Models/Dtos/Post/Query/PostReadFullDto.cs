using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Formats.Asn1;
using App.Models.Dtos.User.Query;

namespace App.Models.Dtos.Post.Read
{
    public class PostReadFullDto
    {
        public int Post_Id { get; set; }
        public UserReadDto User { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime PublishDateTime { get; set; }
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
