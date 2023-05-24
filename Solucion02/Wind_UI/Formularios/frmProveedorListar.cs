using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neptuno.Bussines;
using System.Data.SqlClient;

namespace Wind_UI.Formularios
{
    public partial class frmProveedorListar : Form
    {
        public frmProveedorListar()
        {
            InitializeComponent();
        }
        //instanciar objeto de la clase 
        ProveedorBL obj = new ProveedorBL();

        private void frmProveedorListar_Load(object sender, EventArgs e)
        {
            SqlDataReader drd = obj.ProveedorListar();
            while (drd.Read())
            {
                ListViewItem c = new ListViewItem();
                c = lvwProveedor.Items.Add(drd[0].ToString());
                c.SubItems.Add(drd[1].ToString());
                c.SubItems.Add(drd[2].ToString());
                c.SubItems.Add(drd[3].ToString());
            }
            drd.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
