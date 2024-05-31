namespace SportActivityAPI.Service.Interfaces
{
    public interface IAuthService
    {
        public string GenerateToken(string email, string username);
        public string GenerateRefreshToken();
    }
}
