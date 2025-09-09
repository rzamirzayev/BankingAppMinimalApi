using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.Register
{
    public interface IRegisterService
    {
        public Task Register(RegisterDto registerDto);
    }
}
