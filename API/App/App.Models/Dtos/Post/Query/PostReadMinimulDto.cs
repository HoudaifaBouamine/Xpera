using App.Models.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Dtos.Post.Read
{
    public class PostReadMinimulDto
    {
        public int Post_Id { get; set; }
        public int User_Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime PublishDateTime { get; set; }
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
