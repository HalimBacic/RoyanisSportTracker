namespace SportActivityAPI.Service.Models.Requests
{
    public class UserRequest
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
