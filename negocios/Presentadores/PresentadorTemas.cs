using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbsSW.SwiPlCs;

namespace SistemaExpertoProlog_Videojuegos.negocios.Presentadores
{
    class PresentadorTemas : Presentador<List<String>>
    {
        public override List<string> Procesar(IEnumerable<PlQueryVariables> variables)
        {
            var listaTemas = new List<String>();

            foreach (var v in variables)
            {
                var tema = v["X"].ToString();
                listaTemas.Add(tema);
            }

            return listaTemas;
        }
    }
}
