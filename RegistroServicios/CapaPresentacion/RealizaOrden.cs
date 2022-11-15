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
    public partial class RealizaOrden : Form
    {
        public RealizaOrden()
        {
            InitializeComponent();

            dgv.Formato(dataGridView1, 1);
        }

    }
}
