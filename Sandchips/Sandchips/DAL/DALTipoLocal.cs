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
    public class DALTipoLocal
    {
        public static int agregar(ModelTipoLocal Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdettipolocal(TipoLocal)VALUES('{0}')", Modelo.TipoLocal), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(ModelTipoLocal Modelo)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdettipolocal SET TipoLocal='{1}' WHERE IdTipoLocal='{0}'", Modelo.IdTipoLocal, Modelo.TipoLocal), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT * FROM tbdettipolocal";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        } 
        public static int eliminar(int id)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdettipolocal WHERE IdTipoLocal='{0}'", id), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelTipoLocal> buscar(string Tipo)
        {
            List<ModelTipoLocal> listabuscar = new List<ModelTipoLocal>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbdettipolocal WHERE TipoLocal LIKE '%" + Tipo + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
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

    }

}
