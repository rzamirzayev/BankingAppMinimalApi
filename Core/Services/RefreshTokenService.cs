using Domain.Entities;
using Infrastructure.Tokens;
using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Services.Bases;
using Services.Exceptions;
using Services.Impl.RefreshToken;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RefreshTokenService :BaseHandler, IRefreshTokenService
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;

        public RefreshTokenService(UserManager<User> userManager,ITokenService tokenService,IHttpContextAccessor httpContextAccessor, IMapperr mapper) : base(httpContextAccessor, mapper)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenResponseDto> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(refreshTokenRequestDto.AccessToken);
            string email=principal.FindFirstValue(ClaimTypes.Email);

            User? user=await userManager.FindByEmailAsync(email);
            IList<string> roles= await userManager.GetRolesAsync(user);

            if (user.RefreshTokenExpiryTime > DateTime.UtcNow)
            {
                JwtSecurityToken newAccessToken= await tokenService.CreateToken(user, roles);
                string newRefreshToken = tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                string _token=new JwtSecurityTokenHandler().WriteToken(newAccessToken);
                await userManager.SetAuthenticationTokenAsync(user,"Default", "AccessToken", _token);

                await userManager.UpdateAsync(user);
                return new()
                {
                    AccessToken=new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                    RefreshToken = newRefreshToken,
                };

            }
            else
            {
                 throw new RefreshTokenExpiredException();
            }

        }
    }
}
