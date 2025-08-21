using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.Models
{
    public class Posts
    {
        [Key]
        public int postId { get; set; }
        public string? content { get; set; } 
        public DateTime createdAt { get; set; }


        public int userId { get; set; }
        public SMUser? sMUsers {  get; set; }
        public ICollection<Comments> comments { get; set; }
        public ICollection<LikePosts> likePosts { get; set; } 
        
    }
}
