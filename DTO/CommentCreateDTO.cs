using SMApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.DTO
{
    public class CommentCreateDTO
    {
        public string? commentText { get; set; }
        public int userId { get; set; }
        public int postId { get; set; }
    }
}
