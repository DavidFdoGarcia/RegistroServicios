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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void ordenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealizaOrden RO = new RealizaOrden();
            RO.Show();
        }

        private void diagnosticoDeOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diagnostico dia = new Diagnostico();
            dia.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes re = new Reportes();
            re.Show();
        }

        private void modificarStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarStatus MO = new ModificarStatus();
            MO.Show();
        }

        private void modificarFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarFechaSalida mo = new ModificarFechaSalida();
            mo.Show();
        }

        private void consultaPorFiltroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaFiltro con = new ConsultaFiltro();
            con.Show();
        }
    }
}
