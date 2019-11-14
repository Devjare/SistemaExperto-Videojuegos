using SbsSW.SwiPlCs;
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
                String[] param = { "-q" };  // suppressing informational and banner messages
                var variables = Environment.GetEnvironmentVariables();

                PlEngine.Initialize(param);
                PlQuery.PlCall("assert(father(martin, inka))");
                PlQuery.PlCall("assert(father(uwe, gloria))");
                PlQuery.PlCall("assert(father(uwe, melanie))");
                PlQuery.PlCall("assert(father(uwe, ayala))");
                using (PlQuery q = new PlQuery("father(P, C), atomic_list_concat([P,' is_father_of ',C], L)"))
                {
                    foreach (PlQueryVariables v in q.SolutionVariables)
                        // this.label.Content += "\n\t " + (v["L"].ToString());

                    Console.WriteLine("all child's from uwe:");
                    q.Variables["P"].Unify("uwe");
                    foreach (PlQueryVariables v in q.SolutionVariables)
                        Console.WriteLine(v["C"].ToString());
                }
                PlEngine.PlCleanup();
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
                List<Personaje> personajes = consultor.Consultar();
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
            ActivarControlDeUsuario(ucTarjetaDesarrolladora);
        }

        private void ActualizarTarjetasPersonajes(List<Personaje> personajes)
        {
            ActivarControlDeUsuario(ucTarjetaPersonaje);
        }

        private void ActualizarTarjetasVideojuegos(List<Videojuego> videojuegos)
        {
            ActivarControlDeUsuario(ucTarjetaVideojuego);
        }

        private void ActivarControlDeUsuario(UserControl control)
        {
            ucTarjetaDesarrolladora.Visibility = Visibility.Collapsed;
            ucTarjetaPersonaje.Visibility = Visibility.Collapsed;
            ucTarjetaVideojuego.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }
    }

}
