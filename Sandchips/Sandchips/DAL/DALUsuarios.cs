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
            int retorno = 0;
            try

            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaeusuarios(Usuario,Clave,Nombres,Apellidos, Correo, NumeroDocumento, Direccion, Telefono, Nacimiento, IdTipoDocumento, IdGenero, IdEstado, IdTipoUsuarios)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", add.Usuario, add.Clave, add.Nombre, add.Apellidos, add.Correo, add.NumeroDocumento, add.Direccion, add.Telefono, add.Nacimiento, add.IdTipoDocumento, add.IdGenero, 1, add.IdTipoUsuarios), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros." + ex);
            }
            return retorno;
        }//Mostrasr usuarios
        public static DataTable mostrartabla()
        {
            string instruccion;
            DataTable Consulta = new DataTable();
            try
            {
                instruccion = "SELECT* FROM  tbmaeusuarios  WHERE IdEstado = 1";
                //Guardamos en una variable tipo string la consulta a realizar a la base 
                //instruccion = "Select id_usuario as Numero, usuario as usuario, Password as Clave, id_estado"
                MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros. " + ex);
            }
            return Consulta;
        }//Modificar Usuario
        public static int actualizar(ModelUsuario update)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaeusuarios SET Usuario='{1}',Clave='{2}',Nombres='{3}',Apellidos='{4}', Correo='{5}', NumeroDocumento='{6}', Direccion,='{7}' Telefono='{8}', Nacimiento='{9}', IdTipoDocumento='{10}', IdGenero='{11}', IdEstado='{12}', IdTipoUsuarios='{13}' WHERE IdUsuario='{5}'", update.IdUsuario, update.Usuario, update.Clave, update.Nombre, update.Apellidos, update.Correo, update.NumeroDocumento, update.Direccion, update.Telefono, update.Nacimiento, update.IdTipoDocumento, update.IdGenero, 1, update.IdTipoUsuarios), Conexion.obtenerconexion());
                retorno = consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros. " + ex);
            }
            return retorno;
        }//Eliminar Usuario
        public static int eliminar(int iduser)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbmaeusuarios WHERE IdUsuario = '{0}'", iduser), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ErrorBlinkStyle al ingresar registros. " + ex);
            }
            return retorno;
        }
        public static List<ModelUsuario> buscar(string user)
        {
            List<ModelUsuario> listabuscar = new List<ModelUsuario>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaeusuarios WHERE IdEstado = 1 AND Usuario LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelUsuario()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Usuario = reader.GetString(1),
                        Clave = reader.GetString(2),
                        Nombre = reader.GetString(3),
                        Apellidos = reader.GetString(4),
                        Correo = reader.GetString(5),
                        NumeroDocumento = reader.GetString(6),
                        Direccion = reader.GetString(7),
                        Telefono = reader.GetString(8),
                        Nacimiento = reader.GetString(9),
                        IdTipoDocumento = reader.GetInt32(10),
                        IdGenero = reader.GetInt32(11),
                        IdEstado = reader.GetInt32(12),
                        IdTipoUsuarios = reader.GetInt32(13),
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;

        }

        //Obtiene las personas de la base de datos ok
        public static List<ModelTipoDocumento> ObtenerTipoDocumento()
        {
            List<ModelTipoDocumento> listabuscar = new List<ModelTipoDocumento>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdTipoDocumento, Documento FROM tbdettipodocumento ORDER BY IdTipoDocumento ASC"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelTipoDocumento()
                {
                    IdTipoDocumento = 0,
                    Documento = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoDocumento()
                    {
                        IdTipoDocumento = reader.GetInt32(0),
                        Documento = reader.GetString(1)
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
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdTipoUsuarios, TipoUsuario FROM tbdettipousuarios"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelTipoUsuario()
                {
                    IdTipoUsuario = 0,
                    TipoUsuario = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoUsuario()
                    {
                        IdTipoUsuario = reader.GetInt32(0),
                        TipoUsuario = reader.GetString(1)
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
        public static List<ModelGenero> ObtenerGenero()
        {
            List<ModelGenero> listabuscar = new List<ModelGenero>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdGenero, Genero FROM tbdetgenero"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelGenero
                {
                    IdGenero = 0,
                    Genero = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelGenero
                    {
                        IdGenero = reader.GetInt32(0),
                        Genero = reader.GetString(1)
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

                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdUsuario FROM tbmaeusuarios WHERE Usuario = '" + model.Usuario + "' and Clave = '" + model.Clave + "' and IdEstado = 1 "), Conexion.obtenerconexion());
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


        public static List<ModelTipoUsuario> ObtenerPermiso(string Usuario)
        {
            List<ModelTipoUsuario> listabuscar = new List<ModelTipoUsuario>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT TipoUsuario FROM tbmaeusuarios AS U, tbdettipousuarios AS T WHERE  Usuario = '" + Usuario + "' AND U.IdTipoUsuarios = T.IdTipoUsuarios "), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoUsuario()
                    {
                        TipoUsuarioP = reader.GetString(0)
                    });

                    ModelPermiso.TipoUsuarioP = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }

        public static ModelUsuario ObtenerCorreo(string user)
        {
            ModelUsuario listabuscar = new ModelUsuario();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaeusuarios WHERE IdEstado = 1 AND Usuario = '" + user + "'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar = new ModelUsuario()
                    {
                        IdUsuario = reader.GetInt32(0),
                        Usuario = reader.GetString(1),
                        Clave = reader.GetString(2),
                        Nombre = reader.GetString(3),
                        Apellidos = reader.GetString(4),
                        Correo = reader.GetString(5),
                        NumeroDocumento = reader.GetString(6),
                        Direccion = reader.GetString(7),
                        Telefono = reader.GetString(8),
                        Nacimiento = reader.GetString(9),
                        IdTipoDocumento = reader.GetInt32(10),
                        IdGenero = reader.GetInt32(11),
                        IdEstado = reader.GetInt32(12),
                        IdTipoUsuarios = reader.GetInt32(13),
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;

        }

        public static int ModificarContra(string clave, string usuario)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaeusuarios SET Clave='{0}' WHERE  Usuario='{1}'", clave, usuario), Conexion.obtenerconexion());
                retorno = consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registros. " + ex);
            }
            return retorno;
        }
        #endregion
    }
}
