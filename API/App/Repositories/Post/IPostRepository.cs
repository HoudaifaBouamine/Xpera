using App.API.Models.PostModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.API.Repositories.PostRepository
{
    /// <summary>
    /// Interface for managing posts and tags in the repository.
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Creates a new post and associates it with the specified tags.
        /// </summary>
        /// <param name="post">The post to be created.</param>
        /// <param name="tags">The tags associated with the post.</param>
        /// <returns>The created post or null if unsuccessful.</returns>
        public Task<PostModel?> PostCreateAsync(PostModel post, IEnumerable<TagModel> tags);

        /// <summary>
        /// Retrieves a post by its id.
        /// </summary>
        /// <param name="id">The id of the post to retrieve.</param>
        /// <returns>The post with the specified id or null if not found.</returns>
        public Task<PostModel?> PostReadAsync(int id);

        /// <summary>
        /// Retrieves the tags associated with a specific post.
        /// </summary>
        /// <param name="id">The id of the post.</param>
        /// <returns>A list of tags associated with the post.</returns>
        public Task<List<TagModel>> PostTagsReadAsync(int id);

        /// <summary>
        /// Retrieves posts owned by a specific user.
        /// </summary>
        /// <param name="user_Id">The id of the user.</param>
        /// <returns>A list of posts owned by the user.</returns>
        public Task<List<PostModel>> UserPostsReadAsync(Guid user_Id);

        /// <summary>
        /// Retrieves tags by their ids.
        /// </summary>
        /// <param name="tags_ids">The ids of the tags to retrieve.</param>
        /// <returns>A list of tags with the specified ids.</returns>
        public Task<List<TagModel>> TagsByIdsAsync(IEnumerable<int> tags_ids);

        public Task<List<TagModel>> TagsByNamesAsync(IEnumerable<string> tags_names);

        /// <summary>
        /// Deletes a post by its id.
        /// </summary>
        /// <param name="post_id">The id of the post to delete.</param>
        public Task PostDeleteAsync(int post_id);

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="post">The post with updated information.</param>
        public Task PostUpdateAsync(PostModel post);
    }
}
