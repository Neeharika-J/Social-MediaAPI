using System.ComponentModel.DataAnnotations;

namespace SMApi.DTO
{
    public class UserCreateDTO
    {
        [Required]
        public string? userName { get;set;}
        [Required,EmailAddress]
        public string? email { get;set;}
        public string? phone { get;set;}
        [Required]
        public string? dob {  get;set;}
        public string? gender {  get;set;}   
        public int age { get;set;}
        public string password { get;set;}
       
    }
}
