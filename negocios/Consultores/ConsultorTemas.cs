using SistemaExpertoProlog_Videojuegos.negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios.Consultores
{
    class ConsultorTemas : Consultor<String>
    {
        public override List<string> Consultar(params object[] args)
        {
            GenerarConsulta();
            return null;
        }

        public override List<string> ConsultarTodos()
        {
            DefinirQuery($"{ Consultas[TipoQuery.TEMA] }.");

            var presentador = new PresentadorTemas();
            var listaTemas = presentador.Procesar(ObtenerResultados());

            return listaTemas;
        }

        protected override void DefinirConsultas()
        {
            Consultas = new Dictionary<TipoQuery, string>()
            {
                [TipoQuery.TEMA] = $"tema(X)"
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
