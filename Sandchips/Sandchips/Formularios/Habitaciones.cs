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
            dgvTipoHabitacion.DataSource = DALTipo_Habitaciones.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipo_hab.DataSource = DALHabitaciones.ObtenerTipo_Hab();
            cmbTipo_hab.DisplayMember = "Tipo_Habitacion";
            cmbTipo_hab.ValueMember = "Id_Tipo_Habitacion";
            cmbEstado_hab.DataSource = DALHabitaciones.ObtenerEstado();
            cmbEstado_hab.DisplayMember = "Estado";
            cmbEstado_hab.ValueMember = "Id_Estado";
            cmbTipo_hab.SelectedIndex = 0;
            cmbEstado_hab.SelectedIndex = 0;

        }

        #region Habitacion
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form tipos_de_habitaciones = new Chequeo_habitaciones();
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
            cmbTipo_hab.Text = dgvHabitaciones[2, pocision].Value.ToString();
            cmbEstado_hab.Text = dgvHabitaciones[3, pocision].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ModelHabitaciones model = new ModelHabitaciones();
            model.IdHabitacion = Convert.ToInt32(txtId_hab.Text); 
            model.IdEstado = Convert.ToInt32(cmbEstado_hab.SelectedValue.ToString());
            DALHabitaciones.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHabitaciones.DataSource = DALHabitaciones.mostrartabla();
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
                int datos = DALTipo_Habitaciones.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoHabitacion.DataSource = DALTipo_Habitaciones.mostrartabla();
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
                int datos = DALTipo_Habitaciones.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoHabitacion.DataSource = DALTipo_Habitaciones.mostrartabla();
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
            DALTipo_Habitaciones.eliminar(Convert.ToInt32(txtId_Tipo_Habitacion.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTipoHabitacion.DataSource = DALTipo_Habitaciones.mostrartabla();
        }

        private void btnConsultarT_Click(object sender, EventArgs e)
        {
            dgvTipoHabitacion.DataSource = DALTipo_Habitaciones.mostrartabla();
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
            dgvTipoHabitacion.DataSource = DALTipo_Habitaciones.buscar(txtBuscarT.Text);
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

    }
}
