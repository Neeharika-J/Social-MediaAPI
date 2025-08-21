using SMApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SMApi.DTO
{
    public class UserUpdateDTO
    {
        public int userId {  get; set; }    
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
    }
}
