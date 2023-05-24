using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Neptuno.Bussines;
using Neptuno.Entity;

namespace Wind_UI.Formularios
{
    public partial class frmRegistraVentas : Form
    {
        public frmRegistraVentas()
        {
            InitializeComponent();
        }

        #region Metodos
         private  VentaBL oVenta = new VentaBL();
         private DataSet Ds =new DataSet() ;
         private DataTable dtDetalle ;
         private DataRow drw;
         private decimal total=0;

         private int stk;

         void LlenarCombos()
         {
             cboCliente.DataSource = oVenta.ListarCliente();
             cboCliente.DisplayMember = "NombreCompañía";
             cboCliente.ValueMember = "IdCliente";

             cboEmpleado.DataSource = oVenta.EmpleadoListar();
             cboEmpleado.DisplayMember = "Empleado";
             cboEmpleado.ValueMember = "IdEmpleado";

             cboProducto.DataSource = oVenta.ProductoListar();
             cboProducto.DisplayMember = "NombreProducto";
             cboProducto.ValueMember = "IdProducto";
         }

         private void ConfigurarTabla()
         {
             dtDetalle = Ds.Tables.Add();
             dtDetalle.Columns.Add("Codigo");
             dtDetalle.Columns.Add("Nombre");
             dtDetalle.Columns.Add("Precio");
             dtDetalle.Columns.Add("Cantidad");
             dtDetalle.Columns.Add("SubTotal");
             dgdDetalle.DataSource = dtDetalle;
         }

         private void AgregarFila()
         {
             drw = dtDetalle.NewRow();
             drw["Codigo"] = txtCodigo.Text;
             drw["Nombre"] = cboProducto.Text;
             drw["Precio"] = txtPrecio.Text;
             drw["Cantidad"] = txtCantidad.Text;
             drw["SubTotal"] = txtSubTotal.Text;
             dtDetalle.Rows.Add(drw);
             total += decimal.Parse(txtSubTotal.Text);
             txtTotal.Text = total.ToString();
         }

         private void EliminarFila()
         {

             if (dtDetalle.Rows.Count > 0)
             {
                 total -= decimal.Parse((string)dgdDetalle.Rows[dgdDetalle.CurrentCell.RowIndex].Cells[4].Value);
                 txtTotal.Text = total.ToString("N2");
                 dtDetalle.Rows.RemoveAt(dgdDetalle.CurrentCell.RowIndex);
             }
             else
             {
                 MessageBox.Show("Seleccionar fila");
             }
         }


        #endregion



        private void frmRegistraVentas_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            ConfigurarTabla();
            NuevaVenta();
        }

        private void NuevaVenta()
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtNro.Clear();
            txtTotal.Clear();
            dtDetalle.Rows.Clear();
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x =Convert.ToInt32(cboProducto.SelectedValue);
                SqlDataReader dr = oVenta.ProductoDatos(x);
                dr.Read();
                txtCodigo.Text = dr[0].ToString();
                txtPrecio.Text = dr[1].ToString();
                stk =Convert.ToInt16(dr[2].ToString());
                dr.Close();
                txtCantidad.Text = "1";
                txtCantidad.SelectAll();
                txtCantidad.Focus();
             }
            catch (Exception ex)
            {
            }

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text != "")
                {
                    int cant = Int32.Parse(txtCantidad.Text);
                    if (cant<stk)
                    {
                        txtSubTotal.Text = (cant * decimal.Parse(txtPrecio.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Solo quedan: " + stk.ToString() + " unidades en stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    txtSubTotal.Clear();
                }
            }
            catch (Exception)
            {
                
           }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFila();
            LimpiaControles();
        }

        private void LimpiaControles()
        {
            txtSubTotal.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtCodigo.Clear();
            cboProducto.Focus();
        }

        private void btnEliminaDetalle_Click(object sender, EventArgs e)
        {
            EliminarFila();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Venta o = new Venta();
            List<Detalle> detalle = new List<Detalle>();
            foreach (DataRow item in dtDetalle.Rows)
            {
                Detalle x = new Detalle();
                x.idproducto = Convert.ToInt32(item[0].ToString());
                x.precio = Convert.ToDecimal(item[2].ToString());
                x.cantidad = Convert.ToInt32(item[3].ToString());
                detalle.Add(x);
            }

            try
            {
            o.idcliente = cboCliente.SelectedValue.ToString();
            o.idempleado = (int)cboEmpleado.SelectedValue;
            o.fechaventa = DateTime.Parse(txtFecha.Text);
            o.monto = decimal.Parse(txtTotal.Text);
            o.item = detalle;
            txtNro.Text = oVenta.RegistraVenta(o).ToString();// registra venta
            MessageBox.Show("Gracias por su compa","exito",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            NuevaVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
