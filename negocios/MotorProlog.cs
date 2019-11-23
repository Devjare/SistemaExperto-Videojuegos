using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    class MotorProlog
    {
        private static MotorProlog _instancia;
        public String RutaArchivo { get; set; }
        public static MotorProlog Instancia
        {
            get 
            {
                if (_instancia == null)
                    _instancia = new MotorProlog();

                return _instancia; 
            }
        }


        public bool IniciarProlog()
        {
            try
            {
                if (!PlEngine.IsInitialized)
                {
                    String[] param = { "-q", "-f", RutaArchivo };  // suppressing informational and banner messages
                    PlEngine.Initialize(param);
                }
                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }
        
        public void CerrarProlog()
        {
            if (PlEngine.IsInitialized)
            {
                PlEngine.PlCleanup();                
            }
        }

        internal static List<String> Consultar(string consulta)
        {
            var resultados = new List<String>();

            var query = new PlQuery(consulta);
            var soluciones = query.SolutionVariables;
            foreach (var solucion in soluciones)
            {
                var resultado = solucion["V"].ToString();

                resultados.Add(resultado);
            }

            return resultados;
        }
    }
}
