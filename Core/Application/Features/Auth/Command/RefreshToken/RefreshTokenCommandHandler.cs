using Mapper.Mapper;
using MediatR;
using Services.Impl.RefreshToken;

namespace Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly IRefreshTokenService refreshTokenService;
        private readonly IMapperr mapper;

        public RefreshTokenCommandHandler(IRefreshTokenService refreshTokenService,IMapperr mapper)
        {
            this.refreshTokenService=refreshTokenService;
            this.mapper = mapper;

        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            RefreshTokenRequestDto requestDto=mapper.Map<RefreshTokenRequestDto,RefreshTokenCommandRequest>(request);
            var result =await  refreshTokenService.RefreshToken(requestDto,cancellationToken);
            RefreshTokenCommandResponse response = mapper.Map<RefreshTokenCommandResponse, RefreshTokenResponseDto>(result);
            return response;

        }
    }
}
