using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.data.entidades;
using SistemaExpertoProlog_Videojuegos.negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SistemaExpertoProlog_Videojuegos.Controles
{
    /// <summary>
    /// Interaction logic for ControlCriteriosPersonaje.xaml
    /// </summary>
    public partial class ControlCriteriosPersonaje : UserControl
    {
        private Stack<Personaje> personajes;

        public Stack<Personaje> Personajes
        {
            get 
            {
                foreach (var children in spPersonajes.Children)
                {
                    var ucDatosPersonaje = children as DatosPersonaje;

                    var personaje = ucDatosPersonaje.DPersonaje;

                    personajes.Push(personaje);
                }

                return personajes; 
            }
            private set { personajes = value; }
        }

        private int ContadorPersonajes;
        DatosPersonaje ucUltimoPersonaje;
        public String Anio { get; private set; }
        public String Desarrolladora { get; private set; }
        public String Genero { get; private set; }
        public String Tema { get; private set; }

        public static String NO_SELECCIONADO = "NO SELECCIONADA";

        private int ContadorCheckboxMarcados;

        public ControlCriteriosPersonaje()
        {
            InitializeComponent();

            Personajes = new Stack<Personaje>();
            ContadorPersonajes = 0;
            ContadorCheckboxMarcados = 0;

            LlenarComboboxAnio();
            LlenarComboboxGeneros();
            LlenarComboboxDesarrolladoras();
            LlenarComboboxTemas();

            chkAñoDesconocido.Unchecked += (s, e) => { HabilitarComboBox(cbAños, true, s); };
            chkAñoDesconocido.Checked += (s, e) => { HabilitarComboBox(cbAños, false, s); };

            chkDesarrolladoraDesconocida.Unchecked += (s, e) => { HabilitarComboBox(cbDesarrolladora, true, s); };
            chkDesarrolladoraDesconocida.Checked += (s, e) => { HabilitarComboBox(cbDesarrolladora, false, s); };

            chkGeneroDesconocido.Unchecked += (s, e) => { HabilitarComboBox(cbGenero, true, s); };
            chkGeneroDesconocido.Checked += (s, e) => { HabilitarComboBox(cbGenero, false, s); };

            chkTemaDesconocido.Unchecked += (s, e) => { HabilitarComboBox(cbTema, true, s); };
            chkTemaDesconocido.Checked += (s, e) => { HabilitarComboBox(cbTema, false, s); };

            btnAgregarPersonaje.Click += (s, e) => { AgregarControlPersonaje(); };
            btnEliminarPersonaje.Click += (s, e) => { EliminarPersonaje(); };

            btnDefinirCriterios.Click += (s, e) => { DefinirCriterios(); };
        }

        private void DefinirCriterios()
        {
            if (chkAñoDesconocido.IsChecked == true) Anio = NO_SELECCIONADO;
            else Anio = cbAños.SelectedItem.ToString();

            if (chkDesarrolladoraDesconocida.IsChecked == true) Desarrolladora = NO_SELECCIONADO;
            else Desarrolladora = cbDesarrolladora.SelectedItem.ToString();

            if (chkGeneroDesconocido.IsChecked == true) Genero = NO_SELECCIONADO;
            else Genero = cbGenero.SelectedItem.ToString();

            if (chkTemaDesconocido.IsChecked == true) Tema = NO_SELECCIONADO;
            else Tema = cbTema.SelectedItem.ToString();
        }

        private void LlenarComboboxTemas()
        {
            var temas = MotorProlog.Consultar("tema(V).");
            
            cbTema.ItemsSource = temas;
            cbTema.SelectedIndex = 0;
        }

        private void LlenarComboboxDesarrolladoras()
        {
            var desarrolladoras = MotorProlog.Consultar("desarrolladora(V).");

            cbDesarrolladora.ItemsSource = desarrolladoras;
            cbDesarrolladora.SelectedIndex = 0;
        }

        private void LlenarComboboxGeneros()
        {
            var generos = MotorProlog.Consultar("genero(V).");

            cbGenero.ItemsSource = generos;
            cbGenero.SelectedIndex = 0;
        }

        private void LlenarComboboxAnio()
        {
            var años = new List<Int32>();

            var añoActual = DateTime.Now.Year;
            var añoPrimerVideojuego = 1958;

            años.AddRange(Enumerable.Range(añoPrimerVideojuego, añoActual - añoPrimerVideojuego + 1));

            cbAños.ItemsSource = años;
            cbAños.SelectedIndex = 0;
        }

        private void HabilitarComboBox(ComboBox comboBox, bool estado, Object s)
        {
            if (ContadorCheckboxMarcados == 3 && estado == false)
            {
                MessageBox.Show("Debe mantener al menos un criterio general!");

                var checkbox = s as CheckBox;
                if (checkbox == chkAñoDesconocido) chkAñoDesconocido.IsChecked = false;
                else if (checkbox == chkDesarrolladoraDesconocida) chkDesarrolladoraDesconocida.IsChecked = false;
                else if (checkbox == chkGeneroDesconocido) chkGeneroDesconocido.IsChecked = false;
                else chkTemaDesconocido.IsChecked = false;

                ContadorCheckboxMarcados++;

                return;
            }

            comboBox.IsEnabled = estado;
            if (comboBox.IsEnabled == false)
            {
                ContadorCheckboxMarcados++;
            }
            else
            {
                ContadorCheckboxMarcados--;
            }
        }
        private void AgregarControlPersonaje()
        {
            if (ContadorPersonajes == 0)
            {
                ucUltimoPersonaje = new DatosPersonaje();
                spPersonajes.Children.Add(ucUltimoPersonaje);
                ContadorPersonajes++;
                return;
            }
            else if (!ucUltimoPersonaje.IsReady)
            {
                MessageBox.Show("Defina el ultimo personaje agregado antes de continuar, por favor.");
                return;
            }

            ucUltimoPersonaje = new DatosPersonaje();
            spPersonajes.Children.Add(ucUltimoPersonaje);
            ContadorPersonajes++;
        }

        private void EliminarPersonaje()
        {
            spPersonajes.Children.Remove(ucUltimoPersonaje);
            ContadorPersonajes--;

            if (spPersonajes.Children.Count == 0)
            {
                ucUltimoPersonaje = null;
            }
            else
            {
                ucUltimoPersonaje = (DatosPersonaje) spPersonajes.Children[spPersonajes.Children.Count - 1];
            }
            
        }
    }
}