namespace SMApi.DTO
{
    public class PostReadDTO
    {
        public int postId { get; set; }
        public string content { get; set; }
        public int userId { get; set; }
        public DateTime createdAt { get; set; }

    }
}
