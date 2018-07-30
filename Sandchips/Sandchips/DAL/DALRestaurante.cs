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
    public class DALRestaurante
    {
        public static int agregar(ModelRestaurante Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaerestaurante(Restaurante,NRC, IdEstado)VALUES('{0}','{1}','{2}')", Modelo.Restaurante, Modelo.NRC, 1), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(ModelRestaurante Modelo)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaerestaurante SET Restaurante='{1}', NRC='{2}' WHERE IdRestaurante='{0}'", Modelo.IdRestaurante ,Modelo.Restaurante, Modelo.NRC), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT * FROM tbmaerestaurante";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        }

        public static int eliminar(ModelRestaurante model)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbmaerestaurante WHERE IdRestaurante='{0}'", model.IdRestaurante), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        

        public static List<ModelRestaurante> buscar(string user)
        {
            List<ModelRestaurante> listabuscar = new List<ModelRestaurante>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaerestaurante WHERE Restaurante LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelRestaurante()
                    {
                        IdRestaurante = reader.GetInt32(0),
                        Restaurante = reader.GetString(1),
                        NRC = reader.GetString(2)
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
