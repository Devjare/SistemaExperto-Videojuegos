using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data
{
    public class Desarrolladora : IEntitdad
    {
        public String Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Videojuego> Videojuegos { get; set; }
    }
}
