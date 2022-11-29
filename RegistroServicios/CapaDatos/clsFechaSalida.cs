using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroServicios.CapaDatos
{
    public class clsFechaSalida
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idorden;
        private DateTime _fechaingreso;
        private DateTime _garantiao;

        public int Idorden { get => _idorden; set => _idorden = value; }
        public DateTime Fechaingreso { get => _fechaingreso; set => _fechaingreso = value; }
        public DateTime Garantiao { get => _garantiao; set => _garantiao = value; }

        public clsFechaSalida()
        {
        }

        //Constructor con parametros

        public clsFechaSalida(int idOrden, DateTime FechaIngreso, DateTime Garantia)
        {
            Fechaingreso = FechaIngreso;
            Idorden = idOrden;
            Garantiao = Garantia;
        }

        public DataTable DatagridviewCambiarFecha(int idOrden)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DatagridviewCambiarFecha";
            Comando.Parameters.AddWithValue("@Orden", idOrden);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable DatagridviewGarantia(int idOrden)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DatagridviewGarantia";
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
