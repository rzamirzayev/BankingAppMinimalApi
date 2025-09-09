using Mapper.Mapper;
using MediatR;
using Services.Impl.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IMapperr mapper;
        private readonly ILoginService loginService;

        public LoginCommandHandler(ILoginService loginService,IMapperr mapper) {
            this.mapper = mapper;
            this.loginService = loginService;
        
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginRequestDto requestDto=mapper.Map<LoginRequestDto, LoginCommandRequest>(request);
            LoginResponseDto responseDto = await  loginService.Login(requestDto,cancellationToken);

            LoginCommandResponse response = mapper.Map<LoginCommandResponse, LoginResponseDto>(responseDto);
            return response;
        }
    }
}
