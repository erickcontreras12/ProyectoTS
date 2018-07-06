using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTS
{
    public class Territorio
    {
        public string nombre;
        public bool conquistado;
        public Jugador amo;
        public int tropas, auxTropas;
        public List<Territorio> vecinos;

        public Territorio(string n)
        {
            nombre = n;
            conquistado = false;
            amo = new Jugador();
            tropas = 0;
            auxTropas = 0;
            vecinos = new List<Territorio>();
        }

        public Territorio()
        {
            conquistado = false;
            amo = new Jugador();
            tropas = 0;
            auxTropas = 0;
            vecinos = new List<Territorio>();
        }

        public string verAdyacentes()
        {
            string mostrar = nombre + ": ";
            foreach (Territorio item in vecinos)
            {
                mostrar += item.nombre + ", ";
            }
            return mostrar;
        }

        public string VerEstado()
        {
            if (conquistado)
            {
                return "Territorio: " + nombre + " - Tropas: " + tropas
                    + " - Dueño: " + amo.nick;
            }
            return "Territorio: " + nombre + " - Tropas: " + tropas;
        }
    }
}


