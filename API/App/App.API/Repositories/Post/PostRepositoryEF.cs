using App.API.Data;
using App.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.API.Repositories.PostRepository
{
    public class PostRepositoryEF : IPostRepository
    {
        private readonly AppDbContext _AppDbContext;
        public PostRepositoryEF(AppDbContext appDbContext)
        {
        
            this._AppDbContext = appDbContext;
        
        }

        // Done
        public async Task<Post?> PostCreateAsync(Post post,IEnumerable<Tag> tags)
        {
            var e = await _AppDbContext.Posts.AddAsync(post);

            Post? thePost = e.Entity;

            await _AppDbContext.SaveChangesAsync();

            foreach(Tag tag in tags)
            {
                PostHaveTag h = new PostHaveTag();
                h.Tag_Id = tag.Tag_Id;
                h.Post_Id = thePost.Post_Id;

                await _AppDbContext.PostsHaveTags.AddAsync(h);
            }


            await _AppDbContext.SaveChangesAsync();

            return thePost;
        }

        // Done
        public async Task<List<Tag>> TagsByIdsAsync(IEnumerable<int> tags_ids)
        {
            return await _AppDbContext.Tags.Where(t => tags_ids.Contains(t.Tag_Id)).ToListAsync();
        }

        // Done
        public async Task<Post?> PostReadAsync(int id)
        {
            return await _AppDbContext.Posts.Where(p => p.Post_Id == id).FirstOrDefaultAsync();
        }
        
        // Done
        public async Task<List<Tag>> PostTagsReadAsync(int id)
        {
            return await _AppDbContext.Tags.FromSql($"SELECT T.* FROM   Posts p  JOIN PostsHaveTags pht  ON p.Post_Id = PHT.Post_Id  JOIN Tags t  ON pht.Tag_Id = t.Tag_Id  where P.Post_Id = {id};").ToListAsync(); 
        }

        // Done
        public async Task<List<Post>> UserPostsReadAsync(int user_Id)
        {
            return await _AppDbContext.Posts.Where(p=>p.User_Id == user_Id).ToListAsync();
        }

        public async Task<bool> PostDeleteAsync(int post_id)
        {
            int affectedRows = await _AppDbContext.Posts.Where(p => p.Post_Id == post_id).ExecuteDeleteAsync();

            return affectedRows == 1;
        }

        public Task<Post> PostUpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
