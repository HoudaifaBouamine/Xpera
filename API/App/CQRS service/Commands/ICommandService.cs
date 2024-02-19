using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;

namespace App.API.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for command-related operations in the application, including post and user management.
    /// </summary>
    public interface ICommandService
    {

        #region Post Commands
        /// <summary>
        /// Adds a new post to the system.
        /// </summary>
        /// <param name="postToCreate">Contains new post data.</param>
        /// <returns>Returns minimal information about the newly created post (including post_id) if successful, otherwise returns null.</returns>
        public Task<PostReadMinimulDto?> PostCreateAsync(PostCreateDto postToCreate);

        /// <summary>
        /// Updates an existing post's information.
        /// </summary>
        /// <param name="postToUpdate">Contains the new updated data.</param>
        /// <returns>Returns the updated post information if successful, otherwise returns null.</returns>
        public Task<PostReadMinimulDto?> PostUpdateAsync(PostUpdateDto postToUpdate);

        /// <summary>
        /// Deletes an existing post by post id.
        /// </summary>
        /// <param name="postToDelete_id">The post Id.</param>
        /// <returns>Returns true if the post is deleted successfully.</returns>
        public Task<bool> PostDeleteAsync(int postToDelete_id);

        #endregion

        #region User Commands

        /// <summary>
        /// Adds a new user account to the system.
        /// </summary>
        /// <param name="userToCreate">Contains new user data.</param>
        /// <returns>Returns User Read Dto if user is created successfully, otherwise returns null.</returns>
        public Task<UserReadDto?> UserRegisterAsync(UserCreateDto userToCreate);

        public Task<UserReadDto?> UserFirebaseRegisterAsync(UserFirebaseCreateDto userToCreate);

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="userToUpdate">Contains the new updated data.</param>
        /// <returns>Returns the updated user information if successful, otherwise returns null.</returns>
        public Task<bool> UserUpdateAsync(UserUpdateDto userToUpdate);

        /// <summary>
        /// Deletes an existing user by user id.
        /// </summary>
        /// <param name="UserToDelete_id">The user Id.</param>
        /// <returns>Returns true if the user is deleted successfully.</returns>
        public Task UserDeleteAsync(Guid UserToDelete_id);

        #endregion


        #region Comments

        public Task<CommentMinReadDto> CreateCommentAsync(CommentCreateDto comment); 

        #endregion
    }
}
