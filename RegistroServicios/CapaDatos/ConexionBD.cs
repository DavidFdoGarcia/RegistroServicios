
using RegistroServicios.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Configuration.ConfigurationManager;

namespace RegistroServicios.CapaDatos
{
    public class ConexionBD
    {
        public static string ObtenerString()
        {
            return Settings.Default.RegistroServiciosConnectionString;
        }

        static private string CadenaConexion = ObtenerString();
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

        public static void cambiarConexion(string cadenaConex)
        {
            String cadenaNueva = cadenaConex;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["PuntoVenta.Properties.Settings.PuntoVentaConnectionString"].ConnectionString = cadenaNueva;
            config.Save(ConfigurationSaveMode.Modified, true);
            Properties.Settings.Default.Save();
            MessageBox.Show("LA CADENA DE CONEXION SE ACTUALIZO CORRECTAMENTE", "INFORMACION DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
