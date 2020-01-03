namespace Win.RapiAuto
{
    partial class formMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ArchivosTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.FacturacionTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportesTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.ReporteVehiculosTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.ReporteClientesTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.ReporteFacturasTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArchivosTSM,
            this.FacturacionTSM,
            this.ReportesTSM,
            this.usuariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(845, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ArchivosTSM
            // 
            this.ArchivosTSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehiculosTSM,
            this.clientesTSM});
            this.ArchivosTSM.Name = "ArchivosTSM";
            this.ArchivosTSM.Size = new System.Drawing.Size(96, 29);
            this.ArchivosTSM.Text = "Archivos";
            // 
            // vehiculosTSM
            // 
            this.vehiculosTSM.Name = "vehiculosTSM";
            this.vehiculosTSM.Size = new System.Drawing.Size(171, 30);
            this.vehiculosTSM.Text = "Vehículos";
            this.vehiculosTSM.Click += new System.EventHandler(this.vehículosToolStripMenuItem1_Click);
            // 
            // clientesTSM
            // 
            this.clientesTSM.Name = "clientesTSM";
            this.clientesTSM.Size = new System.Drawing.Size(171, 30);
            this.clientesTSM.Text = "Clientes";
            this.clientesTSM.Click += new System.EventHandler(this.clientesToolStripMenuItem3_Click);
            // 
            // FacturacionTSM
            // 
            this.FacturacionTSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarTSM});
            this.FacturacionTSM.Name = "FacturacionTSM";
            this.FacturacionTSM.Size = new System.Drawing.Size(121, 29);
            this.FacturacionTSM.Text = "Facturación";
            // 
            // facturarTSM
            // 
            this.facturarTSM.Name = "facturarTSM";
            this.facturarTSM.Size = new System.Drawing.Size(158, 30);
            this.facturarTSM.Text = "Facturar";
            this.facturarTSM.Click += new System.EventHandler(this.facturarToolStripMenuItem_Click);
            // 
            // ReportesTSM
            // 
            this.ReportesTSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReporteVehiculosTSM,
            this.ReporteClientesTSM,
            this.ReporteFacturasTSM});
            this.ReportesTSM.Name = "ReportesTSM";
            this.ReportesTSM.Size = new System.Drawing.Size(97, 29);
            this.ReportesTSM.Text = "Reportes";
            // 
            // ReporteVehiculosTSM
            // 
            this.ReporteVehiculosTSM.Name = "ReporteVehiculosTSM";
            this.ReporteVehiculosTSM.Size = new System.Drawing.Size(171, 30);
            this.ReporteVehiculosTSM.Text = "Vehículos";
            this.ReporteVehiculosTSM.Click += new System.EventHandler(this.vehículosToolStripMenuItem_Click);
            // 
            // ReporteClientesTSM
            // 
            this.ReporteClientesTSM.Name = "ReporteClientesTSM";
            this.ReporteClientesTSM.Size = new System.Drawing.Size(171, 30);
            this.ReporteClientesTSM.Text = "Clientes";
            this.ReporteClientesTSM.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // ReporteFacturasTSM
            // 
            this.ReporteFacturasTSM.Name = "ReporteFacturasTSM";
            this.ReporteFacturasTSM.Size = new System.Drawing.Size(171, 30);
            this.ReporteFacturasTSM.Text = "Facturas";
            this.ReporteFacturasTSM.Click += new System.EventHandler(this.facturasToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlDeUsuariosToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.usuariosToolStripMenuItem.Image = global::Win.RapiAuto.Properties.Resources.Login;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // controlDeUsuariosToolStripMenuItem
            // 
            this.controlDeUsuariosToolStripMenuItem.Name = "controlDeUsuariosToolStripMenuItem";
            this.controlDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.controlDeUsuariosToolStripMenuItem.Text = "Control de Usuarios";
            this.controlDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.controlDeUsuariosToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssServidor,
            this.tssUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(845, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssServidor
            // 
            this.tssServidor.AutoToolTip = true;
            this.tssServidor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssServidor.Name = "tssServidor";
            this.tssServidor.Size = new System.Drawing.Size(167, 20);
            this.tssServidor.Text = "Servidor: ----------------";
            this.tssServidor.ToolTipText = "Servidor:";
            // 
            // tssUsuario
            // 
            this.tssUsuario.AutoToolTip = true;
            this.tssUsuario.Name = "tssUsuario";
            this.tssUsuario.Size = new System.Drawing.Size(164, 20);
            this.tssUsuario.Text = "Usuario:-----------------";
            // 
            // formMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 463);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formMenu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ArchivosTSM;
        private System.Windows.Forms.ToolStripMenuItem ReportesTSM;
        private System.Windows.Forms.ToolStripMenuItem ReporteVehiculosTSM;
        private System.Windows.Forms.ToolStripMenuItem ReporteClientesTSM;
        private System.Windows.Forms.ToolStripMenuItem ReporteFacturasTSM;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem vehiculosTSM;
        private System.Windows.Forms.ToolStripMenuItem FacturacionTSM;
        private System.Windows.Forms.ToolStripMenuItem facturarTSM;
        private System.Windows.Forms.ToolStripMenuItem clientesTSM;
        private System.Windows.Forms.ToolStripStatusLabel tssServidor;
        private System.Windows.Forms.ToolStripStatusLabel tssUsuario;
    }
}