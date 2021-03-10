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
    public partial class frmPrincipal : Form
    {
        Logueo oLogin = new Logueo();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios oFrmUser = new frmUsuarios();
            oFrmUser.ShowDialog();
            oFrmUser.BringToFront();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Cerrar Sesión.?", "Usuarios.", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                //varpublic.cadconex=null;
                this.Close();
                frmLogin oFrmLogin = new frmLogin(oLogin);
                oFrmLogin.Show();
            }
        }

        private void mantenimientoDeEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoEmpresa oMantEmpresa = new frmMantenimientoEmpresa();
            oMantEmpresa.ShowDialog();
        }
    }
}
