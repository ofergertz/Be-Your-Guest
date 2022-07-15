using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Infrastructure.Mappers
{
    public interface IMapper<in source, out Tout>
    {
        Tout Map(source source);
    }
}
