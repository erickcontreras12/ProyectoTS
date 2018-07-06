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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Boton para terminar el turno y que se ejecuten todos los 
        /// movimientos guardados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (ClaseGeneral.nuevoJuego.player1.tropas > 0)
            {
                MessageBox.Show("Aun tiene tropas disponibles, debe utilizarlas");
            }
            else
            {
                /*ACA HAY QUE PONER EL METODO O LO QUE SEA DONDE EL IA 
                * HACE TODO SUS MOVIMIENTOS*/
                /*Con la logica que implementada en el boton5 se guardan los movs
                 del IA para que se ejecuten de manera simultanea con los
                 guardados por el jugador en el metodo de abajo */


                radioButton1.Enabled = true;
                ClaseGeneral.nuevoJuego.EjecutarMovimientos();
                cargarDatos();
            }
            
            
        }

        /// <summary>
        /// Actualiza los territorios que tiene el jugador
        /// </summary>
        private void actualizarTerritorios()
        {
            comboBox1.Items.Clear();
            foreach (Territorio item in ClaseGeneral.nuevoJuego.player1.conquistados)
            {
                comboBox1.Items.Add(item.nombre);
            }
        }

        /// <summary>
        /// Metodo para actualizar el mapa
        /// </summary>
        private void actualizarMapa()
        {
            listBox1.Items.Clear();
            foreach (Territorio item in ClaseGeneral.nuevoJuego.territorios)
            {
                listBox1.Items.Add(item.VerEstado());
            }
        }

        /// <summary>
        /// Metodo para actualizar los movimientos que se realizaron
        /// </summary>
        private void actulizarMovimientos()
        {
            listBox2.Items.Clear();
            foreach (Movimiento item in ClaseGeneral.nuevoJuego.moves)
            {
                listBox2.Items.Add(item.describirMovimiento());
            }
        }

        /// <summary>
        /// Metodo para desactivar el comboBox que posee el segundo territorio
        /// porque solo se quiere asignar, y agrega el numero de tropas disponibles
        /// que el jugaro posee para hacer la asignacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox2.Text = "";
                comboBox2.Enabled = false;
                for (int i = 0; i < ClaseGeneral.nuevoJuego.player1.tropas; i++)
                {
                    comboBox3.Items.Add(i + 1);
                }
            }
        }

        /// <summary>
        /// Metodo para activar el comoboBox que tiene la opcion al
        /// segundo territorio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox2.Enabled = true;
            }
        }


        /// <summary>
        /// Boton que guarda el movimiento, valida que no haya "errores" antes
        /// de enviar el movimiento al juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Movimiento nuevo = new Movimiento();
            int trop = 0;
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Debe seleccionar un tipo de movimiento");
            }
            else if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox3.Text)
                || (radioButton2.Checked && string.IsNullOrEmpty(comboBox2.Text)))
            {
                MessageBox.Show("No puede dejar en blanco el espacio");
            }
            else
            {
                nuevo.jugador = ClaseGeneral.nuevoJuego.player1;
                nuevo.territorio1 = ClaseGeneral.nuevoJuego.encontrarTerritorio(comboBox1.Text);
                trop = Convert.ToInt32(comboBox3.Text);
                nuevo.tropas = trop; 
                if (radioButton1.Checked)
                {
                    //Actuliza las tropas que le quedan por asignar al jugador
                    int newTropas = ClaseGeneral.nuevoJuego.player1.tropas - Convert.ToInt32(comboBox3.Text);
                    label3.Text = "Tropas disponibles: " + (newTropas);
                    ClaseGeneral.nuevoJuego.player1.tropas = newTropas;
                    
                    nuevo.descrip = "asignar";
                    ClaseGeneral.nuevoJuego.nuevoAsignar(ClaseGeneral.nuevoJuego.player1.nick, nuevo);
                }
                else if (radioButton2.Checked)
                {
                    string t1 = comboBox1.Text; string t2 = comboBox2.Text;

                    if (ClaseGeneral.nuevoJuego.validarConquistador(ClaseGeneral.nuevoJuego.encontrarTerritorio(t1), 
                        ClaseGeneral.nuevoJuego.encontrarTerritorio(t2)))
                    {
                        nuevo.descrip = "mover";
                    }
                    else
                    {
                        nuevo.descrip = "atacar";
                    }

                    nuevo.territorio2 = ClaseGeneral.nuevoJuego.encontrarTerritorio(comboBox2.Text);
                    ClaseGeneral.nuevoJuego.nuevoMovimiento(ClaseGeneral.nuevoJuego.player1.nick, nuevo);
                }
            }

            cargarDatos();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Metodo para actulizar el comboBox del segundo territorio colocando
        /// solo los vecinos del primer territorio seleccionado y agregar las tropas
        /// disponibles en este ultimo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                foreach (Territorio item in ClaseGeneral.nuevoJuego.encontrarTerritorio(comboBox1.Text).vecinos)
                {
                    comboBox2.Items.Add(item.nombre);
                }


                if (radioButton2.Checked)
                {
                    for (int i = 0; i < ClaseGeneral.nuevoJuego.encontrarTerritorio(comboBox1.Text).auxTropas; i++)
                    {
                        comboBox3.Items.Add(i + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo para limpiar los comboBox y deseleccionar los radioButton
        /// </summary>
        private void limpiarOpciones()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            comboBox3.Text = "";
            comboBox3.Items.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        /// <summary>
        /// Metodo para hacer todas las actualizaciones necesarias
        /// </summary>
        private void cargarDatos()
        {
            if (ClaseGeneral.nuevoJuego.player1.tropas == 0)
            {
                radioButton1.Enabled = false;
            }

            limpiarOpciones();
            label3.Text = "Tropas disponibles: " + ClaseGeneral.nuevoJuego.player1.tropas;
            actualizarMapa();
            actualizarTerritorios();
            actulizarMovimientos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("Realmente desea reiniciar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                ClaseGeneral.nuevoJuego.Reiniciar();
                cargarDatos();
            }
            else
            {
            }
                 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 vent1 = new Form1();
            DialogResult boton = MessageBox.Show("Realmente desea salir?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                vent1.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 vent3 = new Form3();
            vent3.Show();
        }

        
    }
}
