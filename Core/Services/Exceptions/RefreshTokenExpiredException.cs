using Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class RefreshTokenExpiredException:BaseException
    {
        public RefreshTokenExpiredException() : base("Refresh token has expired")
        {
        }
    }
}
