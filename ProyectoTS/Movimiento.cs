using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTS
{
    public class Movimiento
    {
        public string descrip;
        public int numMov;
        public Jugador jugador;
        public Territorio territorio1;
        public Territorio territorio2;
        public int tropas;

        public Movimiento()
        {
            descrip = "";
            numMov = 1000;
            jugador = new Jugador();
            territorio1 = new Territorio();
            territorio2 = new Territorio();
        }

        /// <summary>
        /// Metodo que define que se hizo el en movimiento
        /// </summary>
        /// <returns></returns>
        public string describirMovimiento()
        {
            if (descrip == "asignar")
            {
                return jugador.nick + ": asignó " + tropas + " tropas en " + territorio1.nombre;
            }
            else if (descrip == "mover")
            {
                return jugador.nick + ": reforzó " + territorio2.nombre + " desde " 
                    + territorio1.nombre + " con " + tropas + " tropas";
            }
            else if (descrip == "atacar")
            {
                return jugador.nick + ": atacó " + territorio2.nombre + " desde "
                    + territorio1.nombre + " con " + tropas + " tropas";
            }
            return "";
        }
    }
}
