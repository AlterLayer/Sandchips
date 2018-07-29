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
    public partial class Local : Form
    {
        public Local()
        { 
            InitializeComponent();
        }

        private void Local_Load_1(object sender, EventArgs e)
        {
            dgvLocal.DataSource = DALLocal.mostrartabla();
            dgvTipoLocal.DataSource = DALTipoLocal.mostrartabla();
            dgvTipoLocal.DataSource = DALTipoHabitaciones.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipoLocal.DataSource = DALLocal.ObtenerTipo_Hab();
            cmbTipoLocal.DisplayMember = "TipoLocal";
            cmbTipoLocal.ValueMember = "IdTipoLocal";
        }


        #region Local
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
            if (ValidarLocal())
            {
                ModelLocal model = new ModelLocal();
                model.CodigoLocal = Convert.ToInt32(txtCodigoLocal.Text);
                model.NombreLocal = txtNombreLocal.Text;
                model.IdTipoLocal = Convert.ToInt32(cmbTipoLocal.SelectedValue.ToString()); 
                int datos = DALLocal.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente","Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLocal.DataSource = DALLocal.mostrartabla();
                    txtCodigoLocal.Clear();
                    cmbTipoLocal.SelectedIndex = 0;
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



        public bool ValidarLocal()
        {
            bool validar = false;
            if (Convert.ToInt32(txtCodigoLocal.Text) > 0 && txtCodigoLocal.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false; 
                MessageBox.Show("El campo código es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (Convert.ToInt32(cmbTipoLocal.SelectedIndex) > 0)
            {
                validar = true;
            }
            else
            {
                validar = false; 
                MessageBox.Show("El campo tipo local es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (txtNombreLocal.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo nombre local es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return validar;
            }
            return validar;

        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarLocal())
            {
                ModelLocal model = new ModelLocal();
                model.IdLocales = Convert.ToInt32(txtIdLocal.Text);
                model.CodigoLocal = Convert.ToInt32(txtCodigoLocal.Text);
                model.NombreLocal = txtNombreLocal.Text;
                model.IdTipoLocal = Convert.ToInt32(cmbTipoLocal.SelectedValue.ToString());
                int datos = DALLocal.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLocal.DataSource = DALLocal.mostrartabla();
                    txtCodigoLocal.Clear();
                    cmbTipoLocal.SelectedIndex = 0;
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
            pocision = dgvLocal.CurrentRow.Index;
            txtIdLocal.Text = dgvLocal[0, pocision].Value.ToString();
            txtCodigoLocal.Text = dgvLocal[1, pocision].Value.ToString();
            txtNombreLocal.Text = dgvLocal[2, pocision].Value.ToString();
            cmbTipoLocal.SelectedValue = Convert.ToInt32(dgvLocal[3, pocision].Value.ToString()); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ModelLocal model = new ModelLocal();
            model.IdLocales = Convert.ToInt32(txtIdLocal.Text);  
            DALLocal.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvLocal.DataSource = DALLocal.mostrartabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLocal.DataSource = DALLocal.buscar(Convert.ToInt32(txtBuscar_hab.Text));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvLocal.DataSource = DALLocal.mostrartabla();
        }
        #endregion

        #region Tipo Local

        private void btnAgregarT_Click(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarTipoLocal())
            {
                ModelTipoLocal model = new ModelTipoLocal();
                model.TipoLocal = txtTipoLocal.Text;
                int datos = DALTipoLocal.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoLocal.DataSource = DALTipoLocal.mostrartabla();
                    txtTipoLocal.Clear(); 
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
            if (ValidarTipoLocal())
            {
                ModelTipoLocal model = new ModelTipoLocal();
                model.IdTipoLocal = Convert.ToInt32(txtIdTipoLocal.Text);
                model.TipoLocal = txtTipoLocal.Text;
                int datos = DALTipoLocal.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipoLocal.DataSource = DALTipoLocal.mostrartabla();
                    txtTipoLocal.Clear();
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
            DALTipoLocal.eliminar(Convert.ToInt32(txtIdTipoLocal.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTipoLocal.DataSource = DALTipoLocal.mostrartabla();
        }

        private void btnConsultarT_Click(object sender, EventArgs e)
        {
            dgvTipoLocal.DataSource = DALTipoLocal.mostrartabla();
        }


        private void dgvTipoHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvTipoLocal.CurrentRow.Index;
            txtIdTipoLocal.Text = dgvTipoLocal[0, pocision].Value.ToString();
            txtTipoLocal.Text = dgvTipoLocal[1, pocision].Value.ToString(); 
        }

        private void btnBuscarT_Click(object sender, EventArgs e)
        {
            dgvTipoLocal.DataSource = DALTipoLocal.buscar(txtBuscarT.Text);
        }

        public bool ValidarTipoLocal()
        {
            bool validar = false;
            if (txtTipoLocal.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo tipo de local es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            } 
            return validar;
        }
        #endregion

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

    }
}
