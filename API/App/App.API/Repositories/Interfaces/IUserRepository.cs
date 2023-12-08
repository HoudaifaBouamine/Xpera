using App.API.Entities;

namespace App.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Read(int id);
        Task<User?> Read(string email);

        Task<User?> Create(User user);
    }
}
