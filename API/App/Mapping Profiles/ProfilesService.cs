using App.API.Models;
using App.API.Models.PostModels;
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
            CreateMap<UserModel, UserReadDto>().ForMember(dest => dest.Id,op=>op.MapFrom(src=>src.User_Id)).ReverseMap();
            CreateMap<UserCreateDto, UserModel>().ForMember(dest=>dest.HashedPassword,opt=>opt.MapFrom(src=>src.Password));

            CreateMap<PostCreateDto, PostModel>();
        }
    }
}
