using App.API.Entities;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Query;
using App.Models.Dtos.Post.Read;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace App.API.Extentions.DtosExtentions
{
    public static class PostExtentions
    {
        private static IMapper _mapper = null;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }
        public static PostReadFullDto ToDto(this Post post, User user, List<Tag> tags)
        {

            return new PostReadFullDto()
            {
                Body = post.Body,
                PublishDateTime = post.PublishDateTime,
                Post_Id = post.Post_Id,
                Title = post.Title,
                User = user.ToDto(),
                Tags = tags.ToDto(),
            };
        }

        public static IEnumerable<PostReadFullDto> ToDtoList(this IEnumerable<Post> posts, User user, List<List<Tag>> tags)
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
                        User = user.ToDto(),
                        Tags = tags[i].ToDto(),
                    }
                );
            }

            return postsAsDto;
        }

        public static List<TagDto> ToDto(this IEnumerable<Tag> tags)
        {
            return (from t in tags
                    select new TagDto()
                    {
                        Name = t.Name,
                        Tag_Id = t.Tag_Id
                    }).ToList();
        }

        public static Post ToEntity(this PostCreateDto postCreate)
        {
            Post post = _mapper.Map<Post>(postCreate);
            post.User = null;
            post.PublishDateTime = DateTime.Now;

            return post;
        }

        public static List<Tag> ToEntity(this IEnumerable<TagDto> tagsAsDto)
        {
            return (from t in tagsAsDto
                    select new Tag()
                    {
                        Name = t.Name,
                        Tag_Id = t.Tag_Id
                    }).ToList();
        }


        public static PostReadMinimulDto ToDto(this Post post, IEnumerable<Tag> tags)
        {
            return new PostReadMinimulDto()
            {
                Body = post.Body,
                Post_Id = post.Post_Id,
                PublishDateTime = post.PublishDateTime,
                Tags = tags.ToDto(),
                Title = post.Title,
                User_Id = post.User_Id,
            };
        }

        public static PostHaveTagDto ToDto(this PostHaveTag postHaveTag, Tag tag)
        {
            return new PostHaveTagDto()
            {
                Post_Id = postHaveTag.Post_Id,
                Tag_Id = tag.Tag_Id,
                Tag_Name = tag.Name
            };
        }
        public static IEnumerable<Tag> ToEntities(this IEnumerable<PostHaveTagDto> poatHaveTagsDtos)
        {

            return (from t in poatHaveTagsDtos
                    select new Tag()
                    {
                        Tag_Id = t.Tag_Id,
                        Name = t.Tag_Name
                    });

        }

        public static IEnumerable <PostReadFullDto> ToDto(this IEnumerable<Post> posts,IEnumerable<PostHaveTagDto> tags)
        {
            return from p in posts select new PostReadFullDto()
            {
                Body = p.Body,
                Post_Id = p.Post_Id,
                PublishDateTime = p.PublishDateTime,
                Tags = tags.Where(t=>t.Post_Id == p.Post_Id).ToEntities().ToDto(),
                Title = p.Title,
                User = p.User.ToDto()
            };
        }

        public static IEnumerable<PostReadMinimulDto> ToMinDto(this IEnumerable<Post> posts, IEnumerable<PostHaveTagDto> tags)
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
                   };
        }
    }
}
