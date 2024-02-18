using App.API.Data;
using App.API.Models;
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
        public async Task<UserModel?> UserCreate(UserModel user)
        {
            user.User_Id = default;
            var Entity = await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            UserModel User = Entity.Entity;
            return User;
        }

        // Done
        public async Task UserDelete(int user_id)
        {
            int rowAffected = await dbContext.Users.Where(u => u.User_Id == user_id).ExecuteDeleteAsync();
        }

        // Done
        public async Task<UserModel?> UserRead(int id)
        {
            return await dbContext.Users.Where(u => u.User_Id == id).FirstOrDefaultAsync();
        }

        // Done
        public async Task<UserModel?> UserRead(string email)
        {
            UserModel? user = await dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task UserUpdate(UserModel user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
