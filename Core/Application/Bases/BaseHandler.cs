using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bases
{
    public class BaseHandler
    {
        public readonly Mapper.Mapper.IMapperr mapper;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly string userId;
        public BaseHandler(Mapper.Mapper.IMapperr mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
