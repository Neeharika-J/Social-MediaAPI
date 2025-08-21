namespace SMApi.Models
{
    public class JwtSettings
    {
        public  string? secretKey { get; set; }
        public string? issuer { get; set; }  
        public string? audience { get; set; }
        public int expiryMinutes {  get; set; } 
    }
}
