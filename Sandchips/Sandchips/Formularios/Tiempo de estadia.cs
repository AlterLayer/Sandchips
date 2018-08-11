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
    public partial class Tiempo_de_estadia : Form
    {
        public Tiempo_de_estadia()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Tiempo_de_estadia= new Chequeo_habitaciones();
            Tiempo_de_estadia.Show();
            this.Hide();
        }

        private void Tiempo_de_estadia_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
