using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.Models
{
    public class LikeComments
    {
        [Key]
        public int likeCommentId { get; set; }
        public DateTime createdAt { get; set; }

        public int commentId { get; set; }
        public Comments comments { get; set; }

        public int userId { get; set; }
        public SMUser? sMUsers { get; set; }
    }
}
