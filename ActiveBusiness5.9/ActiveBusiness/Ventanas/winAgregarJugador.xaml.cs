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
    /// Lógica de interacción para winAgregarJugador.xaml
    /// </summary>
    public partial class winAgregarJugador : Window
    {
        public int cantidadJugadores;
        public winAgregarJugador()
        {
            InitializeComponent();
        }
        private void rdbDos_Checked(object sender, RoutedEventArgs e)
        {
            cantidadJugadores = 2;
        }

        private void rdbTres_Checked(object sender, RoutedEventArgs e)
        {
            cantidadJugadores = 3;
        }

        private void rdbCuatro_Checked(object sender, RoutedEventArgs e)
        {
            cantidadJugadores = 4;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            if ((rdbDos.IsChecked == false) && (rdbTres.IsChecked == false) && (rdbCuatro.IsChecked == false))
            {
                MessageBox.Show("Selecciona la cantidad de jugadores!");
            }
            else
            {
                winNombreJugador nombreJugador = new winNombreJugador(cantidadJugadores, cantidadJugadores);
                nombreJugador.Show();
                this.Close();
            }
        }
    }
}
