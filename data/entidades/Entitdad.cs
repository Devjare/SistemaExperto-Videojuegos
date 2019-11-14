using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.data
{
    interface IEntitdad
    {
        string Nombre { get; set; }
        string Descripcion { get; set; }
    }
}
