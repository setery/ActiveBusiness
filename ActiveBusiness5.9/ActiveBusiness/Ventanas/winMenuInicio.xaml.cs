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
using ActiveBusiness.Clases;

namespace ActiveBusiness.Ventanas
{
    public partial class winMenuInicio : Window
    {
        Partida partida;
        List<Jugador> jugadores;
        Tablero tablero;
        Jugador jugadorActual;
        Dictionary<int, Empresa> empresas;

        public winMenuInicio()
        {
            InitializeComponent();
        }

        private void salirJuego(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void iniciarJuego(object sender, RoutedEventArgs e)
        {
            winAgregarJugador agregarJugador = new winAgregarJugador();
            agregarJugador.Show();
            partida = Partida.Instance;             
            tablero = partida.Tablero;
            jugadores = partida.Jugadores;
            empresas = partida.Tablero.empresas;
            jugadorActual = partida.getJugadorActual();
            this.Close();
        }
    }
}
