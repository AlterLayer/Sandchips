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

namespace Sandchips.Formularios
{
    public partial class Usuarios : Form
    {
        public Usuarios()
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
            Form Chequeo_Mesa = new inicio();
            Chequeo_Mesa.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarUsu())
            {
                ModelUsuario model = new ModelUsuario(); 
                model.Usuario = txtusuario.Text;
                model.password = HassPassword(mtbcontrasena.Text);
               model.Id_Persona = Convert.ToInt32(cmbPersona.SelectedValue);
                model.Tipo_Usuario = Convert.ToInt32(cmbtipousuario.SelectedValue);
                model.estado = Convert.ToInt32(cmbestado.SelectedValue);
                int datos = DALUsuarios.agregarusuario(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvusuarios.DataSource = DALUsuarios.mostrartabla();
                    txtusuario.Clear();
                    mtbcontrasena.Clear();
                    mtbconfirmcontrasena.Clear();
                    cmbestado.SelectedIndex = 0;
                    cmbPersona.SelectedIndex = -1;
                    cmbtipousuario.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("Registro no ingresado", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("", "Operacón fallida", MessageBoxButtons.OK);
            }
        }

        public enum Mode
        {
            ENCRYPT, 
            DECRYPT
        }

        public static byte[] AESCrypto(Mode mode, AesCryptoServiceProvider aes, byte[] message)
        {
            using (var memStream = new MemoryStream())
            {
                CryptoStream cryptostream = null;

                if (mode == Mode.ENCRYPT)
                    cryptostream = new CryptoStream(memStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                else if (mode == Mode.DECRYPT)
                    cryptostream = new CryptoStream(memStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                if (cryptostream == null)
                    return null;

                cryptostream.Write(message, 0, message.Length);
                cryptostream.FlushFinalBlock();
                return memStream.ToArray();
            }
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
            if (cmbPersona.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo persona es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (cmbestado.SelectedIndex > 0)
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo estado es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (cmbtipousuario.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo tipo usuario es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            return validar;
        }

        private void Usuarios_LocationChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            dgvusuarios.DataSource = DALUsuarios.mostrartabla(); 
            Conexion.obtenerconexion();
            cmbPersona.DataSource = DALUsuarios.ObtenerPersona();
            cmbPersona.DisplayMember = "Persona";
            cmbPersona.ValueMember = "Id_Persona";
            cmbtipousuario.DataSource = DALUsuarios.ObtenerTipoUsuario();
            cmbtipousuario.DisplayMember = "Tipo_Usuario";
            cmbtipousuario.ValueMember = "Id_Tipo_Usuario";
            cmbestado.DataSource = DALUsuarios.ObtenerEstado();
            cmbestado.DisplayMember = "Estado";
            cmbestado.ValueMember = "Id_Estado";
            cmbPersona.SelectedIndex = -1;
            cmbtipousuario.SelectedIndex = -1;
            cmbestado.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {  //Validar contraseñas que sean iguales
            if (ValidarUsu())
            {
                ModelUsuario model = new ModelUsuario();
                model.Id_Usuario = Convert.ToInt32(txtIdUsuario.Text);
                model.Usuario = txtusuario.Text;
                model.password = HassPassword(mtbcontrasena.Text);
                model.Id_Persona = Convert.ToInt32(cmbPersona.SelectedValue);
                model.Tipo_Usuario = Convert.ToInt32(cmbtipousuario.SelectedValue);
                model.estado = Convert.ToInt32(cmbestado.SelectedValue);
                int datos = DALUsuarios.actualizar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvusuarios.DataSource = DALUsuarios.mostrartabla();
                    txtusuario.Clear();
                    mtbcontrasena.Clear();
                    mtbconfirmcontrasena.Clear();
                    cmbestado.SelectedIndex = 0;
                    cmbPersona.SelectedIndex = -1;
                    cmbtipousuario.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("Registro no modificado", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("", "Operacón fallida", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DALUsuarios.eliminar(Convert.ToInt32(txtIdUsuario.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvusuarios.DataSource = DALUsuarios.mostrartabla();
        }

        private void dgvusuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvusuarios.CurrentRow.Index;
            txtIdUsuario.Text = dgvusuarios[0, pocision].Value.ToString();
            cmbPersona.SelectedValue = Convert.ToInt32(dgvusuarios[1, pocision].Value.ToString());
            txtusuario.Text = dgvusuarios[2, pocision].Value.ToString();
            mtbcontrasena.Text = dgvusuarios[3, pocision].Value.ToString();
            mtbconfirmcontrasena.Text = dgvusuarios[3, pocision].Value.ToString();
            cmbtipousuario.SelectedValue = Convert.ToInt32(dgvusuarios[4, pocision].Value.ToString());
            cmbestado.SelectedValue = Convert.ToInt32(dgvusuarios[5, pocision].Value.ToString());
        }
    }
}
