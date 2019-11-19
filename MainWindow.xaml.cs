using SbsSW.SwiPlCs;
using SistemaExpertoProlog_Videojuegos.Controles;
using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios;
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

namespace SistemaExpertoProlog_Videojuegos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Hacer esto una enumeracion
        private Int32 VIDEOJUEGOS = 0;
        private Int32 PERSONAJES = 1;
        private Int32 DESARROLLADORA = 2;

        public MainWindow()
        {
            InitializeComponent();

            ActivarControlDeUsuario(ucTarjetaBase);

            if (!PlEngine.IsInitialized)
            {
                var file = "C:/Users/jandr/Dropbox/Septimo Semestre/Programacion Logica y Funcional/Unidad IV/Proyecto Final/base_conocimiento.pl/datos_prueba.pl";
                String[] param = { "-q", "-f", file};  // suppressing informational and banner messages
                // String[] param = { "-q" };
                PlEngine.Initialize(param);
                               
                //using (PlQuery q = new PlQuery("personaje_de(P, C), atomic_list_concat([P,' es_personaje_de ',C], L)"))
                //{
                //    foreach (PlQueryVariables v in q.SolutionVariables)
                //        // MessageBox.Show("\n\t " + (v["L"].ToString()));

                //    //MessageBox.Show("Todos los personajes de Zenith:");
                //    q.Variables["P"].Unify("Zenith");
                //    // foreach (PlQueryVariables v in q.SolutionVariables)
                //        //MessageBox.Show(v["C"].ToString());
                //}
                //PlEngine.PlCleanup();
            }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var opcion = cbOpciones.SelectedIndex;
            if (opcion.Equals(VIDEOJUEGOS))
            {
                var consultor = new ConsultorVideojuegos();
                List<Videojuego> videojuegos = consultor.Consultar();
                ActualizarTarjetasVideojuegos(videojuegos);
            } 
            else if(opcion.Equals(PERSONAJES))
            {
                var consultor = new ConsultorPersonajes();
                // Edad, Color cabello, Color ojos, Estatura
                //
                // edad(X, EDAD), color_cabello(X, COLOR), color_ojos(X, OJOS, mide(X, ESTATURA).
                //
                List<Personaje> personajes = consultor.Consultar("19", "Rubio", "Azules");

                //personajes.Add(new Personaje()
                //{
                //    Nombre = "Ryu",
                //    Descripcion = "Pertenece a Street fighter saga",
                //    Videojuegos = new List<Videojuego>()
                //    {
                //        new Videojuego() { Nombre = "Street Fighter I"},
                //        new Videojuego() { Nombre = "Street Fighter II"},
                //        new Videojuego() { Nombre = "Street Fighter III"},
                //        new Videojuego() { Nombre = "Street Fighter IV"},
                //        new Videojuego() { Nombre = "Super Puzzle Fighter II"}
                //    },
                //    Imagen = "ryu_png"
                //});
                //personajes.Add(new Personaje()
                //{
                //    Nombre = "Ken Masters",
                //    Descripcion = "Pertenece a Street fighter saga Tambien!!",
                //    Videojuegos = new List<Videojuego>()
                //    {
                //        new Videojuego() { Nombre = "Street Fighter I"},
                //        new Videojuego() { Nombre = "Street Fighter II"},
                //        new Videojuego() { Nombre = "Street Fighter III"},
                //        new Videojuego() { Nombre = "Street Fighter IV"},
                //        new Videojuego() { Nombre = "Super Puzzle Fighter II"}
                //    },
                //    Imagen = "ken_masters_jpg"
                //});

                ActualizarTarjetasPersonajes(personajes);
            }
            else
            {
                var consultor = new ConsultorDesarrolladoras();
                List<Desarrolladora> desarrolladoras = consultor.Consultar();
                ActualizarTarjetasDesarrolladoras(desarrolladoras);
            }
        }

        private void ActualizarTarjetasDesarrolladoras(List<Desarrolladora> desarrolladoras)
        {
            ucTarjetaDesarrolladora.Desarrolladoras = desarrolladoras;
            ActivarControlDeUsuario(ucTarjetaDesarrolladora);
        }

        private void ActualizarTarjetasPersonajes(List<Personaje> personajes)
        {
            ucTarjetaPersonaje.Personajes = personajes;
            ActivarControlDeUsuario(ucTarjetaPersonaje);
        }

        private void ActualizarTarjetasVideojuegos(List<Videojuego> videojuegos)
        {
            ucTarjetaVideojuego.Videojuegos = videojuegos;
            ActivarControlDeUsuario(ucTarjetaVideojuego);
        }

        private void ActivarControlDeUsuario(UserControl control)
        {
            ucTarjetaDesarrolladora.Visibility = Visibility.Collapsed;
            ucTarjetaPersonaje.Visibility = Visibility.Collapsed;
            ucTarjetaVideojuego.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }

        // Cambiar a Tarjeta Base
        private UserControl ObtenerTarjetaActiva()
        {
            if (ucTarjetaDesarrolladora.Visibility == Visibility.Visible) return ucTarjetaDesarrolladora;
            else if (ucTarjetaVideojuego.Visibility == Visibility.Visible) return ucTarjetaVideojuego;
            else return ucTarjetaPersonaje;
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            var tarjetaActiva = ObtenerTarjetaActiva();
            if (tarjetaActiva is TarjetaPersonaje)
            {
                PersonajeAnterior(tarjetaActiva as TarjetaPersonaje);
            }
            else if (tarjetaActiva is TarjetaDesarrolladora)
            {
                DesarrolladoraAnterior(tarjetaActiva as TarjetaDesarrolladora);
            }
            else
            {
                VideojuegoAnterior(tarjetaActiva as TarjetaVideojuego);
            }
        }

        private void VideojuegoAnterior(TarjetaVideojuego tarjetaVideojuego)
        {
            throw new NotImplementedException();
        }

        private void DesarrolladoraAnterior(TarjetaDesarrolladora tarjetaDesarrolladora)
        {
            throw new NotImplementedException();
        }

        private void PersonajeAnterior(TarjetaPersonaje tarjetaPersonaje)
        {
            tarjetaPersonaje.PersonajeAnterior();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            var tarjetaActiva = ObtenerTarjetaActiva();
            if (tarjetaActiva is TarjetaPersonaje)
            {
                SiguientePersonaje(tarjetaActiva as TarjetaPersonaje);
            }
            else if (tarjetaActiva is TarjetaDesarrolladora)
            {
                SiguieteDesarrolladora(tarjetaActiva as TarjetaDesarrolladora);
            }
            else
            {
                SiguienteVideojuego(tarjetaActiva as TarjetaVideojuego);
            }
        }

        private void SiguienteVideojuego(TarjetaVideojuego tarjetaVideojuego)
        {
            throw new NotImplementedException();
        }

        private void SiguientePersonaje(TarjetaPersonaje tarjetaPersonaje)
        {
            tarjetaPersonaje.SiguientePersonaje();
        }

        private void SiguieteDesarrolladora(TarjetaDesarrolladora tarjetaDesarrolladora)
        {
            throw new NotImplementedException();
        }

        
    }

}
