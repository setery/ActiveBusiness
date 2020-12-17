using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveBusiness.Enums;

namespace ActiveBusiness.Clases
{
    public class Jugador
    {
        public string nombre;
        public int numero;
        private int dinero;                         
        private bool bancarota;                               
        private int posicion;                               
        private int rondasPenalizadas;                                                                                                                
        private bool comprarEmpresa;                         
        private bool venderEmpresa { get; set; }                  
        private bool comprarAccion;                           
        private bool venderAccion { get; set; }
        public Dictionary<Industria, int> cantidadPorIndustrias;          
        public Dictionary<Categoria, int> cantidadPorCategorias;

        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        public int RondasPenalizadas
        {
            get { return rondasPenalizadas; }
            set { rondasPenalizadas = value; }
        }
        public int Dinero
        {
            get { return dinero; }
            set { dinero = value; }
        }
        public bool Bancarota
        {
            get { return bancarota; }
            set { bancarota = value; }
        }
        public bool ComprarEmpresa
        {
            get { return comprarEmpresa; }
            set { comprarEmpresa = value; }
        }
        public bool ComprarAccion
        {
            get { return comprarAccion; }
            set { comprarAccion = value; }
        }
        //Añade el dinero a la cuenta del jugador
        public void agregarDinero(int dinero)
        {
            this.dinero += dinero;
        }
        // Constructor para nombre jugador y parametros defecto 
        public Jugador(string n)
        {
            this.nombre = n;
            this.bancarota = false;
            this.dinero = 18000;
            this.posicion = 0;
            this.rondasPenalizadas = 0;
            this.cantidadPorIndustrias = new Dictionary<Industria, int>();
            this.cantidadPorCategorias = new Dictionary<Categoria, int>();
            this.comprarEmpresa = false;
            this.comprarAccion = false;
            this.venderAccion = false;
            this.venderEmpresa = false;
        }
    }
}
