namespace SportActivityAPI.Service.Models.Requests
{
    public class RefreshUserTokenRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string RefreshToken { get; set; }
    }
}
