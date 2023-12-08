using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Query;

namespace App.API.Servises.Interfaces
{
    public interface IQueryService
    {

        // Post

        /// <summary>
        /// Get post data
        /// </summary>
        /// <param name="post_id">Id to find the post</param>
        /// <returns>Post dto if post exist, otherwise return null</returns>
        public Task<PostReadFullDto?> ReadPostAsync(int post_id);

        /// <summary>
        /// Get all the posts posted by user with User_Id
        /// </summary>
        /// <param name="user_id">Key of the user</param>
        /// <returns>list of all the posts owned by the user with the selected user_id</returns>
        public Task<IEnumerable<PostReadFullDto>> ReadUserPostsAsync(int user_id);

        /// <summary>
        /// Get all the posts information in the system
        /// </summary>
        /// <returns>list of all the posts in the system</returns>
        public Task<IEnumerable<PostReadFullDto>> ReadAllPostsAsync();

        /// <summary>
        /// Get all the posts that contain the tag with tag_id
        /// </summary>
        /// <param name="tag_id">Id of the tag to filter with</param>
        /// <returns>list of all posts contain tag selected by tag_id</returns>
        public Task<IEnumerable<PostReadFullDto>> ReadTagPostsAsync(int tag_id);

        // User

        /// <summary>
        /// Get user by user_id
        /// </summary>
        /// <param name="user_id">Id of the user</param>
        /// <returns>User dto contain user info</returns>
        public Task<UserReadDto?> ReadUser(int user_id);

        /// <summary>
        /// Get user info of Email and password are correct
        /// </summary>
        /// <param name="email">the user Email</param>
        /// <param name="password">the user Password</param>
        /// <returns>return UserReadDto if Email and Password are correct, otherwise return null</returns>
        public Task<UserReadDto?> LoginUser(string email,string password);


    }
}
