using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.Models
{
    public class LikePosts
    {
        [Key]
        public int likePostId { get; set; }   
        public DateTime createdAt { get; set; }

        public int postId { get; set; }
        public Posts? posts { get; set; }

        public int userId { get; set; }
        public SMUser? sMUsers { get; set; }
    }
}
