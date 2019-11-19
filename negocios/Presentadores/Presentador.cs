using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios.Presentadores
{
    abstract class Presentador<T>
    {
        public abstract T Procesar(IEnumerable<PlQueryVariables> variables);
    }
}
