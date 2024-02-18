using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Dtos.Post
{
    public class TagDto
    {
        public int Tag_Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class TagCreateDto{
        public string Name { get; set; } = string.Empty;
    }
}
