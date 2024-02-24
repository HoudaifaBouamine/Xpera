using App.API.Data;
using App.API.Models.Post_Models.Comment_Models;
using Microsoft.EntityFrameworkCore;

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
            _db.Posts.Where(p=>p.Post_Id == comment.Post_Id)
                .ExecuteUpdate(prop=>prop.SetProperty(p=>p.CommentsNumber,p=>p.CommentsNumber + 1));
            await _db.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteCommentAsync(int comment_id)
        {
            var comment = await _db.Comments.Where(c=>c.Comment_Id == comment_id).FirstOrDefaultAsync();

            if(comment is null)
            {
                return false;
            }

            await _db.Posts.Where(p=>p.Post_Id == comment.Post_Id)
                .ExecuteUpdateAsync(prop=>prop
                    .SetProperty(p=>p.CommentsNumber,p=>p.CommentsNumber - 1));

            await _db.Comments.Where(c=>c.Comment_Id == comment.Comment_Id).ExecuteDeleteAsync();

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
