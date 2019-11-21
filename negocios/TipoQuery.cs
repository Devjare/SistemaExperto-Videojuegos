using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoProlog_Videojuegos.negocios
{
    public enum TipoQuery
    {
        // QUERIES PERSONAJES
        PERSONAJE,
        ES_PERSONAJE_DE,
        TIENE_CABELLO_COLOR,
        TIENE_OJOS_COLOR,
        MIDE,
        ES_AMIGO_DE,
        
        // QUERIES VIDEOJUEGOS
        VIDEOJUEGO,
        DESARROLLADO_POR,

        // QUERIES DESARROLLADORAS
        DESARROLLADORA,
        TIENE_EDAD,
        TEMA,
        GENEROS
    }
}
