using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios.Presentadores
{
    class PresentadorListaPersonajes : Presentador<List<Personaje>>
    {
        public override List<Personaje> Procesar(IEnumerable<PlQueryVariables> variables)
        {
            var listaPersonajes = new List<Personaje>();

            foreach (var v in variables)
            {
                var personaje = v["X"].ToString();
                listaPersonajes.Add(new Personaje()
                {
                    Nombre = personaje
                });
            }

            return listaPersonajes;
        }
    }
}
