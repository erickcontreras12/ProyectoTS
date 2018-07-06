using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ClaseGeneral.nuevoJuego.Inicio();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ClaseGeneral.nuevoJuego.player1.nick = "Jugador";
            }
            else
            {
                ClaseGeneral.nuevoJuego.player1.nick = textBox1.Text;
            }
            

            Form2 ven = new Form2();
            ven.Show();
            this.Hide();
        }
    }
}
