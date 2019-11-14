using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data
{
    class Desarrolladora : IEntitdad
    {
        public String Nombre { get; set; }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Videojuego> Videojuegos { get; set; }
    }
}
