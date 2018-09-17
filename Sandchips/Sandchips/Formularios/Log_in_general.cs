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
    public partial class Log_in_general : Form
    {
        public new Point Location { get; set; }
        public Size tamano { get; set; }
        public Log_in_general()
        {            
            InitializeComponent();
        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnacceder_Click_1(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Hotel_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            this.WindowState = FormWindowState.Maximized;
            double porceancho = this.Width - (this.Width * 0.63);
            double porcealtura = this.Height - (this.Height * 0.90);
            double anchoimg = this.Width * 0.2641;
            double alturaimg = this.Height * 0.71;
            double ancholabelusuario = this.Width * 0.474;
            double alturalabelusuario = this.Height * 0.45;
            double ancholabelclave = this.Width * 0.465;
            double alturalabelclave = this.Height * 0.56;
            double ancholabelacceder = this.Width * 0.48;
            double alturalabelacceder = this.Height * 0.66;
            double anchobtnacceder = this.Width * 0.48;
            double alturabtnacceder = this.Height * 0.68;
            pictureBox3.Size = new Size(Convert.ToInt32(anchoimg),Convert.ToInt32(alturaimg));
            pictureBox3.Location = new Point(Convert.ToInt32(porceancho), Convert.ToInt32(porcealtura));
            label1.Location = new Point(Convert.ToInt32(ancholabelusuario),Convert.ToInt32(alturalabelusuario));
            label2.Location = new Point(Convert.ToInt32(ancholabelclave),Convert.ToInt32(alturalabelclave));
            label3.Location = new Point(Convert.ToInt32(ancholabelacceder), Convert.ToInt32(alturalabelacceder));
            btnacceder.Location = new Point(Convert.ToInt32(anchobtnacceder), Convert.ToInt32(alturabtnacceder));
            //Posicion de txtusuario
            double porceanchotxtusu = this.Width - (this.Width * 0.575);
            double porcealturatxtusu = this.Height - (this.Height * 0.52);
            txtusuario.Location = new Point(Convert.ToInt32(porceanchotxtusu), Convert.ToInt32(porcealturatxtusu));

            //Posicion de txtcontraseña
            double porceanchotxtclave = this.Width - (this.Width * 0.575);
            double porcealturatxtclave = this.Height - (this.Height * 0.40);
            mtbcontraseña.Location = new Point(Convert.ToInt32(porceanchotxtclave), Convert.ToInt32(porcealturatxtclave));


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text.Trim() != "" || mtbcontraseña.Text.Trim() != "")
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
                        DALUsuarios.ObtenerPermiso(model.Usuario);
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
            else
            {

                MessageBox.Show("Hay campos vacios", "Verifique");
            }
        }

        private void txtusuario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnacceder_Click_2(object sender, EventArgs e)
        {
            if (txtusuario.Text.Trim() != "" || mtbcontraseña.Text.Trim() != "")
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
            else
            {

                MessageBox.Show("Hay campos vacios", "Verifique");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
