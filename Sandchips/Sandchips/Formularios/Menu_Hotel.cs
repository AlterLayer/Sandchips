using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sandchips.Formularios
{
    public partial class Menu_Hotel : Form
    {
        public Menu_Hotel()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {

           
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            Form Form1 = new Usuarios();
            Form1.Show();
            this.Hide();
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {

            Form Form1 = new Clientes();
            Form1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Form1 = new Local();
            Form1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {

            Form Chequeo_habitaciones = new Habitaciones();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Hotel_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form Menu_Hotel = new inicio();
            Menu_Hotel.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox11_Click_2(object sender, EventArgs e)
        {
            Form Menu_Hotel = new Usuarios();
            Menu_Hotel.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form Menu_Hotel = new Clientes();
            Menu_Hotel.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form Menu_Hotel = new Habitaciones();
            Menu_Hotel.Show();
            this.Hide();
        }
    }
}
