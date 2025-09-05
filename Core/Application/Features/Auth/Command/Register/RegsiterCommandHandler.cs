using Application.Bases;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Command.Register
{
    public class RegsiterCommandHandler :BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public RegsiterCommandHandler(Mapper.Mapper.IMapperr mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            this.userManager = userManager;

            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {

            User user = mapper.Map<User, RegisterCommandRequest>(request);

            user.UserName = request.Email;

            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
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
            return Unit.Value;

        }
    }
}
