using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroServicios.CapaDatos
{
    public class clsStatus
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idstatus;

        private int _idorden;
        private string _statusS;

        public int Idstatus { get => _idstatus; set => _idstatus = value; }
        public string StatusS { get => _statusS; set => _statusS = value; }
        public int Idorden { get => _idorden; set => _idorden = value; }

        public clsStatus()
        {
        }

        //Constructor con parametros

        public clsStatus(int idStatus, int idOrden, string Status)
        {
            Idstatus = idStatus;
            StatusS = Status;
            Idorden = idOrden;
        }

        public DataTable ListarStatus()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "llenarStatus";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable DatagridviewStatus(int idOrden)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DatagridviewStatus";
            Comando.Parameters.AddWithValue("@Orden", idOrden); 
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable actualizarOrdenStatus(int idOrden, int idStatus)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "actualizarOrdenStatus";
            Comando.Parameters.AddWithValue("@orden", idOrden);
            Comando.Parameters.AddWithValue("@status", idStatus);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
    }


   
}
