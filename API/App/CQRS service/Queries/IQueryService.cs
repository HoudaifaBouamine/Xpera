using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;

namespace App.API.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for query-related operations in the application, including post and user retrieval.
    /// </summary>
    public interface IQueryService
    {

        #region Post Queries

        /// <summary>
        /// Retrieves detailed information about a post based on its id.
        /// </summary>
        /// <param name="post_id">The id of the post to retrieve.</param>
        /// <returns>Returns a PostReadFullDto if the post exists, otherwise returns null.</returns>
        public Task<PostReadFullDto?> ReadPostAsync(int post_id);

        /// <summary>
        /// Retrieves a list of minimal information about all posts posted by a user with the specified user_id.
        /// </summary>
        /// <param name="user_id">The user_id of the owner of the posts.</param>
        /// <returns>Returns a list of PostReadMinimulDto containing information about all posts owned by the specified user.</returns>
        public Task<IEnumerable<PostReadMinimulDto>> ReadUserPostsAsync(Guid user_id);

        /// <summary>
        /// Retrieves detailed information about all posts in the system.
        /// </summary>
        /// <returns>Returns a list of PostReadFullDto containing information about all posts in the system.</returns>
        public Task<IEnumerable<PostReadFullDto>> ReadAllPostsAsync();

        /// <summary>
        /// Retrieves detailed information about all posts that contain the specified tag with tag_id.
        /// </summary>
        /// <param name="tag_id">The id of the tag to filter posts with.</param>
        /// <returns>Returns a list of PostReadFullDto containing information about all posts that contain the specified tag.</returns>
        public Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id);

        #endregion

        #region User Queries

        /// <summary>
        /// Retrieves user information based on the user_id.
        /// </summary>
        /// <param name="user_id">The id of the user to retrieve.</param>
        /// <returns>Returns a UserReadDto containing user information if the user exists, otherwise returns null.</returns>
        public Task<UserReadDto?> ReadUserAsync(Guid user_id);

        /// <summary>
        /// Authenticates a user based on their email and password.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>Returns a UserReadDto if the email and password are correct, otherwise returns null.</returns>
        public Task<UserReadDto?> LoginUser(string email, string password);

        #endregion

        #region Comments

        public Task<IEnumerable<CommentPostReadDto>> ReadCommentsByUserIdAsync(Guid user_id);

        public Task<IEnumerable<CommentUserReadDto>> ReadCommentsByPostIdAsync(int post_id);


        #endregion
    }
}
