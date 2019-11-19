using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios.Presentadores;
using SistemaExpertoProlog_Videojuegos.negocios.Util;

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
            switch (args.Length)
            {
                case 1:
                    Parametros[EDAD] = Int32.Parse(args[0].ToString());                    
                    break;
                case 2:
                    Parametros[EDAD] = Int32.Parse(args[0].ToString());
                    Parametros[COLOR_CABELLO] = Procesador.Procesar(args[1].ToString());
                    break;
                case 3:
                    Parametros[EDAD] = Int32.Parse(args[0].ToString());
                    Parametros[COLOR_CABELLO] = Procesador.Procesar(args[1].ToString());
                    Parametros[COLOR_OJOS] = Procesador.Procesar(args[2].ToString());
                    break;
            }

            
            GenerarConsulta();

            var presentador = new PresentadorListaPersonajes();
            var personajes = presentador.Procesar(ObtenerResultados());

            PlEngine.PlCleanup();
            return personajes;
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
