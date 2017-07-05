namespace CapaPresentacion
{
    partial class frmAgregarStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarStock));
            this.txtStockNuevo = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblStockActual = new iTalk_HeaderLabel();
            this.iTalk_HeaderLabel2 = new iTalk_HeaderLabel();
            this.iTalk_HeaderLabel1 = new iTalk_HeaderLabel();
            this.txtPresentacion = new iTalk_TextBox_Big();
            this.SuspendLayout();
            // 
            // txtStockNuevo
            // 
            this.txtStockNuevo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockNuevo.ForeColor = System.Drawing.Color.DimGray;
            this.txtStockNuevo.Location = new System.Drawing.Point(247, 256);
            this.txtStockNuevo.Name = "txtStockNuevo";
            this.txtStockNuevo.Size = new System.Drawing.Size(100, 26);
            this.txtStockNuevo.TabIndex = 3;
            this.txtStockNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save3_icon;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.Location = new System.Drawing.Point(188, 319);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(232, 42);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.BackColor = System.Drawing.Color.Orange;
            this.lblStockActual.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblStockActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblStockActual.Location = new System.Drawing.Point(377, 183);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(38, 46);
            this.lblStockActual.TabIndex = 7;
            this.lblStockActual.Text = "0";
            // 
            // iTalk_HeaderLabel2
            // 
            this.iTalk_HeaderLabel2.AutoSize = true;
            this.iTalk_HeaderLabel2.BackColor = System.Drawing.Color.Gainsboro;
            this.iTalk_HeaderLabel2.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel2.Location = new System.Drawing.Point(159, 183);
            this.iTalk_HeaderLabel2.Name = "iTalk_HeaderLabel2";
            this.iTalk_HeaderLabel2.Size = new System.Drawing.Size(212, 46);
            this.iTalk_HeaderLabel2.TabIndex = 6;
            this.iTalk_HeaderLabel2.Text = "Stock Actual:";
            // 
            // iTalk_HeaderLabel1
            // 
            this.iTalk_HeaderLabel1.AutoSize = true;
            this.iTalk_HeaderLabel1.BackColor = System.Drawing.Color.Gainsboro;
            this.iTalk_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel1.Location = new System.Drawing.Point(196, 65);
            this.iTalk_HeaderLabel1.Name = "iTalk_HeaderLabel1";
            this.iTalk_HeaderLabel1.Size = new System.Drawing.Size(212, 46);
            this.iTalk_HeaderLabel1.TabIndex = 5;
            this.iTalk_HeaderLabel1.Text = "Presentación";
            // 
            // txtPresentacion
            // 
            this.txtPresentacion.BackColor = System.Drawing.Color.Transparent;
            this.txtPresentacion.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPresentacion.ForeColor = System.Drawing.Color.DimGray;
            this.txtPresentacion.Image = null;
            this.txtPresentacion.Location = new System.Drawing.Point(188, 114);
            this.txtPresentacion.MaxLength = 32767;
            this.txtPresentacion.Multiline = false;
            this.txtPresentacion.Name = "txtPresentacion";
            this.txtPresentacion.ReadOnly = false;
            this.txtPresentacion.Size = new System.Drawing.Size(232, 41);
            this.txtPresentacion.TabIndex = 2;
            this.txtPresentacion.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPresentacion.UseSystemPasswordChar = false;
            // 
            // frmAgregarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.apple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(616, 413);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtStockNuevo);
            this.Controls.Add(this.lblStockActual);
            this.Controls.Add(this.iTalk_HeaderLabel2);
            this.Controls.Add(this.iTalk_HeaderLabel1);
            this.Controls.Add(this.txtPresentacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgregarStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAgregarStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private iTalk_TextBox_Big txtPresentacion;
        private iTalk_HeaderLabel iTalk_HeaderLabel1;
        private iTalk_HeaderLabel iTalk_HeaderLabel2;
        private iTalk_HeaderLabel lblStockActual;
        private System.Windows.Forms.TextBox txtStockNuevo;
        private System.Windows.Forms.Button btnGuardar;

    }
}