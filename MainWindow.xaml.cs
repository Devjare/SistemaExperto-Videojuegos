using SistemaExpertoProlog_Videojuegos.Controles;
using SistemaExpertoProlog_Videojuegos.data;
using SistemaExpertoProlog_Videojuegos.negocios;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            var file = "C:/Users/jandr/Dropbox/Septimo Semestre/Programacion Logica y Funcional/Unidad IV/Proyecto Final/base_conocimiento.pl/datos_prueba.pl";

            var archivo = "/Recursos/BaseConocimiento/datos.pl";

            MessageBox.Show($"Path: { archivo }");

            //MotorProlog.Instancia.RutaArchivo = archivo;
            MotorProlog.Instancia.RutaArchivo = file;

            MotorProlog.Instancia.IniciarProlog();

            InitializeComponent();

            ActivarControlDeUsuario(ucTarjetaBase);
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var opcion = cbOpciones.SelectedIndex;
            
            if (opcion.Equals(VIDEOJUEGOS))
            {
                var consultor = new ConsultorVideojuegos();
                List<Videojuego> videojuegos = consultor.Consultar();

                MotorProlog.Instancia.CerrarProlog();
                
                ActualizarTarjetasVideojuegos(videojuegos);
            } 
            else if(opcion.Equals(PERSONAJES))
            {
                var consultor = new ConsultorPersonajes();
                List<Personaje> personajes = consultor.Consultar("19", "Rubio", "Azules");

                //MotorProlog.Instancia.CerrarProlog();
                
                ActualizarTarjetasPersonajes(personajes);
            }
            else
            {
                var consultor = new ConsultorDesarrolladoras();
                List<String> desarrolladoras = consultor.Consultar();
                // ActualizarTarjetasDesarrolladoras(desarrolladoras);
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
