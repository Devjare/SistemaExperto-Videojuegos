﻿using SistemaExpertoProlog_Videojuegos.data;
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
    /// Interaction logic for TarjetaVideojuego.xaml
    /// </summary>
    public partial class TarjetaVideojuego : UserControl
    {
        public List<Videojuego> Videojuegos { get; set; }
        public TarjetaVideojuego()
        {
            InitializeComponent();
        }
    }
}
