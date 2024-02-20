using App.Models.Dtos.User.Query;

namespace App.Models.Dtos.Post.Read
{
    public class PostReadFullDto
    {
        public int Post_Id { get; set; }
        public UserReadDto User { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime PublishDateTime { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public int CommentsNumber { get; set; }

    }
}
