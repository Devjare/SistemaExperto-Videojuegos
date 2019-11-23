using SistemaExpertoProlog_Videojuegos.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaExpertoProlog_Videojuegos.Controles
{
    /// <summary>
    /// Interaction logic for TarjetaVideojuego.xaml
    /// </summary>
    public partial class TarjetaVideojuego : UserControl
    {

        private int Posicion { get; set; }
        private List<Videojuego> _videojuegos;

        public List<Videojuego> Videojuegos
        {
            get { return _videojuegos; }
            set 
            { 
                _videojuegos = value;
                MostrarDatos();
            }
        }

        public TarjetaVideojuego()
        {
            InitializeComponent();
            Posicion = 0;
        }

        private void MostrarDatos()
        {
            var actual = Videojuegos[0];

            if (actual.Nombre == null) tbNombre.Text = "Nombre no encontrado.";
            else
            {
                tbNombre.Text = actual.Nombre;
                var llave = actual.Nombre.Substring(1, actual.Nombre.Length - 2);
                iImagen.Source = Sesion.Instancia.ObtenerImagen(llave);
            }

            if (actual.Genero == null) tbGenero.Text = "Genero no encontrado.";
            else tbGenero.Text = "Genero: " + actual.Genero.ToString();

            if (actual.Tematica == null) tbTematica.Text = "Tema no encontrado.";
            else tbTematica.Text = "Tema: " + actual.Tematica.ToString();

            if (actual.Lanzamiento == null) tbFechaLanzamiento.Text = "Fecha lanzamiento no encontrada.";
            else tbFechaLanzamiento.Text = "Lanzamiento: " + actual.Lanzamiento.ToString();

            if (actual.Desarrolladora == null) tbDesarrolladora.Text = "Desarrolladora no encontrada.";
            else tbDesarrolladora.Text = "Desarrolladora: " + actual.Desarrolladora.ToString();

            if (actual.Descripcion == null) tbDescripcion.Text = "Descripcion no encontrada.";
            else tbDescripcion.Text = "Descripcion: " + actual.Descripcion.ToString();
        }

        internal void SiguienteVideojuego()
        {
            if (Posicion < Videojuegos.Count - 1)
            {
                var siguiente = Videojuegos[++Posicion];

                if (siguiente.Nombre == null) tbNombre.Text = "Nombre no encontrado.";
                else
                {
                    tbNombre.Text = siguiente.Nombre; 
                    var llave = siguiente.Nombre.Substring(1, siguiente.Nombre.Length - 2);
                    iImagen.Source = Sesion.Instancia.ObtenerImagen(llave);
                }

                if (siguiente.Genero == null) tbGenero.Text = "Genero no encontrado.";
                else tbGenero.Text = "Genero: " + siguiente.Genero.ToString();

                if (siguiente.Tematica == null) tbTematica.Text = "Tema no encontrado.";
                else tbTematica.Text = "Tema: " + siguiente.Tematica.ToString();

                if (siguiente.Lanzamiento == null) tbFechaLanzamiento.Text = "Fecha lanzamiento no encontrada.";
                else tbFechaLanzamiento.Text = "Lanzamiento: " + siguiente.Lanzamiento.ToString();

                if (siguiente.Desarrolladora == null) tbDesarrolladora.Text = "Desarrolladora no encontrada.";
                else tbDesarrolladora.Text = "Desarrolladora: " + siguiente.Desarrolladora.ToString();

                if (siguiente.Descripcion == null) tbDescripcion.Text = "Descripcion no encontrada.";
                else tbDescripcion.Text = "Descripcion: " + siguiente.Descripcion.ToString();
            }
            else
            {
                return;
            }
        }

        internal void VideojuegoAnterior()
        {
            if (Posicion > 0)
            {
                var anterior = Videojuegos[--Posicion];

                if (anterior.Nombre == null) tbNombre.Text = "Nombre no encontrado.";
                else
                {
                    tbNombre.Text = anterior.Nombre;
                    var llave = anterior.Nombre.Substring(1, anterior.Nombre.Length - 2);
                    iImagen.Source = Sesion.Instancia.ObtenerImagen(llave);
                }

                if (anterior.Genero == null) tbGenero.Text = "Genero no encontrado.";
                else tbGenero.Text = "Genero: " + anterior.Genero.ToString();

                if (anterior.Tematica == null) tbTematica.Text = "Tema no encontrado.";
                else tbTematica.Text = "Tema: " + anterior.Tematica.ToString();

                if (anterior.Lanzamiento == null) tbFechaLanzamiento.Text = "Fecha lanzamiento no encontrada.";
                else tbFechaLanzamiento.Text = "Lanzamiento: " + anterior.Lanzamiento.ToString();

                if (anterior.Desarrolladora == null) tbDesarrolladora.Text = "Desarrolladora no encontrada.";
                else tbDesarrolladora.Text = "Desarrolladora: " + anterior.Desarrolladora.ToString();

                if (anterior.Descripcion == null) tbDescripcion.Text = "Descripcion no encontrada.";
                else tbDescripcion.Text = "Descripcion: " + anterior.Descripcion.ToString();
            }
            else
            {
                return;
            }
        }
    }
}
