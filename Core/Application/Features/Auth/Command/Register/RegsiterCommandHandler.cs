using Domain.Entities;
using Mapper.Mapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Services;
using Services.Impl.Register;

namespace Application.Features.Auth.Command.Register
{
    public class RegsiterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly IRegisterService registerService;
        private readonly IMapperr mapper;

        public RegsiterCommandHandler(IRegisterService registerService,UserManager<User> userManager,RoleManager<Role> roleManager,IMapperr mapperr)
        {
            this.registerService = registerService;
            this.mapper = mapperr;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterDto registerDto = mapper.Map<RegisterDto, RegisterCommandRequest>(request); 
            await registerService.Register(registerDto);
            return Unit.Value;
        }
    }
}
