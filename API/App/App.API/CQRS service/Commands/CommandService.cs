using App.API.Entities;
using App.API.Extentions.DtosExtentions;
using App.API.Repositories.PostRepository;
using App.API.Repositories.UserRepository;
using App.API.Services.Interfaces;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;

namespace App.API.Servises.Implimentations
{
    public class CommandService(IPostRepository postRepository, IUserRepository userRepository) : ICommandService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPostRepository _postRepository = postRepository;


        #region User Commands
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
        public Task<PostReadMinimulDto?> UserUpdateAsync(UserUpdateDto userToUpdate)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UserDeleteAsync(int UserToDelete_id)
        {
            bool deleted = await _userRepository.UserDelete(UserToDelete_id);

            return deleted;
        }

        #endregion

        #region Post Commands
        public async Task<PostReadMinimulDto?> PostCreateAsync(PostCreateDto postToCreate)
        {
            Post post = postToCreate.ToEntity();
            IEnumerable<Tag> tags = await _postRepository.TagsByIdsAsync(  postToCreate.Tags_Ids );

            post.PublishDateTime = DateTime.Now;

            Post? newPost = await _postRepository.PostCreateAsync(post,tags);

            if(newPost == null)
            {
                return null;
            }

            return newPost.ToDto(tags);
        }
        public Task<PostReadMinimulDto?> PostUpdateAsync(PostUpdateDto postToUpdate)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> PostDeleteAsync(int postToDelete_id)
        {
            return await _postRepository.PostDeleteAsync(postToDelete_id);
        }

        #endregion

    }
}
