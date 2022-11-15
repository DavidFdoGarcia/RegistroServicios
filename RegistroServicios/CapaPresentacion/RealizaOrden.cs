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

            
        }

        private void RealizaOrden_Load(object sender, EventArgs e)
        {
            dgv.Formato(dataGridView1, 1);
        }

        private void ListarEquipos()
        {
            clsCombos objProd = new clsCombos();
            cmbEquipo.DataSource = objProd.ListarEquipos();
            cmbEquipo.DisplayMember = "CATEGORIA";
            cmbEquipo.ValueMember = "IDCATEG";
        }
    }


    }
