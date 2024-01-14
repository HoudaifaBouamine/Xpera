using App.API.Entities;
using App.API.Security;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using AutoMapper;

namespace App.API.Extentions.DtosExtentions
{
    static public class UserExtentions
    {

        private static IMapper _mapper = null;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        static public User ToEntity(this UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.HashedPassword = SecurityService.HashPassword( userCreateDto.Password );

            return user;
        }

        static public User ToEntity(this UserReadDto userReadDto)
        {
            return _mapper.Map<User>(userReadDto);
        }

        static public UserReadDto ToDto(this User user)
        {
            return _mapper.Map<UserReadDto>(user);
        }
    }
}
