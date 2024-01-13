using App.API.Entities;

namespace App.API.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User?> UserRead(int id);
        Task<User?> UserRead(string email);

        Task<User?> UserCreate(User user);
        Task<User?> UserUpdate(User user);
        Task<bool> UserDelete(int user_id);


    }
}
