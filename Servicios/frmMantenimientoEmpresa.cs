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
    public partial class frmMantenimientoEmpresa : Form
    {
        Conexion oConexion = new Conexion();
        Empresa oEmpresa = new Empresa();
        public frmMantenimientoEmpresa()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = llenarCampos(txtDRuc.Text);
                
                txtDNombre.Text = Convert.ToString(dt.Rows[0]["NombreEmpresa"]);
                txtNombre.Text = Convert.ToString(dt.Rows[0]["NombreEmpresa"]);
                
                txtPersona.Text = Convert.ToString(dt.Rows[0]["Contacto"]);
                txtCelular.Text = Convert.ToString(dt.Rows[0]["Celular"]);
                txtDireccion.Text= Convert.ToString(dt.Rows[0]["Direccion"]);
                //txtRuc.Text = Convert.ToString(dt.Rows[0]["Ruc"]);
               txtRuc.Text = txtDRuc.Text;
                oConexion.Cerrar();
            }
            catch
            {
            }
        }
        void LimpiarText()
        {
            txtDRuc.Clear();
            txtDNombre.Clear();
            txtRuc.Clear();
            txtNombre.Clear();
            txtPersona.Clear();
            txtDireccion.Clear();
            txtCelular.Clear();
            txtRuc.Focus();
        }
        void Editar()
        {
            txtRuc.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtPersona.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtCelular.ReadOnly = false;
            txtRuc.ReadOnly = false;
            txtRuc.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDRuc.Enabled = false;
            txtDNombre.Enabled = false;
            Editar();
            LimpiarText();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarText();
            MessageBox.Show("Cancelar Registro");
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oConexion.Conectar();
            SqlCommand cmd2 = new SqlCommand("Select * from Empresa where Ruc='" + txtRuc.Text + "'", oConexion.conexion);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count == 0)
            {
                oConexion.Conectar();
                SqlCommand cmd = new SqlCommand("S_InsEmpresa'"
                + txtDRuc.Text + "','"
                + txtNombre.Text + "','"
                + txtPersona.Text + "','"
                + txtCelular.Text + "','"
                + txtDireccion.Text + "'", oConexion.conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                oConexion.Cerrar();
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("¡Bien! se Registraron Los Datos.", "Mapex.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarText();
                txtRuc.Focus();
            }
            else
            {
                MessageBox.Show("Ya existe");
                LimpiarText();
                txtRuc.Focus();
            }
            oConexion.Cerrar();
        }
        private DataTable llenarCampos(string ruc)
        {
            oConexion.Conectar();
            SqlCommand cmd = new SqlCommand("S_llenarCampos'" +
                ruc + "'", oConexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            
        }
        private void txtDRuc_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
