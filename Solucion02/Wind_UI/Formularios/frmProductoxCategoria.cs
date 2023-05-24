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
    public partial class frmProductoxCategoria : Form
    {
        public frmProductoxCategoria()
        {
            InitializeComponent();
        }
        // instanciar objeto de la clase productodatos
        ProductoBL oProd = new ProductoBL();

        void LlenarLista()
        {
            cboCategoria.DataSource = oProd.CategoriaListar();
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "IdCategoria";
        }


        private void frmProductoxCategoria_Load(object sender, EventArgs e)
        {
            LlenarLista();
            cboCategoria_SelectedIndexChanged(sender, e);
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             dgdProducto.DataSource = oProd.ProduductoPorCategoria(Convert.ToInt16(cboCategoria.SelectedValue));
            }
            catch (Exception)
            {
                
            }
        }
    }
}
