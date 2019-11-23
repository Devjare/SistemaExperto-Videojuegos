using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data.entidades
{
    public class Personaje
    {
        public String Nombre { get; internal set; }
        public String Genero { get; internal set; }
        public String Especie { get; internal set; }
        public String AtaqueEspecial { get; internal set; }
        public String ColorDistintivo { get; internal set; }
    }
}
