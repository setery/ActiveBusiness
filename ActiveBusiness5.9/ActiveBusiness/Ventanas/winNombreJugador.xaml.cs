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
    /// Lógica de interacción para winNombreJugador.xaml
    /// </summary>
    public partial class winNombreJugador : Window
    {
        public int cantidadRestante;
        public int cantidadJugadores;
        Partida partida = Partida.Instance;
        public winNombreJugador()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }
        public winNombreJugador(int cantidadR, int cantidad)
        {
            InitializeComponent();
            this.cantidadRestante = cantidadR;
            this.cantidadJugadores = cantidad;
            this.lblNombreJugador.Content = "Jugador " + (cantidad - cantidadR + 1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtNombreJugador.Focus();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreJugador.Text == "")
                MessageBox.Show("Ingrese el nombre del Jugador");
            else
            {
                partida.agregarJugador(new Jugador(txtNombreJugador.Text));
                if (cantidadRestante > 1)
                {
                    cantidadRestante--;
                    winNombreJugador nombreJugador = new winNombreJugador(cantidadRestante, cantidadJugadores);
                    nombreJugador.Show();
                    this.Close();
                }
                else
                {
                    winActiveBusiness juego = new winActiveBusiness();
                    partida.ventanas.Add(juego);
                    juego.Show();
                    this.Close();
                }

            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnAceptar_Click(sender, e);
            }
        }
    }
}
