using App.API.Data;
using App.API.Entities;
using App.API.Repositories.Interfaces;
using App.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace App.API.Repositories.Implimentations
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly AppDbContext dbContext;
        public UserRepositoryEF(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<User?> Create(User user)
        {
            user.User_Id = default;
            var Entity = await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            User User = Entity.Entity;
            return User;
        }

        public async Task<User?> Read(int id)
        {
            return await dbContext.Users.Where(u=>u.User_Id == id).FirstOrDefaultAsync();
        }

        public async Task<User?> Read(string email)
        {
            User? user = await dbContext.Users.Where(u=>u.Email == email).FirstOrDefaultAsync();
            return user;
        }
    }
}
