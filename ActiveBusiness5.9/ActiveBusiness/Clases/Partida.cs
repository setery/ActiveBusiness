using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using ActiveBusiness.Ventanas;

namespace ActiveBusiness.Clases
{
    public class Partida
    {
        public int turno;
        static Jugador jugadorActual;
        private List<Jugador> jugadores;
        private Tablero tablero;
        public List<Window> ventanas;

        public Tablero Tablero
        {
            get { return tablero; }
        }
        public List<Jugador> Jugadores
        {
            get { return jugadores; }
        }
        // Constructor por defecto
        private Partida()
        {
            turno = 0;
            jugadores = new List<Jugador>();
            tablero = new Tablero();
            ventanas = new List<Window>();
        }
        // Añade un jugador
        public void agregarJugador(Jugador jugador)
        {
            jugadores.Add(jugador);
            jugadorActual = jugadores[0];
        }
        // Le indica al siguiente jugador que es su turno
        public Jugador siguienteTurno()
        {
            turno = (turno + 1) % (jugadores.Count);      
            jugadorActual = jugadores[turno];
            return jugadores[turno];
        }
        // Retorna el jugador actual
        public Jugador getJugadorActual()
        {
            return jugadorActual;
        }
        // Elimina un jugador
        public void eliminarJugador(Jugador jugador)
        {  
            if (turno == jugadores.Count - 1)
            {
                turno = -1;
            }
            else
            {
                turno--;
            }
            jugadores.Remove(jugador);
        }
        // Da por concluido el juego el ultimo jugador como ganador
        public void finalizarJuego(int finJuego, Jugador jugador)
        {

            winFinDelJuego winFinJuego = new winFinDelJuego(finJuego, jugador);
            winFinJuego.Show();
            foreach (Window window in ventanas)
            {
                window.Close();
            }         
        }
        // Instancia una partida
        static private Partida intancia;
        public static Partida Instance
        {
            get
            {
                if (intancia == null) // if instance doesn't exist
                    intancia = new Partida();
                return intancia;
            }
        }
    }
}
