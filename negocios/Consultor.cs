using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.negocios.Util;
using System;
using System.Collections.Generic;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    abstract class Consultor<T>
    {
        protected PlQuery Query { get; set; }
        protected Dictionary<TipoQuery, string> Consultas;
        protected Dictionary<string, object> Parametros;
        protected ProcesadorEntrada Procesador;

        public Consultor()
        {
            DefinirConsultas();
            DefinirParametros();
            Procesador = new ProcesadorEntrada();
        }
        public abstract List<T> Consultar(params object[] args);
        protected void DefinirQuery(String query)
        {
            Query = new PlQuery(query);
        }

        protected abstract void DefinirConsultas();
        protected abstract void DefinirParametros();
        protected abstract void GenerarConsulta();
        protected IEnumerable<PlQueryVariables> ObtenerResultados()
        {
            return Query.SolutionVariables;
        }
    }
}
