using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Servicios
{
    public class Conexion
    {
        public SqlConnection conexion;
        public void Conectar()
        {
            try
            {
                //instrucciones
                conexion = new SqlConnection(@"server=DENIS;" +
                "database=Servicios ; integrated security = true");
                conexion.Open();
                //MessageBox.Show("Abrio la conexion");

            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la conexión" + error.Message);
            }
        }
        public void Cerrar()
        {
            conexion.Close();
        }
    }
}
