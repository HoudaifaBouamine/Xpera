using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Dtos.Post.Query
{
    public class PostHaveTagDto
    {
        public int Post_Id { get; set; }
        public int Tag_Id { get; set; }
        public string Tag_Name { get; set;} = string.Empty;
    }
}
