using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMApi.Models
{
    public class UserSecurity
    {
        [Key]
        [ForeignKey("sMUser")]
        public int userId { get; set; }
        public SMUser? sMUser { get; set; }
        public string? password {  get; set; }
        public string? verificationToken { get; set; }
        public DateTime? tokenExpiry { get; set; }
    }
}
