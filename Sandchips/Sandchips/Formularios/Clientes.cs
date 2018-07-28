using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sandchips.Models;
using Sandchips.DAL;
using Sandchips; 

namespace Sandchips.Formularios
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPersonas.DataSource = DALClientes.mostrartabla();
            Conexion.obtenerconexion(); 
            cmbTipoDoc.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
            cmbMunicipio.SelectedIndex = 0;
        } 

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ValidarPersonas())
            {
                ModelClientes agregar = new ModelClientes();
                agregar.Nombre = txtNombre.Text;
                agregar.Apellidos = txtApellido.Text;
                agregar.Documento = txtCorreo.Text;
                agregar.Telefono = txtDireccion.Text;
                agregar.IdGenero = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                agregar.IdEstado = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                agregar.IdUsuario = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                agregar.IdTipoDocumento = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString());
                int datos = DALClientes.agregar(agregar);
                if (datos > 0)
                {
                    MessageBox.Show("Usuario ingresado");
                    txtIdPersonas.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtDireccion.Clear();
                    cmbTipoDoc.SelectedIndex = 0;
                    txtNumDoc.Clear();
                    txtTelefono.Clear();
                    txtEstadoCivil.Clear();
                    cmbGenero.SelectedIndex = 0;
                    cmbMunicipio.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Usuario no registrado");
                }
            }
            else
            {
            }
        }

        public bool ValidarPersonas()
        {
            bool validacion = false;
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtCorreo.Text != "" && txtDireccion.Text != "" && cmbTipoDoc.SelectedIndex != 0 && txtNumDoc.Text != "" && txtEstadoCivil.Text != "" && txtTelefono.Text != "" && cmbGenero.SelectedIndex != 0 && cmbMunicipio.SelectedIndex != 0)
            {
                validacion = true;
            }
            else
            {
                validacion = false;
                MessageBox.Show("El campo nombre es requerido");
                return validacion;
            }
            return validacion;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvPersonas.DataSource = DALClientes.mostrartabla();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (ValidarPersonas())
            {
                ModelClientes actualizar = new ModelClientes();
                actualizar.IdClientes = Convert.ToInt32(txtIdPersonas.Text);
                actualizar.Nombre = txtNombre.Text;
                actualizar.Apellidos = txtApellido.Text;
                actualizar.Documento = txtCorreo.Text;
                actualizar.Telefono = txtDireccion.Text;
                actualizar.IdGenero = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                actualizar.IdEstado = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                actualizar.IdUsuario = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                actualizar.IdTipoDocumento = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString());
                int datos = DALClientes.actualizar(actualizar);
                if (datos > 0)
                {
                    MessageBox.Show("Usuario Modificado");
                    dgvPersonas.DataSource = DALClientes.mostrartabla();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtDireccion.Clear();
                    cmbTipoDoc.SelectedIndex = -1;
                    txtNumDoc.Clear();
                    txtEstadoCivil.Clear();
                    txtTelefono.Clear();
                    cmbGenero.SelectedIndex = -1;
                    cmbMunicipio.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Usuario no modificado");
                }
            }
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int pocision;
            pocision = dgvPersonas.CurrentRow.Index;
            txtIdPersonas.Text = dgvPersonas[0, pocision].Value.ToString();
            txtNombre.Text = dgvPersonas[1, pocision].Value.ToString();
            txtApellido.Text = dgvPersonas[2, pocision].Value.ToString();
            txtCorreo.Text = dgvPersonas[3, pocision].Value.ToString();
            txtDireccion.Text = dgvPersonas[4, pocision].Value.ToString();
            cmbTipoDoc.SelectedIndex = Convert.ToInt32(dgvPersonas[5, pocision].Value.ToString());
            txtNumDoc.Text = dgvPersonas[6, pocision].Value.ToString();
            txtEstadoCivil.Text = dgvPersonas[7, pocision].Value.ToString();
            txtTelefono.Text = dgvPersonas[8, pocision].Value.ToString();
            cmbGenero.SelectedIndex = Convert.ToInt32(dgvPersonas[9, pocision].Value.ToString());
            cmbMunicipio.SelectedValue = Convert.ToInt32(dgvPersonas[10, pocision].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ModelClientes eliminar = new ModelClientes();
            eliminar.IdClientes = Convert.ToInt32(txtIdPersonas.Text);
            eliminar.IdEstado = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
            DALClientes.eliminar(eliminar);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dgvPersonas.DataSource = DALClientes.mostrartabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPersonas.DataSource = DALClientes.buscar(txtBuscar.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            dgvPersonas.DataSource = DALClientes.mostrartabla();
            txtBuscar.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Form Chequeo_habitaciones = new Menu_Restaurante();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
