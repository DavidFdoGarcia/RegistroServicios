using RegistroServicios.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroServicios.CapaPresentacion
{
    public partial class ModificarFechaSalida : Form
    {
        public ModificarFechaSalida()
        {
            InitializeComponent();
        }

        private void ModificarFechaSalida_Load(object sender, EventArgs e)
        {

        }

        private void DatagridviewCambiarFecha()
        {
            clsFechaSalida objS = new clsFechaSalida();
            dataGridView1.DataSource = objS.DatagridviewCambiarFecha(Convert.ToInt32(txtOrden.Text));
            dgv.Formato(dataGridView1, 1);
        }

        private void actualizarOrdenFecha()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            String FechaS = dateTimePicker1.Value.Date.Year.ToString() + "/" + dateTimePicker1.Value.Date.Month.ToString() + "/" + dateTimePicker1.Value.Date.Day.ToString();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "actualizarOrdenFecha";
            cmd2.Connection = cn.AbrirConexion();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@fecha", FechaS);
            cmd2.Parameters.AddWithValue("@orden", txtOrden.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            actualizarOrdenFecha();
            DatagridviewCambiarFecha();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DatagridviewCambiarFecha();
        }
    }
}
