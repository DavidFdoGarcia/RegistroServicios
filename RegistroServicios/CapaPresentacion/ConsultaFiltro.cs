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
    public partial class ConsultaFiltro : Form
    {
        public ConsultaFiltro()
        {
            InitializeComponent();
        }

        

        private void ConsultaFiltro_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }

        private void ListarCliente()
        {
            clsFiltro objEq = new clsFiltro();
            cmbCliente.DataSource = objEq.ListarClientes();
            cmbCliente.DisplayMember = "Cliente";
            cmbCliente.ValueMember = "idUsuario";

            cmbCliente.AutoCompleteCustomSource = objEq.Autocomplete();
            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ConsultaOrdenFiltro()
        {
            clsFiltro objS = new clsFiltro();
            dataGridView1.DataSource = objS.ConsultaOrdenFiltro(Convert.ToInt32(txtOrden.Text));
            dgv.Formato(dataGridView1, 1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rOrden.Checked)
            {
              ConsultaOrdenFiltro();
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDiagnostico.Text = dataGridView1.Rows[e.RowIndex].Cells["Diagnostico"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells["FechaSalida"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells["Garantia"].Value.ToString();
            txtGarantia.Text = Consultagarantia();
        }

        public string Consultagarantia()
        {
            ConexionBD con = new ConexionBD();
            con.AbrirConexion();
            String fecha1 = dateTimePicker1.Value.Date.Year.ToString() + "/" + dateTimePicker1.Value.Date.Month.ToString() + "/" + dateTimePicker1.Value.Date.Day.ToString();
            String fecha2 = dateTimePicker2.Value.Date.Year.ToString() + "/" + dateTimePicker2.Value.Date.Month.ToString() + "/" + dateTimePicker2.Value.Date.Day.ToString();
            string query = "SELECT DATEDIFF(day, '" + fecha1 + "', '" + fecha2 + "') AS Diferencia;";
            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["Diferencia"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

    }
}
