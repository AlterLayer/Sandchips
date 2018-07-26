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
    public class DALTipo_Servicios
    {
        public static int agregar(ModelTipoServicio Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdettipo_servicios(Tipo_Servicio)VALUES('{0}')", Modelo.Tipo_Servicio), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(ModelTipoServicio Modelo)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdettipo_servicios SET Tipo_Servicio='{1}' WHERE Id_Tipo_Servicio='{0}'", Modelo.Id_Tipo_Servicio, Modelo.Tipo_Servicio), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT * FROM tbdettipo_servicios";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        } 
        public static int eliminar(int id)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdettipo_servicios WHERE Id_Tipo_Servicio='{0}'", id), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelTipoServicio> buscar(string Tipo)
        {
            List<ModelTipoServicio> listabuscar = new List<ModelTipoServicio>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbdettipo_servicios WHERE Tipo_Servicio LIKE '%" + Tipo + "%'"), Conexion.obtenerconexion());
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

    }

}
