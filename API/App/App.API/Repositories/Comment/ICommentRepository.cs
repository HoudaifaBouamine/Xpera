using App.API.Models.Post_Models.Comment_Models;

namespace App.API.Repositories.Comment
{
    public interface ICommentRepository
    {

        Task<int> CreateCommentAsync(CommentModel comment);
    }
}
