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
        
        
        // Done
        public async Task<PostReadMinimulDto?> PostCreateAsync(PostCreateDto postToCreate)
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

        public Task<bool> PostDeleteAsync(int postToDelete_id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserDeleteAsync(int UserToDelete_id)
        {
            bool deleted = await _userRepository.UserDelete(UserToDelete_id);

            return deleted;
        }

        // Done
        public async Task<UserReadDto?> UserRegisterAsync(UserCreateDto userToCreate)
        {
            User? user = await _userRepository.UserRead(userToCreate.Email);

            if(user != null)
            {
                return null;
            }

            User? createdUser = await _userRepository.UserCreate(userToCreate.ToEntity());

            if(createdUser == null)
            {
                return null;
            }

            return createdUser.ToDto();
        }

        public Task<PostReadMinimulDto?> PostUpdateAsync(PostUpdateDto postToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<PostReadMinimulDto?> UserUpdateAsync(UserUpdateDto userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
