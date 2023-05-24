using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neptuno.Bussines;
using Neptuno.Entity;

namespace Wind_UI.Formularios
{
    public partial class frmProductoMant : Form
    {
        public frmProductoMant()
        {
            InitializeComponent();
        }

        #region Metodos
    // instanciar objeto de las clases
        ProductoBL obj = new ProductoBL();

        Producto oProd = new Producto();

        void LlenarListas()
        {
            cboProveedor.DataSource = obj.ProveedorListar();
            cboProveedor.DisplayMember = "NombreCompañía";
            cboProveedor.ValueMember = "IdProveedor";

            cboCategoria.DataSource = obj.CategoriaListar();
            cboCategoria.DisplayMember = "NombreCategoría";
            cboCategoria.ValueMember = "IdCategoría";
        }

        void cargaGrilla()
        {
            dgdProducto.DataSource = obj.ProductoListar();
        }

        #endregion
    
        private void frmProductoMant_Load(object sender, EventArgs e)
        {
            LlenarListas();
            cargaGrilla();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            oProd.nombre = txtNombre.Text;
            oProd.idprove = (int)cboProveedor.SelectedValue;
            oProd.idcat =(int) cboCategoria.SelectedValue;
            oProd.precio = decimal.Parse(txtPrecio.Text);
            oProd.stock = Int32.Parse(numCantidad.Value.ToString());
            try
            {
                if (obj.ProductoAdicionar(oProd)>0)
                {
                    MessageBox.Show("Producto registrado con exito", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cargaGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oProd.codigo = Int32.Parse(txtCodigo.Text);
            oProd.nombre = txtNombre.Text;
            oProd.idprove = (int)cboProveedor.SelectedValue;
            oProd.idcat = (int)cboCategoria.SelectedValue;
            oProd.precio = decimal.Parse(txtPrecio.Text);
            oProd.stock = Int32.Parse(numCantidad.Value.ToString());
            try
            {
                if (obj.ProductoModificar(oProd) > 0)
                {
                    MessageBox.Show("Producto actualizado con exito", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cargaGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oProd.codigo = Int32.Parse(txtCodigo.Text);
            try
            {
                if (obj.ProductoEliminar(oProd) > 0)
                {
                    MessageBox.Show("Producto eliminado con exito", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cargaGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tb = obj.ProductoPorCodigo(Int32.Parse(txtCodigo.Text));
            if (tb.Rows.Count>0)
            {
             txtCodigo.Text = tb.Rows[0][0].ToString();
            txtNombre.Text = tb.Rows[0][1].ToString();
            cboProveedor.SelectedValue = tb.Rows[0][2].ToString();
            cboCategoria.SelectedValue = tb.Rows[0][3].ToString();
            txtPrecio.Text = tb.Rows[0][4].ToString();
            numCantidad.Value = Int32.Parse(tb.Rows[0][5].ToString());
            }
            else
            {
                MessageBox.Show("Codigo no exite", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
