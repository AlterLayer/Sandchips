using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace Sandchips.Formularios
{
    public partial class Grafico : Form
    {
        MySqlConnection conectar;
        public Grafico()
        {
            InitializeComponent();
        }
        public void Conectar()
        {
            Conexion.obtenerconexion();
        }

        public DataTable EnviarDatos(String consulta)
        {
            
            DataTable tabla = new DataTable();
            MySqlDataAdapter mda = new MySqlDataAdapter(consulta, Conexion.obtenerconexion());
            mda.Fill(tabla);
            return tabla;

        }
        private void chart1_Click(object sender, EventArgs e)
        {
            /*
            //Los vectores con los datos
            string[] series = { "Eduardo", "Jorge", "Luis" };
            int[] puntos = {23,10,70};

            //cambiar la combinacion de colores
            chart1.Palette = ChartColorPalette.Pastel;

            chart1.Titles.Add("Edades");

            for(int i = 0; i < series.Length; i++)
            {
                //Titulos
                Series serie = chart1.Series.Add(series[i]);

                //Cantidades
                serie.Label = puntos[i].ToString();

                serie.Points.Add(puntos[i]);
            }*/
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Conectar();
            chart1.Series["Series1"].LegendText = "Grafica de edades";
            chart1.Series["Series1"].XValueMember = "Nombre";
            chart1.Series["Series1"].YValueMembers = "IdGenero";
            chart1.DataSource = EnviarDatos("SELECT Nombre, IdGenero FROM tbmaeclientes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Grafica = new Clientes();
            Grafica.Show();
            this.Hide();
        }
    }
}
