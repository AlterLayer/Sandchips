using Sandchips.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandchips.Formularios
{
    public partial class inicio : Form
    {

        public inicio()
        {
            InitializeComponent();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form inicio = new Menu_Hotel();
            inicio.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form inicio = new Menu_Restaurante();
            inicio.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            /*panel1.Width = this.Width - 50;

            ImagenHotel.Height = this.Height - 360;
            ImagenHotel.Width = this.Width - 950;

            ImagenRes.Height = this.Height - 360;
            ImagenRes.Width = this.Width - 1050;
            */
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Pagina_Principal = new Menu_Hotel();
            Pagina_Principal.Show();
            this.Hide();
        }
    }
}
