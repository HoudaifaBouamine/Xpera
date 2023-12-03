using App.API.Entities;
using App.Models.Dtos.Post;

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
