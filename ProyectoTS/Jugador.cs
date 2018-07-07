using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTS
{
    public class Jugador
    {
        public string nick;
        public int tropas;
        public List<Territorio> conquistados;

        public Jugador(string n)
        {
            nick = n;
            tropas = 5;
            conquistados = new List<Territorio>();
        }

        public Jugador()
        {
            nick = "IA";
            tropas = 5;
            conquistados = new List<Territorio>();
        }
    }
}
