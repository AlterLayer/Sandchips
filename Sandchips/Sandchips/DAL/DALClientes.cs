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
    public class DALClientes
    {
        public static int agregar(ModelClientes Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaeclientes(Nombre,Apellidos,Documento,Telefono,IdGenero,IdEstado,IdUsuario, IdTipoDocumento)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", Modelo.Nombre, Modelo.Apellidos, Modelo.Documento, Modelo.Telefono, Modelo.IdGenero, 1, Modelo.IdUsuario, Modelo.IdTipoDocumento), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int actualizar(ModelClientes update)
        {
            //tipo entero
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaeclientes SET Nombre='{1}', Apellidos='{2}', Documento='{3}', Telefono='{4}', IdGenero='{5}', IdEstado='{6}', IdUsuario='{7}', IdTipoDocumento='{8}' WHERE IdClientes='{0}'", update.IdClientes, update.Nombre, update.Apellidos, update.Telefono, update.IdGenero, 1, update.IdUsuario, update.IdTipoDocumento), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT*FROM  tbmaeclientes WHERE IdEstado = 1";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        } 
        public static int eliminar(ModelClientes model)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE SET IdEstado = 2 tbmaeclientes WHERE IdClientes='{0}'", model.IdClientes), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelClientes> buscar(string user)
        {
            List<ModelClientes> listabuscar = new List<ModelClientes>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaeclientes WHERE Nombre LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelClientes()
                    {
                        IdClientes = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Documento = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        IdGenero = reader.GetInt32(5),
                        IdEstado = reader.GetInt32(6),
                        IdUsuario = reader.GetInt32(7),
                        IdTipoDocumento = reader.GetInt32(8)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;

        }


        public static List<ModelUsuario> ObtenerUsuario()
        {
            List<ModelUsuario> listabuscar = new List<ModelUsuario>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdUsuario, Usuario FROM tbmaeusuario"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelUsuario()
                {
                    IdUsuario = 0,
                    Usuario = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelUsuario()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Usuario = reader.GetString(1)
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
