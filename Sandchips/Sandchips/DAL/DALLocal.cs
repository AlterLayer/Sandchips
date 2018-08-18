﻿using MySql.Data.MySqlClient;
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
    public class DALLocal
    {
        public static int agregar(ModelLocal Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaelocales(CodigoLocal,NombreLocal,IdTipoLocal)VALUES('{0}','{1}','{2}')", Modelo.CodigoLocal, Modelo.NombreLocal, Modelo.IdTipoLocal), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static int modificar(ModelLocal Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaelocales SET CodigoLocal='{1}', NombreLocal='{2}', IdTipoLocal='{3}' WHERE IdLocales='{0}'", Modelo.IdLocales, Modelo.CodigoLocal, Modelo.NombreLocal, Modelo.IdTipoLocal), Conexion.obtenerconexion());
                retorno = consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            DataTable Consulta = new DataTable();
            try
            {
                instruccion = "SELECT * FROM tbmaelocales";
                MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return Consulta;
        }
        public static int eliminar(ModelLocal model)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbmaelocales WHERE IdLocales='{0}'", model.IdLocales), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static List<ModelTipoLocal> ObtenerTipo_Hab()
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

        public static List<ModelLocal> buscar(int user)
        {
            List<ModelLocal> listabuscar = new List<ModelLocal>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdLocales, CodigoLocal, L.NombreLocal, T.IdTipoLocal FROM tbmaelocales AS L, tbdettipolocal AS T WHERE L.IdTipoLocal = T.IdTipoLocal AND L.NombreLocal LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelLocal()
                    {
                        IdLocales = reader.GetInt32(0),
                        CodigoLocal = reader.GetInt32(1),
                        NombreLocal = reader.GetString(2),
                        TipoLocal = reader.GetString(3)
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
