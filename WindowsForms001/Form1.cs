
using Semicrol.Curso.Filtros;
using Semicrol.Curso.Interfaces;
using Semicrol.Curso.PersistenciaADO;
using Semicrol.Curso.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms001
{
    public partial class Form1 : Form
    {

        ServicioFacturas servicioFacturas = new ServicioFacturas(new FacturaRepository(), new LineaFacturaRepository());
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = 
                servicioFacturas.BuscarTodasLasFacturas();
            dataGridView1.DataSource = bindingSource1;

            
        }

        private void radioONumero_CheckedChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = "Numero";
        }

        private void radioOConcepto_CheckedChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = "Concepto";
        }

        private void botonFiltrar_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = servicioFacturas.BuscarFacturasFiltradas(new FiltroFactura().AddConcepto(cajaFiltrar.Text));
        }

        private void botonRestaurar_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource =
                servicioFacturas.BuscarTodasLasFacturas();
        }
    }
}
