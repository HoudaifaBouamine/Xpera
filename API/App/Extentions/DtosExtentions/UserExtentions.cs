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
            return user;
        }

        static public UserModel ToEntity(this UserReadDto userReadDto)
        {
            return _mapper!.Map<UserModel>(userReadDto);
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
            return _mapper!.Map<UserReadDto>(user);
        }

    }
}
