using SistemaExpertoProlog_Videojuegos.Controles;
using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SistemaExpertoProlog_Videojuegos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var rutaArchivo = "C:/Users/jandr/Dropbox/Septimo Semestre/Programacion Logica y Funcional/Unidad IV/Proyecto Final/base_conocimiento.pl/datos_prueba_real.pl";
            var rutaImagenes = "C:/Users/jandr/Dropbox/Septimo Semestre/Programacion Logica y Funcional/Unidad IV/Proyecto Final/Recursos/Imagenes/";

            //var dialogoRutas = new DialogoRutas();
            //if (dialogoRutas.ShowDialog() == true)
            //{
            //    rutaArchivo = dialogoRutas.RutaArchivo;
            //    rutaImagenes = dialogoRutas.RutaImagenes;
            //}
            //else
            //{
            //    Environment.Exit(-1);
            //}

            MotorProlog.Instancia.RutaArchivo = rutaArchivo;
            MotorProlog.Instancia.IniciarProlog();

            Sesion.Instancia.RutaPadre = rutaImagenes;
            Sesion.Instancia.CargarImagenes();

            InitializeComponent();

            ActivarControlDeUsuario(ucTarjetaBase);
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var consulta = "";

            var consultas = new List<String>();

            var anio = ucCriteriosPersonaje.Anio;
            var genero = ucCriteriosPersonaje.Genero;
            var tema = ucCriteriosPersonaje.Tema;
            var desarrolladora = ucCriteriosPersonaje.Desarrolladora;

            if (anio != ControlCriteriosPersonaje.NO_SELECCIONADO) consultas.Add($"lanzado_el(V, '{anio}')");
            if (genero != ControlCriteriosPersonaje.NO_SELECCIONADO) consultas.Add($"es_genero(V, '{genero}')");
            if (tema != ControlCriteriosPersonaje.NO_SELECCIONADO) consultas.Add($"es_tema(V, '{tema}')");
            if (desarrolladora != ControlCriteriosPersonaje.NO_SELECCIONADO) consultas.Add($"desarrollado_por(V, '{desarrolladora}')");

            for (int i = 0; i < consultas.Count - 1; i++) consulta += consultas[i] + ", ";

            var pilaPersonajes = ucCriteriosPersonaje.Personajes;

            if (pilaPersonajes.Count == 0)
            {
                consulta += $"{consultas[consultas.Count - 1]}.";
                var nombresVideojuegos = MotorProlog.Consultar(consulta);
                var listaVideojuegos = ObtenerVideojuegos(nombresVideojuegos);

                if (nombresVideojuegos.Count == 0) MessageBox.Show("No videojuegos encontrados con esas caracteristicas!");
                else ActualizarTarjetasVideojuegos(listaVideojuegos);

            }
            else
            {
                consulta += consultas[consultas.Count - 1] + ", ";
                consultas.Clear();
                
                foreach (var personaje in pilaPersonajes)
                {
                    if (personaje.Nombre != null)
                    {
                        var nombre = $"'{personaje.Nombre}'";
                        consultas.Add($"personaje_de({nombre}, V)");
                    }
                    else
                    {
                        consultas.Add(ObtenerConsultaPersonaje(personaje));
                    }
                }

                for (int i = 0; i < consultas.Count - 1; i++) consulta += consultas[i] + ", ";
                consulta += $"{consultas[consultas.Count - 1]}.";
                var nombresVideojuegos = MotorProlog.Consultar(consulta);
                var listaVideojuegos = ObtenerVideojuegos(nombresVideojuegos);

                if (nombresVideojuegos.Count == 0) MessageBox.Show("No videojuegos encontrados con esas caracteristicas!");
                else ActualizarTarjetasVideojuegos(listaVideojuegos);
            }
        }

        private string ObtenerConsultaPersonaje(Personaje personaje)
        {
            var consultaBuilder = new StringBuilder();
            
            consultaBuilder.Append("es_personaje_de(");

            if (personaje.Genero != null) consultaBuilder.Append($"'{personaje.Genero}', ");
            else consultaBuilder.Append("S, ");

            if (personaje.Especie != null) consultaBuilder.Append($"'{personaje.Especie}', ");
            else consultaBuilder.Append("E, ");

            if (personaje.AtaqueEspecial != null) consultaBuilder.Append($"'{personaje.AtaqueEspecial}', ");
            else consultaBuilder.Append("A, ");

            if (personaje.ColorDistintivo != null) consultaBuilder.Append($"'{personaje.ColorDistintivo}', ");
            else consultaBuilder.Append("C, ");

            consultaBuilder.Append("V)");

            return consultaBuilder.ToString();
        }

        private List<Videojuego> ObtenerVideojuegos(List<string> nombresVideojuegos)
        {
            var listaVideojuegos = new List<Videojuego>();

            nombresVideojuegos.ForEach(nombre =>
            {
                nombre = $"'{nombre}'";
                var fechaLanzamiento = MotorProlog.Consultar($"fecha_lanzamiento({nombre}, V).");
                var genero = MotorProlog.Consultar($"es_genero({nombre}, V).");
                var tema = MotorProlog.Consultar($"es_tema({nombre}, V).");
                var desarrolladora = MotorProlog.Consultar($"desarrollado_por({nombre}, V).");
                var descripcion = MotorProlog.Consultar($"descripcion({nombre}, V).");

                var videojuego = new Videojuego()
                {
                    Nombre = nombre,
                    Lanzamiento = fechaLanzamiento.Count != 0 ? fechaLanzamiento[0] : "No encontrado",
                    Genero = genero.Count != 0 ? genero[0] : "No encontrado",
                    Tematica = tema.Count != 0 ? tema[0] : "No encontrada",
                    Desarrolladora = desarrolladora.Count != 0 ? desarrolladora[0] : "No encontrada",
                    Descripcion = descripcion.Count != 0 ? descripcion[0] : "No encontrada"
                };

                listaVideojuegos.Add(videojuego);
            });

            return listaVideojuegos;
        }

        private void ActualizarTarjetasVideojuegos(List<Videojuego> videojuegos)
        {
            ucTarjetaVideojuego.Videojuegos = videojuegos;
            ActivarControlDeUsuario(ucTarjetaVideojuego);
        }

        private void ActivarControlDeUsuario(UserControl control)
        {
            ucTarjetaVideojuego.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            VideojuegoAnterior(ucTarjetaVideojuego);
        }

        private void VideojuegoAnterior(TarjetaVideojuego tarjetaVideojuego)
        {
            tarjetaVideojuego.VideojuegoAnterior();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            SiguienteVideojuego(ucTarjetaVideojuego);
        }

        private void SiguienteVideojuego(TarjetaVideojuego tarjetaVideojuego)
        {
            tarjetaVideojuego.SiguienteVideojuego();
        }
        
    }

}
