using Sandchips.DAL;
using Sandchips.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Sandchips.Formularios
{
    public partial class Recuperar : Form
    {
        public Recuperar()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Chequeo_Mesa = new Log_in_general();
            Chequeo_Mesa.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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

        public bool ValidarUsu()
        {
            bool validar = false;
            if (txtusuario.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo usuario es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (mtbcontrasena.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo contraseña es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (mtbconfirmcontrasena.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo confirmar contraseña es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (mtbconfirmcontrasena.Text == mtbcontrasena.Text)
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("Las contraseñas no coinciden", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            } 
            
            return validar;
        }

        private void Usuarios_LocationChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        { 
        }

      
        //GUARDAR USUARIO
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtusuario.Text != "" && mtbcontrasena.Text == mtbconfirmcontrasena.Text)
            {
                try
                {
                    var model = DALUsuarios.ObtenerCorreo(txtusuario.Text);
                    if (model != null)
                    {
                        var correo = "diegoalrama@gmail.com";
                        var fromAddress = new MailAddress("sandchips.hotel.restaurant@gmail.com", "Sandchip's Hotel & Restaurant");
                        var toAddress = new MailAddress(model.Correo, model.Usuario);
                        const string fromPassword = "sandchips2018";
                        const string subject = "Cambio de contraseña";
                        const string body = "Su nueva contraseña : ";
                        var contra = DALUsuarios.ModificarContra(HassPassword(mtbcontrasena.Text), txtusuario.Text);
                        if (contra > 0)
                        {
                            var smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                            };
                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body + mtbcontrasena.Text
                            })
                            {
                                smtp.Send(message);
                            }
                            MessageBox.Show("Contraseña modificada exitosamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("La contraseña ha sido enviada al correo vinculado con la cuenta de este usuario", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, usuario no existente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recuperar la contraseña, verifique su conexión -" + ex);
                }
            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados");
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbconfirmcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Correo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {
            txtusuario.Text.TrimStart();
        }

        private void cmbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbTipoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbcontrasena_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtbcontrasena.Text.TrimStart();
        }

        private void mtbconfirmcontrasena_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtbconfirmcontrasena.Text.TrimStart();
        }

      
        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
