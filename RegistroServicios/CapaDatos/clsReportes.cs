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
    public class clsReportes
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idusuario;
        private int _idrango;
        private int _idreporte;
        private int _idrefaccion;
        private string _nombrecompleto;
        private string _descripcionfalla;
        private double _importetotal;

        public int Idusuario { get => _idusuario; set => _idusuario = value; }
        public int Idrango { get => _idrango; set => _idrango = value; }
        public string Nombrecompleto { get => _nombrecompleto; set => _nombrecompleto = value; }
        public int Idreporte { get => _idreporte; set => _idreporte = value; }
        public string Descripcionfalla { get => _descripcionfalla; set => _descripcionfalla = value; }
        public int Idrefaccion { get => _idrefaccion; set => _idrefaccion = value; }
        public double Importetotal { get => _importetotal; set => _importetotal = value; }

        public clsReportes()
        {
        }

        //Constructor con parametros

        public clsReportes(int idReporte, int idRefaccion, int idUsuario, double ImporteTotal, string NombreCompleto, string DescipcionFalla)
        {
            Idusuario = idUsuario;
            Nombrecompleto = NombreCompleto;
            Idreporte = idReporte;
            Descripcionfalla = DescipcionFalla;
            Idrefaccion = idRefaccion;
            Importetotal = ImporteTotal;
        }

        public DataTable ListarTecnico()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarTecnicos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = ListarTecnico();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["NombreCompleto"]));
            }

            return coleccion;
        }

        public void ActualizaReporte(int idReporte, int idOrden, string DescripcionFalla)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizaReporte";
            Comando.Parameters.AddWithValue("@ID", idReporte);
            Comando.Parameters.AddWithValue("@Orden", idOrden);
            Comando.Parameters.AddWithValue("@Descripcion", DescripcionFalla);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void EliminaReporte(int idReporte)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminaReporte";
            Comando.Parameters.AddWithValue("@ID", idReporte);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void EliminaRefaccion(int idOrden)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminaRefaccion";
            Comando.Parameters.AddWithValue("@ID", idOrden);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void insertaReporte(int idOrden, string DescripcionFalla)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertaReporte";
            Comando.Parameters.AddWithValue("@Orden", idOrden);
            Comando.Parameters.AddWithValue("@Descripcion", DescripcionFalla);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void ActualizaOrdenImporteTotal(int idOrden, double ImporteTotal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizaOrdenImporteTotal";
            Comando.Parameters.AddWithValue("@Orden", idOrden);
            Comando.Parameters.AddWithValue("@Total", ImporteTotal);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void ActualizaOrdenEnReporte(int idReporte, int idOrden)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActualizaOrdenEnReporte";
            Comando.Parameters.AddWithValue("@Orden", idOrden);
            Comando.Parameters.AddWithValue("@Reporte", idReporte);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

    }
}
