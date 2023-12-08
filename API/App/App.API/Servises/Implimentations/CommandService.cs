using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.Interfaces;
using App.API.Servises.Interfaces;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;

namespace App.API.Servises.Implimentations
{
    public class CommandService : ICommandService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public CommandService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        public async Task<PostReadMinimulDto?> CreatePost(PostCreateDto postToCreate)
        {
            Post post = postToCreate.ToEntity();
            IEnumerable<Tag> tags = await _postRepository.GetTagsByIds(  postToCreate.Tags_Ids );

            post.PublishDateTime = DateTime.Now;

            Post? newPost = await _postRepository.Create(post,tags);

            if(newPost == null)
            {
                return null;
            }

            return newPost.ToDto(tags);
        }

        public Task<bool> DeletePost(int postToDelete_id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int UserToDelete_id)
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDto?> SignInUser(UserCreateDto userToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<PostReadMinimulDto?> UpdatePost(PostUpdateDto postToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<PostReadMinimulDto?> UpdateUser(UserUpdateDto userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
