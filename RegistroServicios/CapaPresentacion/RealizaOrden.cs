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
    public partial class RealizaOrden : Form
    {
        public RealizaOrden()
        {
            InitializeComponent();

            ConexionBD cn = new ConexionBD();

            dtIngreso.Enabled = false;
            txtOrden.Enabled = true;

            ListarEquipos();
            ListarEmpleados();
            ListarAccesorio();
        }

        DataTable Tabla = new DataTable();

        private void RealizaOrden_Load(object sender, EventArgs e)
        {
            dgv.Formato(dataGridView1, 1);

            txtOrden.Text = ConsultaOrdenId();

            Tabla.Columns.Add("idAccesorio");
            Tabla.Columns.Add("Accesorio");
            Tabla.Columns.Add("Serie");
            Tabla.Columns.Add("Observacion");
            Tabla.Columns.Add("Orden");

            dataGridView1.DataSource = Tabla;
        }

        private void ListarEquipos()
        {
            clsEquipo objEq = new clsEquipo();
            cmbEquipo.DataSource = objEq.ListarEquipos();
            cmbEquipo.DisplayMember = "TipoEquipo";
            cmbEquipo.ValueMember = "idEquipo";

            cmbEquipo.AutoCompleteCustomSource = objEq.Autocomplete();
            cmbEquipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbEquipo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ListarEmpleados()
        {
            clsRangoUsuario objRaUsu = new clsRangoUsuario();
            cmbAtiende.DataSource = objRaUsu.ListarEmpleados();
            cmbAtiende.DisplayMember = "NombreCompleto";
            cmbAtiende.ValueMember = "idUsuario";

            cmbAtiende.AutoCompleteCustomSource = objRaUsu.Autocomplete();
            cmbAtiende.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbAtiende.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ListarAccesorio()
        {
            clsAccesorios objAcc = new clsAccesorios();
            cmbAccesorio.DataSource = objAcc.ListarAccesorio();
            cmbAccesorio.DisplayMember = "TipoAccesorio";
            cmbAccesorio.ValueMember = "idAccesorio";

            cmbAccesorio.AutoCompleteCustomSource = objAcc.Autocomplete();
            cmbAccesorio.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbAccesorio.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public string ConsultaOrdenId()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select max (idOrden)+1 as ID from Orden";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["ID"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string ConsultaUsuarioId()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select max (idUsuario) as ID from Usuario";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["ID"].ToString();
            }
            else
            {
                return "NULL";
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tabla = dataGridView1.DataSource as DataTable;
            DataRow datarow;
            datarow = Tabla.NewRow();

            datarow["idAccesorio"] = Convert.ToInt32(cmbAccesorio.SelectedValue);
            datarow["Accesorio"] = cmbAccesorio.Text;
            datarow["Serie"] = 1;
            datarow["Observacion"] = 1;
            datarow["Orden"] = txtOrden.Text;
            Tabla.Rows.Add(datarow);
        } //Botón Agregar

        private void button3_Click(object sender, EventArgs e) //Botón Guardar
        {
            InsertaUsuarioCliente();
            InsertaOrdenEquipo();
            InsertaAccesorio();
            InsertaOrdenStatus();
            actualizaOrdenFallaC();

            txtIDUsu.Text = ConsultaUsuarioId();
            insertaOrdenUsuario();

        }
        
        public void InsertaUsuarioCliente()
        {
            clsRangoUsuario clu = new clsRangoUsuario();
            clu.InsertaUsuarioCliente(1, txtNombre.Text, txtApellido.Text, txtCel.Text);
            MessageBox.Show("El usuario fue agregado");
        }

        private void InsertaOrdenEquipo()
        {
            clsEquipo objEq = new clsEquipo();
            objEq.InsertaOrdenEquipo(Convert.ToInt32(txtOrden.Text), Convert.ToInt32(cmbEquipo.SelectedValue), txtModelo.Text, txtSerie.Text, txtObservacion.Text);
            MessageBox.Show("El equipo fue agregado");
        }

        private void InsertaOrdenStatus()
        {
            clsOrden clsO = new clsOrden();
            clsO.InsertaOrdenStatus(Convert.ToInt16(txtOrden.Text), 1);
        }

        private void insertaOrden()
        {
            clsOrden clsO = new clsOrden();
            clsO.InsertaOrden();
        }

        private void insertaOrdenUsuario()
        {
            clsOrden clsO = new clsOrden();
            clsO.insertaUsuarioOrden(Convert.ToInt16(txtIDUsu.Text), Convert.ToInt16(txtOrden.Text));
        }

        public void InsertaAccesorio()
        {

            try
            {
                ConexionBD cn = new ConexionBD();
                cn.AbrirConexion();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "INSERT INTO AccesorioOrden(idAccesorio,idOrden,Serie,Observacion) Values (@Accesorio,@Orden,@Serie,@Observacion)";
                cmd2.Connection = cn.AbrirConexion();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@Accesorio", Convert.ToString(row.Cells["idAccesorio"].Value));
                    cmd2.Parameters.AddWithValue("@Orden", Convert.ToString(row.Cells["idOrden"].Value));
                    cmd2.Parameters.AddWithValue("@Serie", Convert.ToString(row.Cells["Serie"].Value));
                    cmd2.Parameters.AddWithValue("@Observacion", Convert.ToString(row.Cells["Observacion"].Value));
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron agregados con exito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al agregar" + ex);
            }


        }



        private void actualizaOrdenFallaC()
        {
            clsOrden cls = new clsOrden();
            cls.actualizaOrdenFallaC(Convert.ToInt16(txtOrden.Text), txtFalla.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            insertaOrden();
        }
    }
    
}
