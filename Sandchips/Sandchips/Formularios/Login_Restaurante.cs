using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using Sandchips.Models;
using Sandchips.DAL;

namespace Sandchips.Formularios
{
    public partial class Login_Restaurante : Form
    {
        public Login_Restaurante()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Restaurante_Reservacion_y_Chequeo = new Login_Restaurante();
            Restaurante_Reservacion_y_Chequeo.Show();
            this.Hide();
        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            try
            {
                string Contra = HassPassword(mtbcontraseña.Text);
                ModelUsuario model = new ModelUsuario();
                model.Usuario = txtusuario.Text;
                model.Clave = HassPassword(mtbcontraseña.Text);
                bool datos = DALUsuarios.IniciarSession(model);
                if (datos)
                { 
                    MessageBox.Show("Bienvenid@ " + model.Usuario, "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menu_Restaurante hab = new Menu_Restaurante();
                    hab.Show();
                    this.Hide();
                }
                else
                { 
                    MessageBox.Show("Haz introducido el nombre o contraseña incorrecta", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private string HassPassword(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // Convertimos los valores en hexadecimal, cuando tiene una cifra hay que rellenarlo con cero para que siempre ocupen dos dígitos.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            //Devolvemos la cadena con el hash en mayúsculas
            return sb.ToString().ToUpper();
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void mtbcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
