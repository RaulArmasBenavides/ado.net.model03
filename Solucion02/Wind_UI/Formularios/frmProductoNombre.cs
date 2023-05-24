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
    public partial class frmProductoNombre : Form
    {
        public frmProductoNombre()
        {
            InitializeComponent();
        }
        // instanciar objeto

        ProductoBL oProd = new ProductoBL();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text!="")
                {
                     dgdProducto.DataSource = oProd.ProduductoPorNombre(txtNombre.Text);
                }
                else
                {
                    dgdProducto.DataSource = null;
                }               
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void frmProductoNombre_Load(object sender, EventArgs e)
        {

        }
    }
}
