
using App.API.Extentions.DtosExtentions;
using App.API.Models;
using App.API.Models.Post_Models.Comment_Models;
using App.API.Models.PostModels;
using App.API.Repositories.Comment;
using App.API.Repositories.PostRepository;
using App.API.Repositories.UserRepository;
using App.API.Services.Interfaces;
using App.Models.Dtos.Comment;
using App.Models.Dtos.Post.Create;
using App.Models.Dtos.Post.Read;
using App.Models.Dtos.User.Command;
using App.Models.Dtos.User.Query;

namespace App.API.Servises.Implimentations
{
    public class CommandService(IPostRepository postRepository, IUserRepository userRepository,ICommentRepository commentRepository) : ICommandService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IPostRepository _postRepository = postRepository;


        #region User Commands
        public async Task<UserReadDto?> UserRegisterAsync(UserCreateDto userToCreate)
        {
            UserModel? user = await _userRepository.UserRead(userToCreate.Email);

            if(user != null)
            {
                return null;
            }


            UserModel? createdUser = await _userRepository.UserCreate(userToCreate.ToEntity());

            if(createdUser == null)
            {
                return null;
            }

            return createdUser.ToDto();
        }

        #endregion

        #region Post Commands
        public async Task<PostReadMinimulDto?> PostCreateAsync(PostCreateDto postToCreate)
        {
            PostModel post = postToCreate.ToEntity();
            IEnumerable<TagModel> tags = await _postRepository.TagsByIdsAsync( postToCreate.Tags_Ids );

            post.PublishDateTime = DateTime.Now;

            PostModel? newPost = await _postRepository.PostCreateAsync(post,tags);

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
            await _postRepository.PostDeleteAsync(postToDelete_id);
            return true;
        }

        public async Task<bool> UserUpdateAsync(UserUpdateDto userToUpdate)
        {
            UserModel? user = await _userRepository.UserRead(userToUpdate.User_Id);
            if (user == null)
            {
                return false;
            }

            user = userToUpdate.ToEntity(user);

            if (user == null)
            {
                return false;
            }

            await _userRepository.UserUpdate(user);

            return true;
        }

        public async Task UserDeleteAsync(int UserToDelete_id)
        {
            await _userRepository.UserDelete(UserToDelete_id);
        }


        #endregion


        #region Comment

        public async Task<CommentMinReadDto> CreateCommentAsync(CommentCreateDto comment)
        {
            CommentModel? createdComment = await _commentRepository.CreateCommentAsync(comment.ToEntity());

            return createdComment.ToMinDto();
        }

        #endregion

    }
}
