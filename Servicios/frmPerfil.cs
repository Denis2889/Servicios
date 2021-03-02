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
    public partial class frmPerfil : Form
    {
        Conexion oConexion = new Conexion();
        Logueo oLogin = new Logueo();
        //Perfil oPerfil = new Perfil();
        public frmPerfil(Logueo Datos)
        {
            oLogin._IDPerfil = Datos._IDPerfil;
            oLogin._NombrePerfil = Datos._NombrePerfil;
            oLogin._Estado = Datos._Estado;
            InitializeComponent();
        }
        private void cargar_perfil()
        {
            oConexion.Conectar();
            SqlCommand cmd = new SqlCommand("S_ListPerfil", oConexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbPerfil.DataSource = dt;
            cmbPerfil.DisplayMember = "NombrePerfil";
            cmbPerfil.ValueMember = "IDPerfil";
            cmbPerfil.SelectedValue = oLogin._IDPerfil;
            da.Dispose();
        }
        private void frmPerfil_Load(object sender, EventArgs e)
        {
            oLogin._Estado = true;
            Text = "Perfil del Usuario";
                
                cargar_perfil();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbPerfil.SelectedValue) == oLogin._IDPerfil)
            {
                frmPrincipal oFrmPrincipal = new frmPrincipal();
                oFrmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Perfil Incorrecto");
            }
        }
    }
}
