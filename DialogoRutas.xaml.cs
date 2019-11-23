using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace SistemaExpertoProlog_Videojuegos
{
    /// <summary>
    /// Interaction logic for DialogoRutas.xaml
    /// </summary>
    public partial class DialogoRutas : Window
    {
        private String rutaArchivo;

        public String RutaArchivo
        {
            get { return rutaArchivo; }
            private set { rutaArchivo = value; }
        }

        private String rutaImagenes;

        public String RutaImagenes
        {
            get { return rutaImagenes; }
            private set { rutaImagenes = value; }
        }

        private int ARCHIVO = 1;
        private int CARPETA = 2;

        public DialogoRutas()
        {
            InitializeComponent();

            btnAceptar.Click += (s, e) => Aceptar();
            btnCancelar.Click += (s, e) => Cancelar(); 

            btnSeleccionarArchivo.Click += (s, e) => RutaArchivo = ObtenerRuta(ARCHIVO);
            btnSeleccionarCarpeta.Click += (s, e) => RutaImagenes = ObtenerRuta(CARPETA);
        }

        private string ObtenerRuta(int opcion)
        {
            var ruta = "";

            if (opcion == ARCHIVO)
            {
                var fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta = fileDialog.FileName;
                    txtRutaArchivo.Text = ruta;
                }
            }
            else
            {
                var folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta = folderDialog.SelectedPath;
                    txtRutaCarpetaImagenes.Text = ruta;
                }
            }

            return ruta;
        }

        private void Cancelar()
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Aceptar()
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
