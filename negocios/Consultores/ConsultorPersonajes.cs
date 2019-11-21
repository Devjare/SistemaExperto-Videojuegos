using System;
using System.Collections.Generic;
using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios.Presentadores;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class ConsultorPersonajes : Consultor<Personaje>
    {
        private readonly string EDAD = "EDAD";
        private readonly string COLOR_CABELLO = "COLOR_CABELLO";
        private readonly string NOMBRE = "NOMBRE";
        private readonly string COLOR_OJOS = "COLOR_OJOS";

        public ConsultorPersonajes() : base()
        {

        }

        public override List<Personaje> Consultar(params object[] args)
        {
            // edad(X, EDAD), color_cabello(X, COLOR), color_ojos(X, OJOS, mide(X, ESTATURA).            

            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0) Parametros[EDAD] = Int32.Parse(args[i].ToString());
                else if (i == 1) Parametros[COLOR_CABELLO] = Procesador.Procesar(args[i].ToString());
                else Parametros[COLOR_OJOS] = Procesador.Procesar(args[i].ToString());
            }

            GenerarConsulta();

            var presentador = new PresentadorListaPersonajes();
            var personajes = presentador.Procesar(ObtenerResultados());
            
            return personajes;
        }

        public override List<Personaje> ConsultarTodos()
        {
            DefinirQuery($"{ Consultas[TipoQuery.PERSONAJE] }.");

            var presentador = new PresentadorListaPersonajes();
            var listaPersonajes = presentador.Procesar(ObtenerResultados());

            return listaPersonajes;
        }

        protected override void DefinirConsultas()
        {
            Consultas = new Dictionary<TipoQuery, string>()
            {
                [TipoQuery.PERSONAJE] = $"personaje(X)",
                [TipoQuery.TIENE_CABELLO_COLOR] = $"color_cabello(X, {COLOR_CABELLO})",
                [TipoQuery.TIENE_OJOS_COLOR] = $"color_ojos(X, {COLOR_OJOS})",
                [TipoQuery.TIENE_EDAD] = $"edad(X, {EDAD})"
            };
        }

        protected override void DefinirParametros()
        {
            Parametros = new Dictionary<string, object>()
            {
                [NOMBRE] = String.Empty,
                [EDAD] = Int32.MinValue,
                [COLOR_CABELLO] = String.Empty,
                [COLOR_OJOS] = String.Empty
            };
        }

        protected override void GenerarConsulta()
        {
            var query = "";

            if (!Parametros[EDAD].Equals(Int32.MinValue))
            {
                query += Consultas[TipoQuery.TIENE_EDAD];
                var edad = Parametros[EDAD].ToString();
                query = query.Replace(EDAD, edad);
            }

            if (!Parametros[COLOR_CABELLO].Equals(String.Empty))
            {
                if (!Parametros[EDAD].Equals(Int32.MinValue))
                    query += $", {Consultas[TipoQuery.TIENE_CABELLO_COLOR]}";
                else
                    query += $"{Consultas[TipoQuery.TIENE_CABELLO_COLOR]}";
                
                var colorCabello = Parametros[COLOR_CABELLO].ToString();
                query = query.Replace(COLOR_CABELLO, colorCabello);
            }

            if (!Parametros[COLOR_OJOS].Equals(String.Empty))
            {
                if (!Parametros[COLOR_CABELLO].Equals(String.Empty))
                    query += $", {Consultas[TipoQuery.TIENE_OJOS_COLOR]}";
                else
                    query += $"{Consultas[TipoQuery.TIENE_OJOS_COLOR]}";

                var colorOjos = Parametros[COLOR_OJOS].ToString();
                query = query.Replace(COLOR_OJOS, colorOjos);
            }

            DefinirQuery($"{query}.");
        }
    }
}
