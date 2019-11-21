using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorDesarrolladoras : Consultor<String>
    {
        public override List<String> Consultar(params object[] args)
        {
            var lista = new List<String>();
            return lista;
        }

        public override List<String> ConsultarTodos()
        {
            DefinirQuery($"{ Consultas[TipoQuery.DESARROLLADORA] }.");

            var presentador = new PresentadorDesarrolladoras();
            var desarrolladoras = presentador.Procesar(ObtenerResultados());

            return desarrolladoras;
        }

        protected override void DefinirConsultas()
        {
            Consultas = new Dictionary<TipoQuery, string>()
            {
                [TipoQuery.DESARROLLADORA] = $"desarrolladora(X)"
            };
        }

        protected override void DefinirParametros()
        {
            Parametros = new Dictionary<string, object>();
        }

        protected override void GenerarConsulta()
        {
            var query = "";
        }
    }
}
