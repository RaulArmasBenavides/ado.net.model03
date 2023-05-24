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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // instanciar objeto de la clase Empleadodatos
        EmpleadoBL obj = new EmpleadoBL();

        private void Form1_Load(object sender, EventArgs e)
        {
            dgdEmpleado.DataSource = obj.EmpleadoListar();
        }
    }
}
