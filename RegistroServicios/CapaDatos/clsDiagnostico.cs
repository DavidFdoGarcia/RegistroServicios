using System;
using System.Collections.Generic;
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


    }


}
