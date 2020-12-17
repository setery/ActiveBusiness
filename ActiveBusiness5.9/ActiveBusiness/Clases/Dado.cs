using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveBusiness.Clases
{
    public class Dado
    {

        private Random random;        
        private int dado1;     
        private int dado2;     

        public Dado()
        {
            random = new Random();
        }

        //Genera un numero random
        public void lanzar()
        {
            dado1 = random.Next(1, 7);
            dado2 = random.Next(1, 7);
        }
        //Entrega el valor de los dados en un string
        public String toString()
        {
            return "Sacaste un: " + (dado1 + dado2);
        }
        //devuelve el valor de la suma de los dos dados
        public int getValor()
        {
            return (dado1 + dado2);
        }
    }
}
