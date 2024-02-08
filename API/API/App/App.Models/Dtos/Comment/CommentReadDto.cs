using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Dtos.Comment
{

    public class CommentMinReadDto
    {
        required public int Id { get; set; }
        required public string Text { get; set; }
        required public DateTime Time { get; set; }
    }

    /// <summary>
    /// This type will be returned when <c> query by post </c> and want to <c> get user data </c>
    /// </summary>
    public class CommentUserReadDto : ICommentDto
    {
        required public int Id { get; set; }
        required public string Text { get; set; }
        required public DateTime Time { get; set; }
        required public UserReadDto User { get; set; }

    }

    /// <summary>
    /// This type will be returned when <c> query by user </c> and want to <c> get post data </c>
    /// </summary>
    public class CommentPostReadDto : ICommentDto
    {
       
        required public int Id { get; set; }
        required public string Text { get; set; }
        required public DateTime Time { get; set; }
        required public PostReadFullDto Post { get; set; }
    
    }

    public class CommentFullReadDto : ICommentDto
    {

        required public int Id { get; set; }
        required public string Text { get; set; }
        required public DateTime Time { get; set; }
        required public PostReadFullDto Post { get; set; }
        required public UserReadDto User { get; set; }


    }

    public interface ICommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }

    public class CommentCreateDto
    {
        [MaxLength(2000)]
        [MinLength(1)]
        required public string Text { get; set; }
        required public int Post_Id { get; set; }
        required public int User_Id { get; set; }
    }
}
