using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios.Presentadores
{
    class PresentadorPersonaje : Presentador<Personaje>
    {
        public override Personaje Procesar(IEnumerable<PlQueryVariables> variables)
        {
            var personaje = new Personaje();

            // TODO Buscar imagen del personaje y regresarla.
            

            return personaje;
        }
    }
}
