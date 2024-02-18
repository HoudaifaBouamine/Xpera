using System.Threading.Tasks;
using App.API.Models;

namespace App.API.Repositories.UserRepository
{
    /// <summary>
    /// Interface for managing user data in the repository.
    /// </summary>
    public interface IUserRepository
    {

        /// <summary>
        /// Retrieves a user by their email.
        /// </summary>
        /// <param name="Id">The Id of the user to retrieve.</param>
        /// <returns>The user with the specified Id or null if not found.</returns>
        Task<UserModel?> UserRead(int Id);
        /// <summary>
        /// Retrieves a user by their email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve.</param>
        /// <returns>The user with the specified email or null if not found.</returns>
        Task<UserModel?> UserRead(string email);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user to be created.</param>
        /// <returns>The created user or null if unsuccessful.</returns>
        Task<UserModel?> UserCreate(UserModel user);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user with updated information.</param>
        Task UserUpdate(UserModel user);

        /// <summary>
        /// Deletes a user by their id.
        /// </summary>
        /// <param name="user_id">The id of the user to be deleted.</param>
        Task UserDelete(int user_id);
    }
}
