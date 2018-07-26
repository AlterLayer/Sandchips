using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Sandchips;
using Sandchips.DAL;
using Sandchips.Formularios;
using Sandchips.Models;

namespace Sandchips.DAL
{
    public class DALUsuarios
    {
        //Agregar Usuario
        public static int agregarusuario(ModelUsuario add)
        {
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaeusuario(Id_Persona,Usuario,Contraseña,Id_Tipo_Usuario,Id_Estado)VALUES('{0}','{1}','{2}','{3}','{4}')", add.Id_Persona, add.Usuario, add.password, add.Tipo_Usuario, add.estado), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        //Mostrasr usuarios
        public static DataTable mostrartabla()
        {
            string instruccion;

            //Guardamos en una variable tipo string la consulta a realizar a la base 
            //instruccion = "Select id_usuario as Numero, usuario as usuario, Password as Clave, id_estado"
            instruccion = "SELECT*FROM  tbmaeusuario";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        }

        //Modificar Usuario
        public static int actualizar(ModelUsuario update)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaeusuario SET Id_Persona='{0}', Usuario='{1}', Contraseña='{2}', Id_Tipo_Usuario='{3}', Id_Estado='{4}' WHERE IdUsuario='{5}'", update.Id_Persona, update.Usuario, update.password, update.Tipo_Usuario, update.estado, update.Id_Usuario), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }

        //Eliminar Usuario
        public static int eliminar(int iduser)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbmaeusuario WHERE IdUsuario='{0}'", iduser), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelUsuario> buscar(string user)
        {
            List<ModelUsuario> listabuscar = new List<ModelUsuario>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaeusuario WHERE Usuario LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelUsuario()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        Id_Persona = reader.GetInt32(1),
                        Usuario = reader.GetString(2),
                        estado = reader.GetInt32(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;

        }

        //Obtiene las personas de la base de datos
        public static List<ModelUsuario> ObtenerPersona()
        {
            List<ModelUsuario> listabuscar = new List<ModelUsuario>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT Id_Persona, CONCAT(Apellidos, ', ', Nombre) AS Nombre FROM tbmaepersonas"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelUsuario()
                    {
                        Id_Persona = reader.GetInt32(0),
                        Persona = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }

        //Obtiene el tipo de usuario de la base de datos
        public static List<ModelTipoUsuario> ObtenerTipoUsuario()
        {
            List<ModelTipoUsuario> listabuscar = new List<ModelTipoUsuario>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT Id_Tipo_Usuario, Tipo_Usuario FROM tbdettipo_usuario"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoUsuario()
                    {
                        Id_Tipo_Usuario = reader.GetInt32(0),
                        Tipo_Usuario = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }

        //Obtiene los estados que estan en la base de datos
        public static List<ModelEstado> ObtenerEstado()
        {
            List<ModelEstado> listabuscar = new List<ModelEstado>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT Id_Estado, Estado FROM tbdetestado"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelEstado
                    {
                        IdEstado = reader.GetInt32(0),
                        Estado = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }


        #region Iniciar Sesion

        public static bool IniciarSession(ModelUsuario model)
        {
            try
            {
                bool valid = false;

                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdUsuario FROM tbmaeusuarios WHERE Usuario = '" + model.Usuario + "' and Clave = '" + model.password + "' "), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    valid = true;
                }
                return valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
