namespace SMApi.DTO
{
    public class AuthResponseDTO
    {
        public UserReadDTO userReadDTO { get; set; }
        public string token { get; set; }
        public DateTime expiry { get; set; }
        public string message { get; set; }
    }
}
