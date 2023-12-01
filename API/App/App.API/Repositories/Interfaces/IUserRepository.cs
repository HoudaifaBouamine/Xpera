using App.API.Entities;

namespace App.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Read(int id);

        Task<User?> Create(User user);
    }
}
