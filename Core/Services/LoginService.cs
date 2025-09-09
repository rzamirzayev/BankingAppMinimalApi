using Domain.Entities;
using Infrastructure.Tokens;
using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Bases;
using Services.Impl.Login;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginService : BaseHandler,ILoginService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;

        public LoginService(UserManager<User> userManager,RoleManager<Role> roleManager,IConfiguration configuration,ITokenService tokenService,IHttpContextAccessor httpContextAccessor, IMapperr mapperr) : base(httpContextAccessor, mapperr)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginDto,CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(loginDto.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (checkPassword)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                JwtSecurityToken token=await tokenService.CreateToken(user, roles.ToList());
                string resreshToken=tokenService.GenerateRefreshToken();

                _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                user.RefreshToken=resreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

                await userManager.UpdateAsync(user);
                await userManager.UpdateSecurityStampAsync(user);

                string _token=new JwtSecurityTokenHandler().WriteToken(token);

                await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);
                LoginResponseDto response = new()
                {
                    AccessToken = _token,
                    RefreshToken = resreshToken,
                    Expiration = token.ValidTo
                };
                return response;

            }
            throw new Exception("Email or Password is incorrect");

        }
    }
}
