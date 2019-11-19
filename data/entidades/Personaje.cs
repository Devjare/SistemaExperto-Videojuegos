using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data
{
    public class Personaje : IEntitdad
    {
        public String Imagen { get; set; }
        public List<Videojuego> Videojuegos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
