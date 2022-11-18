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
    public class clsRangoUsuario
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idUsuario;
        private int _idRango;
        private string _nombre_Completo;
        private string _rango;
        private string _nombreU;
        private string _apellidosU;
        private string _celularU;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdRango { get => _idRango; set => _idRango = value; }
        public string Nombre_Completo { get => _nombre_Completo; set => _nombre_Completo = value; }
        public string rango { get => _rango; set => _rango = value; }
        public string NombreU { get => _nombreU; set => _nombreU = value; }
        public string ApellidosU { get => _apellidosU; set => _apellidosU = value; }
        public string CelularU { get => _celularU; set => _celularU = value; }

        public clsRangoUsuario()
        {
        }

        //Constructor con parametros

        public clsRangoUsuario(int idRango, int idUsuario, string NombreCompleto, string Rango, string Nombre, string Apellidos, string Celular)
        {
            IdUsuario = idUsuario;
            IdRango = idRango;
            Nombre_Completo = NombreCompleto;
            rango = Rango;
            NombreU = Nombre;
            ApellidosU = Apellidos;
            CelularU = Celular;
        }

        public DataTable ListarEmpleados()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarEmpleados";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = ListarEmpleados();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["NombreCompleto"]));
            }

            return coleccion;
        }

        public DataTable InsertaUsuarioCliente(int Rango, string Nombre, string Apellidos, string Celular)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertaUsuarioCliente";
            Comando.Parameters.AddWithValue("@Rango", Rango); ;
            Comando.Parameters.AddWithValue("@Nombre", Nombre);
            Comando.Parameters.AddWithValue("@Apellidos", Apellidos);
            Comando.Parameters.AddWithValue("@Celular", Celular);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
    }
}
