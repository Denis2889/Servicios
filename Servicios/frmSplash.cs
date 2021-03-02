using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public partial class frmSplash : Form
    {
        Logueo oLogin = new Logueo();
        public frmSplash()
        {
            InitializeComponent();
        }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 30;
            Timer1.Enabled = true;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Increment(1);
            if(ProgressBar1.Value == ProgressBar1.Maximum)
            {
                frmLogin oFrmLogin = new frmLogin(oLogin);
                oFrmLogin.Show();
                this.Hide();
                Timer1.Stop();
            }
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        
    }
}
