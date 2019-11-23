using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios;
using SistemaExpertoProlog_Videojuegos.negocios.Consultores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace SistemaExpertoProlog_Videojuegos.Controles
{
    /// <summary>
    /// Interaction logic for ControlCriteriosPersonaje.xaml
    /// </summary>
    public partial class ControlCriteriosPersonaje : UserControl
    {
        public Stack<Personaje> Personajes { get; private set; }
        DatosPersonaje ultimoPersonajeAgregado;
        public String Anio { get; private set; }
        public String Desarrolladora { get; private set; }
        public String Genero { get; private set; }
        public String Tema { get; private set; }

        public static String NO_SELECCIONADO = "NO SELECCIONADA";

        public ControlCriteriosPersonaje()
        {
            InitializeComponent();

            Personajes = new Stack<Personaje>();

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

            var consultor = new ConsultorTemas();
            var temas = consultor.ConsultarTodos();

            cbTema.ItemsSource = temas;
            cbTema.SelectedIndex = 0;
        }

        private void LlenarComboboxDesarrolladoras()
        {
            var consultor = new ConsultorDesarrolladoras();
            var desarrolladoras = consultor.ConsultarTodos();

            cbDesarrolladora.ItemsSource = desarrolladoras;
            cbDesarrolladora.SelectedIndex = 0;
        }

        private void LlenarComboboxGeneros()
        {
            var consultor = new ConsultorGeneros();
            var generos = consultor.ConsultarTodos();

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
            Personajes.Push(new Personaje());

            ultimoPersonajeAgregado = new DatosPersonaje();
            spPersonajes.Children.Add(ultimoPersonajeAgregado);
        }

        private void EliminarPersonaje()
        {
            if (Personajes.Count > 0)
            {
                Personajes.Pop();
            }

            spPersonajes.Children.Remove(ultimoPersonajeAgregado);
        }
    }
}