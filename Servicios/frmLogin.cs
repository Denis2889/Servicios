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
    public partial class frmLogin : Form
    {
        Conexion oConexion = new Conexion();
        Logueo oLogin = new Logueo();
        public frmLogin(Logueo Datos)
        {
            oLogin._User = Datos._User;
            oLogin._Clave = Datos._Clave;
            oLogin._IDPerfil = Datos._IDPerfil;
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "" && txtcontraseña.Text != "")
            {
                oConexion.Conectar();
                SqlCommand cmd = new SqlCommand("S_Login '" + txtusuario.Text + "','" + txtcontraseña.Text + "'", oConexion.conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    oLogin._IDPerfil = Convert.ToInt32(dt.Rows[0][0]);
                    oLogin._Clave = dt.Rows[0][0].ToString();
                    //varpublic.privilegios = Boolean.Parse(dt.Rows[0][0].ToString());
                    frmPerfil oPerfil = new frmPerfil(oLogin);
                    oPerfil.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error, usuario y/o contraseña incorrectos.");
                }
            }
            else
            {
                MessageBox.Show("Error, datos incompletos...");
            }
        }
    }
}
