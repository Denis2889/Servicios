using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Transactions;

namespace Servicios
{
    public class Conexion
    {
        public SqlConnection conexion;

        public void Conectar()
        {
            try
            {
                conexion = new SqlConnection(@"server=DENIS ; " +
                "database=Servicios ; integrated security = true");
                conexion.Open();
                //MessageBox.Show("Abrio la conexion");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la conexion: " + error.Message);
            }
        }
        public void ConectarBD2()
        {
            try
            {
                conexion = new SqlConnection(@"server=DENIS ; " +
                "database=Banco ; integrated security = true");
                conexion.Open();
                //MessageBox.Show("Abrio la conexion");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error en la conexion: " + error.Message);
            }
        }
        public void Cerrar()
        {
            conexion.Close();
        }
        public DataSet ConsultaBD(string storeProcedure)
        {
            DataSet dts = new DataSet();
            Conectar();
            SqlCommand cmd = new SqlCommand(storeProcedure, conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dts);
            Cerrar();
            return dts;
        }
        public DataSet ConsultaBDParametro(string storeProcedure, string nombreParametro, string valorPrametro)
        {
            DataSet dts = new DataSet();
            Conectar();
            SqlCommand cmd = new SqlCommand(storeProcedure, conexion);
            cmd.CommandType = CommandType.StoredProcedure;//
            cmd.Parameters.AddWithValue(nombreParametro, valorPrametro);//
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dts);
            Cerrar();
            return dts;
        }
        //
        public DataSet ConsultaBDParametroDevUsuario(string storeProcedure, string usuario)
        {
            DataSet dts = new DataSet();
            Conectar();
            SqlCommand cmd = new SqlCommand(storeProcedure, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdUsuario", usuario);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dts);
            Cerrar();
            return dts;
        }
        //Crear Transaction Scope - donde realiza 2 conexiones - 2 bd - SERVIDORES
        public int CreateTransactionScope(string CodigoCliente1, double monto, string CodigoCliente2)
        {
            int valorExitoso = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //Abrir conexion 1 - Servicios
                    Conectar();
                    //Retiro
                    SqlCommand cmd = new SqlCommand("sp_RetiroCliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cCodigoCliente", CodigoCliente1);
                    cmd.Parameters.AddWithValue("@nMonto", monto);
                    valorExitoso = cmd.ExecuteNonQuery();
                    MessageBox.Show("Realizo el Retiro");
                    //Deposito (2 - Banco)
                    ConectarBD2();
                    SqlCommand cmd2 = new SqlCommand("sp_DepositoCliente", conexion);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@cCodigoCliente", CodigoCliente2);
                    cmd2.Parameters.AddWithValue("@nMonto", monto);
                    valorExitoso = cmd2.ExecuteNonQuery();
                    MessageBox.Show("Realizo el Deposito");

                    scope.Complete();
                    //devolver datos
                }

            }
            catch (TransactionAbortedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return valorExitoso;
        }
        //Insertar Data
        public void InsertarDatosEmpresa(string storeProcedure, Empresa dataEmpresa)
        {

            Conectar();
            SqlCommand cmd = new SqlCommand(storeProcedure, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nRuc", dataEmpresa.Ruc);
            cmd.Parameters.AddWithValue("@cNombreEmpresa", dataEmpresa.NombreEmpresa);
            cmd.Parameters.AddWithValue("@cPersonaContacto", dataEmpresa.PersonaContacto);
            cmd.Parameters.AddWithValue("@ncelular", dataEmpresa.celular);
            cmd.Parameters.AddWithValue("@cDireccion", dataEmpresa.Direccion);
            cmd.Parameters.AddWithValue("@lCuenta", dataEmpresa.Cuenta);
            cmd.Parameters.AddWithValue("@cUsuRegistro", dataEmpresa.Usuario);
            cmd.ExecuteNonQuery();
            Cerrar();
        }
    }
