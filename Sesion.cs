﻿using SistemaExpertoProlog_Videojuegos.negocios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SistemaExpertoProlog_Videojuegos
{
    class Sesion
    {
        private static Sesion _instancia;

        private Dictionary<String, ImageSource> Imagenes;
        private String rutaPadre;

        public static Sesion Instancia
        {
            get {
                if (_instancia == null)
                {
                    _instancia = new Sesion();
                }
                return _instancia; 
            }
        }

        public Sesion() 
        {
            // CAMBIAR
            rutaPadre = "C:/Users/jandr/Dropbox/Septimo Semestre/Programacion Logica y Funcional/Unidad IV/Proyecto Final/Recursos/Imagenes";

            Imagenes = new Dictionary<string, ImageSource>();

            var nombres = MotorProlog.Consultar("videojuego(V).");
            nombres.ForEach(nombre =>
            {
                AgregarImagen(nombre, $"{ rutaPadre }/{ nombre }.jpg");
            });
        }

        private void AgregarImagen(string llave, string dir)
        {
            ImageSource imagen = new BitmapImage(new Uri(dir));
            Imagenes[llave] = imagen;
        }

        public ImageSource ObtenerImagen(string llave)
        {
            return Imagenes[llave];
        }
    }
}
