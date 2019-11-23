using SistemaExpertoProlog_Videojuegos.data;
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

        public ControlCriteriosPersonaje()
        {
            InitializeComponent();

            Personajes = new Stack<Personaje>();
            ContadorPersonajes = 0;

            LlenarComboboxAnio();
            LlenarComboboxGeneros();
            LlenarComboboxDesarrolladoras();
            LlenarComboboxTemas();

            chkAñoDesconocido.Unchecked += (s, e) => { HabilitarComboBox(cbAños, true); };
            chkAñoDesconocido.Checked += (s, e) => { HabilitarComboBox(cbAños, false); };

            chkDesarrolladoraDesconocida.Unchecked += (s, e) => { HabilitarComboBox(cbDesarrolladora, true); };
            chkDesarrolladoraDesconocida.Checked += (s, e) => { HabilitarComboBox(cbDesarrolladora, false); };

            chkGeneroDesconocido.Unchecked += (s, e) => { HabilitarComboBox(cbGenero, true); };
            chkGeneroDesconocido.Checked += (s, e) => { HabilitarComboBox(cbGenero, false); };

            chkTemaDesconocido.Unchecked += (s, e) => { HabilitarComboBox(cbTema, true); };
            chkTemaDesconocido.Checked += (s, e) => { HabilitarComboBox(cbTema, false); };

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

        private void HabilitarComboBox(ComboBox comboBox, bool estado)
        {
            comboBox.IsEnabled = estado;
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
            ucUltimoPersonaje = (DatosPersonaje) spPersonajes.Children[spPersonajes.Children.Count - 1];
        }
    }
}