using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroServicios.CapaDatos
{
    public class clsOrden
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        private int _idorden;
        private int _idstatus;
        private int _idusuario;
        private string _fallacliente;

        public int Idorden { get => _idorden; set => _idorden = value; }
        public int Idstatus { get => _idstatus; set => _idstatus = value; }
        public string Fallacliente { get => _fallacliente; set => _fallacliente = value; }
        public int Idusuario { get => _idusuario; set => _idusuario = value; }

        public clsOrden()
        {
        }

        //Constructor con parametros

        public clsOrden(int idOrden, int idStatus, int idUsuario, string FallaCliente)
        {
            Idorden = idOrden;
            Idstatus = Idstatus;
            Idusuario = idUsuario;
            Fallacliente = FallaCliente;
        }

        public void InsertaOrdenStatus(int idOrden, int idStatus)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "insertaStatusOrden";
            Comando.Parameters.AddWithValue("@Orden", idOrden); ;
            Comando.Parameters.AddWithValue("@Status", idStatus);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void InsertaOrden()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "insertaOrden";

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void actualizaOrdenFallaC(int idOrden, string FallaCliente)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "actualizaOrdenFallaC";
            Comando.Parameters.AddWithValue("@Orden", idOrden); ;
            Comando.Parameters.AddWithValue("@Falla", FallaCliente);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void insertaUsuarioOrden(int idUsuario, int idOrden)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "insertaUsuarioOrden";
            Comando.Parameters.AddWithValue("@Orden", idOrden); ;
            Comando.Parameters.AddWithValue("@Usuario", idUsuario);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }
    }
}
