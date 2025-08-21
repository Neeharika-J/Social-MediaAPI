using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.Models
{
    public class Comments
    {
        [Key]
        public int commentId { get; set; }
        public string? commentText { get; set; }
        public DateTime createdAt { get; set; } 

        public int userId { get; set; }
        public SMUser? smusers { get; set; }  
        
        public int postId { get; set; }
        public Posts? post { get; set; }

        public ICollection<LikeComments> likeComments { get; set; } 
    }
}
