using App.API.Entities;
using App.Models.Dtos.Post;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace App.API.Extentions.DtosExtentions
{
    public static class PostExtentions
    {
        public static PostReadDto ToDto(this Post post,User user, List<Tag> tags)
        {
            return new PostReadDto()
            {
                Body = post.Body,
                PublishDateTime = post.PublishDateTime,
                Post_Id = post.Post_Id,
                Title = post.Title,
                User = user.ToDto(),
                Tags = tags.ToDto(),
            };
        }

        public static IEnumerable<PostReadDto> ToDtoList(this IEnumerable<Post> posts, User user, List<List<Tag>> tags)
        {
            var postsAsList = posts.ToList();
            var postsAsDto = new List<PostReadDto>();

            for (int i = 0; i < postsAsList.Count(); i++)
            {
                postsAsDto.Add
                (
                    new PostReadDto()
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

        public static List<TagDto> ToDto(this List<Tag> tags) 
        {
            return (from t in tags
                   select new TagDto()
                   {
                       Name = t.Name,
                       Tag_Id = t.Tag_Id
                   }).ToList();
        }
    }
}
