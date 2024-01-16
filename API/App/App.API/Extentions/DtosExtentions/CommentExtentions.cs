using App.API.Models;
using App.API.Models.Post_Models.Comment_Models;
using App.API.Models.PostModels;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Read;

namespace App.API.Extentions.DtosExtentions
{
    public static class CommentExtentions
    {
        public static CommentUserReadDto ToDto(this CommentModel comment, UserModel user) => new ()
        {
            Id = comment.Id,
            Text = comment.Text,
            Time = comment.PublishDateTime,
            User = user.ToDto()
        };

        public static CommentPostReadDto ToDto(this CommentModel comment, PostReadFullDto post) => new ()
        {
            Id = comment.Id,
            Text = comment.Text,
            Time = comment.PublishDateTime,
            Post = post
        };

        public static CommentModel ToEntity(this CommentCreateDto comment)
        {
            return new CommentModel()
            {
                Post_Id = comment.Post_Id,
                Text = comment.Text,
                User_Id = comment.User_Id,
                PublishDateTime = DateTime.Now,
            };

        }
    }
}
