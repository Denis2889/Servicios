using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Servicios
{
    public partial class frmBuscarEmpresa : Form
    {
        Conexion oConexion = new Conexion();
        Empresa oEmpresa = new Empresa();
        public frmBuscarEmpresa()
        {
            InitializeComponent();
        }
        void RellenarListaEmpresa()
        {
            oConexion.Conectar();
            SqlCommand cmd = new SqlCommand("S_ListEmpresa ", oConexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEmpresa.DataSource = dt;
            oConexion.Cerrar();
        }
        private void frmBuscarEmpresa_Load(object sender, EventArgs e)
        {
            RellenarListaEmpresa();
        }

        private void dgvEmpresa_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
