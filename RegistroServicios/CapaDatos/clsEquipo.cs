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
    public class clsEquipo
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idEquipo;
        private string _tipoEquipo;
        private int _idorden;
        private string _modeloO;
        private string _serieO;
        private string _ObservacionO;

        public int IdEquipo { get => _idEquipo; set => _idEquipo = value; }
        public string tipoEquipo { get => _tipoEquipo; set => _tipoEquipo = value; }
        public int Idorden { get => _idorden; set => _idorden = value; }
        public string ModeloO { get => _modeloO; set => _modeloO = value; }
        public string SerieO { get => _serieO; set => _serieO = value; }
        public string ObservacionO { get => _ObservacionO; set => _ObservacionO = value; }

        public clsEquipo()
        {
        }

        //Constructor con parametros

        public clsEquipo(int idEquipo, int idOrden, string TipoEquipo, string Modelo, string Serie)
        {
            IdEquipo = idEquipo;
            tipoEquipo = TipoEquipo;
            Idorden = idOrden;
            ModeloO = Modelo;
            SerieO = Serie;
        }

        public DataTable ListarEquipos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarEquipos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = ListarEquipos();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["TipoEquipo"]));
            }

            return coleccion;
        }

        public void InsertaOrdenEquipo(int idOrden, int idEquipo, string Modelo, string Serie, string Observacion)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertaEquipoOrden";
            Comando.Parameters.AddWithValue("@Orden", idOrden); ;
            Comando.Parameters.AddWithValue("@Equipo", idEquipo);
            Comando.Parameters.AddWithValue("@Modelo", Modelo);
            Comando.Parameters.AddWithValue("@Serie", Serie);
            Comando.Parameters.AddWithValue("@Observacion", Observacion);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            
        }

    }
}
