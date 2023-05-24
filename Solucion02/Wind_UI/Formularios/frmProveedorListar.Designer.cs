namespace Wind_UI.Formularios
{
    partial class frmProveedorListar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwProveedor = new System.Windows.Forms.ListView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwProveedor
            // 
            this.lvwProveedor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwProveedor.GridLines = true;
            this.lvwProveedor.Location = new System.Drawing.Point(13, 13);
            this.lvwProveedor.Name = "lvwProveedor";
            this.lvwProveedor.Size = new System.Drawing.Size(483, 250);
            this.lvwProveedor.TabIndex = 0;
            this.lvwProveedor.UseCompatibleStateImageBehavior = false;
            this.lvwProveedor.View = System.Windows.Forms.View.Details;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(421, 269);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Codigo";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width = 207;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Pais";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ciudad";
            this.columnHeader4.Width = 111;
            // 
            // frmProveedorListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 297);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lvwProveedor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedorListar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Proveedores";
            this.Load += new System.EventHandler(this.frmProveedorListar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwProveedor;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}