using App.API.Models;
using App.API.Security;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using AutoMapper;

namespace App.API.Extentions.DtosExtentions
{
    static public class UserExtentions
    {

        private static IMapper? _mapper = null;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        static public UserModel ToEntity(this UserCreateDto userCreateDto)
        {
            var user = _mapper!.Map<UserModel>(userCreateDto);
            user.HashedPassword = SecurityService.HashPassword( userCreateDto.Password );
            user.FirstName = userCreateDto.Name;
            return user;
        }

        static public UserModel ToEntity(this UserReadDto userReadDto)
        {
            UserModel userModel = _mapper!.Map<UserModel>(userReadDto);
            userModel.FirstName = userReadDto.Name;

            return userModel;
        }

        static public UserModel? ToEntity(this UserUpdateDto userUpdate,UserModel userModel)
        {
            if(userUpdate.User_Id != userModel.User_Id)
            {
                return null;
            }

            return new UserModel()
            {

                Email = userModel.Email,
                HashedPassword = userModel.HashedPassword,
                FirstName = userUpdate.FirstName,
                LastName = userUpdate.LastName,
                User_Id = userModel.User_Id

            };
        }

        static public UserReadDto ToDto(this UserModel user)
        {
            var userDto = _mapper!.Map<UserReadDto>(user);

            userDto.Name = user.FirstName;

            return userDto;
        }

    }
}
