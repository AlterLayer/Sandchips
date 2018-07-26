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
    public class DALServicios
    {
        public static int agregar(ModelServicios Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaeservicios(Nombre_Servicio,Id_Tipo_Servicios)VALUES('{0}','{1}')", Modelo.Nombre_Servicio, Modelo.Id_Tipo_Servicios), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(ModelServicios Modelo)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaeservicios SET Nombre_Servicio='{1}', Id_Tipo_Servicios='{2}' WHERE 	Id_Sercicios='{0}'", Modelo.Id_Sercicios, Modelo.Nombre_Servicio, Modelo.Id_Tipo_Servicios), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT Id_Sercicios, Nombre_Servicio, T.Tipo_Servicio FROM tbmaeservicios AS S, tbdettipo_servicios AS T WHERE S.Id_Tipo_Servicios = T.Id_Tipo_Servicio";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        }
        public static List<ModelTipoServicio> ObtenerTipo_Ser()
        {
            List<ModelTipoServicio> listabuscar = new List<ModelTipoServicio>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT Id_Tipo_Servicio, Tipo_Servicio FROM tbdettipo_servicios"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoServicio()
                    {
                        Id_Tipo_Servicio = reader.GetInt32(0),
                        Tipo_Servicio = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }
         

        public static int eliminar(int idpersonas)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbmaeservicios WHERE Id_Sercicios='{0}'", idpersonas), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelServicios> buscar(int user)
        {
            List<ModelServicios> listabuscar = new List<ModelServicios>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaeservicios WHERE Numero_Habitacion LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelServicios()
                    {
                        Id_Sercicios = reader.GetInt32(0),
                        Nombre_Servicio = reader.GetString(1),
                        Tipo_Servicios = reader.GetString(2)
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
