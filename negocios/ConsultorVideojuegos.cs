using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaExpertoProlog_Videojuegos.data;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorVideojuegos : IConsultor<Videojuego>
    {
        public List<Videojuego> Consultar()
        {
            var lista = new List<Videojuego>();
            return lista;
        }
    }
}
