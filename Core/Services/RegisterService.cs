using Domain.Entities;
using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Services.Bases;
using Services.Impl.Register;

namespace Services
{
    public class RegisterService :BaseHandler, IRegisterService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterService(UserManager<User> userManager,RoleManager<Role> roleManager,IHttpContextAccessor httpContextAccessor, IMapperr mapperr) : base(httpContextAccessor, mapperr)
        {
            this.userManager=userManager;
            this.roleManager= roleManager;
        }

        public async Task Register(RegisterDto registerDto)
        {

            User user = mapper.Map<User, RegisterDto>(registerDto);
            user.UserName = registerDto.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName = "user",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
