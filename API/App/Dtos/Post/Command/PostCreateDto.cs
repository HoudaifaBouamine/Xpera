using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;

namespace App.Models.Dtos.Post.Create
{
    public class PostCreateDto
    {
        [Required] public string Title { get; set; } = string.Empty;
        [Required] public string Body { get; set; } = string.Empty;
        public IEnumerable<string> TagsNames { get; set; } = null!;
    }
}
