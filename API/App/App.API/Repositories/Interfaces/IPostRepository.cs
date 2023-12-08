﻿using App.API.Entities;

namespace App.API.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post?> Create(Post post,IEnumerable<Tag> tags);

        public Task<Post?> Read(int id);

        public Task<List<Tag>> ReadPostTags(int id);

        public Task<List<Post>> ReadUserPostsAsync(int user_Id);

        public Task<List<Tag>> GetTagsByIds(IEnumerable<int> tags_ids);
    }
}
