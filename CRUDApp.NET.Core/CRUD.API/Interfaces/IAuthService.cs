using CRUD.Common.DTOs;

namespace CRUD.API.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthenticationResponseDto?> GenerateJwtToken(AuthenticationRequestDto authenticationRequest);
    }
}