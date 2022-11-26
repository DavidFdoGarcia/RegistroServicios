using RegistroServicios.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroServicios.CapaPresentacion
{
    public partial class ModificarStatus : Form
    {
        public ModificarStatus()
        {
            InitializeComponent();

            ListarStatus();
        }

        private void ModificarStatus_Load(object sender, EventArgs e)
        {
           
        }

        private void ListarStatus()
        {
            clsStatus objS = new clsStatus();
            cmbStatus.DataSource = objS.ListarStatus();
            cmbStatus.DisplayMember = "TipoStatus";
            cmbStatus.ValueMember = "idStatus";
        }

        private void DatagridviewStatus()
        {
            clsStatus objS = new clsStatus();
            dataGridView1.DataSource = objS.DatagridviewStatus(Convert.ToInt32(txtOrden.Text));
            dgv.Formato(dataGridView1, 1);
        }

        private void actualizarOrdenStatus()
        {
            clsStatus objS = new clsStatus();
            objS.actualizarOrdenStatus(Convert.ToInt32(txtOrden.Text), Convert.ToInt32(cmbStatus.SelectedValue));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DatagridviewStatus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            actualizarOrdenStatus();
            DatagridviewStatus();
        }
    }
}
