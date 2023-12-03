using App.API.Entities;

namespace App.API.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post?> Create(Post post,List<Tag> tags);

        public Task<Post?> Read(int id);

        public Task<List<Tag>> ReadPostTags(int id);

    }
}
