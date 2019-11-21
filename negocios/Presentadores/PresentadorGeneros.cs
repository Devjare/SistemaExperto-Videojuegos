using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbsSW.SwiPlCs;

namespace SistemaExpertoProlog_Videojuegos.negocios.Presentadores
{
    class PresentadorGeneros : Presentador<List<String>>
    {
        public override List<string> Procesar(IEnumerable<PlQueryVariables> variables)
        {
            var listaGeneros = new List<String>();

            foreach (var v in variables)
            {
                var genero = v["X"].ToString();
                listaGeneros.Add(genero);
            }

            return listaGeneros;
        }
    }
}
