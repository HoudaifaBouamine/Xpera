using App.API.Entities;
using App.Models.Dtos;
using AutoMapper;

namespace App.API.Extentions.DtosExtentions
{
    static public class UserExtentions
    {

        static public User ToEntity(this UserCreateDto userCreateDto)
        {

            return new User()
            {
                User_Id = default,
                Email = userCreateDto.Email,
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                HashedPassword = userCreateDto.Password
            };

        }

        static public UserReadDto ToDto(this User user)
        {
            return new UserReadDto()
            {
                Id = user.User_Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}
