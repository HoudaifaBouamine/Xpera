using System.Linq.Expressions;
using App.API.Data;
using App.API.Models;
using App.Models.Dtos;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace App.API.Repositories.UserRepository
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly AppDbContext db;
        public UserRepositoryEF(AppDbContext db)
        {
            this.db = db;
        }

        // Done
        public async Task<UserModel?> UserCreate(UserModel user)
        {

            if(user.User_Id == default)
            {
                //user.User_Id = Guid.NewGuid();
                var Entity = await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                UserModel createdUser = Entity.Entity;
                return createdUser;
            }
            else
            {
                System.Console.WriteLine("not default");
                UserModel? foundUser = await db.Users.Where(u=>u.User_Id == user.User_Id).FirstOrDefaultAsync();

                if(foundUser is null)
                {
                    var Entity = await db.Users.AddAsync(user);

                    System.Console.WriteLine("Creating the user from firebase");

                    System.Console.WriteLine("--> created localy with name : " + Entity.Entity.FirstName);

                    foundUser = Entity.Entity;

                    await db.SaveChangesAsync();

                    System.Console.WriteLine("--> created to the database with name : " + foundUser.FirstName);

                }
                else
                {
                    foundUser = user;
                    await db.SaveChangesAsync();
                }

                return foundUser;
            }
        }

        // Done
        public async Task UserDelete(Guid user_id)
        {
            int rowAffected = await db.Users.Where(u => u.User_Id == user_id).ExecuteDeleteAsync();
        }

        public async Task<UserModel?> UserRead(Guid id)
        {
            UserModel? user = await db.Users.FirstOrDefaultAsync(u => u.User_Id == id);
            return user;
        }

        // Done
        public async Task<UserModel?> UserRead(string email)
        {
            UserModel? user = await db.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task UserUpdate(UserModel user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
        }
    }
}
