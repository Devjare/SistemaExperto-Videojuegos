using SistemaExpertoProlog_Videojuegos.data.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data
{
    public class Videojuego
    {
        public String Lanzamiento { get; set; }
        public String Descripcion { get; set; }
        public String Genero { get; set; }
        public String Tematica { get; set; }
        public String Desarrolladora { get; set; }
        public List<Personaje> Personajes { get; set; }
        public string Nombre { get; set; }
    }
}
