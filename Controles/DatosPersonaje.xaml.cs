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
    /// Interaction logic for DatosPersonaje.xaml
    /// </summary>
    public partial class DatosPersonaje : UserControl
    {
        private Personaje DPersonaje { get; set; }

        public DatosPersonaje()
        {
            InitializeComponent();

            btnDefinirPersonaje.Click += (s, e) => { DefinirPersonaje(); };
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
