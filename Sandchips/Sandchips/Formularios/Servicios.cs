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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
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

        private void Servicios_Load(object sender, EventArgs e)
        {
            dgvServicios.DataSource = DALServicios.mostrartabla();
            dgvTipo_Servicio.DataSource = DALTipo_Servicios.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipo_Servicio.DataSource = DALServicios.ObtenerTipo_Ser();
            cmbTipo_Servicio.DisplayMember = "Tipo_Servicio";
            cmbTipo_Servicio.ValueMember = "Id_Tipo_Servicio";
            cmbTipo_Servicio.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool ValidarSer()
        {
            bool validar = false;
            if (txtServicio.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo nombre de servicio es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (Convert.ToInt32(cmbTipo_Servicio.SelectedIndex) > 0)
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

        private void btnAgregarT_Click(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarSer())
            {
                ModelServicios model = new ModelServicios();
                model.Nombre_Servicio = txtServicio.Text;
                model.Id_Tipo_Servicios = Convert.ToInt32(cmbTipo_Servicio.SelectedValue.ToString()); 
                int datos = DALServicios.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvServicios.DataSource = DALServicios.mostrartabla();
                    txtServicio.Clear();
                    cmbTipo_Servicio.SelectedIndex = 0; 
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
            //Validar contraseñas que sean iguales
            if (ValidarSer())
            {
                ModelServicios model = new ModelServicios();
                model.Id_Sercicios = Convert.ToInt32(txtId_Servicio.Text);
                model.Nombre_Servicio = txtServicio.Text;
                model.Id_Tipo_Servicios = Convert.ToInt32(cmbTipo_Servicio.SelectedValue.ToString());
                int datos = DALServicios.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvServicios.DataSource = DALServicios.mostrartabla();
                    txtServicio.Clear();
                    cmbTipo_Servicio.SelectedIndex = 0;
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

        private void btnEliminarT_Click(object sender, EventArgs e)
        {
            DALServicios.eliminar(Convert.ToInt32(txtId_Servicio.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvServicios.DataSource = DALServicios.mostrartabla();
        }

        private void btnBuscarT_Click(object sender, EventArgs e)
        {
            dgvServicios.DataSource = DALServicios.buscar(Convert.ToInt32(txtId_Servicio.Text));
        }

        private void btnConsultarT_Click(object sender, EventArgs e)
        {
            dgvServicios.DataSource = DALServicios.mostrartabla();
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvServicios.CurrentRow.Index;
            txtId_Servicio.Text = dgvServicios[0, pocision].Value.ToString();
            txtServicio.Text = dgvServicios[1, pocision].Value.ToString();
            cmbTipo_Servicio.Text = dgvServicios[2, pocision].Value.ToString();
        }

        /// Métodos tipos de servicios
        /// 
        public bool ValidarSerT()
        {
            bool validar = false;
            if (txtTipo_Servicio.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo nombre de servicio es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            return validar;

        }

        private void btnAgregarTS_Click(object sender, EventArgs e)
        { 
            //Validar contraseñas que sean iguales
            if (ValidarSerT())
            {
                ModelTipoServicio model = new ModelTipoServicio(); 
                model.Tipo_Servicio = txtTipo_Servicio.Text; 
                int datos = DALTipo_Servicios.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipo_Servicio.DataSource = DALTipo_Servicios.mostrartabla();
                    txtTipo_Servicio.Clear(); 
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

        private void btnModificarTS_Click(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarSerT())
            {
                ModelTipoServicio model = new ModelTipoServicio();
                model.Tipo_Servicio = txtTipo_Servicio.Text;
                model.Id_Tipo_Servicio = Convert.ToInt32(txtIdTipo_Servicio.Text);
                int datos = DALTipo_Servicios.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTipo_Servicio.DataSource = DALTipo_Servicios.mostrartabla();
                    txtTipo_Servicio.Clear(); 
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

        private void btnEliminarTS_Click(object sender, EventArgs e)
        {
            DALTipo_Servicios.eliminar(Convert.ToInt32(txtIdTipo_Servicio.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTipo_Servicio.DataSource = DALTipo_Servicios.mostrartabla();
        }

        private void btnConsultarTS_Click(object sender, EventArgs e)
        {
            dgvTipo_Servicio.DataSource = DALTipo_Servicios.mostrartabla();
        }

        private void btnBuscar_TS_Click(object sender, EventArgs e)
        {
            dgvTipo_Servicio.DataSource = DALTipo_Servicios.buscar(txtBuscar_TS.Text);
        }

        private void dgvTipo_Servicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvTipo_Servicio.CurrentRow.Index;
            txtIdTipo_Servicio.Text = dgvTipo_Servicio[0, pocision].Value.ToString();
            txtTipo_Servicio.Text = dgvTipo_Servicio[1, pocision].Value.ToString(); 
        }
    }
}
