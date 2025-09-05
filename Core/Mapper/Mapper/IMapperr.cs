using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Mapper
{
    public interface IMapperr
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);
        IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null);
        TDestination Map<TDestination>(IList<object> source, string? ignore = null);
        IList<TDestination> Map<TDestination>(IList<IList<object>> source, string? ignore = null);
    }
}
