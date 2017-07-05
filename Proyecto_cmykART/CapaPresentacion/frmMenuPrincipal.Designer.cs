namespace CapaPresentacion
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVentanas = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstadoUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.MnuSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBitacoraMovimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBitacoraIngresosSalidas = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCambiarContraseña = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPresentaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuArticulos = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuIngresos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReporteStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReporteSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuManual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuAcercade = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSeguridad,
            this.MnuAlmacen,
            this.MnuVentas,
            this.MnuCompras,
            this.MnuReportes,
            this.MnuAyuda,
            this.salirToolStripMenuItem,
            this.MnuVer,
            this.MnuVentanas});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.MnuVentanas;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1236, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // MnuVer
            // 
            this.MnuVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.MnuVer.Name = "MnuVer";
            this.MnuVer.Size = new System.Drawing.Size(35, 20);
            this.MnuVer.Text = "&Ver";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.toolBarToolStripMenuItem.Text = "&Barra de herramientas";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.statusBarToolStripMenuItem.Text = "&Barra de estado";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // MnuVentanas
            // 
            this.MnuVentanas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.MnuVentanas.Name = "MnuVentanas";
            this.MnuVentanas.Size = new System.Drawing.Size(66, 20);
            this.MnuVentanas.Text = "&Ventanas";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascada";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileVerticalToolStripMenuItem.Text = "Mosaico &vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Mosaico &horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1236, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.lblEstadoUsuario});
            this.statusStrip.Location = new System.Drawing.Point(0, 510);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1236, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(86, 20);
            this.toolStripStatusLabel.Text = "Bienvenido:";
            // 
            // lblEstadoUsuario
            // 
            this.lblEstadoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoUsuario.Name = "lblEstadoUsuario";
            this.lblEstadoUsuario.Size = new System.Drawing.Size(59, 20);
            this.lblEstadoUsuario.Text = "Usuario";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CapaPresentacion.Properties.Resources.logout_icon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Cerrar Sesión";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "Ayuda";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // MnuSeguridad
            // 
            this.MnuSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuPerfiles,
            this.MnuRoles,
            this.MnuUsuarios,
            this.MnuBitacoraMovimientos,
            this.MnuBitacoraIngresosSalidas,
            this.MnuCambiarContraseña});
            this.MnuSeguridad.Image = global::CapaPresentacion.Properties.Resources.security_icon;
            this.MnuSeguridad.Name = "MnuSeguridad";
            this.MnuSeguridad.Size = new System.Drawing.Size(88, 20);
            this.MnuSeguridad.Text = "&Seguridad";
            // 
            // MnuPerfiles
            // 
            this.MnuPerfiles.Image = global::CapaPresentacion.Properties.Resources.profile_icon;
            this.MnuPerfiles.Name = "MnuPerfiles";
            this.MnuPerfiles.Size = new System.Drawing.Size(212, 22);
            this.MnuPerfiles.Text = "Perfiles";
            this.MnuPerfiles.Click += new System.EventHandler(this.MnuPerfiles_Click);
            // 
            // MnuRoles
            // 
            this.MnuRoles.Image = global::CapaPresentacion.Properties.Resources.user_settings_icon;
            this.MnuRoles.Name = "MnuRoles";
            this.MnuRoles.Size = new System.Drawing.Size(212, 22);
            this.MnuRoles.Text = "Roles";
            this.MnuRoles.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // MnuUsuarios
            // 
            this.MnuUsuarios.Image = global::CapaPresentacion.Properties.Resources.User_blue_icon;
            this.MnuUsuarios.Name = "MnuUsuarios";
            this.MnuUsuarios.Size = new System.Drawing.Size(212, 22);
            this.MnuUsuarios.Text = "Usuarios";
            this.MnuUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // MnuBitacoraMovimientos
            // 
            this.MnuBitacoraMovimientos.Image = global::CapaPresentacion.Properties.Resources.Blog_icon;
            this.MnuBitacoraMovimientos.Name = "MnuBitacoraMovimientos";
            this.MnuBitacoraMovimientos.Size = new System.Drawing.Size(212, 22);
            this.MnuBitacoraMovimientos.Text = "Bitácora Movimientos";
            this.MnuBitacoraMovimientos.Click += new System.EventHandler(this.MnuBitacoraMovimientos_Click);
            // 
            // MnuBitacoraIngresosSalidas
            // 
            this.MnuBitacoraIngresosSalidas.Image = global::CapaPresentacion.Properties.Resources.Blog_icon;
            this.MnuBitacoraIngresosSalidas.Name = "MnuBitacoraIngresosSalidas";
            this.MnuBitacoraIngresosSalidas.Size = new System.Drawing.Size(212, 22);
            this.MnuBitacoraIngresosSalidas.Text = "Bitácora Ingresos y Salidas";
            this.MnuBitacoraIngresosSalidas.Click += new System.EventHandler(this.MnuBitacoraIngresosSalidas_Click);
            // 
            // MnuCambiarContraseña
            // 
            this.MnuCambiarContraseña.Image = global::CapaPresentacion.Properties.Resources.User_blue_icon;
            this.MnuCambiarContraseña.Name = "MnuCambiarContraseña";
            this.MnuCambiarContraseña.Size = new System.Drawing.Size(212, 22);
            this.MnuCambiarContraseña.Text = "Cambiar Contraseña";
            this.MnuCambiarContraseña.Click += new System.EventHandler(this.MnuCambiarContraseña_Click_1);
            // 
            // MnuAlmacen
            // 
            this.MnuAlmacen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuPresentaciones,
            this.MnuArticulos});
            this.MnuAlmacen.Image = global::CapaPresentacion.Properties.Resources.box_icon;
            this.MnuAlmacen.Name = "MnuAlmacen";
            this.MnuAlmacen.Size = new System.Drawing.Size(82, 20);
            this.MnuAlmacen.Text = "&Almacen";
            this.MnuAlmacen.Click += new System.EventHandler(this.MnuMantenimiento_Click);
            // 
            // MnuPresentaciones
            // 
            this.MnuPresentaciones.Image = global::CapaPresentacion.Properties.Resources.Food_Soda_Bottle_icon;
            this.MnuPresentaciones.Name = "MnuPresentaciones";
            this.MnuPresentaciones.Size = new System.Drawing.Size(153, 22);
            this.MnuPresentaciones.Text = "Presentaciones";
            this.MnuPresentaciones.Click += new System.EventHandler(this.MnuPresentaciones_Click);
            // 
            // MnuArticulos
            // 
            this.MnuArticulos.Image = global::CapaPresentacion.Properties.Resources.item;
            this.MnuArticulos.Name = "MnuArticulos";
            this.MnuArticulos.Size = new System.Drawing.Size(153, 22);
            this.MnuArticulos.Text = "Artículos";
            this.MnuArticulos.Click += new System.EventHandler(this.MnuArticulos_Click);
            // 
            // MnuVentas
            // 
            this.MnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuPedido,
            this.MnuClientes});
            this.MnuVentas.Image = global::CapaPresentacion.Properties.Resources.payment_icon;
            this.MnuVentas.Name = "MnuVentas";
            this.MnuVentas.Size = new System.Drawing.Size(69, 20);
            this.MnuVentas.Text = "&Ventas";
            // 
            // MnuPedido
            // 
            this.MnuPedido.Image = global::CapaPresentacion.Properties.Resources.Files_New_File_icon;
            this.MnuPedido.Name = "MnuPedido";
            this.MnuPedido.Size = new System.Drawing.Size(152, 22);
            this.MnuPedido.Text = "Pedidos";
            this.MnuPedido.Click += new System.EventHandler(this.MnuPedido_Click);
            // 
            // MnuClientes
            // 
            this.MnuClientes.Image = global::CapaPresentacion.Properties.Resources.Clients_icon;
            this.MnuClientes.Name = "MnuClientes";
            this.MnuClientes.Size = new System.Drawing.Size(152, 22);
            this.MnuClientes.Text = "Clientes";
            this.MnuClientes.Click += new System.EventHandler(this.MnuClientes_Click_1);
            // 
            // MnuCompras
            // 
            this.MnuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuIngresos,
            this.mnuInventario});
            this.MnuCompras.Image = global::CapaPresentacion.Properties.Resources.Add_item_icon;
            this.MnuCompras.Name = "MnuCompras";
            this.MnuCompras.Size = new System.Drawing.Size(83, 20);
            this.MnuCompras.Text = "&Compras";
            // 
            // MnuIngresos
            // 
            this.MnuIngresos.Image = global::CapaPresentacion.Properties.Resources.Document_Write_icon;
            this.MnuIngresos.Name = "MnuIngresos";
            this.MnuIngresos.Size = new System.Drawing.Size(152, 22);
            this.MnuIngresos.Text = "Ingresos";
            this.MnuIngresos.Click += new System.EventHandler(this.MnuIngresos_Click);
            // 
            // mnuInventario
            // 
            this.mnuInventario.Image = global::CapaPresentacion.Properties.Resources.Document_Write_icon;
            this.mnuInventario.Name = "mnuInventario";
            this.mnuInventario.Size = new System.Drawing.Size(152, 22);
            this.mnuInventario.Text = "Inventario";
            this.mnuInventario.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
            // 
            // MnuReportes
            // 
            this.MnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuReporteStock,
            this.MnuReporteVentas,
            this.MnuReporteSeguimiento});
            this.MnuReportes.Image = global::CapaPresentacion.Properties.Resources.SEO_icon;
            this.MnuReportes.Name = "MnuReportes";
            this.MnuReportes.Size = new System.Drawing.Size(87, 20);
            this.MnuReportes.Text = "&Consultas";
            // 
            // MnuReporteStock
            // 
            this.MnuReporteStock.Image = global::CapaPresentacion.Properties.Resources.sale_report_icon;
            this.MnuReporteStock.Name = "MnuReporteStock";
            this.MnuReporteStock.Size = new System.Drawing.Size(152, 22);
            this.MnuReporteStock.Text = "Stock Vendido";
            this.MnuReporteStock.Click += new System.EventHandler(this.MnuReporteStock_Click);
            // 
            // MnuReporteVentas
            // 
            this.MnuReporteVentas.Image = global::CapaPresentacion.Properties.Resources.report_icon;
            this.MnuReporteVentas.Name = "MnuReporteVentas";
            this.MnuReporteVentas.Size = new System.Drawing.Size(152, 22);
            this.MnuReporteVentas.Text = "Ventas";
            this.MnuReporteVentas.Click += new System.EventHandler(this.MnuReporteVentas_Click);
            // 
            // MnuReporteSeguimiento
            // 
            this.MnuReporteSeguimiento.Name = "MnuReporteSeguimiento";
            this.MnuReporteSeguimiento.Size = new System.Drawing.Size(152, 22);
            this.MnuReporteSeguimiento.Text = "Seguimiento";
            // 
            // MnuAyuda
            // 
            this.MnuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuManual,
            this.toolStripSeparator8,
            this.MnuAcercade});
            this.MnuAyuda.Image = global::CapaPresentacion.Properties.Resources.Button_Help_icon;
            this.MnuAyuda.Name = "MnuAyuda";
            this.MnuAyuda.Size = new System.Drawing.Size(69, 20);
            this.MnuAyuda.Text = "&Ayuda";
            // 
            // MnuManual
            // 
            this.MnuManual.Image = ((System.Drawing.Image)(resources.GetObject("MnuManual.Image")));
            this.MnuManual.ImageTransparentColor = System.Drawing.Color.Black;
            this.MnuManual.Name = "MnuManual";
            this.MnuManual.Size = new System.Drawing.Size(173, 22);
            this.MnuManual.Text = "&Manual de Usuario";
            this.MnuManual.Click += new System.EventHandler(this.MnuManual_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(170, 6);
            // 
            // MnuAcercade
            // 
            this.MnuAcercade.Name = "MnuAcercade";
            this.MnuAcercade.Size = new System.Drawing.Size(173, 22);
            this.MnuAcercade.Text = "&Acerca de...";
            this.MnuAcercade.Click += new System.EventHandler(this.MnuAcercade_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.logout_icon;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1236, 535);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA DE REGISTRO E INVENTARIO CMYKART";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.SizeChanged += new System.EventHandler(this.frmMenuPrincipal_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem MnuAcercade;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuVer;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuVentanas;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuAyuda;
        private System.Windows.Forms.ToolStripMenuItem MnuManual;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem MnuSeguridad;
        private System.Windows.Forms.ToolStripMenuItem MnuAlmacen;
        private System.Windows.Forms.ToolStripMenuItem MnuVentas;
        private System.Windows.Forms.ToolStripMenuItem MnuPerfiles;
        private System.Windows.Forms.ToolStripMenuItem MnuPresentaciones;
        private System.Windows.Forms.ToolStripMenuItem MnuArticulos;
        private System.Windows.Forms.ToolStripMenuItem MnuPedido;
        private System.Windows.Forms.ToolStripMenuItem MnuClientes;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem MnuCompras;
        private System.Windows.Forms.ToolStripMenuItem MnuIngresos;
        private System.Windows.Forms.ToolStripMenuItem MnuReportes;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoUsuario;
        private System.Windows.Forms.ToolStripMenuItem MnuRoles;
        private System.Windows.Forms.ToolStripMenuItem MnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MnuBitacoraMovimientos;
        private System.Windows.Forms.ToolStripMenuItem MnuBitacoraIngresosSalidas;
        private System.Windows.Forms.ToolStripMenuItem MnuReporteStock;
        private System.Windows.Forms.ToolStripMenuItem MnuReporteVentas;
        private System.Windows.Forms.ToolStripMenuItem MnuReporteSeguimiento;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuCambiarContraseña;
        private System.Windows.Forms.ToolStripMenuItem mnuInventario;
    }
}



