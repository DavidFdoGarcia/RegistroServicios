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
    public class clsFiltro
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idorden;
        private string _equipof;
        private string _fallaf;
        private string _clientef;
        private DateTime _ingresof;
        private string _statusf;
        private double _importef;
        private DateTime _garantiaf;

        public int Idorden { get => _idorden; set => _idorden = value; }
        public string Equipof { get => _equipof; set => _equipof = value; }
        public string Fallaf { get => _fallaf; set => _fallaf = value; }
        public string Statusf { get => _statusf; set => _statusf = value; }
        public double Importef { get => _importef; set => _importef = value; }
        public DateTime Garantiaf { get => _garantiaf; set => _garantiaf = value; }
        public DateTime Ingresof { get => _ingresof; set => _ingresof = value; }
        public string Clientef { get => _clientef; set => _clientef = value; }

        public clsFiltro()
        {
        }

        //Constructor con parametros

        public clsFiltro(int idOrden, string Equipo, string FallaCliente, string Status, double ImporteTotal, DateTime Garantia,DateTime FechaIngreso,string Cliente)
        {
            Idorden = idOrden;
            Equipof = Equipo;
            Fallaf = FallaCliente;
            Statusf = Status;
            Importef = ImporteTotal;
            Garantiaf = Garantia;
            Ingresof = FechaIngreso;
            Clientef = Cliente;
        }

        public DataTable ListarClientes()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "listarclientes";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = ListarClientes();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["Cliente"]));
            }

            return coleccion;
        }

        public DataTable ConsultaOrdenFiltro(int idOrden)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ConsultaOrdenFiltro";
            Comando.Parameters.AddWithValue("@Orden", idOrden);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

    }
}
