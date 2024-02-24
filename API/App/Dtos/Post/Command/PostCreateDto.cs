using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Dtos.Post.Create
{
    public class PostCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IEnumerable<string> TagsNames { get; set; } = null!;
    }
}
