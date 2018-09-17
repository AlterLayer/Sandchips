using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Windows.Forms;
using Sandchips.DAL;
using Sandchips.Formularios;
using Sandchips.Models;

namespace Sandchips.DAL
{
    class DALReservacionRestaurante
    {
        public DataTable mostrarEstado()
        {
            DataTable Consulta = new DataTable();

            string instruccion;
            instruccion = "SELECT * FROM tbdetestadoreservacion";
            MySqlCommand comando = new MySqlCommand(instruccion, Conexion.obtenerconexion());
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(Consulta);
                return Consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return Consulta;
            }
            finally
            {
                Conexion.obtenerconexion().Close();
            }

        }

        public static int agregarusuario(ModelReservacionRestaurante add)
        {
            int retorno = 0;
            try

            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdetreservacionrestaurante(IdReservacionRestaurante,FechaHoraIngreso,NumeroPersonas,IdCliente, IdEstadoRestaurante, IdRestaurante)VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", add.IdReservacionRestaurante, add.FechaHoraIngreso, add.NumeroPersonas, add.IdCliente, add.IdEstadoRestaurante, add.IdRestaurante), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros." + ex);
            }
            return retorno;
        }
        public static int actualizar(ModelReservacionRestaurante update)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdetreservacionrestaurante SET NumeroPersonas='{2}',IdEstadoRestaurante='{4}' WHERE IdReservacionRestaurante='{0}'", update.NumeroPersonas, update.IdEstadoRestaurante), Conexion.obtenerconexion());
                retorno = consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros. " + ex);
            }
            return retorno;
        }
        public static int eliminar(int iduser)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdetreservacionrestaurante WHERE IdReservacionRestaurante = '{0}'", iduser), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ErrorBlinkStyle al ingresar registros. " + ex);
            }
            return retorno;
        }
        public  DataTable mostrartabla()
        {
            string instruccion;
            DataTable Consulta = new DataTable();
            try
            {
                instruccion = "SELECT rsr.IdReservacionRestaurante, rsr.FechaHoraIngreso, rsr.NumeroPersonas, c.Nombre, c.Apellidos, etr.Estado, restaran.IdRestaurante FROM tbdetreservacionrestaurante rsr,   tbmaeclientes c, tbdetestadoreservacion etr, tbmaerestaurante restaran WHERE c.IdClientes = rsr.IdCliente AND etr.IdEstadoReservacion = rsr.IdEstadoRestaurante AND restaran.idRestaurante = rsr.IdRestaurante";
                 MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros. " + ex);
            }
            return Consulta;
        }
    }
}
