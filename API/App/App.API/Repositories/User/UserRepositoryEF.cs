using App.API.Data;
using App.API.Entities;
using App.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace App.API.Repositories.UserRepository
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly AppDbContext dbContext;
        public UserRepositoryEF(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Done
        public async Task<User?> UserCreate(User user)
        {
            user.User_Id = default;
            var Entity = await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            User User = Entity.Entity;
            return User;
        }

        // Done
        public async Task<bool> UserDelete(int user_id)
        {
            int rowAffected = await dbContext.Users.Where(u => u.User_Id == user_id).ExecuteDeleteAsync();

            if (rowAffected == 1)
                return true;

            return false;
        }

        // Done
        public async Task<User?> UserRead(int id)
        {
            return await dbContext.Users.Where(u => u.User_Id == id).FirstOrDefaultAsync();
        }

        // Done
        public async Task<User?> UserRead(string email)
        {
            User? user = await dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public Task<User?> UserUpdate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
