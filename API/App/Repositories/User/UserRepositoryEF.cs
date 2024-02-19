using App.API.Data;
using App.API.Models;
using App.Models.Dtos;
using Microsoft.AspNetCore.HttpLogging;
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

            if(user.User_Id == default)
            {
                var Entity = await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                UserModel createdUser = Entity.Entity;
                return createdUser;
            }
            else
            {
                UserModel? foundUser = await dbContext.Users.Where(u=>u.User_Id == user.User_Id).FirstOrDefaultAsync();

                if(foundUser is null)
                {
                    var Entity = await dbContext.Users.AddAsync(user);

                    System.Console.WriteLine("Creating the user from firebase");

                    System.Console.WriteLine("--> created localy with name : " + Entity.Entity.FirstName);

                    foundUser = Entity.Entity;

                    await dbContext.SaveChangesAsync();

                    System.Console.WriteLine("--> created to the database with name : " + foundUser.FirstName);

                }
                else
                {
                    foundUser = user;
                    await dbContext.SaveChangesAsync();
                }

                return foundUser;
            }
        }

        // Done
        public async Task UserDelete(Guid user_id)
        {
            int rowAffected = await dbContext.Users.Where(u => u.User_Id == user_id).ExecuteDeleteAsync();
        }

        // Done
        public async Task<UserModel?> UserRead(Guid id)
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
