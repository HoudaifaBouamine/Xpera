using App.API.Models.Post_Models.Comment_Models;
using App.Models.Dtos.Comment;

namespace App.API.Repositories.Comment
{
    public interface ICommentRepository
    {
        Task<CommentModel> CreateCommentAsync(CommentModel comment);
    }
}
