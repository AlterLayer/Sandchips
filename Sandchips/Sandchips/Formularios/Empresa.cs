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
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipoEmpresa.DataSource = DALEmpresa.ObtenerTipoEmpresa();
            cmbTipoEmpresa.DisplayMember = "TipoEmpresa";
            cmbTipoEmpresa.ValueMember = "IdTipoEmpresa";
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

        /// Métodos tipos de servicios
        /// 
        public bool ValidarSerT()
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
            return validar;

        }
        

        private void btnEliminarTS_Click(object sender, EventArgs e)
        {
            DALTipo_Servicios.eliminar(Convert.ToInt32(txtBuscarE.Text));
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvEmpresas.DataSource = DALTipo_Servicios.mostrartabla();
        }

        private void btnConsultarTS_Click(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALTipo_Servicios.mostrartabla();
        }

        private void btnBuscar_TS_Click(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALTipo_Servicios.buscar(txtBuscarE.Text);
        }

        private void dgvTipo_Servicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvEmpresas.CurrentRow.Index;
            ////txtIdTipo_Servicio.Text = dgvTipo_Servicio[0, pocision].Value.ToString();
            ////txtTipo_Servicio.Text = dgvTipo_Servicio[1, pocision].Value.ToString(); 
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarEmpresa())
            {
                ModelEmpresa model = new ModelEmpresa();
                model.Empresa = txtEmpresa.Text;
                model.NRC = txtNRC.Text;
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvEmpresas.DataSource = DALEmpresa.mostrartabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            //Validar contraseñas que sean iguales
            if (ValidarEmpresa())
            {
                ModelEmpresa model = new ModelEmpresa();
                model.IdEmpresa = Convert.ToInt32(txtEmpresa.Text);
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
    }
}
