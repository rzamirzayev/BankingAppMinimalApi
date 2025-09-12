using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.RefreshToken
{
    public interface IRefreshTokenService
    {
        public Task<RefreshTokenResponseDto> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto,CancellationToken cancellationToken);
    }
}
