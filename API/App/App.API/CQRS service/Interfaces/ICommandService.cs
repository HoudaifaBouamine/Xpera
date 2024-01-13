using App.API.Entities;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;

namespace App.API.Servises.Interfaces
{
    public interface ICommandService
    {

        // Post

        /// <summary>
        /// Add new post to the system
        /// </summary>
        /// <param name="postToCreate">contatin new post's data</param>
        /// <returns>Minimul information about the new created post (including post_id) if created successfuly,otherwise return null</returns>
        public Task<PostReadMinimulDto?> PostCreateAsync(PostCreateDto postToCreate);

        /// <summary>
        /// Update an existing post information
        /// </summary>
        /// <param name="postToUpdate">Contain the new updated data</param>
        /// <returns>return the updated post info of updated succesfuly ,otherwize return null</returns>
        public Task<PostReadMinimulDto?> PostUpdateAsync(PostUpdateDto postToUpdate);

        /// <summary>
        /// Delete an existing post by post id
        /// </summary>
        /// <param name="postToDelete_id">the post Id</param>
        /// <returns>return <c>true</c> if deleted</returns>
        public Task<bool> PostDeleteAsync(int postToDelete_id);


        // User


        /// <summary>
        /// Add new user account to the system
        /// </summary>
        /// <param name="userToCreate">contatin new user's data</param>
        /// <returns>return User Read Dto if user Created Successfuly, otherwize return null</returns>
        public Task<UserReadDto?> UserRegisterAsync(UserCreateDto userToCreate);

        /// <summary>
        /// Update an existing post information
        /// </summary>
        /// <param name="userToUpdate">Contain the new updated data</param>
        /// <returns>return the updated post info of updated succesfuly ,otherwize return null</returns>
        public Task<PostReadMinimulDto?> UserUpdateAsync(UserUpdateDto userToUpdate);

        /// <summary>
        /// Delete an existing post by post id
        /// </summary>
        /// <param name="UserToDelete_id">the user Id</param>
        /// <returns>return <c>true</c> if deleted</returns>
        public Task<bool> UserDeleteAsync(int UserToDelete_id);

    }
}
