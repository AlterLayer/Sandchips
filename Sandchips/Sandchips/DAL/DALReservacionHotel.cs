using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sandchips.Models;
using Sandchips;
using System.Windows.Forms;

namespace Sandchips.DAL
{
    public class DALReservacionHotel
    {
        public static int agregar(ModelReservacionHotel Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdetreservacionhotel(FechaIngreso,FechaSalida, IdClientes,Precio,IdHabitaciones,IdDetalleLocal,IdEstadoReservacion)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Modelo.FechaIngreso, Modelo.FechaSalida, Modelo.IdClientes, Modelo.Precio, Modelo.IdHabitaciones, Modelo.IdDetalleLocal, 1), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static int modificar(ModelReservacionHotel Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdetreservacionhotel SET FechaIngreso='{1}', FechaSalida='{2}', IdClientes='{3}', Precio='{4}', IdHabitaciones='{5}', IdDetalleLocal='{6}' WHERE IdReservacionHotel='{0}'", Modelo.IdReservacionHotel, Modelo.FechaIngreso, Modelo.FechaSalida, Modelo.IdClientes, Modelo.Precio, Modelo.IdHabitaciones, Modelo.IdDetalleLocal), Conexion.obtenerconexion());
                retorno = consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar modificar registro. " + ex);
            }
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            DataTable Consulta = new DataTable();
            try
            {
                instruccion = "SELECT * FROM tbdetreservacionhotel";
                MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al cargar registros " + ex);
            }
            return Consulta;
        }

        public static int eliminar(ModelReservacionHotel model)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdetreservacionhotel WHERE IdReservacionHotel='{0}'", model.IdReservacionHotel), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar eliminar registro. " + ex);
            }
            return retorno;
        }
        public static List<ModelReservacionHotel> buscar(string user)
        {
            List<ModelReservacionHotel> listabuscar = new List<ModelReservacionHotel>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbdetreservacionhotel WHERE Restaurante LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelReservacionHotel()
                    {
                        IdReservacionHotel = reader.GetInt32(0),
                        FechaIngreso = reader.GetDateTime(1),
                        FechaSalida = reader.GetDateTime(3),
                        IdClientes = reader.GetInt32(4),
                        Precio = reader.GetDouble(5),
                        IdHabitaciones = reader.GetInt32(6),
                        IdDetalleLocal = reader.GetInt32(7),
                        IdEstadoReservacion = reader.GetInt32(8)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;

        }


        public static List<ModelTipoLocal> ObtenerDetalle_Local()
        {
            List<ModelTipoLocal> listabuscar = new List<ModelTipoLocal>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdTipoLocal, TipoLocal FROM tbdettipolocal"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelTipoLocal()
                {
                    IdTipoLocal = 0,
                    TipoLocal = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoLocal()
                    {
                        IdTipoLocal = reader.GetInt32(0),
                        TipoLocal = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }
        public static List<ModelClientes> ObtenerClientes()
        {
            List<ModelClientes> listabuscar = new List<ModelClientes>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdClientes, Nombre FROM tbmaeclientes"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelClientes()
                {
                    IdClientes = 0,
                    Nombre = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelClientes()
                    {
                        IdClientes = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }

        public static List<ModelTipoHabitacion> ObtenerTipo_Hab()
        {
            List<ModelTipoHabitacion> listabuscar = new List<ModelTipoHabitacion>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdTipoHabitacion, TipoHabitacion FROM tbdettipohabitacion"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelTipoHabitacion()
                {
                    IdTipoHabitacion = 0,
                    TipoHabitacion = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoHabitacion()
                    {
                        IdTipoHabitacion = reader.GetInt32(0),
                        TipoHabitacion = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }
    }

}
