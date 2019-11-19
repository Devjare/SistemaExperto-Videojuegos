using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorDesarrolladoras : Consultor<Desarrolladora>
    {
        public override List<Desarrolladora> Consultar(params object[] args)
        {
            var lista = new List<Desarrolladora>();
            return lista;
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
