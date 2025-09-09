using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bases
{
    public class BaseHandler
    {
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly IMapperr mapper;
        public readonly string userId;
        public BaseHandler(IHttpContextAccessor httpContextAccessor,IMapperr mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
