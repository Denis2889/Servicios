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
    public partial class frmCliente : Form
    {
        Conexion oConexion = new Conexion();
        Clientes oClientes = new Clientes();
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet dts = new DataSet();
            dts = oConexion.ConsultaBDParametro("S_DCliente", "@DNI", this.txtDni.Text);
            if (dts.Tables[0].Rows.Count > 0)
            {
                var listaClientes = (from DataRow dr in dts.Tables[0].Rows
                                    select new Clientes()
                                    {
                                        DNI = dr["DNI"].ToString(),
                                        Nombres = dr["Nombres"].ToString(),
                                        Apellidos = dr["Apellidos"].ToString(),
                                        Celular = dr["Celular"].ToString(),
                                        Email = dr["Email"].ToString(),
                                        Direccion = dr["Direccion"].ToString(),
                                        Cuenta = Convert.ToBoolean(dr["Cuenta"])

                                    }
                                    );
                oClientes = listaClientes.First();
                txtDni.Text = oClientes.DNI;
                txtNombreCliente.Text = oClientes.Nombres;
                txtApellidosCliente.Text = oClientes.Apellidos;
                txtCelular.Text = oClientes.Celular;
                txtEmail.Text = oClientes.Email;
                txtDireccion.Text = oClientes.Direccion;
                btnEditar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existe Empresa con el valor Ingresado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();//
            HabilitarControles(true);//
            Opcion = 'N';
            this.btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            ControlDatosBusqueda(false);
        }
    }
}
