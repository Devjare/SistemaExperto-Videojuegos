using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbsSW.SwiPlCs;

namespace SistemaExpertoProlog_Videojuegos.negocios.Presentadores
{
    class PresentadorDesarrolladoras : Presentador<List<String>>
    {
        public override List<string> Procesar(IEnumerable<PlQueryVariables> variables)
        {
            var listaDesarrolladoras = new List<String>();

            foreach (var v in variables)
            {
                var desarrolladora = v["X"].ToString();
                listaDesarrolladoras.Add(desarrolladora);
            }

            return listaDesarrolladoras;
        }
    }
}
