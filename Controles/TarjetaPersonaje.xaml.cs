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
    /// Interaction logic for TarjetaPersonaje.xaml
    /// </summary>
    public partial class TarjetaPersonaje : UserControl
    {
        private int Posicion { get; set; }

        public List<Personaje> Personajes { get; set; }

        public TarjetaPersonaje()
        {
            InitializeComponent();
            Personajes = new List<Personaje>();
            var personajeBase = new Personaje()
            {
                Nombre = "El personaje",
                Videojuegos = new List<Videojuego>()
                {
                    new Videojuego(){ Nombre = "El videojuego I"},
                    new Videojuego(){ Nombre = "El videojuego  II"}
                },
                Descripcion = "La descripcion",
                Imagen = "base_jpg"
            };
            Personajes.Add(personajeBase);
            Posicion = 0;

            tbNombre.Text = Personajes[Posicion].Nombre;
            tbVideojuegos.Text += Personajes[Posicion].Videojuegos.ToString();
            tbDescripcion.Text += Personajes[Posicion].Descripcion.ToString();

            var currentDir = Environment.CurrentDirectory;
            var uri = $"{currentDir}/../../Recursos/Imagenes/{Personajes[Posicion].Imagen.ToString()}.jpg";
            iImagen.Source = new BitmapImage(new Uri(uri));
        }
        
        internal void SiguientePersonaje()
        {
            if (Posicion < Personajes.Count - 1)
            {
                var siguientePersonaje = Personajes[++Posicion];
                if (siguientePersonaje.Nombre == null) tbNombre.Text = "Nombre no encontrado.";
                else tbNombre.Text = siguientePersonaje.Nombre;

                if (siguientePersonaje.Videojuegos == null) tbVideojuegos.Text = "Videojuegos no encontrados.";
                else tbVideojuegos.Text = "Videojuegos: " + siguientePersonaje.Videojuegos.ToString();

                if (siguientePersonaje.Descripcion == null) tbDescripcion.Text = "Descripcion no encontrada.";
                else tbDescripcion.Text = "Descripcion: " + siguientePersonaje.Descripcion.ToString();
            }
            else
            {
                return;
            }
        }

        internal void PersonajeAnterior()
        {
            if (Posicion > 0)
            {
                var personajeAnterior = Personajes[--Posicion];
                if (personajeAnterior.Nombre == null) tbNombre.Text = "Nombre no encontrado.";
                else tbNombre.Text = personajeAnterior.Nombre;

                if (personajeAnterior.Videojuegos == null) tbVideojuegos.Text = "Videojuegos no encontrados.";
                else tbVideojuegos.Text = "Videojuegos: " + personajeAnterior.Videojuegos.ToString();

                if (personajeAnterior.Descripcion == null) tbDescripcion.Text = "Descripcion no encontrada.";
                else tbDescripcion.Text = "Descripcion: " + personajeAnterior.Descripcion.ToString();
            }
            else
            {
                return;
            }
        }
    }
}
