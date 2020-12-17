using ActiveBusiness.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveBusiness.Clases
{
    public class Empresa
    {
        public Jugador dueño;             
        public int acciones;
        public int precio;
        public int precioAccion;
        public int venta; 
        public string nombre;
        public int posicion;
        public Industria industria;
        public Categoria categoria;

        public Empresa()
        { 

        }
        // Constructor para Empresa
        public Empresa(int posicion, Industria industria, string nombre, int precio, int precioAccion, int venta, Categoria categoria)
        {
            // Instancia la empresa
            this.posicion = posicion;
            this.industria = industria;
            this.nombre = nombre;
            this.precio = precio;
            this.precioAccion = precioAccion;
            this.venta = venta;
            this.categoria = categoria;
            acciones = 0;
            dueño = null;
        }

    }

}

