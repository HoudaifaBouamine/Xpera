using App.API.Entities;

namespace App.API.Repositories.PostRepository
{
    public interface IPostRepository
    {
        public Task<Post?> PostCreateAsync(Post post, IEnumerable<Tag> tags);

        public Task<Post?> PostReadAsync(int id);

        public Task<List<Tag>> PostTagsReadAsync(int id);

        public Task<List<Post>> UserPostsReadAsync(int user_Id);

        /// <summary>
        /// Get list of posts's ids and
        /// return list of tags in it
        /// </summary>
        /// <param name="tags_ids"></param>
        /// <returns></returns>
        public Task<List<Tag>> TagsByIdsAsync(IEnumerable<int> tags_ids);

        public Task<bool> PostDeleteAsync(int post_id);

        public Task<Post> PostUpdateAsync();
    }
}
