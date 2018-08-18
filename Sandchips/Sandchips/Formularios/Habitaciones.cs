using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sandchips.Models;
using Sandchips.DAL;

namespace Sandchips.Formularios
{
    public partial class Habitaciones : Form
    {
        public Habitaciones()
        { 
            InitializeComponent();
        }

        private void Habitaciones_Load(object sender, EventArgs e)
        {
        }


        private void Habitaciones_Load_1(object sender, EventArgs e)
        {
            dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipo_hab.DataSource = DALHabitaciones.ObtenerTipo_Hab();
            cmbTipo_hab.DisplayMember = "TipoHabitacion";
            cmbTipo_hab.ValueMember = "IdTipoHabitacion";
            cmbEstado_hab.DataSource = DALHabitaciones.ObtenerEstado();
            cmbEstado_hab.DisplayMember = "Estado";
            cmbEstado_hab.ValueMember = "IdEstado";
            cmbTipo_hab.SelectedIndex = 0;
            cmbEstado_hab.SelectedIndex = 0;

        }

        #region Habitacion
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form tipos_de_habitaciones = new Menu_Hotel();
            tipos_de_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            //Validar contraseñas que sean iguales
            if (ValidarHab())
            {
                ModelHabitaciones model = new ModelHabitaciones();
                model.NumeroHabitacion = Convert.ToInt32(txtNumero_hab.Text);
                model.IdTipoHabitacion = Convert.ToInt32(cmbTipo_hab.SelectedValue.ToString());
                model.IdEstado = Convert.ToInt32(cmbEstado_hab.SelectedValue.ToString()); 
                int datos = DALHabitaciones.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente","Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
                    txtNumero_hab.Clear();
                    cmbTipo_hab.SelectedIndex = 0;
                    cmbEstado_hab.SelectedIndex = 0; 
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



        public bool ValidarHab()
        {
            bool validar = false;
            if (Convert.ToInt32(txtNumero_hab.Text) > 0 && txtNumero_hab.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false; 
                MessageBox.Show("El campo número de habitación es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (Convert.ToInt32(cmbEstado_hab.SelectedIndex) > 0)
            {
                validar = true;
            }
            else
            {
                validar = false; 
                MessageBox.Show("El campo estado es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (Convert.ToInt32(cmbTipo_hab.SelectedIndex) > 0)
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo Tipo de habitación es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return validar;
            }
            return validar;

        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarHab())
            {
                ModelHabitaciones model = new ModelHabitaciones();
                model.IdHabitacion = Convert.ToInt32(txtId_hab.Text);
                model.NumeroHabitacion = Convert.ToInt32(txtNumero_hab.Text);
                model.IdTipoHabitacion = Convert.ToInt32(cmbTipo_hab.SelectedValue.ToString());
                model.IdEstado = Convert.ToInt32(cmbEstado_hab.SelectedValue.ToString());
                int datos = DALHabitaciones.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
                    txtId_hab.Clear();
                    txtNumero_hab.Clear();
                    cmbTipo_hab.SelectedIndex = 0;
                    cmbEstado_hab.SelectedIndex = 0;
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

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvHabitaciones.CurrentRow.Index;
            txtId_hab.Text = dgvHabitaciones[0, pocision].Value.ToString();
            txtNumero_hab.Text = dgvHabitaciones[1, pocision].Value.ToString();
            cmbTipo_hab.SelectedValue = Convert.ToInt32(dgvHabitaciones[2, pocision].Value.ToString());
            cmbEstado_hab.Text = dgvHabitaciones[3, pocision].Value.ToString();
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            ModelHabitaciones model = new ModelHabitaciones();
            model.IdHabitacion = Convert.ToInt32(txtId_hab.Text); 
            model.IdEstado = Convert.ToInt32(cmbEstado_hab.SelectedValue.ToString());
            DALHabitaciones.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
            txtId_hab.Clear();
            txtNumero_hab.Clear();
            cmbTipo_hab.SelectedIndex = 0;
            cmbEstado_hab.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvHabitaciones.DataSource = DALHabitaciones.buscar(Convert.ToInt32(txtBuscar_hab.Text));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
        }
        #endregion

        #region Tipo de Habitaciones

        private void btnAgregarT_Click(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarHabT())
            {
                ModelTipoHabitacion model = new ModelTipoHabitacion();
                model.TipoHabitacion = txtTipo_Habitacion.Text;
                int datos = DALTipoHabitaciones.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
                    txtTipo_Habitacion.Clear(); 
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

        private void btnModificarT_Click(object sender, EventArgs e)
        {
            if (ValidarHabT())
            {
                ModelTipoHabitacion model = new ModelTipoHabitacion();
                model.IdTipoHabitacion = Convert.ToInt32(txtId_Tipo_Habitacion.Text);
                model.TipoHabitacion = txtTipo_Habitacion.Text;
                int datos = DALTipoHabitaciones.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
                    txtTipo_Habitacion.Clear();
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

        private void btnEliminarT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            DALTipoHabitaciones.eliminar(Convert.ToInt32(txtId_Tipo_Habitacion.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
        }

        private void btnConsultarT_Click(object sender, EventArgs e)
        {
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
        }


        private void dgvTipoHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvTipoHabitacion.CurrentRow.Index;
            txtId_Tipo_Habitacion.Text = dgvTipoHabitacion[0, pocision].Value.ToString();
            txtTipo_Habitacion.Text = dgvTipoHabitacion[1, pocision].Value.ToString(); 
        }

        private void btnBuscarT_Click(object sender, EventArgs e)
        {
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.buscar(txtBuscarT.Text);
        }

        public bool ValidarHabT()
        {
            bool validar = false;
            if (txtTipo_Habitacion.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo tipo de habitación es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            } 
            return validar;
        }
        #endregion

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtId_hab_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txtNumero_hab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscar_hab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTipo_Habitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarT_TextChanged(object sender, EventArgs e)
        {
            txtBuscarT.Text.TrimStart();
        }

        private void txtBuscarT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtId_hab_TextChanged(object sender, EventArgs e)
        {

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
         

        private void tabPage1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void tabPage2_MouseMove(object sender, MouseEventArgs e)
        { 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false; 
        }

        private void cmbTipo_hab_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btnModificar_MouseMove(object sender, MouseEventArgs e)
        {
            btnModificar.BackColor = Color.Black;
            btnModificar.ForeColor = Color.FromArgb(190, 239, 158);

        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.FromArgb(190, 239, 158);
            btnModificar.ForeColor = Color.Black;
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipo_hab.DataSource = DALHabitaciones.ObtenerTipo_Hab();
            cmbTipo_hab.DisplayMember = "TipoHabitacion";
            cmbTipo_hab.ValueMember = "IdTipoHabitacion";
            cmbEstado_hab.DataSource = DALHabitaciones.ObtenerEstado();
            cmbEstado_hab.DisplayMember = "Estado";
            cmbEstado_hab.ValueMember = "IdEstado";
            cmbTipo_hab.SelectedIndex = 0;
            cmbEstado_hab.SelectedIndex = 0;
        }
        private void tabControl1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {            
            dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipo_hab.DataSource = DALHabitaciones.ObtenerTipo_Hab();
            cmbTipo_hab.DisplayMember = "TipoHabitacion";
            cmbTipo_hab.ValueMember = "IdTipoHabitacion";
            cmbEstado_hab.DataSource = DALHabitaciones.ObtenerEstado();
            cmbEstado_hab.DisplayMember = "Estado";
            cmbEstado_hab.ValueMember = "IdEstado";
            cmbTipo_hab.SelectedIndex = 0;
            cmbEstado_hab.SelectedIndex = 0;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.FromArgb(190, 239, 158);
            btnEliminar.ForeColor = Color.Black;
        }

        private void btnEliminar_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminar.BackColor = Color.Black;
            btnEliminar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnConsultar_MouseMove(object sender, MouseEventArgs e)
        {
            btnConsultar.BackColor = Color.Black;
            btnConsultar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnConsultar_MouseLeave(object sender, EventArgs e)
        {
            btnConsultar.BackColor = Color.FromArgb(190, 239, 158);
            btnConsultar.ForeColor = Color.Black;
        }

        private void btnLimpiar_MouseMove(object sender, MouseEventArgs e)
        {
            btnLimpiar.BackColor = Color.Black;
            btnLimpiar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnLimpiar_MouseLeave(object sender, EventArgs e)
        {
            btnLimpiar.BackColor = Color.FromArgb(190, 239, 158);
            btnLimpiar.ForeColor = Color.Black;
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            btnBuscar.BackColor = Color.FromArgb(190, 239, 158);
            btnBuscar.ForeColor = Color.Black;
        }

        private void btnBuscar_MouseMove(object sender, MouseEventArgs e)
        {
            btnBuscar.BackColor = Color.Black;
            btnBuscar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void txtNumero_hab_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbTipo_hab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbEstado_hab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumero_hab_TextChanged(object sender, EventArgs e)
        {
            txtNumero_hab.Text.TrimStart();
        }

        private void txtBuscar_hab_TextChanged(object sender, EventArgs e)
        {
            txtBuscar_hab.Text.TrimStart();
        }

        private void txtTipo_Habitacion_TextChanged(object sender, EventArgs e)
        {
            txtTipo_Habitacion.Text.TrimStart();
        }
    }
}
