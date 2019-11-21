using SistemaExpertoProlog_Videojuegos.negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios.Consultores
{
    class ConsultorGeneros : Consultor<String>
    {
        public override List<string> Consultar(params object[] args)
        {
            throw new NotImplementedException();
        }

        public override List<string> ConsultarTodos()
        {
            DefinirQuery($"{ Consultas[TipoQuery.GENEROS] }.");

            var presentador = new PresentadorGeneros();
            var listaGeneros = presentador.Procesar(ObtenerResultados());

            return listaGeneros;
        }

        protected override void DefinirConsultas()
        {
            Consultas = new Dictionary<TipoQuery, string>()
            {
                [TipoQuery.GENEROS] = $"genero(X)"
            };
        }

        protected override void DefinirParametros()
        {
            Parametros = new Dictionary<string, object>();
        }

        protected override void GenerarConsulta()
        {
            throw new NotImplementedException();
        }
    }
}
