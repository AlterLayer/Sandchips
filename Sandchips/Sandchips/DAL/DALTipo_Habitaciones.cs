using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sandchips.Models;
using Sandchips;

namespace Sandchips.DAL
{
    public class DALTipo_Habitaciones
    {
        public static int agregar(ModelTipoHabitacion Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdettipo_habitacion(Tipo_Habitacion)VALUES('{0}')", Modelo.TipoHabitacion), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(ModelTipoHabitacion Modelo)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdettipo_habitacion SET Tipo_Habitacion='{1}' WHERE Id_Tipo_Habitacion='{0}'", Modelo.IdTipoHabitacion, Modelo.TipoHabitacion), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT * FROM tbdettipo_habitacion";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        } 
        public static int eliminar(int id)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdettipo_habitacion WHERE Id_Tipo_Habitacion='{0}'", id), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelTipoHabitacion> buscar(string Tipo)
        {
            List<ModelTipoHabitacion> listabuscar = new List<ModelTipoHabitacion>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbdettipo_habitacion WHERE Tipo_Habitacion LIKE '%" + Tipo + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
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
