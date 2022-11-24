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
            txtOrden.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtCel.Enabled = false;
            cmbAccesorio.Enabled = false;
            cmbEquipo.Enabled = false;
            txtModelo.Enabled = false;
            txtSerie.Enabled = false;
            dtIngreso.Enabled = false;
            txtNombre.Enabled = false;
            txtObservacion.Enabled = false;
            cmbAtiende.Enabled = false;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            txtFalla.Enabled = false; 
            radioButton1.Enabled = false;

            dgv.Formato(dataGridView1, 1);

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
            string query = "select max (idOrden) as ID from Orden";
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
            insertaOrdenUsuarioE();
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
            MessageBox.Show("La Orden fue Agregada!!");
        }

        private void insertaOrdenUsuario()
        {
            clsOrden clsO = new clsOrden();
            clsO.insertaUsuarioOrden(Convert.ToInt16(txtIDUsu.Text), Convert.ToInt16(txtOrden.Text));
        }

        private void insertaOrdenUsuarioE()
        {
            clsOrden clsO = new clsOrden();
            clsO.insertaEmpleadoOrden(Convert.ToInt16(cmbAtiende.SelectedValue), Convert.ToInt16(txtOrden.Text));
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

        private void EliminaOrden()
        {
            clsOrden cls = new clsOrden();
            cls.EliminaOrden(Convert.ToInt16(txtOrden.Text));
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea agregar una nueva orden? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                txtOrden.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtCel.Enabled = true;
                cmbAccesorio.Enabled = true;
                cmbEquipo.Enabled = true;
                txtModelo.Enabled = true;
                txtSerie.Enabled = true;
                dtIngreso.Enabled = true;
                txtNombre.Enabled = true;
                txtObservacion.Enabled = true;
                cmbAtiende.Enabled = true;
                btnImprimir.Enabled = true;
                btnCancelar.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                txtFalla.Enabled = true;
                radioButton1.Enabled = true;

                insertaOrden();
                txtOrden.Text = ConsultaOrdenId();
            }
            
        }

        private void button2_Click(object sender, EventArgs e) //botonImprimir1
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

        private void Imprimir2(object sender, PrintPageEventArgs e)
        {
            //Font tipoTexto = new Font("Arial", 10, FontStyle.Bold);
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Font font2 = new Font("Arial", 8, FontStyle.Bold);
            //  
            int y = 20;
            e.Graphics.DrawImage(pictureCabecera.Image, new Rectangle(5, y += 600, 850, 80));
            e.Graphics.DrawString("Orden de Servicio", font, Brushes.Black, new Rectangle(360, y += 70, 1000, 60));

            e.Graphics.DrawString("No.Orden: " + txtOrden.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Fecha de Ingreso: " + dtIngreso.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Equipo: " + cmbEquipo.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Nombre: " + txtNombre.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Modelo: " + txtModelo.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Apellidos: " + txtApellido.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Serie: " + txtSerie.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Celular: " + txtCel.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Falla: " + txtFalla.Text, font, Brushes.Black, new Rectangle(20, y += 60, 1000, 60));

            e.Graphics.DrawString("Accesorio", font, Brushes.Black, new Rectangle(20, y += 60, 1000, 60));
            e.Graphics.DrawString("Serie", font, Brushes.Black, new Rectangle(230, y + 0, 1000, 60));
            e.Graphics.DrawString("Observacion", font, Brushes.Black, new Rectangle(400, y + 0, 1000, 60));

            foreach (DataRow row in Tabla.Rows)
            {
                e.Graphics.DrawString(row["Accesorio"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +



               row["Serie"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +

                row["Observacion"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "


                   , font2, Brushes.Black, new Rectangle(20, y += 25, 1000, 60));
            }

            e.Graphics.DrawImage(picturePie.Image, new Rectangle(5, y += 25, 850, 50));

            e.Graphics.DrawString("Condiciones generales", font2, Brushes.Black, new Rectangle(360, 120, 1000, 60));
            e.Graphics.DrawString("I. Todo equipo nuevo viene con su póliza de garantía en la cual se especifican los términos de la misma.", font2, Brushes.Black, new Rectangle(20, 140, 900, 60));
            e.Graphics.DrawString("II. Toda revisión de equipos fuera de su garantía genera un cargo, siendo el monto minimo de $100.00 + IVA \n el cual cambiará de acuerdo al modelo del equipo.", font2, Brushes.Black, new Rectangle(20, 160, 900, 60));
            e.Graphics.DrawString("III. Toda reparación que requiera cambio de parte, se solicitara el 50% de anticipo.", font2, Brushes.Black, new Rectangle(20, 190, 900, 60));
            e.Graphics.DrawString("IV. Toda revisión o reparación en la que no proceda la garantía tendra un costo.", font2, Brushes.Black, new Rectangle(20, 210, 900, 60));
            e.Graphics.DrawString("V. La garantía del equipo no cubre problemas de software(programas y aplicaciones) únicamente problemas de hardware (daños fisicos).", font2, Brushes.Black, new Rectangle(20, 230, 900, 60));
            e.Graphics.DrawString("VI. La garantía del equipo tampoco cubre el servicio de mantenimiento preventivo.", font2, Brushes.Black, new Rectangle(20, 250, 900, 60));
            e.Graphics.DrawString("VII. La garantía del servicio es de 30 días naturales.", font2, Brushes.Black, new Rectangle(20, 270, 900, 60));
            e.Graphics.DrawString("VIII. En el caso de la información contenida en el disco duro es RESPONSABILIDAD ABSOLUTA DEL CLIENTE.", font2, Brushes.Black, new Rectangle(20, 290, 900, 60));
            e.Graphics.DrawString("IX. Todo equipo que no se haya recogido después de 8 días de habérse notificado al cliente, tendrá un cargo de almacenamiento de $15.00 por día", font2, Brushes.Black, new Rectangle(20, 310, 900, 60));
            e.Graphics.DrawString("X. Transcurridos 30 días naturales después de la notificación, el equipo se pasará al almacén de destrucción sin ninguna  responsabilidad para \n Computadoras Centro de Servicio.", font2, Brushes.Black, new Rectangle(20, 330, 900, 60));
            e.Graphics.DrawString("XI. El horario para seguimiento de reportes es de 10:00 a 19:00 hrs. de lunes a viernes, sábados de 10:00 a 14:00 hrs. \n a los teléfonos 444-817-5710, 444-128-6760, WhatsApp 444-427-3576.", font2, Brushes.Black, new Rectangle(20, 360, 900, 60));

            e.Graphics.DrawString("ACEPTO", font2, Brushes.Black, new Rectangle(80, 390, 800, 60));
            e.Graphics.DrawString("NOMBRE Y FIRMA", font2, Brushes.Black, new Rectangle(50, 410, 900, 60));

            e.Graphics.DrawString("RECIBE", font2, Brushes.Black, new Rectangle(630, 390, 880, 60));
            e.Graphics.DrawString(cmbAtiende.Text, font2, Brushes.Black, new Rectangle(600, 410, 900, 60));
            /*//e.Graphics.DrawString(txtTitulo.Text, font, Brushes.Black, 50, 130);
            Bitmap varbmp = new Bitmap(este.Image);
            Image img = este.Image;
            e.Graphics.DrawImage(img, new Rectangle(20, 30, 185, 50));
            e.Graphics.DrawString("*" + txtCodigo.Text + "*", font, Brushes.Black, new Rectangle(75, 85, 150, 20)); */

        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            //Font tipoTexto = new Font("Arial", 10, FontStyle.Bold);
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Font font2 = new Font("Arial", 10, FontStyle.Bold);
            // 
            int y = 20;
            e.Graphics.DrawImage(pictureCabecera.Image, new Rectangle(5, 5, 850, 80));
            e.Graphics.DrawString("Orden de Servicio", font, Brushes.Black, new Rectangle(360, y += 60, 1000, 60));

            e.Graphics.DrawString("No.Orden: " + txtOrden.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Fecha de Ingreso: " + dtIngreso.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Equipo: " + cmbEquipo.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Nombre: " + txtNombre.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Modelo: " + txtModelo.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Apellidos: " + txtApellido.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Serie: " + txtSerie.Text, font, Brushes.Black, new Rectangle(500, y + 30, 1000, 60));
            e.Graphics.DrawString("Celular: " + txtCel.Text, font, Brushes.Black, new Rectangle(20, y += 30, 1000, 60));

            e.Graphics.DrawString("Falla: " + txtFalla.Text, font, Brushes.Black, new Rectangle(20, y += 60, 1000, 60));

            e.Graphics.DrawString("Accesorio", font, Brushes.Black, new Rectangle(20, y += 60, 1000, 60));
            e.Graphics.DrawString("Serie", font, Brushes.Black, new Rectangle(230, y + 0, 1000, 60));
            e.Graphics.DrawString("Observacion", font, Brushes.Black, new Rectangle(400, y + 0, 1000, 60));

            foreach (DataRow row in Tabla.Rows)
            {
                e.Graphics.DrawString(row["Accesorio"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +



               row["Serie"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +

                row["Observacion"].ToString() + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "


                   , font2, Brushes.Black, new Rectangle(20, y += 25, 1000, 60));
            }
            e.Graphics.DrawImage(picturePie.Image, new Rectangle(5, y += 25, 850, 50));

            e.Graphics.DrawString("Condiciones generales", font2, Brushes.Black, new Rectangle(360, 600, 1000, 60));
            e.Graphics.DrawString("I. Todo equipo nuevo viene con su póliza de garantía en la cual se especifican los términos de la misma.", font2, Brushes.Black, new Rectangle(20, 620, 900, 60));
            e.Graphics.DrawString("II. Toda revisión de equipos fuera de su garantía genera un cargo, siendo el monto minimo de $100.00 + IVA \n el cual cambiará de acuerdo al modelo del equipo.", font2, Brushes.Black, new Rectangle(20, 650, 900, 60));
            e.Graphics.DrawString("III. Toda reparación que requiera cambio de parte, se solicitara el 50% de anticipo.", font2, Brushes.Black, new Rectangle(20, 680, 900, 60));
            e.Graphics.DrawString("IV. Toda revisión o reparación en la que no proceda la garantía tendra un costo.", font2, Brushes.Black, new Rectangle(20, 700, 900, 60));
            e.Graphics.DrawString("V. La garantía del equipo no cubre problemas de software(programas y aplicaciones) únicamente problemas de hardware (daños fisicos).", font2, Brushes.Black, new Rectangle(20, 720, 900, 60));
            e.Graphics.DrawString("VI. La garantía del equipo tampoco cubre el servicio de mantenimiento preventivo.", font2, Brushes.Black, new Rectangle(20, 740, 900, 60));
            e.Graphics.DrawString("VII. La garantía del servicio es de 30 días naturales.", font2, Brushes.Black, new Rectangle(20, 760, 900, 60));
            e.Graphics.DrawString("VIII. En el caso de la información contenida en el disco duro es RESPONSABILIDAD ABSOLUTA DEL CLIENTE.", font2, Brushes.Black, new Rectangle(20, 780, 900, 60));
            e.Graphics.DrawString("IX. Todo equipo que no se haya recogido después de 8 días de habérse notiicado al cliente, tendrá un cargo de almacenamiento de $15.00 por día", font2, Brushes.Black, new Rectangle(20, 800, 900, 60));
            e.Graphics.DrawString("X. Transcurridos 30 días naturales después de la notificación, el equipo se pasará al almacén de destrucción sin ninguna  responsabilidad para \n Computadoras Centro de Servicio.", font2, Brushes.Black, new Rectangle(20, 820, 900, 60));
            e.Graphics.DrawString("XI. El horario para seguimiento de reportes es de 10:00 a 19:00 hrs. de lunes a viernes, sábados de 10:00 a 14:00 hrs. \n a los teléfonos 444-817-5710, 444-128-6760, WhatsApp 444-427-3576.", font2, Brushes.Black, new Rectangle(20, 850, 900, 60));

            e.Graphics.DrawString("ACEPTO", font2, Brushes.Black, new Rectangle(80, 880, 800, 60));
            e.Graphics.DrawString("NOMBRE Y FIRMA", font2, Brushes.Black, new Rectangle(50, 980, 900, 60));

            e.Graphics.DrawString("RECIBE", font2, Brushes.Black, new Rectangle(630, 880, 880, 60));
            e.Graphics.DrawString(cmbAtiende.Text, font2, Brushes.Black, new Rectangle(600, 980, 900, 60));
            /*//e.Graphics.DrawString(txtTitulo.Text, font, Brushes.Black, 50, 130);
            Bitmap varbmp = new Bitmap(este.Image);
            Image img = este.Image;
            e.Graphics.DrawImage(img, new Rectangle(20, 30, 185, 50));
            e.Graphics.DrawString("*" + txtCodigo.Text + "*", font, Brushes.Black, new Rectangle(75, 85, 150, 20)); */

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog pd2 = new PrintDialog();
            PrintDocument doc2 = new PrintDocument();
            doc2.PrintPage += Imprimir2;
            pd2.Document = doc2;
            if (pd2.ShowDialog() == DialogResult.OK)
            {
                doc2.Print();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EliminaOrden();
        }


    }

}
