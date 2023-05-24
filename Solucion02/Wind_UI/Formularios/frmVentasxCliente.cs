using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neptuno.Bussines;

namespace Wind_UI.Formularios
{
    public partial class frmVentasxCliente : Form
    {
        public frmVentasxCliente()
        {
            InitializeComponent();
        }

        // instanciar objeto de la clase ventadatos
        VentaBL oVen = new VentaBL();

        private void frmVentasxCliente_Load(object sender, EventArgs e)
        {
            dgdCliente.DataSource = oVen.ClienteListar();
        }

        private void dgdCliente_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int f = dgdCliente.CurrentCell.RowIndex;
                string cod = dgdCliente.Rows[f].Cells[0].Value.ToString();
                dgdVentas.DataSource = oVen.VentasPorCliente(cod);
            }
            catch (Exception)
            {
             
            }
        }

        private void dgdVentas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int f = dgdVentas.CurrentCell.RowIndex;
                int cod = (int)dgdVentas.Rows[f].Cells[0].Value;
                dgdDetalle.DataSource = oVen.DetallesPorVenta(cod);
            }
            catch (Exception)
            {

            }
        }
    }
}
