namespace SportActivityAPI.Service.Models.Requests
{
    public class UserRequest
    {
        public int? Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? Email { get; set; }
    }
}