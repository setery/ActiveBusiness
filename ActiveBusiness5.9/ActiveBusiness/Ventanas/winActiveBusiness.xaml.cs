using ActiveBusiness.Clases;
using ActiveBusiness.Enums;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ActiveBusiness.Ventanas
{
    public partial class winActiveBusiness : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

       // private const int rondasTotales = 200;
        private int ronda = 0;

        Jugador jugadorActual;
        List<Jugador> jugadores;
        Partida partida = Partida.Instance; // Mantenemos la instancia de partida con atributos previamente configurados en ventanas anteriores.

        List<Rectangle> casillas = new List<Rectangle>();
        List<Image> fichas = new List<Image>();
        List<Label> nombreJugadores = new List<Label>();
        List<Label> dineroJugadores = new List<Label>();

        List<Rectangle> rectanguloJugadores = new List<Rectangle>();
        List<Rectangle> rectanguloColores = new List<Rectangle>();
        List<ListView> listaLisview = new List<ListView>();

        // Inicio por defecto
        public winActiveBusiness()
        {
            InitializeComponent();
            jugadorActual = partida.getJugadorActual();
            jugadores = partida.Jugadores;
            establecerNumero();
            agregarCasillas();
            agregarObjetos();
            comenzarTiempo();
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            btnTerminarTurno.IsEnabled = false;
            btnComprar.IsEnabled = false;
        }
        // Añade los objetos para poder iniciarlos segun cantidad de jugadores
        public void agregarObjetos()
        {
            // Imagenes de jugadores que representan las fichas del tablero
            fichas.Add(imgJugador1);
            fichas.Add(imgJugador2);
            fichas.Add(imgJugador3);
            fichas.Add(imgJugador4);

            // Labels de los nombres de jugadores para la interfaz
            nombreJugadores.Add(lblJugador_1);
            nombreJugadores.Add(lblJugador_2);
            nombreJugadores.Add(lblJugador_3);
            nombreJugadores.Add(lblJugador_4);

            // Labels que representan el dinero de los jugadores en la interfaz
            dineroJugadores.Add(lblDineroJugador_1);
            dineroJugadores.Add(lblDineroJugador_2);
            dineroJugadores.Add(lblDineroJugador_3);
            dineroJugadores.Add(lblDineroJugador_4);

            // Rectangulo jugador
            rectanguloJugadores.Add(regJugado1);
            rectanguloJugadores.Add(regJugado2);
            rectanguloJugadores.Add(regJugado3);
            rectanguloJugadores.Add(regJugado4);

            // Color jugador
            rectanguloColores.Add(regColorJugador1);
            rectanguloColores.Add(regColorJugador2);
            rectanguloColores.Add(regColorJugador3);
            rectanguloColores.Add(regColorJugador4);

            //listviews jugadores
            listaLisview.Add(lsvJugador1);
            listaLisview.Add(lsvJugador2);
            listaLisview.Add(lsvJugador3);
            listaLisview.Add(lsvJugador4);

            // Dependiendo de la cantidad de jugadores muestra sus respectivos objetos
            foreach (Image ficha in fichas)
            {
                if (fichas.IndexOf(ficha) < jugadores.Count)
                {
                    ficha.Visibility = Visibility.Visible;
                }
                else ficha.Visibility = Visibility.Hidden;
            }
            foreach (Label nombreJugador in nombreJugadores)
            {
                if (nombreJugadores.IndexOf(nombreJugador) < jugadores.Count)
                {
                    nombreJugador.Visibility = Visibility.Visible;
                }
                else nombreJugador.Visibility = Visibility.Hidden;
            }
            foreach (Label dineroJugador in dineroJugadores)
            {
                if (dineroJugadores.IndexOf(dineroJugador) < jugadores.Count)
                {
                    dineroJugador.Visibility = Visibility.Visible;
                }
                else dineroJugador.Visibility = Visibility.Hidden;
            }
            foreach(Rectangle regJugador in rectanguloJugadores)
            {
                if (rectanguloJugadores.IndexOf(regJugador) < jugadores.Count)
                {
                    regJugador.Visibility = Visibility.Visible;
                }
                else regJugador.Visibility = Visibility.Hidden;
            }
            foreach (Rectangle regColor in rectanguloColores)
            {
                if (rectanguloColores.IndexOf(regColor) < jugadores.Count)
                {
                    regColor.Visibility = Visibility.Visible;
                }
                else regColor.Visibility = Visibility.Hidden;
            }
            foreach (ListView lView in listaLisview)
            {
                if (listaLisview.IndexOf(lView) < jugadores.Count)
                {
                    lView.Visibility = Visibility.Visible;
                }
                else lView.Visibility = Visibility.Hidden;
            }
            // Ingresa el nombre de la lista a nombre jugador
            for (int i = 0; i < jugadores.Count; i++)
            {
                nombreJugadores[i].Content = jugadores[i].nombre;
            }
        }
        // Añade los rectangulos utilizados para la creacion de los tableros
        public void agregarCasillas()
        {
            casillas.Add(casilla0);
            casillas.Add(casilla1);
            casillas.Add(casilla2);
            casillas.Add(casilla3);
            casillas.Add(casilla4);
            casillas.Add(casilla5);
            casillas.Add(casilla6);
            casillas.Add(casilla7);
            casillas.Add(casilla8);
            casillas.Add(casilla9);
            casillas.Add(casilla10);
            casillas.Add(casilla11);
            casillas.Add(casilla12);
            casillas.Add(casilla13);
            casillas.Add(casilla14);
            casillas.Add(casilla15);
            casillas.Add(casilla16);
            casillas.Add(casilla17);
            casillas.Add(casilla18);
            casillas.Add(casilla19);
            casillas.Add(casilla20);
            casillas.Add(casilla21);
            casillas.Add(casilla22);
            casillas.Add(casilla23);
            casillas.Add(casilla24);
            casillas.Add(casilla25);
            casillas.Add(casilla26);
            casillas.Add(casilla27);
            casillas.Add(casilla28);
            casillas.Add(casilla29);
            casillas.Add(casilla30);
            casillas.Add(casilla31);
            casillas.Add(casilla32);
            casillas.Add(casilla33);
            casillas.Add(casilla34);
            casillas.Add(casilla35);
            casillas.Add(casilla36);
            casillas.Add(casilla37);
            casillas.Add(casilla38);
            casillas.Add(casilla39);
            casillas.Add(casilla40);
            casillas.Add(casilla41);
            casillas.Add(casilla42);
            casillas.Add(casilla43);
            casillas.Add(casilla44);
            casillas.Add(casilla45);
            casillas.Add(casilla46);
            casillas.Add(casilla47);
        }
        // Crea un timer
        private void comenzarTiempo()
        {
            dispatcherTimer.Tick += actualizarJuego;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }
        // Realiza acciones a medida que se actualiza el tiempo en juego
        private void actualizarJuego(object sender, EventArgs e)
        {
            // Actualiza la posicion del jugador respecto a las casillas
            foreach (Jugador player in jugadores)
            {
                if (jugadores.IndexOf(player) == 0)
                {
                    Canvas.SetLeft(fichas[jugadores.IndexOf(player)], Canvas.GetLeft(casillas[player.Posicion]));
                    Canvas.SetTop(fichas[jugadores.IndexOf(player)], Canvas.GetTop(casillas[player.Posicion]));
                }
                if (jugadores.IndexOf(player) == 1)
                {
                    Canvas.SetLeft(fichas[jugadores.IndexOf(player)], Canvas.GetLeft(casillas[player.Posicion]));
                    Canvas.SetTop(fichas[jugadores.IndexOf(player)], Canvas.GetTop(casillas[player.Posicion]));
                }
                if (jugadores.IndexOf(player) == 2)
                {
                    Canvas.SetLeft(fichas[jugadores.IndexOf(player)], Canvas.GetLeft(casillas[player.Posicion]));
                    Canvas.SetTop(fichas[jugadores.IndexOf(player)], Canvas.GetTop(casillas[player.Posicion]));
                }
                if (jugadores.IndexOf(player) == 3)
                {
                    Canvas.SetLeft(fichas[jugadores.IndexOf(player)], Canvas.GetLeft(casillas[player.Posicion]));
                    Canvas.SetTop(fichas[jugadores.IndexOf(player)], Canvas.GetTop(casillas[player.Posicion]));
                }
            }
            // Actualiza el dinero de cada jugador a medida que se refresca el tiempo de juego
            for (int i = 0; i < jugadores.Count; i++)
            {
                dineroJugadores[i].Content = "$" + jugadores[i].Dinero;
            }
            // Barra de tiempo para finalizar turno
            if (progressBar1.Value == 100)
            {            
                MessageBox.Show("¡Lo sentimos, se acabo el tiempo!");              
                progressBar1.Value = 0;
                progressBar1.BeginAnimation(ProgressBar.ValueProperty, null);
                jugadorActual = partida.siguienteTurno();
                txtMensaje.Text = "Le toca a " + jugadorActual.nombre;
                ronda++;
                btnJugar.IsEnabled = true;
                btnTerminarTurno.IsEnabled = false;
                btnComprar.IsEnabled = false;
                //cambiar tablero
                if (ronda == 30)
                {
                    MessageBox.Show("Caída economica, todas las empresas sufren una reorganizacion");
                    reduccionTablero();
                }
            }
        }
        // Boton jugar
        private void iniciarJuego(object sender, RoutedEventArgs e)
        {           
            btnTerminarTurno.IsEnabled = true;
            btnComprar.IsEnabled = true;
            Duration duracion = new Duration(TimeSpan.FromSeconds(15));
            progressBar1.Value = 0;
            DoubleAnimation doubleAnimation = new DoubleAnimation(progressBar1.Value + 100, duracion);
            progressBar1.BeginAnimation(ProgressBar.ValueProperty, null);
            progressBar1.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);

            // Limpia el color verde de quien está jugando
            regJugado1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            regJugado2.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            regJugado3.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            regJugado4.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            // Indica con color verde quien está jugando
            if (jugadorActual.numero == 1)
            {
                regJugado1.Fill = new SolidColorBrush(Color.FromRgb(129, 209, 31));
            }
            else if (jugadorActual.numero == 2)
            {
                regJugado2.Fill = new SolidColorBrush(Color.FromRgb(129, 209, 31));
            }
            else if (jugadorActual.numero == 3)
            {
                regJugado3.Fill = new SolidColorBrush(Color.FromRgb(129, 209, 31));
            }
            else if (jugadorActual.numero == 4)
            {
                regJugado4.Fill = new SolidColorBrush(Color.FromRgb(129, 209, 31));
            }

            btnJugar.IsEnabled = false;
            jugarRonda();

            // Segun la casilla en la que se encuentre, pregunta si desea comprar la empresa
            if (jugadorActual.ComprarEmpresa && partida.Tablero.empresas.ContainsKey(jugadorActual.Posicion))
            {
               string mensaje = jugadorActual.nombre + "\n ¿Quieres adquirir " + partida.Tablero.empresas[jugadorActual.Posicion].nombre + " por $" + partida.Tablero.empresas[jugadorActual.Posicion].precio + "?";
                txtMensaje.Text = mensaje;
            }
            desactivarComprar();
        }
        private void mostrarTarjeta()
        {
            regTarjeta.Visibility = Visibility.Visible;
            lblTextEmpresa.Visibility = Visibility.Visible;
            lblTextAccion.Visibility = Visibility.Visible;
            txtIndustria.Visibility = Visibility.Visible;
            lblPrecioAccionTarjeta.Visibility = Visibility.Visible;
            lblPrecioEmpresaTarjeta.Visibility = Visibility.Visible;
            lblCategoriaTarjeta.Visibility = Visibility.Visible;
            lblIndustriaTarjeta.Visibility = Visibility.Visible;
            lblNombreTarjeta.Visibility = Visibility.Visible;
            if (partida.Tablero.empresas.ContainsKey(jugadorActual.Posicion))
            {

                if (partida.Tablero.empresas[jugadorActual.Posicion].industria == Industria.Comida)
                {
                   regTarjeta.Fill = new SolidColorBrush(Color.FromRgb(126, 217, 87));
                }
                else if (partida.Tablero.empresas[jugadorActual.Posicion].industria == Industria.Transporte)
                {
                    regTarjeta.Fill = new SolidColorBrush(Color.FromRgb(140, 82, 255));
                }
                else if (partida.Tablero.empresas[jugadorActual.Posicion].industria == Industria.Tecnologia)
                {
                    regTarjeta.Fill = new SolidColorBrush(Color.FromRgb(253, 73, 73));
                }
                else if (partida.Tablero.empresas[jugadorActual.Posicion].industria == Industria.Textil)
                {
                    regTarjeta.Fill = new SolidColorBrush(Color.FromRgb(239, 38, 147));
                }
                else
                {
                    regTarjeta.Fill = new SolidColorBrush(Color.FromRgb(255, 189, 89));                
                }
            }
            if (partida.Tablero.empresas.ContainsKey(jugadorActual.Posicion))
            {
                lblNombreTarjeta.Text = (partida.Tablero.empresas[jugadorActual.Posicion].nombre);

                if (partida.Tablero.empresas[jugadorActual.Posicion].categoria == Categoria.Una)
                {
                    lblCategoriaTarjeta.Text = "★";
                }
                else if (partida.Tablero.empresas[jugadorActual.Posicion].categoria == Categoria.Dos)
                {
                    lblCategoriaTarjeta.Text = "★★";
                }
                else if (partida.Tablero.empresas[jugadorActual.Posicion].categoria == Categoria.Tres)
                {
                    lblCategoriaTarjeta.Text = "★★★";
                }
                else if (partida.Tablero.empresas[jugadorActual.Posicion].categoria == Categoria.Cuatro)
                {
                    lblCategoriaTarjeta.Text = "★★★★";
                }
                else
                {
                    lblCategoriaTarjeta.Text = "★★★★★";
                }
                lblIndustriaTarjeta.Text =  partida.Tablero.empresas[jugadorActual.Posicion].industria.ToString();
                lblPrecioEmpresaTarjeta.Text = ("$" + partida.Tablero.empresas[jugadorActual.Posicion].precio.ToString());
                lblPrecioAccionTarjeta.Text = ("$" + partida.Tablero.empresas[jugadorActual.Posicion].precioAccion.ToString());
            }
            else
            {
                regTarjeta.Visibility = Visibility.Hidden;
                lblTextEmpresa.Visibility = Visibility.Hidden;
                lblTextAccion.Visibility = Visibility.Hidden;
                lblNombreTarjeta.Text = "";
                lblIndustriaTarjeta.Text = "";
                lblCategoriaTarjeta.Text = "";
                lblPrecioEmpresaTarjeta.Text = "";
                lblPrecioAccionTarjeta.Text = "";
                txtIndustria.Visibility = Visibility.Hidden;
                lblPrecioAccionTarjeta.Visibility = Visibility.Hidden;
                lblPrecioEmpresaTarjeta.Visibility = Visibility.Hidden;
                lblCategoriaTarjeta.Visibility = Visibility.Hidden;
                lblIndustriaTarjeta.Visibility = Visibility.Hidden;
                lblNombreTarjeta.Visibility = Visibility.Hidden;
            }
        }
        // Indica quien es cada jugador
        public void establecerNumero()
        {
            int n = 1;
            foreach(Jugador jugador in jugadores)
            {
                jugador.numero = n;
                n++;
            }
        }
        // Metodo para sinergia de Comida
        public void sinergiaComida()
        {
            if (jugadorActual.cantidadPorIndustrias.ContainsKey(Industria.Comida))
            {
                if (ronda < 21)
                {
                    if (jugadorActual.cantidadPorIndustrias[Industria.Comida] > 1)
                    {
                        if (jugadorActual.Posicion == 2 || jugadorActual.Posicion == 5 || jugadorActual.Posicion == 9 || jugadorActual.Posicion == 18
                            || jugadorActual.Posicion == 21 || jugadorActual.Posicion == 30 || jugadorActual.Posicion == 35 || jugadorActual.Posicion == 37 
                            || jugadorActual.Posicion == 43 || jugadorActual.Posicion == 47)
                        {
                            MessageBox.Show("Recompensa: $200", "Activacion de sinergia Comida");
                            jugadorActual.agregarDinero(200);
                        }
                    }
                } 
                else
                {
                    if (jugadorActual.cantidadPorIndustrias[Industria.Comida] > 1)
                    {
                        if ( jugadorActual.Posicion == 1)
                        {
                            MessageBox.Show("Recompensa: $5000", "Activacion de sinergia Comida");
                            jugadorActual.agregarDinero(5000);
                        }
                    }
                }
            }
        }
        // Inicia una ronda
        private void jugarRonda()
        {
            jugadorActual = partida.getJugadorActual();
            partida.Tablero.tirarDados(jugadorActual);
            mostrarTarjeta();
            sinergiaComida();

            // Permite a un jugador comprar acciones al conseguir ciertos requisitos
            if (jugadorActual.ComprarAccion)
            {

                string message = jugadorActual.nombre + ", Quieres comprar una accion por $" + partida.Tablero.empresas[jugadorActual.Posicion].precioAccion;
                if (MessageBox.Show(message, "Compro una Accion de "+ partida.Tablero.empresas[jugadorActual.Posicion].nombre, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    partida.Tablero.comprarAcciones(jugadorActual, partida.Tablero.empresas[jugadorActual.Posicion]);
                    if (jugadorActual.numero == 1)
                    {
                        LinearGradientBrush rojoAccion = new LinearGradientBrush();
                        rojoAccion.StartPoint = new Point(0, 0);
                        rojoAccion.EndPoint = new Point(0, 1);
                        rojoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(232, 26, 26), 0.20));
                        rojoAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.50));
                        rojoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(232, 26, 26), 1.0));
                        casillas[jugadorActual.Posicion].Stroke = rojoAccion;

                    } else if (jugadorActual.numero == 2)
                    {
                        LinearGradientBrush celesteAccion = new LinearGradientBrush();
                        celesteAccion.StartPoint = new Point(0, 0);
                        celesteAccion.EndPoint = new Point(0, 1);
                        celesteAccion.GradientStops.Add(new GradientStop(Color.FromRgb(2, 169, 175), 0.20));
                        celesteAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.50));
                        celesteAccion.GradientStops.Add(new GradientStop(Color.FromRgb(2, 169, 175), 1.0));
                        casillas[jugadorActual.Posicion].Stroke = celesteAccion;
                    } else if (jugadorActual.numero == 3)
                    {
                        LinearGradientBrush azulAccion = new LinearGradientBrush();
                        azulAccion.StartPoint = new Point(0, 0);
                        azulAccion.EndPoint = new Point(0, 1);
                        azulAccion.GradientStops.Add(new GradientStop(Color.FromRgb(0, 74, 173), 0.20));
                        azulAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.60));
                        azulAccion.GradientStops.Add(new GradientStop(Color.FromRgb(0, 74, 173), 1.0));
                        casillas[jugadorActual.Posicion].Stroke = azulAccion;
                    } else
                    {
                        LinearGradientBrush naranjoAccion = new LinearGradientBrush();
                        naranjoAccion.StartPoint = new Point(0, 0);
                        naranjoAccion.EndPoint = new Point(0, 1);
                        naranjoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(251, 126, 10), 0.20));
                        naranjoAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.60));
                        naranjoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(251, 126, 10), 1.0));
                        casillas[jugadorActual.Posicion].Stroke = naranjoAccion;
                    }
                }
                jugadorActual.ComprarAccion = false;
            }

            // Consulta si un jugador pierde y lo remueve del juego
            if (partida.Tablero.derrota(jugadorActual))
            {
                if (jugadorActual.numero == 1)
                {
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual)
                        {
                            empresa.dueño = null;
                            lsvJugador1.Items.Clear();
                            foreach (Rectangle casilla in casillas)
                            {
                                casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                casillas[empresa.posicion].StrokeThickness = 1;
                            }
                        }
                    }
                }
                else if (jugadorActual.numero == 2)
                {
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual)
                        {
                            empresa.dueño = null;
                            lsvJugador2.Items.Clear();
                            foreach (Rectangle casilla in casillas)
                            {
                                casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                casillas[empresa.posicion].StrokeThickness = 1;
                            }
                        }
                    }
                }
                else if (jugadorActual.numero == 3)
                {
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual)
                        {
                            empresa.dueño = null;
                            lsvJugador3.Items.Clear();
                            foreach (Rectangle casilla in casillas)
                            {
                                casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                casillas[empresa.posicion].StrokeThickness = 1;
                            }
                        }
                    }
                }
                else if (jugadorActual.numero == 4)
                {
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual)
                        {
                            empresa.dueño = null;
                            lsvJugador4.Items.Clear();
                            foreach (Rectangle casilla in casillas)
                            {
                                casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                casillas[empresa.posicion].StrokeThickness = 1;
                            }
                        }
                    }
                }
                partida.eliminarJugador(jugadorActual);
                // elimina los sobrantes del jugador que perdió
                if (jugadorActual.numero == 1)
                {
                    fichas.Remove(imgJugador1);
                    this.imgJugador1.Visibility = Visibility.Hidden;
                    dineroJugadores.Remove(lblDineroJugador_1);
                    regHide1.Opacity = 90;
                }
                else if (jugadorActual.numero == 2)
                {
                    fichas.Remove(imgJugador2);
                    this.imgJugador2.Visibility = Visibility.Hidden;
                    dineroJugadores.Remove(lblDineroJugador_2);
                    regHide2.Opacity = 90;
                }
                else if (jugadorActual.numero == 3)
                {
                    fichas.Remove(imgJugador3);
                    this.imgJugador3.Visibility = Visibility.Hidden;
                    dineroJugadores.Remove(lblDineroJugador_3);
                    regHide3.Opacity = 90;
                }
                else if (jugadorActual.numero == 4)
                {
                    fichas.Remove(imgJugador4);
                    this.imgJugador4.Visibility = Visibility.Hidden;
                    dineroJugadores.Remove(lblDineroJugador_4);
                    regHide4.Opacity = 90;
                }
                // Condicion ultimo jugador en pie
                if (jugadores.Count < 2)
                {                   
                    partida.finalizarJuego(0, jugadores[0]);
                    this.Close();
                }
            }
        }
        // Boton comprar
        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            // Consulta si un jugador puede comprar y luego realiza la accion de comprar y añadirlo a listview
            if (jugadorActual.ComprarEmpresa && jugadorActual.Posicion != 0 && partida.Tablero.empresas.ContainsKey(jugadorActual.Posicion))
            {
                string mensaje = "";
                txtMensaje.Text = mensaje;
                jugadorActual.ComprarEmpresa = false;
                partida.Tablero.comprarEmpresa(jugadorActual, partida.Tablero.empresas[jugadorActual.Posicion]);

                if (jugadorActual.numero == 1)
                {
                    casillas[jugadorActual.Posicion].Stroke = new SolidColorBrush(Color.FromRgb(232, 26, 26));
                    casillas[jugadorActual.Posicion].StrokeThickness = 8;            

                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual && !lsvJugador1.Items.Contains(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria))
                        {
                            lsvJugador1.Items.Add(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria);
                        }
                    }
                }
                else if (jugadorActual.numero == 2)
                {
                    casillas[jugadorActual.Posicion].Stroke = new SolidColorBrush(Color.FromRgb(2, 169, 175));
                    casillas[jugadorActual.Posicion].StrokeThickness = 8;
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual && !lsvJugador2.Items.Contains(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria))
                        {
                            lsvJugador2.Items.Add(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria);
                        }
                    }
                }
                else if (jugadorActual.numero == 3)
                {
                    casillas[jugadorActual.Posicion].Stroke = new SolidColorBrush(Color.FromRgb(0,74, 173));
                    casillas[jugadorActual.Posicion].StrokeThickness = 8;
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual && !lsvJugador3.Items.Contains(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria))
                        {
                            lsvJugador3.Items.Add(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria);
                        }
                    }
                }
                else if (jugadorActual.numero == 4)
                {
                    casillas[jugadorActual.Posicion].Stroke = new SolidColorBrush(Color.FromRgb(251, 126, 10));
                    casillas[jugadorActual.Posicion].StrokeThickness = 8;
                    foreach (Empresa empresa in partida.Tablero.empresas.Values)
                    {
                        if (empresa.dueño == jugadorActual && !lsvJugador4.Items.Contains(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria))
                        {
                            lsvJugador4.Items.Add(empresa.nombre + "   Industria: " + empresa.industria + "    ★: " + empresa.categoria);
                        }
                    }
                }
            }
        }
        // Boton terminar turno
        private void btnTerminarTurno_Click(object sender, RoutedEventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.BeginAnimation(ProgressBar.ValueProperty, null);
            jugadorActual = partida.siguienteTurno();
            txtMensaje.Text = "Es el turno de "+jugadorActual.nombre;
            ronda++;
            btnJugar.IsEnabled = true;
            btnTerminarTurno.IsEnabled = false;
            btnComprar.IsEnabled = false;

            //cambiar tablero pasado ciertas rondas
            if (ronda == 30)
            {
                MessageBox.Show("Caída economica, todas las empresas sufren una reorganizacion");
                reduccionTablero();
            }
        }
        // Boton salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //
        public void reduccionTablero()
        {
            // Cambia la posicion de los jugadores al reducir el tablero
            foreach(Jugador jugador in partida.Jugadores)
            {
                if(jugador.Posicion != 16)
                {
                    jugador.Posicion = 0;
                }
            }
            // Cambia la imagen al segundo tablero
            this.imgTablero1.Visibility = Visibility.Visible;
            this.imgTablero2.Visibility = Visibility.Hidden;

            // Vuelve a sus prefig las casillas
            foreach (Rectangle casilla in casillas)
            {
                casilla.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                casilla.StrokeThickness = 1;
            }

            // Esconde las casillas sobrantes y resalta la casilla faltante para el nuevo tablero
            this.casillaX.Visibility = Visibility.Visible;
            this.casilla29.Visibility = Visibility.Hidden;
            this.casilla30.Visibility = Visibility.Hidden;
            this.casilla31.Visibility = Visibility.Hidden;
            this.casilla32.Visibility = Visibility.Hidden;
            this.casilla33.Visibility = Visibility.Hidden;
            this.casilla34.Visibility = Visibility.Hidden;
            this.casilla35.Visibility = Visibility.Hidden;
            this.casilla36.Visibility = Visibility.Hidden;
            this.casilla37.Visibility = Visibility.Hidden;
            this.casilla38.Visibility = Visibility.Hidden;
            this.casilla39.Visibility = Visibility.Hidden;
            this.casilla40.Visibility = Visibility.Hidden;
            this.casilla41.Visibility = Visibility.Hidden;
            this.casilla42.Visibility = Visibility.Hidden;
            this.casilla43.Visibility = Visibility.Hidden;
            this.casilla44.Visibility = Visibility.Hidden;
            this.casilla45.Visibility = Visibility.Hidden;

            // Remueve las casillas sobrantes y agrega la casilla faltante
            // Remove
            casillas.Remove(casilla29);
            casillas.Remove(casilla30);
            casillas.Remove(casilla31);
            casillas.Remove(casilla32);
            casillas.Remove(casilla33);
            casillas.Remove(casilla34);
            casillas.Remove(casilla35);
            casillas.Remove(casilla36);
            casillas.Remove(casilla37);
            casillas.Remove(casilla38);
            casillas.Remove(casilla39);
            casillas.Remove(casilla40);
            casillas.Remove(casilla41);
            casillas.Remove(casilla42);
            casillas.Remove(casilla43);
            casillas.Remove(casilla44);
            casillas.Remove(casilla45);
            casillas.Remove(casilla46);
            casillas.Remove(casilla47);
            // Add
            casillas.Add(casillaX);
            casillas.Add(casilla46);
            casillas.Add(casilla47);

            // Ingresa el nuevo tablero e indica su tamaño
            partida.Tablero.reducirTablero();
            partida.Tablero.tamaño = casillas.Count;

            // Vuelve a marcar los colores de las casillas ya compradas antes de la reduccion de tablero
            foreach (Jugador jugador in partida.Jugadores)
            {
                foreach (Empresa empresa in partida.Tablero.empresas.Values)
                {
                    if(jugador.numero == 1)
                    { 
                        if (empresa.acciones > 0 && empresa.dueño == jugador)
                        {
                            LinearGradientBrush rojoAccion = new LinearGradientBrush();
                            rojoAccion.StartPoint = new Point(0, 0);
                            rojoAccion.EndPoint = new Point(0, 1);
                            rojoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(232, 26, 26), 0.20));
                            rojoAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.50));
                            rojoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(232, 26, 26), 1.0));
                            casillas[empresa.posicion].Stroke = rojoAccion;
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                        else if (empresa.dueño == jugador)
                        {
                            casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(232, 26, 26));
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                    }
                    else if(jugador.numero == 2)
                    { 
                        if(empresa.acciones > 0 && empresa.dueño == jugador)
                        {
                            LinearGradientBrush celesteAccion = new LinearGradientBrush();
                            celesteAccion.StartPoint = new Point(0, 0);
                            celesteAccion.EndPoint = new Point(0, 1);
                            celesteAccion.GradientStops.Add(new GradientStop(Color.FromRgb(2, 169, 175), 0.20));
                            celesteAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.50));
                            celesteAccion.GradientStops.Add(new GradientStop(Color.FromRgb(2, 169, 175), 1.0));
                            casillas[empresa.posicion].Stroke = celesteAccion;
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                        else if (empresa.dueño == jugador)
                        {
                            casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(2, 169, 175));
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                    }
                    else if (jugador.numero == 3)
                    { 
                        if (empresa.acciones > 0 && empresa.dueño == jugador)
                        {
                            LinearGradientBrush azulAccion = new LinearGradientBrush();
                            azulAccion.StartPoint = new Point(0, 0);
                            azulAccion.EndPoint = new Point(0, 1);
                            azulAccion.GradientStops.Add(new GradientStop(Color.FromRgb(0, 74, 173), 0.20));
                            azulAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.60));
                            azulAccion.GradientStops.Add(new GradientStop(Color.FromRgb(0, 74, 173), 1.0));
                            casillas[empresa.posicion].Stroke = azulAccion;
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                        else if (empresa.dueño == jugador)
                        {
                            casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(0, 74, 173));
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                    }
                    else
                    { 
                        if (empresa.acciones > 0 && empresa.dueño == jugador)
                        {
                            LinearGradientBrush naranjoAccion = new LinearGradientBrush();
                            naranjoAccion.StartPoint = new Point(0, 0);
                            naranjoAccion.EndPoint = new Point(0, 1);
                            naranjoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(251, 126, 10), 0.20));
                            naranjoAccion.GradientStops.Add(new GradientStop(Colors.Yellow, 0.60));
                            naranjoAccion.GradientStops.Add(new GradientStop(Color.FromRgb(251, 126, 10), 1.0));
                            casillas[empresa.posicion].Stroke = naranjoAccion;
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                        else if (empresa.dueño == jugador)
                        {
                            casillas[empresa.posicion].Stroke = new SolidColorBrush(Color.FromRgb(251, 126, 10));
                            casillas[empresa.posicion].StrokeThickness = 8;
                        }
                    }  
                }             
            }
        }
        // Desactiva el boton comprar para cuando la casilla no es una empresa
        public void desactivarComprar()
        {
            if(!partida.Tablero.empresas.ContainsKey(jugadorActual.Posicion))
            {
                this.btnComprar.IsEnabled = false;
            }
            if (partida.Tablero.empresas.ContainsKey(jugadorActual.Posicion))
            {
                if (jugadorActual.Dinero < partida.Tablero.empresas[jugadorActual.Posicion].precio)
                {
                    this.btnComprar.IsEnabled = false;
                    this.txtMensaje.Text = "No tienes suficiente dinero para comprar";
                }
                if (partida.Tablero.empresas[jugadorActual.Posicion].dueño != jugadorActual && partida.Tablero.empresas[jugadorActual.Posicion].dueño != null)
                {
                    this.btnComprar.IsEnabled = false;
                    this.txtMensaje.Text = "Empresa de " + partida.Tablero.empresas[jugadorActual.Posicion].dueño.nombre;
                }       
                if (partida.Tablero.empresas[jugadorActual.Posicion].dueño == jugadorActual)
                {
                    this.btnComprar.IsEnabled = false;
                }
            }
        }
    }
}
