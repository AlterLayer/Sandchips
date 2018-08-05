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
            Form Chequeo_Mesa = new Menu_Hotel();
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
            if (cmbTipoDocumento.SelectedIndex > 0)
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
            cmbTipoDocumento.DataSource = DALUsuarios.ObtenerTipoDocumento();
            cmbTipoDocumento.DisplayMember = "Documento";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoUsuario.DataSource = DALUsuarios.ObtenerTipoUsuario();
            cmbTipoUsuario.DisplayMember = "TipoUsuario";
            cmbTipoUsuario.ValueMember = "IdTipoUsuario";
            cmbGenero.DataSource = DALUsuarios.ObtenerGenero();
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.ValueMember = "IdGenero";
            cmbTipoUsuario.SelectedIndex = 0;
            cmbTipoDocumento.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
        }

        private void dgvusuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvusuarios.CurrentRow.Index;
            txtIdUsuario.Text = dgvusuarios[0, pocision].Value.ToString();
            txtusuario.Text = dgvusuarios[1, pocision].Value.ToString();
            mtbcontrasena.Text = dgvusuarios[2, pocision].Value.ToString();
            mtbconfirmcontrasena.Text = dgvusuarios[2, pocision].Value.ToString();
            txtNombre.Text = dgvusuarios[3, pocision].Value.ToString();
            txtApellidos.Text = dgvusuarios[4, pocision].Value.ToString();
            txtCorreo.Text = dgvusuarios[5, pocision].Value.ToString();
            txtNumeroDocumento.Text = dgvusuarios[6, pocision].Value.ToString();
            txtDireccion.Text = dgvusuarios[7, pocision].Value.ToString();
            mtbTelefono.Text = dgvusuarios[8, pocision].Value.ToString();
            dtpNacimiento.Value = Convert.ToDateTime(dgvusuarios[9, pocision].Value);
            cmbTipoDocumento.SelectedValue = Convert.ToInt32(dgvusuarios[10, pocision].Value.ToString());
            cmbGenero.SelectedValue = Convert.ToInt32(dgvusuarios[11, pocision].Value.ToString());
            cmbTipoUsuario.SelectedValue = Convert.ToInt32(dgvusuarios[13, pocision].Value.ToString());
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            dgvusuarios.DataSource = DALUsuarios.mostrartabla();
        }

        //GUARDAR USUARIO
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarUsu())
            {
                ModelUsuario model = new ModelUsuario();
                model.Usuario = txtusuario.Text;
                model.Clave = HassPassword(mtbcontrasena.Text);
                model.Nombre = txtNombre.Text;
                model.Apellidos = txtApellidos.Text;
                model.Correo = txtCorreo.Text;
                model.NumeroDocumento = txtNumeroDocumento.Text;
                model.Direccion = txtDireccion.Text;
                model.Telefono = mtbTelefono.Text; 
                var fecN = dtpNacimiento.Text.Split('/')[2] + "-" + dtpNacimiento.Text.Split('/')[1] + "-" + dtpNacimiento.Text.Split('/')[0];
                model.Nacimiento = fecN;
                model.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
                model.IdTipoUsuarios = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                model.IdGenero = Convert.ToInt32(cmbGenero.SelectedValue);
                int datos = DALUsuarios.agregarusuario(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvusuarios.DataSource = DALUsuarios.mostrartabla();
                    txtusuario.Clear();
                    mtbcontrasena.Clear();
                    mtbconfirmcontrasena.Clear();
                    cmbGenero.SelectedIndex = 0;
                    cmbTipoUsuario.SelectedIndex = 0;
                    cmbTipoDocumento.SelectedIndex = 0;

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

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarUsu())
            {
                ModelUsuario model = new ModelUsuario();
                model.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                model.Usuario = txtusuario.Text;
                model.Clave = HassPassword(mtbcontrasena.Text);
                model.Nombre = txtNombre.Text;
                model.Apellidos = txtApellidos.Text;
                model.Correo = txtCorreo.Text;
                model.NumeroDocumento = txtNumeroDocumento.Text;
                model.Direccion = txtDireccion.Text;
                model.Telefono = mtbTelefono.Text;
                var fecN = dtpNacimiento.Text.Split('/')[2] + "-" + dtpNacimiento.Text.Split('/')[1] + "-" + dtpNacimiento.Text.Split('/')[0];
                model.Nacimiento = fecN;
                model.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
                model.IdTipoUsuarios = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                model.IdGenero = Convert.ToInt32(cmbGenero.SelectedValue);
                int datos = DALUsuarios.actualizar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvusuarios.DataSource = DALUsuarios.mostrartabla();
                    txtusuario.Clear();
                    mtbcontrasena.Clear();
                    mtbconfirmcontrasena.Clear();
                    cmbGenero.SelectedIndex = 0;
                    cmbTipoUsuario.SelectedIndex = 0;
                    cmbTipoDocumento.SelectedIndex = 0;

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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DALUsuarios.eliminar(Convert.ToInt32(txtIdUsuario.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvusuarios.DataSource = DALUsuarios.mostrartabla();
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbconfirmcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text.TrimStart();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            txtApellidos.Text.TrimStart();
        }

        private void Correo_TextChanged(object sender, EventArgs e)
        {
            txtCorreo.Text.TrimStart();
        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            txtNumeroDocumento.Text.TrimStart();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.Text.TrimStart();
        }
    }
}
