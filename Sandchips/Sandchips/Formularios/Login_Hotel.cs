using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sandchips;
using Sandchips.DAL;
using Sandchips.Formularios;
using System.Security.Cryptography;
using System.IO;
using Sandchips.Models;

namespace Sandchips.Formularios
{
    public partial class Login_Hotel : Form
    {
        public Login_Hotel()
        {            
            InitializeComponent();
        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            if(txtusuario.Text.Trim() == ""|| mtbcontraseña.Text.Trim() == ""){

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
                        inicio hab = new inicio();
                        hab.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Haz introducido el usurio o contraseña incorrecta", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception " + ex);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private string HassPassword(string cadena)
        {
            //Encriptar
            //Inicializa una nueva instancia de la clase UTF8Encoding.
            UTF8Encoding enc = new UTF8Encoding();
            //Codifica todos los caracteres de la cadena en secuencia de bytes
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            //Calcula el valor criptografico de la variable "sha"
            result = sha.ComputeHash(data);

            //StringBuilder representa una cadena de caracteres
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

        private void btnacceder_Enter(object sender, EventArgs e)
        {
            

        }

        private void Login_Hotel_Enter(object sender, EventArgs e)
        {
             
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

        private void btnacceder_MouseMove(object sender, MouseEventArgs e)
        {
            btnacceder.BackColor = Color.White;
            btnacceder.ForeColor = Color.MidnightBlue;
        }

        private void btnacceder_MouseLeave(object sender, EventArgs e)
        {
            btnacceder.BackColor = Color.MidnightBlue;
            btnacceder.ForeColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnacceder_MouseMove_1(object sender, MouseEventArgs e)
        {
            btnacceder.BackColor = Color.White;
            btnacceder.ForeColor = Color.MidnightBlue;
        }

        private void btnacceder_MouseLeave_1(object sender, EventArgs e)
        {
            btnacceder.BackColor = Color.MidnightBlue;
            btnacceder.ForeColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
