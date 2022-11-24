using RegistroServicios.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroServicios.CapaPresentacion
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();

            ListarTecnicos();


        }
        DataTable Tabla = new DataTable();

        private void Reportes_Load(object sender, EventArgs e)
        {
            txtOrden.Enabled = false;
            txtIDReporte.Enabled = false;
            txtEquipo.Enabled = false;
            txtCel.Enabled = false;
            txtReporte.Enabled = false;
            txtApellido.Enabled = false;
            txtModelo.Enabled = false;
            txtSerie.Enabled = false;
            dtSalida.Enabled = false;
            txtNombre.Enabled = false;
            cmbReparo.Enabled = false;
            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnGuardar.Enabled = false;
            txtCantidad.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            btnAgregar.Enabled = false;
            txtImp.Enabled = false;
            btnCancelar.Enabled = false;
            radioButton1.Enabled = false;

            dgv.Formato(dataGridView1, 1);


            Tabla.Columns.Add("idOrden");
            Tabla.Columns.Add("Cantidad");
            Tabla.Columns.Add("Descripcion");
            Tabla.Columns.Add("Precio");
            Tabla.Columns.Add("Importe");

            dataGridView1.DataSource = Tabla;
        }

        private void ListarTecnicos()
        {
            clsReportes obj = new clsReportes();
            cmbReparo.DataSource = obj.ListarTecnico();
            cmbReparo.DisplayMember = "NombreCompleto";
            cmbReparo.ValueMember = "idUsuario";

            cmbReparo.AutoCompleteCustomSource = obj.Autocomplete();
            cmbReparo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbReparo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public string ConsultaOrdenNombre()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select Usuario.Nombre from Usuario inner join UsuarioOrden on UsuarioOrden.idUsuario = Usuario.idUsuario where UsuarioOrden.idOrden='" + txtOrden.Text + "'";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["Nombre"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string ConsultaOrdenApellidos()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select Usuario.Apellidos from Usuario inner join UsuarioOrden on UsuarioOrden.idUsuario = Usuario.idUsuario where UsuarioOrden.idOrden='" + txtOrden.Text + "'";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["Apellidos"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string ConsultaOrdenCelular()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select Usuario.Celular from Usuario inner join UsuarioOrden on UsuarioOrden.idUsuario = Usuario.idUsuario where UsuarioOrden.idOrden='" + txtOrden.Text + "'";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["Celular"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string ConsultaOrdenEquipo()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select Equipo.TipoEquipo from Equipo inner join OrdenEquipo on OrdenEquipo.idEquipo = Equipo.idEquipo where OrdenEquipo.idOrden='" + txtOrden.Text + "'";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["TipoEquipo"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string ConsultaOrdenModelo()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select OrdenEquipo.Modelo from OrdenEquipo where OrdenEquipo.idOrden='" + txtOrden.Text + "'";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["Modelo"].ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string ConsultaOrdenSerie()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select OrdenEquipo.Serie from OrdenEquipo where OrdenEquipo.idOrden='" + txtOrden.Text + "'";
            SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion());
            SqlDataReader reg = cmd.ExecuteReader();
            if (reg.Read())
            {
                return reg["Serie"].ToString();
            }
            else
            {
                return "NULL";
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = ConsultaOrdenNombre();
            txtApellido.Text = ConsultaOrdenApellidos();
            txtCel.Text = ConsultaOrdenCelular();
            txtEquipo.Text = ConsultaOrdenEquipo();
            txtModelo.Text = ConsultaOrdenModelo();
            txtSerie.Text = ConsultaOrdenSerie();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsReportes cls = new clsReportes();
            cls.ActualizaReporte(Convert.ToInt32(txtIDReporte.Text), txtReporte.Text);
            
            InsertaRefaccion();
        }

        public string ConsultaReporteId()
        {
            ConexionBD cn = new ConexionBD();
            cn.AbrirConexion();
            string query = "select max (idReporte) as ID from Reporte";
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


        public void InsertaRefaccion()
        {

            try
            {
                ConexionBD cn = new ConexionBD();
                cn.AbrirConexion();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "INSERT INTO Refaccion(idOrden,TipoRefaccion,Cantidad,PrecioUnitario,ImporteRefaccion) Values (@Orden,@Tipo,@Cantidad,@Precio,@Importe)";
                cmd2.Connection = cn.AbrirConexion();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@Orden", Convert.ToString(row.Cells["idOrden"].Value));
                    cmd2.Parameters.AddWithValue("@Tipo", Convert.ToString(row.Cells["Descripcion"].Value));
                    cmd2.Parameters.AddWithValue("@Cantidad", Convert.ToString(row.Cells["Cantidad"].Value));
                    cmd2.Parameters.AddWithValue("@Precio", Convert.ToString(row.Cells["Precio"].Value));
                    cmd2.Parameters.AddWithValue("@Importe", Convert.ToString(row.Cells["Importe"].Value));
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron agregados con exito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al agregar" + ex);
            }


        }


        public void ImporteTotal()
        {
            decimal Total = 0;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                Total += Convert.ToDecimal(Row.Cells["Importe"].Value);
            }
            txtImp.Text = Convert.ToString(Total);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Imprimir;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            int ancho = 1000;
            int y = 20;
            //Font tipoTexto = new Font("Arial", 10, FontStyle.Bold);
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Font font2 = new Font("Arial", 8, FontStyle.Bold);
            //  
            e.Graphics.DrawImage(pictureCabecera.Image, new Rectangle(5, 5, 850, 80));
            e.Graphics.DrawString("Reporte de Orde No.: " + txtOrden.Text, font, Brushes.Black, new Rectangle(360, y += 50, ancho, 60));

            e.Graphics.DrawString("Fecha de Salida: " + dtSalida.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("Apellidos: " + txtApellido.Text, font, Brushes.Black, new Rectangle(450, y + 30, ancho, 60));
            e.Graphics.DrawString("Nombre: " + txtNombre.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("Modelo: " + txtModelo.Text, font, Brushes.Black, new Rectangle(450, y + 30, ancho, 60));
            e.Graphics.DrawString("Equipo: " + txtEquipo.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("Reparó: " + cmbReparo.Text, font, Brushes.Black, new Rectangle(450, y + 30, ancho, 60));
            e.Graphics.DrawString("No. Serie: " + txtSerie.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));
            e.Graphics.DrawString("Reporte: " + txtReporte.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("No. Refacciones", font, Brushes.Black, new Rectangle(270, y += 50, ancho, 60));

            e.Graphics.DrawString("Cant.", font, Brushes.Black, new Rectangle(50, y + 20, ancho, 60));
            e.Graphics.DrawString("Descripción", font, Brushes.Black, new Rectangle(120, y + 20, ancho, 60));
            e.Graphics.DrawString("Precio", font, Brushes.Black, new Rectangle(230, y + 20, ancho, 60));
            e.Graphics.DrawString("Importe", font, Brushes.Black, new Rectangle(290, y + 20, ancho, 60));





            foreach (DataRow row in Tabla.Rows)
            {
                e.Graphics.DrawString(row["Cantidad"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +



               row["Descripcion"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +

                row["Precio"].ToString() + " " + " " + " " + " " + " " +

                row["Importe"].ToString()

                   , font2, Brushes.Black, new Rectangle(50, y += 40, 1000, 60));


            }
            e.Graphics.DrawString("Monto a pagar: " + txtImp.Text, font, Brushes.Black, new Rectangle(50, y += 50, 1000, 60));
            e.Graphics.DrawString("Firma de conformidad", font, Brushes.Black, new Rectangle(50, y += 40, ancho, 60));
            e.Graphics.DrawImage(picturePie.Image, new Rectangle(5, y += 80, 850, 50));


            e.Graphics.DrawImage(pictureCabecera.Image, new Rectangle(5, y = 580, 850, 80));
            e.Graphics.DrawString("Reporte de Orden No.: " + txtOrden.Text, font, Brushes.Black, new Rectangle(360, y += 70, ancho, 60));
            e.Graphics.DrawString("Fecha de Salida: " + dtSalida.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("Apellidos: " + txtApellido.Text, font, Brushes.Black, new Rectangle(450, y + 30, ancho, 60));
            e.Graphics.DrawString("Nombre: " + txtNombre.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("Modelo: " + txtModelo.Text, font, Brushes.Black, new Rectangle(450, y + 30, ancho, 60));
            e.Graphics.DrawString("Equipo: " + txtEquipo.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("Reparó: " + cmbReparo.Text, font, Brushes.Black, new Rectangle(450, y + 30, ancho, 60));
            e.Graphics.DrawString("No. Serie: " + txtSerie.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));
            e.Graphics.DrawString("Reporte: " + txtReporte.Text, font, Brushes.Black, new Rectangle(50, y += 30, ancho, 60));

            e.Graphics.DrawString("No. Refacciones", font, Brushes.Black, new Rectangle(270, y += 50, ancho, 60));

            e.Graphics.DrawString("Cant.", font, Brushes.Black, new Rectangle(50, y + 20, ancho, 60));
            e.Graphics.DrawString("Descripción", font, Brushes.Black, new Rectangle(120, y + 20, ancho, 60));
            e.Graphics.DrawString("Precio", font, Brushes.Black, new Rectangle(230, y + 20, ancho, 60));
            e.Graphics.DrawString("Importe", font, Brushes.Black, new Rectangle(290, y + 20, ancho, 60));

            foreach (DataRow row in Tabla.Rows)
            {
                e.Graphics.DrawString(row["Cantidad"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +



               row["Descripcion"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +

                row["Precio"].ToString() + " " + " " + " " + " " + " " +

                row["Importe"].ToString()

                   , font2, Brushes.Black, new Rectangle(50, y += 40, 1000, 60));


            }
            e.Graphics.DrawString("Monto a pagar: " + txtImp.Text, font, Brushes.Black, new Rectangle(50, y += 50, 1000, 60));
            e.Graphics.DrawString("Firma de conformidad", font, Brushes.Black, new Rectangle(50, y += 40, ancho, 60));
            e.Graphics.DrawImage(picturePie.Image, new Rectangle(5, y += 80, 850, 50));
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            double importe = Convert.ToDouble(txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text);
            Tabla = dataGridView1.DataSource as DataTable;
            DataRow datarow;
            datarow = Tabla.NewRow();

            datarow["idOrden"] = txtOrden.Text;
            datarow["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
            datarow["Descripcion"] = txtDescripcion.Text;
            datarow["Precio"] = Convert.ToDouble(txtPrecio.Text);
            datarow["Importe"] = importe;
            Tabla.Rows.Add(datarow);

            ImporteTotal();

            lblRow.Text = "Total de registros: " + Convert.ToString(dataGridView1.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
             clsReportes cls = new clsReportes();
            cls.insertaReporte(txtReporte.Text);
            MessageBox.Show("El reporte esta listo para ser procesado");

            txtIDReporte.Text = ConsultaReporteId();

            txtOrden.Enabled = true;
            txtReporte.Enabled = true;
            cmbReparo.Enabled = true;
            btnBuscar.Enabled = true;
            btnImprimir.Enabled = true;
            btnGuardar.Enabled = true;
            txtCantidad.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            btnAgregar.Enabled = true;
            txtImp.Enabled = true;
            btnCancelar.Enabled = true;
            radioButton1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clsReportes cls = new clsReportes();
            cls.EliminaReporte(Convert.ToInt32(txtIDReporte.Text));

            cls.EliminaRefaccion(Convert.ToInt32(txtOrden.Text));
        }
    }

}
