using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;



namespace Sandchips
{
    public class Conexion
    {
        public static MySqlConnection obtenerconexion()
        {
            try
            {
                //Declaracion de las variables de coneccion para la base de Datos
                string server = "127.0.0.1";
                string database = "bdsandchips";
                string Uid = "root";
                string pwd = "";
                MySqlConnection con = new MySqlConnection("server=" + server + ";database=" + database + ";SslMode=none"+";Uid=" + Uid + ";pwd="+pwd);

                con.Open();
                return con;

            }
            catch (Exception ex)
            {
                MySqlConnection conex = new MySqlConnection();
                MessageBox.Show("Error al intentar conectar a la base de datos, Verifique que la base este cargada. " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return conex;
                
            }
        }
    }
}
