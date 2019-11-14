using System.Collections.Generic;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    interface IConsultor<T>
    {
        List<T> Consultar();
    }
}
