using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Dtos.Post.Query
{
    /// <summary>
    /// Reporesent the relation between Post and Tag (used to create M -> M relation between Posts & Tags tables)
    /// </summary>
    public class PostHaveTagDto
    {
        public int Post_Id { get; set; }
        public int Tag_Id { get; set; }
        public string Tag_Name { get; set;} = string.Empty;
    }
}
