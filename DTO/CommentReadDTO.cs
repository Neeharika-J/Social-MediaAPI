using SMApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.DTO
{
    public class CommentReadDTO
    {
        public int commentId { get; set; }
        public string? commentText { get; set; }
        public DateTime createdAt { get; set; }
        public int userId { get; set; }
        public int postId { get; set; }
    }
}
