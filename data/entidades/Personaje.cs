using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data
{
    class Personaje : IEntitdad
    {
        public String Imagen { get; set; }
        public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
