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
    public class DALTipoEmpresa
    {
        public static int agregar(ModelTipoEmpresa Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdettipoempresa(TipoEmpresa)VALUES('{0}')", Modelo.TipoEmpresa), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static int modificar(ModelTipoEmpresa Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdettipoempresa SET TipoEmpresa='{1}' WHERE IdTipoEmpresa='{0}'", Modelo.IdTipoEmpresa, Modelo.TipoEmpresa), Conexion.obtenerconexion());
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
                instruccion = "SELECT * FROM tbdettipoempresa";
                MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return Consulta;
        }
        public static int eliminar(int id)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdettipoempresa WHERE IdTipoEmpresa='{0}'", id), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static List<ModelTipoEmpresa> buscar(string Tipo)
        {
            List<ModelTipoEmpresa> listabuscar = new List<ModelTipoEmpresa>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbdettipoempresa WHERE TipoEmpresa LIKE '%" + Tipo + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
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

    }

}
