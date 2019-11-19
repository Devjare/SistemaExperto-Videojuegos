using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios.Util
{
    class ProcesadorEntrada
    {        
        public String Procesar(String entrada)
        {
            string salida;
            
            salida = entrada.Trim();
            salida = salida.ToLower();
            salida = salida.Replace(" ", "_");

            return salida;
        }

    }
}
