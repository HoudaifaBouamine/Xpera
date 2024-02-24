namespace App.Models.Dtos.Post.Read
{
    public class PostReadMinimulDto
    {
        public int Post_Id { get; set; }
        public Guid User_Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime PublishDateTime { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();
        public int CommentsNumber { get; set; }
    
    }
}
