using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaExpertoProlog_Videojuegos.data;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorVideojuegos : Consultor<Videojuego>
    {
        public override List<Videojuego> Consultar(params object[] args)
        {
            var lista = new List<Videojuego>();
            return lista;
        }

        public override List<Videojuego> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        protected override void DefinirConsultas()
        {
            throw new NotImplementedException();
        }

        protected override void DefinirParametros()
        {
            throw new NotImplementedException();
        }

        protected override void GenerarConsulta()
        {
            throw new NotImplementedException();
        }
    }
}
