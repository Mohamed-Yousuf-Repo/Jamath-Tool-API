namespace Administration.Domain.Models.ResponseModels
{
    public class LoginResponseModel
    {
        public string Token { get; set; } = null!;
        public string TokenType { get; set; } = null!;
        public int ExpiresInSeconds { get; set; }
    }
}
