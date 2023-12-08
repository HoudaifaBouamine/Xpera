using App.API.Entities;
using App.Models.Dtos.Post;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Query;
using App.Models.Dtos.Post.Read;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace App.API.Extentions.DtosExtentions
{
    public static class PostExtentions
    {
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
            return new Post()
            {
                Post_Id = default,
                Title = postCreate.Title,
                Body = postCreate.Body,
                User_Id = postCreate.User_Id,
                User = null,
                PublishDateTime = DateTime.Now,
            };
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
    }
}
