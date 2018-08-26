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
    public partial class Introduccion : Form
    {
        public Introduccion()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form Introduccion = new Log_in_general();
            Introduccion.Show();
            this.Hide();
            timer1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Introduccion_Load(object sender, EventArgs e)
        { 
        }
    }
}
