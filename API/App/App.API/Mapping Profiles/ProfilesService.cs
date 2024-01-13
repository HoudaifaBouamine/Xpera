using App.API.Entities;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;
using AutoMapper;

namespace App.API.Mapping_Profiles
{
    public class ProfilesService : Profile
    {
        public ProfilesService() 
        {
            CreateMap<User, UserReadDto>().ForMember(dest => dest.Id,op=>op.MapFrom(src=>src.User_Id)).ReverseMap();
            CreateMap<UserCreateDto, User>().ForMember(dest=>dest.HashedPassword,opt=>opt.MapFrom(src=>src.Password));

            CreateMap<PostCreateDto, Post>();
        }
    }
}
