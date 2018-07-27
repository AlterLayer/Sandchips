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
    public class DALEmpresa
    {
        public static int agregar(ModelEmpresa Modelo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaeempresa(Empresa, NRC, NIT, Direccion, Correo, IdTipoEmpresa, RegistroIva, RegistroAuditor, IdEstado)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", Modelo.Empresa, Modelo.NRC, Modelo.NIT, Modelo.Direccion, Modelo.Correo, Modelo.IdTipoEmpresa, Modelo.RegistroIVA, Modelo.RegistroAuditor, 1), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int modificar(ModelEmpresa Modelo)
        {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaeempresa SET Empresa='{1}', NRC='{2}', NIT='{3}', Direccion='{4}', Correo='{5}', IdTipoEmpresa='{6}', RegistroIVA='{7}', RegistroAuditor='{8}' WHERE IdEmpresa='{0}'", Modelo.IdEmpresa, Modelo.Empresa, Modelo.NRC, Modelo.NIT, Modelo.Direccion, Modelo.Correo, Modelo.IdTipoEmpresa, Modelo.RegistroIVA, Modelo.RegistroAuditor), Conexion.obtenerconexion());
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            instruccion = "SELECT S.IdEmpresa, S.Empresa, S.NRC, S.NIT, S.Direccion, S.Correo, T.TipoEmpresa, S.RegistroIVA, S.RegistroAuditor FROM tbmaeempresa AS S, tbdettipoempresa AS T WHERE S.IdTipoEmpresa = T.IdTipoEmpresa";
            MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
            DataTable Consulta = new DataTable();
            adapter.Fill(Consulta);
            return Consulta;
        }
        public static List<ModelTipoEmpresa> ObtenerTipoEmpresa()
        {
            List<ModelTipoEmpresa> listabuscar = new List<ModelTipoEmpresa>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdTipoEmpresa, TipoEmpresa FROM tbdettipoempresa"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelTipoEmpresa()
                {
                    IdTipoEmpresa = 0,
                    TipoEmpresa = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoEmpresa()
                    {
                        IdTipoEmpresa = reader.GetInt32(0),
                        TipoEmpresa = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }
         

        public static int eliminar(ModelEmpresa model)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE SET IdEstado=2 tbmaeempresa WHERE IdClientes='{0}'", model.IdEmpresa), Conexion.obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }
        public static List<ModelEmpresa> buscar(int user)
        {
            List<ModelEmpresa> listabuscar = new List<ModelEmpresa>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbmaeempresa WHERE Empresa LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelEmpresa()
                    {
                        IdEmpresa = reader.GetInt32(0),
                        Empresa = reader.GetString(1),
                        NRC = reader.GetString(2),
                        NIT = reader.GetString(3),
                        Direccion = reader.GetString(4),
                        Correo = reader.GetString(5),
                        IdTipoEmpresa = reader.GetInt32(6),
                        RegistroIVA = reader.GetString(7),
                        RegistroAuditor = reader.GetString(8)
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
