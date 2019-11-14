using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaExpertoProlog_Videojuegos.data;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorPersonajes : IConsultor<Personaje>
    {
        public List<Personaje> Consultar()
        {
            var lista = new List<Personaje>();
            return lista;
        }
    }
}
