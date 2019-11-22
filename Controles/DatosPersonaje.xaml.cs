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

namespace SistemaExpertoProlog_Videojuegos.Controles
{
    /// <summary>
    /// Interaction logic for DatosPersonaje.xaml
    /// </summary>
    public partial class DatosPersonaje : UserControl
    {
        private Personaje DPersonaje { get; set; }

        public DatosPersonaje()
        {
            InitializeComponent();

            LlenarComboboxPersonajes();
            LlenarComboboxColores();
            LlenarComboboxGenero();
            LlenarComboboxAtaque();
            LlenarComboboxEspecie();

            btnDefinirPersonaje.Click += (s, e) => { DefinirPersonaje(); };

            cbPersonajes.IsEnabled = false;
            
            chkPersonajeConocido.Checked += (s, e) => { HabilitarComboboxPersonaje(true); };
            chkPersonajeConocido.Unchecked += (s, e) => { HabilitarComboboxPersonaje(false); };
        }

        private void LlenarComboboxEspecie()
        {
            throw new NotImplementedException();
        }

        private void LlenarComboboxAtaque()
        {
            throw new NotImplementedException();
        }

        private void LlenarComboboxGenero()
        {
            throw new NotImplementedException();
        }

        private void LlenarComboboxColores()
        {
            throw new NotImplementedException();
        }

        private void HabilitarComboboxPersonaje(bool estado)
        {
            cbPersonajes.IsEnabled = estado;
            cbAtaque.IsEnabled = !estado;
            cbColor.IsEnabled = !estado;
            cbEspecie.IsEnabled = !estado;
            cbGenero.IsEnabled = !estado;
        }

        private void LlenarComboboxPersonajes()
        {
            var consultor = new ConsultorPersonajes();
            var personajes = consultor.ConsultarTodos();

            var nombresPersonajes = new List<String>();

            foreach (var p in personajes)
            {
                nombresPersonajes.Add(p.Nombre);
            }

            cbPersonajes.ItemsSource = nombresPersonajes;
        }

        private void DefinirPersonaje()
        {
            DPersonaje.ColorDistintivo = cbColor.SelectedItem.ToString();
            DPersonaje.Genero = cbGenero.SelectedItem.ToString();
            DPersonaje.Especie = cbEspecie.SelectedItem.ToString();
            DPersonaje.AtaqueEspecial = cbAtaque.SelectedItem.ToString();
        }
    }
}
