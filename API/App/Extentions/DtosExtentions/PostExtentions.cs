﻿using App.API.Models;
using App.API.Models.PostModels;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Query;
using App.Models.Dtos.Post.Read;
using AutoMapper;

namespace App.API.Extentions.DtosExtentions
{
    public static class PostExtentions
    {
        private static IMapper? _mapper = null;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }
        public static PostReadFullDto ToDto(this PostModel post, UserModel user, List<TagModel> tags)
        {

            return new PostReadFullDto()
            {
                Body = post.Body,
                PublishDateTime = post.PublishDateTime,
                Post_Id = post.Post_Id,
                Title = post.Title,
                CommentsNumber = post.CommentsNumber,
                User = (user is null ? null : user.ToDto())!,
                Tags = (tags is null ? null : tags.ToDto())!,
            };
        }

        public static PostReadFullDto ToDto(this PostModel post)
        {

            return new PostReadFullDto()
            {
                Body = post.Body,
                PublishDateTime = post.PublishDateTime,
                Post_Id = post.Post_Id,
                Title = post.Title,
                CommentsNumber = post.CommentsNumber,
                NumberOfLikes = post.NumberOfLikes,
                User = null!,
                Tags = null!
            };
        }

        public static IEnumerable<PostReadFullDto> ToDtoList(this IEnumerable<PostModel> posts, UserModel? user, List<List<TagModel>>? tags)
        {
            var postsAsList = posts.ToList();
            var postsAsDto = new List<PostReadFullDto>();

            for (int i = 0; i < postsAsList.Count(); i++)
            {
                postsAsDto.Add
                (
                    new PostReadFullDto()
                    {
                        Body = postsAsList[i].Body,
                        PublishDateTime = postsAsList[i].PublishDateTime,
                        Post_Id = postsAsList[i].Post_Id,
                        Title = postsAsList[i].Title,
                        CommentsNumber = postsAsList[i].CommentsNumber,
                        User = user?.ToDto()!,
                        Tags = tags?[i]?.ToDto()!,
                    }
                );
            }

            return postsAsDto;
        }

        public static List<string> ToDto(this IEnumerable<TagModel> tags)
        {
            return (from t in tags
                    select t.Name).ToList();
        }

        public static string ToDto(this TagModel tag){
            
            return tag.Name;
            
        }

        public static PostModel ToEntity(this PostCreateDto postCreate,UserModel? user = null)
        {
            PostModel post = _mapper!.Map<PostModel>(postCreate);
            post.User = user!;
            post.User_Id = user.User_Id;
            post.PublishDateTime = DateTime.UtcNow;
            post.CommentsNumber = 0;
            return post;
        }

        public static List<TagModel> ToEntity(this IEnumerable<TagDto> tagsAsDto)
        {
            return (from t in tagsAsDto
                    select new TagModel()
                    {
                        Name = t.Name,
                        Tag_Id = t.Tag_Id

                    }).ToList();
        }

        /// <summary>
        /// convert post to post read
        /// </summary>
        /// <param name="post">the post model</param>
        /// <param name="tags">tags to insert in the post (save to send null)</param>
        /// <returns></returns>
        public static PostReadMinimulDto ToDto(this PostModel post, IEnumerable<TagModel>? tags)
        {
            return new PostReadMinimulDto()
            {
                Body = post.Body,
                Post_Id = post.Post_Id,
                PublishDateTime = post.PublishDateTime,
                Tags = tags is null ? Enumerable.Empty<TagModel>().ToDto() : tags.ToDto(),
                Title = post.Title,
                User_Id = post.User_Id,
                CommentsNumber = post.CommentsNumber,
                FavoritsNumber = post.NumberOfLikes
            };
        }

        public static PostHaveTagDto ToDto(this PostHaveTagRelation postHaveTag, TagModel tag)
        {
            return new PostHaveTagDto()
            {
                Post_Id = postHaveTag.Post_Id,
                Tag_Id = tag.Tag_Id,
                Tag_Name = tag.Name
            };
        }
        public static IEnumerable<TagModel> ToEntities(this IEnumerable<PostHaveTagDto> poatHaveTagsDtos)
        {

            return (from t in poatHaveTagsDtos
                    select new TagModel()
                    {
                        Tag_Id = t.Tag_Id,
                        Name = t.Tag_Name
                    });

        }

        public static IEnumerable <PostReadFullDto> ToDto(this IEnumerable<PostModel> posts,IEnumerable<PostHaveTagDto> tags)
        {
            return from p in posts select new PostReadFullDto()
            {
                Body = p.Body,
                Post_Id = p.Post_Id,
                PublishDateTime = p.PublishDateTime,
                Tags = tags.Where(t=>t.Post_Id == p.Post_Id).ToEntities().ToDto(),
                Title = p.Title,
                User = p.User.ToDto(),
                CommentsNumber = p.CommentsNumber
            };
        }

        public static IEnumerable<PostReadMinimulDto> ToMinDto(this IEnumerable<PostModel> posts, IEnumerable<PostHaveTagDto> tags)
        {
            return from p in posts
                   select new PostReadMinimulDto()
                   {
                       User_Id = p.User_Id,
                       Body = p.Body,
                       Post_Id = p.Post_Id,
                       PublishDateTime = p.PublishDateTime,
                       Tags = tags.Where(t => t.Post_Id == p.Post_Id).ToEntities().ToDto(),
                       Title = p.Title,
                       CommentsNumber = p.CommentsNumber
                   };
        }
    }
}
