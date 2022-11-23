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
    public partial class Diagnostico : Form
    {
        public Diagnostico()
        {
            InitializeComponent();
        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            DiagnosticoO();
        }

        private void DiagnosticoO()
        {
            clsDiagnostico objDiag = new clsDiagnostico();
            objDiag.ActualizaOrdenDiagnostico(Convert.ToInt32(txtOrden.Text), txDiagnostico.Text);
            MessageBox.Show("El Diagnostico fue agregado");
        }
    }
}
