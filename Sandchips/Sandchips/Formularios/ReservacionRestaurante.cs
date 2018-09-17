using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sandchips.DAL;
using Sandchips.Formularios;
using Sandchips.Models;

namespace ReservacionRestaurante
{
    public partial class ReservacionRestaurante : Form
    {
        ModelReservacionRestaurante ag = new ModelReservacionRestaurante();
        ModelReservacionRestaurante acto = new ModelReservacionRestaurante();
        void agregar()
        {
            ag.FechaHoraIngreso = dateFechaIngreso.Text;
            ag.NumeroPersonas = Convert.ToInt32(txtNumeroPersonas.Text);
            ag.IdEstadoRestaurante = Convert.ToInt32(cmbEstadoResturante.SelectedValue);
        }
        void insertar()
        {
            if(txtNumeroPersonas.Text.Trim() == "")
            {
                MessageBox.Show("Existen campos vacíos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                agregar();
                int datos = DALReservacionRestaurante.agregarusuario(ag);
            }
        }
        void actualizar()
        {
            acto.NumeroPersonas = Convert.ToInt32(txtNumeroPersonas.Text);
            acto.IdEstadoRestaurante = Convert.ToInt32(cmbEstadoResturante.SelectedValue);
        }
        void eliminar()
        {
            try
            {
                ModelReservacionRestaurante del = new ModelReservacionRestaurante();
                int datos = DALReservacionRestaurante.eliminar(Convert.ToInt32(txtIdReservacion.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los campos de la tabla estan vacios", "Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void cargarEstado()
        {
            DALReservacionRestaurante mostrarEstado = new DALReservacionRestaurante();
            cmbEstadoResturante.DisplayMember = "Estado";
            cmbEstadoResturante.ValueMember = "IdEstadoReservacion";
            cmbEstadoResturante.DataSource = mostrarEstado.mostrarEstado();
        }
        void mostrarreserva()
        {
            DALReservacionRestaurante mostrar = new DALReservacionRestaurante();
            dgvMostrarReservacionResta.DataSource = mostrar.mostrartabla();
        }
        public ReservacionRestaurante()
        {
            InitializeComponent();
        }

        private void ReservacionRestaurante_Load(object sender, EventArgs e)
        {
            cargarEstado();
            mostrarreserva();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            acto.IdReservacionRestaurante = Convert.ToInt32(txtIdReservacion.Text);
            actualizar();
            int datos = DALReservacionRestaurante.actualizar(acto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eliminar();
            
        }
    }
}
