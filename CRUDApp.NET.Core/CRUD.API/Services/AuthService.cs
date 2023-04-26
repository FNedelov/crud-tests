using CRUD.API.Interfaces;
using CRUD.Common;
using CRUD.Common.DTOs;
using CRUD.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace CRUD.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _context;
        private readonly CrudappContext _dbContext;

        public AuthService(IConfiguration config, IHttpContextAccessor context, CrudappContext dbContext)
        {
            _config = config;
            _context = context;
            _dbContext = dbContext;
        }

        public async Task<AuthenticationResponseDto?> GenerateJwtToken(AuthenticationRequestDto authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName))
                return default;

            string uid;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                uid = _context.HttpContext?.User?.Identity?.Name ?? WindowsIdentity.GetCurrent()?.Name ?? string.Empty;
            }
            else
                uid = _context.HttpContext?.User?.Identity?.Name ?? string.Empty;

            if (string.IsNullOrEmpty(uid))
                return default;

            UserRoleDto? userAccount = await GetUserAccount(authenticationRequest);
            if (userAccount == null)
                return default;

            DateTime tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Convert.ToDouble(_config["TokenExpiry"] ?? default));
            byte[] tokenKey = Encoding.ASCII.GetBytes(_config["JwtSecurityKey"] ?? string.Empty);
            if (tokenExpiryTimeStamp == default || tokenKey.All(singleByte => singleByte == 0))
                return default;

            ClaimsIdentity claimsIdentity = new(new List<Claim>
            {
                new(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new(ClaimTypes.Role, userAccount.RoleDefinition ?? Constants.UNKNOWN)
            });

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return new AuthenticationResponseDto
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }

        private async Task<UserRoleDto?> GetUserAccount(AuthenticationRequestDto authenticationRequest)
        {
            return await _dbContext.Users.Where(users => users.Status && users.Name == authenticationRequest.UserName)
                            .Join(_dbContext.Roles.Where(roles => roles.Status),
                            users => users.RoleId,
                            roles => roles.RoleId,
                            (users, roles) => new UserRoleDto
                            {
                                UserName = users.Name,
                                RoleDefinition = roles.Definition
                            }).FirstOrDefaultAsync();
        }
    }
}