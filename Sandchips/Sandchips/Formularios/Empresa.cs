using Sandchips.DAL;
using Sandchips.Models;
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
    public partial class empresa : Form
    {
        public empresa()
        {
            InitializeComponent();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
            dgvTipoEmpresa.DataSource = DALTipoEmpresa.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipoEmpresa.DataSource = DALEmpresa.ObtenerTipoEmpresa();
            cmbTipoEmpresa.DisplayMember = "TipoEmpresa";
            cmbTipoEmpresa.ValueMember = "IdTipoEmpresa";
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnModificarT.Enabled = false;
            btnEliminarT.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Servicios = new Chequeo_habitaciones();
            Servicios.Show();
            this.Hide();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool ValidarEmpresa()
        {
            bool validar = false;
            if (txtEmpresa.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo nombre de servicio es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (txtNRC.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo nrc es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (Convert.ToInt32(cmbTipoEmpresa.SelectedIndex) > 0)
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo tipo de servicio es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            return validar;

        }
        public bool ValidarTipoEmpresa()
        {
            bool validar = false;
            if (txtTipoEmpresa.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo tipo empresa es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            return validar;

        }




        private void btnBuscar_TS_Click(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALTipoEmpresa.buscar(txtBuscarE.Text);
        }



        private void pEmpresas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form tipos_de_habitaciones = new Menu_Hotel();
            tipos_de_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        //AGREGAR EMPRESA
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                //Validar contraseñas que sean iguales
                if (ValidarEmpresa())
                {
                    ModelEmpresa model = new ModelEmpresa();
                    model.Empresa = txtEmpresa.Text;
                    var vnrc1 = txtNRC.Text.TrimStart();
                    var vnrc2 = vnrc1.TrimEnd();
                    model.NRC = vnrc2;
                    model.NIT = txtNIT.Text;
                    model.Direccion = txtDescripcion.Text;
                    model.Correo = txtCorreo.Text;
                    model.RegistroIVA = txtRegistroIVA.Text;
                    model.RegistroAuditor = txtRegistroAuditor.Text;
                    model.IdTipoEmpresa = Convert.ToInt32(cmbTipoEmpresa.SelectedValue);
                    int datos = DALEmpresa.agregar(model);
                    if (datos > 0)
                    {
                        MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
                        txtEmpresa.Clear();
                        cmbTipoEmpresa.SelectedIndex = 0;
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
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MODIFICAR EMPRESA
        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                //Validar contraseñas que sean iguales
                if (ValidarEmpresa())
                {
                    ModelEmpresa model = new ModelEmpresa();
                    model.IdEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
                    model.Empresa = txtEmpresa.Text;
                    model.NRC = txtNRC.Text;
                    model.NIT = txtNIT.Text;
                    model.Direccion = txtDescripcion.Text;
                    model.Correo = txtCorreo.Text;
                    model.RegistroIVA = txtRegistroIVA.Text;
                    model.RegistroAuditor = txtRegistroAuditor.Text;
                    model.IdTipoEmpresa = Convert.ToInt32(cmbTipoEmpresa.SelectedValue);
                    int datos = DALEmpresa.modificar(model);
                    if (datos > 0)
                    {
                        MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
                        txtEmpresa.Clear();
                        cmbTipoEmpresa.SelectedIndex = 0;
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
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ELIMINAR EMPRESA
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            ModelEmpresa model = new ModelEmpresa();
            model.IdEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
            DALEmpresa.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MOSTRAR DATOS EMPRESA
        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvEmpresas.CurrentRow.Index;
            txtIdEmpresa.Text = dgvEmpresas[0, pocision].Value.ToString();
            txtEmpresa.Text = dgvEmpresas[1, pocision].Value.ToString();
            txtNRC.Text = dgvEmpresas[2, pocision].Value.ToString();
            txtNIT.Text = dgvEmpresas[3, pocision].Value.ToString();
            txtDescripcion.Text = dgvEmpresas[4, pocision].Value.ToString();
            txtCorreo.Text = dgvEmpresas[5, pocision].Value.ToString();
            cmbTipoEmpresa.Text = dgvEmpresas[6, pocision].Value.ToString();
            txtRegistroIVA.Text = dgvEmpresas[7, pocision].Value.ToString();
            txtRegistroAuditor.Text = dgvEmpresas[8, pocision].Value.ToString();
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        //CONSUTLAR EMPRESAS
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
        }

        //BUSCAR EMPRESA
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALEmpresa.buscar(txtBuscarE.Text);
        }


        //METODOS TIPO EMPRESA--------------------------------
        //AGREGAR TIPO EMPRESA
        private void button5_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                //Validar contraseñas que sean iguales
                if (ValidarTipoEmpresa())
            {
                ModelTipoEmpresa model = new ModelTipoEmpresa();
                model.TipoEmpresa = txtTipoEmpresa.Text;
                int datos = DALTipoEmpresa.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoEmpresa.DataSource = DALTipoEmpresa.mostrartabla();
                    txtTipoEmpresa.Clear();
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
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MODIFICAR TIPO EMPRESA
        private void btnModificarT_Click(object sender, EventArgs e)
        {  //Validar contraseñas que sean iguales
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (ValidarTipoEmpresa())
            {
                ModelTipoEmpresa model = new ModelTipoEmpresa();
                model.IdTipoEmpresa = Convert.ToInt32(txtIdTipoEmpresaT.Text);
                model.TipoEmpresa = txtTipoEmpresa.Text;
                int datos = DALTipoEmpresa.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoEmpresa.DataSource = DALTipoEmpresa.mostrartabla();
                    txtTipoEmpresa.Clear();
                    txtIdTipoEmpresaT.Clear();
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
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ELMINAR TIPO EMPRESA
        private void btnEliminarT_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            int id = Convert.ToInt32(txtIdEmpresa.Text);
            int respuesta = DALTipoEmpresa.eliminar(id);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTipoEmpresa.DataSource = DALTipoEmpresa.mostrartabla();
            txtTipoEmpresa.Clear();
            txtIdTipoEmpresaT.Clear();
            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultatT_Click(object sender, EventArgs e)
        {
            dgvTipoEmpresa.DataSource = DALTipoEmpresa.mostrartabla();
        }

        //Mostrar datos tipo empresa
        private void dgvTipoEmpresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvTipoEmpresa.CurrentRow.Index;
            txtIdTipoEmpresaT.Text = dgvTipoEmpresa[0, pocision].Value.ToString();
            txtTipoEmpresa.Text = dgvTipoEmpresa[1, pocision].Value.ToString();
            btnEliminarT.Enabled = true;
            btnModificarT.Enabled = true;
            btnAgregarT.Enabled = false;
        }

        private void btnBuscarT_Click(object sender, EventArgs e)
        {
            dgvTipoEmpresa.DataSource = DALTipoEmpresa.buscar(txtBuscarT.Text);
        }

        private void txtIdEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            txtEmpresa.Text.TrimStart();
        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRegistroIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRegistroAuditor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbTipoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarE_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtTipoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNRC_TextChanged(object sender, EventArgs e)
        {
            txtNRC.Text.TrimStart();
            txtNRC.Text.TrimEnd();
        }

        private void txtNIT_TextChanged(object sender, EventArgs e)
        {
            txtNIT.Text.TrimStart();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text.TrimStart();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            txtCorreo.Text.TrimStart();
        }

        private void txtRegistroIVA_TextChanged(object sender, EventArgs e)
        {
            txtRegistroIVA.Text.TrimStart();
        }

        private void txtRegistroAuditor_TextChanged(object sender, EventArgs e)
        {
            txtRegistroAuditor.Text.TrimStart();
        }

        private void txtBuscarE_TextChanged(object sender, EventArgs e)
        {
            txtBuscarE.Text.TrimStart();
        }

        private void btnAgregar_MouseMove(object sender, MouseEventArgs e)
        {
            btnAgregar.BackColor = Color.Black;
            btnAgregar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.FromArgb(190, 239, 158);
            btnAgregar.ForeColor = Color.Black;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtEmpresa.Text = "";
            txtIdEmpresa.Text = "";
            txtNRC.Text = "";
            txtNIT.Text = "";
            txtDescripcion.Text = "";
            txtCorreo.Text = "";
            txtRegistroIVA.Text = "";
            txtRegistroAuditor.Text = "";
            cmbTipoEmpresa.SelectedIndex = 0;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;

        }

        private void btnlimpiarcampos_Click(object sender, EventArgs e)
        {
            txtIdTipoEmpresaT.Text = "";
            txtTipoEmpresa.Text = "";
            btnAgregar.Enabled = true;
            btnModificarT.Enabled = false;
            btnEliminarT.Enabled = false;
        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtIdTipoEmpresaT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipoEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarT_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTipoEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
