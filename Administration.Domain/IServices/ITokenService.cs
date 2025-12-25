using Administration.Domain.Models.DTOs;

namespace Administration.Domain.IServices
{
    public interface ITokenService
    {
        string GenerateToken(UserModel user);
    }
}
