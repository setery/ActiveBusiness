using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ActiveBusiness.Enums;

namespace ActiveBusiness.Clases
{
    public class Tablero
    {
        public delegate void Callback(Jugador jugador);
        public int tamaño;
        private List<string> casillas { get; set; }
        private Dictionary<string, Callback> metodoCasillaActual;
        public Dictionary<int, Empresa> empresas;
        private Random efectoAleatorio;

        Dado dado = new Dado();

       // Empresa(posicion, industria, nombre, precio, precioAccion, venta, categoria)

        // Industria Comida
        Empresa empresa1 = new Empresa(3, Industria.Comida, "Heladeria", 1000, 250, 200, Categoria.Una); 
        Empresa empresa2 = new Empresa(4, Industria.Comida, "Pizzeria", 3000, 750, 600, Categoria.Tres);
        Empresa empresa3 = new Empresa(6, Industria.Comida, "BurgerQueen", 5000, 1250, 1000, Categoria.Cinco);
        Empresa empresa4 = new Empresa(7, Industria.Comida, "Sushi Time", 4000, 1000, 800, Categoria.Cuatro);
        Empresa empresa5 = new Empresa(8, Industria.Comida, "Cafeteria", 2000, 500, 400, Categoria.Dos);
        
        // Industria Transporte
        Empresa empresa6 = new Empresa(11, Industria.Transporte, "Taller Mecanico", 1000, 250, 200, Categoria.Una);
        Empresa empresa7 = new Empresa(12, Industria.Transporte, "Luxury Transport", 4000, 1000, 800, Categoria.Cuatro);
        Empresa empresa8 = new Empresa(14, Industria.Transporte, "Mensajeria", 3000, 750, 600, Categoria.Tres);
        Empresa empresa9 = new Empresa(15, Industria.Transporte, "World Aeroline", 5000, 1250, 1000, Categoria.Cinco);
        Empresa empresa10 = new Empresa(17, Industria.Transporte, "Taxis", 2000, 500, 400, Categoria.Dos);

        // Industria Tecnología
        Empresa empresa11 = new Empresa(19, Industria.Tecnologia, "Telefonia", 4000, 1000, 800, Categoria.Cuatro);
        Empresa empresa12 = new Empresa(20, Industria.Tecnologia, "Red Social", 3000, 750, 600, Categoria.Tres);
        Empresa empresa13 = new Empresa(22, Industria.Tecnologia, "E-Commerce", 1000, 250, 200, Categoria.Una);
        Empresa empresa14 = new Empresa(23, Industria.Tecnologia, "CPU Commpany", 5000, 1250, 1000, Categoria.Cinco);
        Empresa empresa15 = new Empresa(24, Industria.Tecnologia, "Game Store", 2000, 500, 400, Categoria.Dos);

        // Industria Textil
        Empresa empresa16 = new Empresa(27, Industria.Textil, "Mall", 4000, 1000, 800, Categoria.Cuatro);
        Empresa empresa17 = new Empresa(29, Industria.Textil, "Lavanderia", 1000, 250, 200, Categoria.Una);
        Empresa empresa18 = new Empresa(31, Industria.Textil, "Agirre & Sons", 3000, 750, 600, Categoria.Tres);
        Empresa empresa19 = new Empresa(33, Industria.Textil, "Naik", 2000, 500, 400, Categoria.Dos);
        Empresa empresa20 = new Empresa(34, Industria.Textil, "Fabrica de ropa", 5000, 1250, 1000, Categoria.Cinco);

        // Industria Entretenimiento
        Empresa empresa21 = new Empresa(39, Industria.Entretenimiento, "Hotel", 4000, 1000, 800, Categoria.Cuatro);
        Empresa empresa22 = new Empresa(40, Industria.Entretenimiento, "Cine", 3000, 750, 600, Categoria.Tres);
        Empresa empresa23 = new Empresa(42, Industria.Entretenimiento, "Casino", 5000, 1250, 1000, Categoria.Cinco);
        Empresa empresa24 = new Empresa(44, Industria.Entretenimiento, "Karaoke", 1000, 250, 200, Categoria.Una);
        Empresa empresa25 = new Empresa(45, Industria.Entretenimiento, "Pub", 2000, 500, 400, Categoria.Dos);

        // Constructor por defecto
        public Tablero()
        {
            efectoAleatorio = new Random();
            casillas = new List<string>();
            empresas = new Dictionary<int, Empresa>();
            metodoCasillaActual = new Dictionary<string, Callback>();

            iniciarTablero();
            tamaño = casillas.Count;
            
            metodoCasillaActual["CasillaLibre"] = casillaLibre;
            metodoCasillaActual["Inicio"] = agregarDinero;
            metodoCasillaActual["Carcel"] = penalizacionCarcel;
            metodoCasillaActual["IrCarcel"] = irCarcel;
            metodoCasillaActual["Drop"] = drop;
            metodoCasillaActual["Empresa"] = casillaEmpresa;
            metodoCasillaActual["Penalizacion"] = casillaPenalizacion;          
        }
        
        //Tablero a base de casillas
        public void iniciarTablero()
        {
            //Primer tablero utilizado

            // Industria Comida
            empresas[3] = empresa1;
            empresas[4] = empresa2;
            empresas[6] = empresa3;
            empresas[7] = empresa4;
            empresas[8] = empresa5;

            // Industria transporte
            empresas[11] = empresa6;
            empresas[12] = empresa7;
            empresas[14] = empresa8;
            empresas[15] = empresa9;
            empresas[17] = empresa10;

            // Industria Tecnología
            empresas[19] = empresa11;
            empresas[20] = empresa12;
            empresas[22] = empresa13;
            empresas[23] = empresa14;
            empresas[24] = empresa15;

            // Industria Textil
            empresas[27] = empresa16;
            empresas[29] = empresa17;
            empresas[31] = empresa18;
            empresas[33] = empresa19;
            empresas[34] = empresa20;

            // Industria Entretenimiento
            empresas[39] = empresa21;
            empresas[40] = empresa22;
            empresas[42] = empresa23;
            empresas[44] = empresa24;
            empresas[45] = empresa25;

            // Orden de Primer tablero
            casillas.Add("Inicio");  
            casillas.Add("Penalizacion");
            casillas.Add("CasillaLibre");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("CasillaLibre");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("CasillaLibre");

            casillas.Add("Drop");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Penalizacion");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Carcel");
            casillas.Add("Empresa");
            casillas.Add("CasillaLibre");
            casillas.Add("Empresa");

            casillas.Add("Empresa");
            casillas.Add("CasillaLibre");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Penalizacion");
            casillas.Add("Drop");
            casillas.Add("Empresa");
            casillas.Add("IrCarcel");
            casillas.Add("Empresa");

            casillas.Add("CasillaLibre");
            casillas.Add("Empresa");
            casillas.Add("Penalizacion");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("CasillaLibre");
            casillas.Add("Drop");
            casillas.Add("CasillaLibre");
            casillas.Add("IrCarcel");
            casillas.Add("Empresa");

            casillas.Add("Empresa");
            casillas.Add("Penalizacion");
            casillas.Add("Empresa");
            casillas.Add("CasillaLibre");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Drop");
            casillas.Add("CasillaLibre");

            tamaño = casillas.Count;
        }
        public void reducirTablero()
        {
           
            // Limpiar empresas para insertar siguiente tablero 
            empresas.Clear();
            empresa1.posicion = 2;
            empresa2.posicion = 3;
            empresa3.posicion = 4;
            empresa4.posicion = 5;
            empresa5.posicion = 6;
            empresa6.posicion = 7;
            empresa7.posicion = 8;
            empresa8.posicion = 9;
            empresa9.posicion = 11;
            empresa10.posicion = 12;
            empresa11.posicion = 14;
            empresa12.posicion = 15;
            empresa13.posicion = 17;
            empresa14.posicion = 18;
            empresa15.posicion = 19;
            empresa16.posicion = 20;
            empresa17.posicion = 21;
            empresa18.posicion = 22;
            empresa19.posicion = 23;
            empresa20.posicion = 24;
            empresa21.posicion = 25;
            empresa22.posicion = 27;
            empresa23.posicion = 28;
            empresa24.posicion = 30;
            empresa25.posicion = 31;

            // Segundo tablero utilizado

            // Industria Comida
            empresas[2] = empresa1;
            empresas[3] = empresa2;
            empresas[4] = empresa3;
            empresas[5] = empresa4;
            empresas[6] = empresa5;

            // Industria Transporte
            empresas[7] = empresa6;
            empresas[8] = empresa7;
            empresas[9] = empresa8;
            empresas[11] = empresa9;
            empresas[12] = empresa10;

            // Industria Tecnología
            empresas[14] = empresa11;
            empresas[15] = empresa12;
            empresas[17] = empresa13;
            empresas[18] = empresa14;
            empresas[19] = empresa15;

            // Industria Textil
            empresas[20] = empresa16;
            empresas[21] = empresa17;
            empresas[22] = empresa18;
            empresas[23] = empresa19;
            empresas[24] = empresa20;

            // Industria Entretenimiento
            empresas[25] = empresa21;
            empresas[27] = empresa22;
            empresas[28] = empresa23;
            empresas[30] = empresa24;
            empresas[31] = empresa25;

            //Limpiar el orden del tablero para ingresar siguiente
            casillas.Clear();

            // Orden de segundo tablero
            casillas.Add("Inicio");
            casillas.Add("CasillaLibre");

            for (int i = 0; i < 8; i++)
            {
                casillas.Add("Empresa");
            }

            casillas.Add("Drop");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Penalizacion");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("Carcel");

            for (int i = 0; i < 9; i++)
            {
                casillas.Add("Empresa");
            }

            casillas.Add("Drop");
            casillas.Add("Empresa");
            casillas.Add("Empresa");
            casillas.Add("IrCarcel");
            casillas.Add("Empresa");
            casillas.Add("Empresa");

            tamaño = casillas.Count;
        }
        // Hace que el jugador avanze segun el valor obtenido de los dados
        public void tirarDados(Jugador jugador)
        {
            dado.lanzar();           
            int movimientos = dado.getValor();
            moverPosicion(jugador, movimientos);
        }
        // Manda el mensaje adecuado para las acciones realizadas por el jugador
        public void mostrarInformacionTablero(Jugador jugador)
        {
            int posicion = jugador.Posicion;
            string casillaActual = casillas[posicion];

            if (casillaActual == "Empresa")
            {      
                Empresa empresa = empresas[posicion];
                MessageBox.Show("       " + jugador.nombre + " sacó un: " + dado.getValor() +"\n\n   "+ "Se mueve a " + empresa.nombre + "\n");
            }         
            else if (casillaActual == "IrCarcel")
            {
                MessageBox.Show("       " + jugador.nombre + " sacó un: " + dado.getValor() + "\n\n   " + "Es enviado a la Carcel!\n", "Directo a la cárcel");
            }
            else if (casillaActual == "Carcel")
            {
                MessageBox.Show("       " + jugador.nombre + " sacó un: " + dado.getValor() + "\n\n   " + "A la carcel.\n", "Cárcel");
            }
            else
            {
                MessageBox.Show("       " + jugador.nombre + " sacó un: " + dado.getValor()+ "\n\n   " + " Se mueve a " + casillaActual);
            }
        }
        // Mueve al jugador a la casilla asignada, en caso de estar en la carsel indica cuantos turnos faltan para salir de ahí
        public void moverPosicion(Jugador jugador, int movimientos)
        {
            if (jugador.RondasPenalizadas > 0)
            {
                MessageBox.Show("A "+jugador.nombre + " le quedan " + (jugador.RondasPenalizadas).ToString() + " para salir de la cárcel.\n");
                jugador.RondasPenalizadas--;
            }
            else
            {
                jugador.Posicion += movimientos;
                if (jugador.Posicion >= tamaño)
                {
                    jugador.Posicion -= tamaño;
                }
                mostrarInformacionTablero(jugador);
                sinergiaTransporte(jugador);         
                AccionJugador(jugador);
            }
        }
        // Segun lo que le ocurra a jugador, seleccionara el metodo decuado a realizar
        public void AccionJugador(Jugador jugador)
        {
            string casillaActual = casillas[jugador.Posicion];
            metodoCasillaActual[casillaActual](jugador);
        }
        public void casillaLibre(Jugador jugador) {}
        // Da una penalizacion de dineri a una jugador, dependiendo de una numero aleatorio.
        public void casillaPenalizacion(Jugador jugador)
        {
            if (jugador.cantidadPorIndustrias.ContainsKey(Industria.Textil) && jugador.cantidadPorIndustrias[Industria.Textil] > 1)
            {
                MessageBox.Show("¡ No te afectan las penalizaciones !", "Activacion de sinegia Textil");
            }
            else
            {
                int penalizacion = efectoAleatorio.Next(5);
                if (penalizacion == 0)
                {
                    MessageBox.Show(jugador.nombre + ", Un desastre natural afecto una de tus empresas. Pierdes $400 por reparaciones\n", "Penalización");
                    modificarDinero(jugador, -400);
                }
                else if (penalizacion == 1)
                {
                    MessageBox.Show(jugador.nombre + ", Multa por incumplimiento de contrato con uno de sus clientes. Te cobran $600!\n", "Penalización");
                    modificarDinero(jugador, -600);
                }
                else if (penalizacion == 2)
                {
                    MessageBox.Show(jugador.nombre + ", Pago de impuestos. Te cobran $800\n", "Penalización");
                    modificarDinero(jugador, -800);
                }
                else if (penalizacion == 3)
                {
                    MessageBox.Show(jugador.nombre + ", Una de tus empresas perdio un gran negocio. Pierdes $1000!\n", "Penalización");
                    modificarDinero(jugador, -1000);
                }
                else
                {
                    MessageBox.Show("¡"+jugador.nombre + " ha echo negocios ilícitos. A la carcel Pillin!\n", "Penalización");
                    irCarcel(jugador);
                }
            }
        }
        // Añade dinero al jugador (usado para la casilla de inicio)
        public void agregarDinero(Jugador jugador)
        {
            jugador.agregarDinero(2000);
            MessageBox.Show(jugador.nombre + " recibió $2000\n");
        }
        // Resta dinero al jugador y manda mensaje correspondiente
        public void penalizacionCarcel(Jugador jugador)
        {
            if (jugador.cantidadPorIndustrias.ContainsKey(Industria.Tecnologia) && jugador.cantidadPorIndustrias[Industria.Tecnologia] > 1)
            {
                MessageBox.Show("Evitas ir a la cárcel", "Activacion de sinergia Tecnologia");
            }
            else
            {
                if (jugador.Dinero > 0)
                {
                    if (MessageBox.Show("¿ Quieres evitar perder 3 turnos pagando la fianza de $1000 ?", "Pagar fianza", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        modificarDinero(jugador, -1000);
                    }
                    else
                    {
                        jugador.RondasPenalizadas = jugador.RondasPenalizadas + 3;
                        MessageBox.Show(jugador.nombre + ", Estafar no es el camino, quedas encerrado por 3 turnos\n");
                    }
                }
                else
                {
                    jugador.RondasPenalizadas = jugador.RondasPenalizadas + 3;
                    MessageBox.Show(jugador.nombre + ", Estafar no es el camino, quedas encerrado por 3 turnos\n");
                }
            }
        }
        // Posiciona al jugador en la casilla de carcel y llama al metodo penalizacionCarcel
        public void irCarcel(Jugador jugador)
        {
            if (jugador.cantidadPorIndustrias.ContainsKey(Industria.Tecnologia) && jugador.cantidadPorIndustrias[Industria.Tecnologia] > 1)
            {       
                MessageBox.Show("Evitas ir a la cárcel","Activacion de sinergia Tecnologia");
            }
            else {
                MessageBox.Show(jugador.nombre + " ha echo negocios ilícitos. A la cárcel Pillin, multa de $1000 y pierdes un turno\n", "A la cárcel");
                jugador.Posicion = 16;
                modificarDinero(jugador, -1000);
                jugador.RondasPenalizadas = jugador.RondasPenalizadas + 1;
            }      
        }
        // Entrega beneficios o perdidas segun el drop que toque(aleatorio)
        public void drop(Jugador jugador)
        {
            int drop = efectoAleatorio.Next(5);
            if (jugador.cantidadPorIndustrias.ContainsKey(Industria.Entretenimiento) && jugador.cantidadPorIndustrias[Industria.Entretenimiento] > 2)
            {
                MessageBox.Show("Tus drops fueron potenciados","Activacion de sinergia Entretenimiento");
                if (drop == 0)
                {
                    MessageBox.Show(jugador.nombre + "! Ganaste un proyecto de emprendimiento con un premio de $2200 !\n", "Drop");
                    modificarDinero(jugador, 2200);
                }
                else if (drop == 1)
                {
                    MessageBox.Show(jugador.nombre + "! Una empresa de tu competencia ha quebrado. Ganas $3000 !\n", "Drop");
                    modificarDinero(jugador, 3000);
                }
                else if (drop == 2)
                {
                    MessageBox.Show(jugador.nombre + "! Tu campaña de marketing la esta reventando. Ganas $1800 por buena gestion !\n", "Drop");
                    modificarDinero(jugador, 1800);
                }
                else if (drop == 3)
                {
                    MessageBox.Show(jugador.nombre + "! Una de tus empresas concretó un gran negocio. Consigues $2000 !\n", "Drop");
                    modificarDinero(jugador, 2000);
                }
                else
                {
                    MessageBox.Show(jugador.nombre + "! Un inversiones a confiando en ti. Ingreso de $2400 !\n", "Drop");
                    modificarDinero(jugador, 2400);
                }
            }
            else
            {
                if (drop == 0)
                {
                    MessageBox.Show(jugador.nombre + "! Ganaste un proyecto de emprendimiento con un premio de $1200 !\n", "Drop");
                    modificarDinero(jugador, 1200);
                }
                else if (drop == 1)
                {
                    MessageBox.Show(jugador.nombre + "! Una empresa de tu competencia ha quebrado. Ganas $2000 !\n", "Drop");
                    agregarDinero(jugador);
                }
                else if (drop == 2)
                {
                    MessageBox.Show(jugador.nombre + "! Tu campaña de marketing la esta reventando. Ganas $800 por buena gestion !\n", "Drop");
                    modificarDinero(jugador, 800);
                }
                else if (drop == 3)
                {
                    MessageBox.Show(jugador.nombre + "! Una de tus empresas concretó un gran negocio. Consigues $1000 !\n", "Drop");
                    modificarDinero(jugador, 1000);
                }
                else
                {
                    MessageBox.Show(jugador.nombre + "! Un inversiones a confiando en ti. Ingreso de $1400 !\n", "Drop");
                    modificarDinero(jugador, 1400);
                }
            }
        }
        // Actualiza el dinero de un jugador
        public void modificarDinero(Jugador jugador, int dinero)
        {
            jugador.agregarDinero(dinero); ;
            // En caso de restar dinero y el jugador pasa a valores negativos lo saca del juego
            if (jugador.Dinero < 0)
            {
                jugador.Bancarota = true;
                MessageBox.Show(jugador.nombre + " Salio de la partida. \n");
            }
        }
        // Permite verificar el estado de casilla y verificar si un jugador es apto o no para comprar(Empresas o Acciones)
        public void casillaEmpresa(Jugador jugador)
        {
            // Localiza la empresa en la que se encuentra el jugador
            Empresa empresa = empresas[jugador.Posicion];

            if (empresa.dueño == null)
            {
                if (jugador.Dinero >= empresa.precio)
                {
                    jugador.ComprarEmpresa = true;
                }
            }
            else if (empresa.dueño != jugador)
            {
                int total;
               
                total = empresa.venta + (empresa.acciones*empresa.precioAccion); // Total = valor de Empresa + (Valor de accion * Precio accion) 
                jugador.agregarDinero(-total);
                empresa.dueño.agregarDinero(total);
                MessageBox.Show(jugador.nombre + " paga " + total + " a " + empresa.dueño.nombre + "\n");

                if (jugador.Dinero < 0)
                {
                    jugador.Bancarota = true;
                    MessageBox.Show(jugador.nombre + " terminó su carrera por bancarota\n");
                }
            }
            // El jugador puede comprar acciones cuando tres empresas de la misma categoria son de su propiedad.
            else if (jugador.cantidadPorCategorias[empresa.categoria] > 1 && empresa.acciones < 3) // minimo 3 empresas de misma categoria, maximo 3 acciones 
            {
                if (jugador.Dinero >= empresa.precioAccion)
                {
                    jugador.ComprarAccion = true;
                    MessageBox.Show(jugador.nombre + " puede comprar acciones");
                }
            }
        }
        // Indica el dueño de la empresa
        public void comprarEmpresa(Jugador jugador, Empresa empresa)
        {
            // Resta al jugador el dinero que vale comprar la empresa
            jugador.agregarDinero(-empresa.precio);

            // En caso de que el jugador quede sin dinero, este pierde
            if (jugador.Dinero < 0)
            {
                jugador.Bancarota = true;
            }
            // Asigna un dueño a la empresa que se está comprando
            empresa.dueño = jugador;
            MessageBox.Show(jugador.nombre + " compra " + empresa.nombre + "\n");      
            
            // Sinergia Industria
            if (jugador.cantidadPorIndustrias.ContainsKey(empresa.industria))
            {    
                jugador.cantidadPorIndustrias[empresa.industria]++;
                if (jugador.cantidadPorIndustrias[empresa.industria] == 2)
                {
                    if (empresa.industria == Industria.Comida)
                    {
                        MessageBox.Show(jugador.nombre + ", ahora tienes la sigeneria de " + empresa.industria + ":\n\n" + "Las casillas libres dan bonificacion");
                    }
                    else if (empresa.industria == Industria.Tecnologia)
                    {
                        MessageBox.Show(jugador.nombre + ", ahora tienes la sigeneria de " + empresa.industria +":\n\n" + "Evitas ir a la carcel");
                    }
                    else if (empresa.industria == Industria.Transporte)
                    {
                        MessageBox.Show(jugador.nombre + ", ahora tienes la sigeneria de " + empresa.industria + ":\n\n" + "Puedes moverte un espacio adicional");
                    }
                    else if (empresa.industria == Industria.Entretenimiento)
                    {
                        MessageBox.Show(jugador.nombre + ", ahora tienes la sigeneria de " + empresa.industria + ":\n\n" + "Se potencia la bonificacion de los drops");
                    }
                    else
                    {
                        MessageBox.Show(jugador.nombre + ", ahora tienes la sigeneria de " + empresa.industria + ":\n\n" + "No te afectan las penalizaciones");
                    }
                }
            }
            else
            {
                jugador.cantidadPorIndustrias[empresa.industria] = 1;
            }

            if (jugador.cantidadPorCategorias.ContainsKey(empresa.categoria))
            {
                jugador.cantidadPorCategorias[empresa.categoria]++;
                if (jugador.cantidadPorCategorias[empresa.categoria] == 2)
                {
                    MessageBox.Show(jugador.nombre + ", ahora podras comprar acciones de esta categoria.");
                }
            }
            else
            {
                jugador.cantidadPorCategorias[empresa.categoria] = 1;
            }
        }
        // Agrega las acciones de una empresa a su dueño correspondiente
        public void comprarAcciones(Jugador jugador, Empresa empresa)
        {
            MessageBox.Show(jugador.nombre + " compra una accion de " + empresa.nombre + "\n");
            jugador.agregarDinero(-empresa.precioAccion);

            if (jugador.Dinero < 0)
            {
                jugador.Bancarota = true;
            }
            empresa.acciones++;
        }
        // Devuelve el estado derrota
        public bool derrota(Jugador jugador)
        {
            return jugador.Dinero < 0;
        }
        public void sinergiaTransporte(Jugador jugador)
        {
            // Segun la cantidad de industrias que posea un jugador, le permite avanzar un espacio extra
            if (jugador.cantidadPorIndustrias.ContainsKey(Industria.Transporte))
            {
                if (jugador.cantidadPorIndustrias[Industria.Transporte] > 1)
                {
                    if (MessageBox.Show("¿Quieres avazar un espacio adiconal?", "Activacion de sinergia Transporte", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                      
                        if (jugador.Posicion == tamaño-1)
                        {
                            jugador.Posicion = 0;
                        } 
                        else
                        {
                            jugador.Posicion++;
                        }                      
                    }
                }
            }
        }
    }
}
