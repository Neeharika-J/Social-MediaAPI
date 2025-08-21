using SMApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SMApi.DTO
{
    public class UserReadDTO
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string dob { get; set; }// format yyyyy-mm-dd
        public string gender { get; set; } = string.Empty;
        public int age { get; set; }
    }
}
