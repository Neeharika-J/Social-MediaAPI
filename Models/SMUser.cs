using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SMApi.Models
{
    public class SMUser
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; }= string.Empty;
        public string phone { get; set; }=string.Empty;
        [DataType(DataType.Date)]
        public DateTime registerDate { get; set; }
        public string dob { get; set; } // format yyyyy-mm-dd
        public string gender { get; set; } = string.Empty;
        public int age { get; set; }

        public UserSecurity? userSecurity { get; set; }
        public ICollection<Posts> posts { get; set; } = new List<Posts>();
        public ICollection<Comments> comments { get; set; }= new List<Comments>();
        public ICollection<LikePosts> likePosts { get; set; }
        public ICollection <LikeComments> likeComments { get; set; }


    }
}
