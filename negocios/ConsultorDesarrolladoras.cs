using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorDesarrolladoras : IConsultor<Desarrolladora>
    {
        public List<Desarrolladora> Consultar()
        {
            var lista = new List<Desarrolladora>();
            return lista;
        }
    }
}
