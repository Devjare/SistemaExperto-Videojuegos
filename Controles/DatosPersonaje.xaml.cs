using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios;
using System.Windows.Controls;

namespace SistemaExpertoProlog_Videojuegos.Controles
{
    /// <summary>
    /// Interaction logic for DatosPersonaje.xaml
    /// </summary>
    public partial class DatosPersonaje : UserControl
    {
        public Personaje DPersonaje { get; private set; }
        public bool IsReady { get; private set; }
        public DatosPersonaje()
        {
            InitializeComponent();

            IsReady = false;

            LlenarComboboxPersonajes();
            LlenarComboboxColores();
            LlenarComboboxGenero();
            LlenarComboboxAtaque();
            LlenarComboboxEspecie();

            cbColor.SelectedIndex = 0;
            cbGenero.SelectedIndex = 0;
            cbPersonajes.SelectedIndex = 0;
            cbAtaque.SelectedIndex = 0;
            cbEspecie.SelectedIndex = 0;

            btnDefinirPersonaje.Click += (s, e) => { DefinirPersonaje(); };

            cbPersonajes.IsEnabled = false;
            
            chkPersonajeConocido.Checked += (s, e) => { HabilitarComboboxPersonaje(true); };
            chkPersonajeConocido.Unchecked += (s, e) => { HabilitarComboboxPersonaje(false); };
        }

        private void LlenarComboboxEspecie()
        {
            var especies = MotorProlog.Consultar("especie(V).");
            cbEspecie.ItemsSource = especies;
        }

        private void LlenarComboboxAtaque()
        {
            var ataques = MotorProlog.Consultar("ataque(V).");
            cbAtaque.ItemsSource = ataques;
        }

        private void LlenarComboboxGenero()
        {
            var colores = MotorProlog.Consultar("sexo(V).");
            cbGenero.ItemsSource = colores;
        }

        private void LlenarComboboxColores()
        {
            var colores = MotorProlog.Consultar("color(V).");
            cbColor.ItemsSource = colores;
        }

        private void LlenarComboboxPersonajes()
        {
            var personajes = MotorProlog.Consultar("personaje(V).");
            cbPersonajes.ItemsSource = personajes;
        }

        private void DefinirPersonaje()
        {
            DPersonaje = new Personaje();

            if (chkPersonajeConocido.IsChecked == true)
            {
                DPersonaje.Nombre = cbPersonajes.SelectedItem.ToString();
            }
            else
            {
                DPersonaje.ColorDistintivo = cbColor.SelectedItem.ToString();
                DPersonaje.Genero = cbGenero.SelectedItem.ToString();
                DPersonaje.Especie = cbEspecie.SelectedItem.ToString();
                DPersonaje.AtaqueEspecial = cbAtaque.SelectedItem.ToString();
            }

            IsReady = true;
        }

        private void HabilitarComboboxPersonaje(bool estado)
        {
            cbPersonajes.IsEnabled = estado;
            cbAtaque.IsEnabled = !estado;
            cbColor.IsEnabled = !estado;
            cbEspecie.IsEnabled = !estado;
            cbGenero.IsEnabled = !estado;
        }
    }
}
