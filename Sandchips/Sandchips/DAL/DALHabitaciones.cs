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
    public class DALHabitaciones
    {
        public static int agregar(ModelHabitaciones Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbmaehabitaciones(NumeroHabitacion,IdTipoHabitacion,IdEstado)VALUES('{0}','{1}','{2}')", Modelo.NumeroHabitacion, Modelo.IdTipoHabitacion, Modelo.IdEstado), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static int modificar(ModelHabitaciones Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbmaehabitaciones SET NumeroHabitacion='{1}', IdTipoHabitacion='{2}', IdEstado='{3}' WHERE IdHabitacion='{0}'", Modelo.IdHabitacion, Modelo.NumeroHabitacion, Modelo.IdTipoHabitacion, Modelo.IdEstado), Conexion.obtenerconexion());
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

                instruccion = "SELECT IdHabitaciones, NumeroHabitacion, H.IdTipoHabitacion, E.Estado FROM tbmaehabitaciones AS Ha, tbdettipohabitacion AS H, tbmaeestado AS E WHERE H.IdTipoHabitacion = Ha.IdTipoHabitacion AND E.IdEstado = Ha.IdEstado AND Ha.IdEstado = 1";
                MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return Consulta;
        }
        public static List<ModelTipoHabitacion> ObtenerTipo_Hab()
        {
            List<ModelTipoHabitacion> listabuscar = new List<ModelTipoHabitacion>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdTipoHabitacion, TipoHabitacion FROM tbdettipohabitacion"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelTipoHabitacion()
                {
                    IdTipoHabitacion = 0,
                    TipoHabitacion = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelTipoHabitacion()
                    {
                        IdTipoHabitacion = reader.GetInt32(0),
                        TipoHabitacion = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }

        public static List<ModelEstado> ObtenerEstado()
        {
            List<ModelEstado> listabuscar = new List<ModelEstado>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdEstado, Estado FROM tbmaeestado"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelEstado()
                {
                    IdEstado = 0,
                    Estado = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelEstado()
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

        public static int eliminar(ModelHabitaciones model)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbmaehabitaciones WHERE IdHabitaciones='{0}'", model.IdHabitacion), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static List<ModelHabitaciones> buscar(int user)
        {
            List<ModelHabitaciones> listabuscar = new List<ModelHabitaciones>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdHabitacion, NumeroHabitacion, H.IdTipoHabitacion, E.IdEstado FROM tbmaehabitaciones AS Ha, tbdettipohabitacion AS H, tbdetestado AS E WHERE H.IdTipoHabitacion = Ha.IdTipoHabitacion AND E.IdEstado = Ha.IdEstado AND NumeroHabitacion LIKE '%" + user + "%'"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listabuscar.Add(new ModelHabitaciones()
                    {
                        IdHabitacion = reader.GetInt32(0),
                        NumeroHabitacion = reader.GetInt32(1),
                        TipoHabitacion = reader.GetString(2),
                        Estado = reader.GetString(3)
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
