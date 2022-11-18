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
   public class clsAccesorios
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idaccesorio;
        private string _tipoaccesorio;
        private int _idorden;
        private string _seriaa;
        private string _observaciona;

        public int Idaccesorio { get => _idaccesorio; set => _idaccesorio = value; }
        public string Tipoaccesorio { get => _tipoaccesorio; set => _tipoaccesorio = value; }
        public int Idorden { get => _idorden; set => _idorden = value; }
        public string Seriaa { get => _seriaa; set => _seriaa = value; }
        public string Observaciona { get => _observaciona; set => _observaciona = value; }

        public clsAccesorios()
        {
        }

        //Constructor con parametros

        public clsAccesorios(int idAccesorio, int idOrden, string TipoAccesorio, string Serie, string Observacion)
        {
            Idaccesorio = idAccesorio;
            Tipoaccesorio = TipoAccesorio;
            Idorden = idOrden;
            Seriaa = Serie;
            Observaciona = Observacion;
        }

        public DataTable ListarAccesorio()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarAccesorio";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = ListarAccesorio();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["TipoAccesorio"]));
            }

            return coleccion;
        }


    }


}
