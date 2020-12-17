using ActiveBusiness.Clases;
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
using System.Windows.Shapes;

namespace ActiveBusiness.Ventanas
{
    /// <summary>
    /// Lógica de interacción para winFinDelJuego.xaml
    /// </summary>
    public partial class winFinDelJuego : Window
    {
        public winFinDelJuego()
        {
            InitializeComponent();
        }
        public winFinDelJuego(int rason, Jugador jugador)
        {
            InitializeComponent();
            txtGanador.Text = jugador.nombre;
        }

        private void salirJuego(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
