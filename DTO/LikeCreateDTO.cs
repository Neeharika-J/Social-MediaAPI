using SMApi.Models;

namespace SMApi.DTO
{
    public class LikeCreateDTO
    {
        public int likePostId { get; set; }
        public int postId { get; set; }
        public int likeCommentId { get; set; }
        public int commentId { get; set; }
        public int userId { get; set; }
    }
}
