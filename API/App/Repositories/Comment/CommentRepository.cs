using App.API.Data;
using App.API.Models.Post_Models.Comment_Models;

namespace App.API.Repositories.Comment
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<CommentModel> CreateCommentAsync(CommentModel comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return comment;
        }
    }
}
