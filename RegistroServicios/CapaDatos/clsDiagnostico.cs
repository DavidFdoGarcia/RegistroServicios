using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroServicios.CapaDatos
{
    public class clsDiagnostico
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private string _diagnosticoO;
        private int _idorden;


        public int Idorden { get => _idorden; set => _idorden = value; }
        public string DiagnosticoO { get => _diagnosticoO; set => _diagnosticoO = value; }

        public clsDiagnostico()
        {
        }

        //Constructor con parametros

        public clsDiagnostico(int idOrden, string Diagnostico)
        {
            Idorden = idOrden;
            DiagnosticoO = Diagnostico;     
        }

        public void ActualizaOrdenDiagnostico(int idOrden, string Diagnostico)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "actualizaOrdenDiagnostico";
            Comando.Parameters.AddWithValue("@Orden", idOrden); ;
            Comando.Parameters.AddWithValue("@Diagnostico", Diagnostico);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }
    }


}
