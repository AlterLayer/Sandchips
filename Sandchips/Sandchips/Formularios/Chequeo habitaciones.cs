using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sandchips.DAL;

namespace Sandchips.Formularios
{
    public partial class Chequeo_habitaciones : Form
    {
        public Chequeo_habitaciones()
        { 
            InitializeComponent();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new Tiempo_de_estadia();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Form Usuarios = new Usuarios();
            Usuarios.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new empresa();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new Habitaciones();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new inicio();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Form1 = new Clientes();
            Form1.Show();
            this.Hide();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }
    }
}
