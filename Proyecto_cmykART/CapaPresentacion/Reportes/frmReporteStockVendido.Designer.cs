namespace CapaPresentacion
{
    partial class frmReporteStockVendido
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.SP_Reporte_Cantidad_Vendida1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_Reporte_Cantidad_Vendida1TableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.SP_Reporte_Cantidad_Vendida1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_Reporte_Cantidad_Vendida1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_Reporte_Cantidad_Vendida1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptReporteStockVendido.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(686, 481);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_Reporte_Cantidad_Vendida1BindingSource
            // 
            this.SP_Reporte_Cantidad_Vendida1BindingSource.DataMember = "SP_Reporte_Cantidad_Vendida1";
            this.SP_Reporte_Cantidad_Vendida1BindingSource.DataSource = this.dsPrincipal;
            // 
            // SP_Reporte_Cantidad_Vendida1TableAdapter
            // 
            this.SP_Reporte_Cantidad_Vendida1TableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteStockVendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 481);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteStockVendido";
            this.Text = "frmReporteStockVendido";
            this.Load += new System.EventHandler(this.frmReporteStockVendido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_Reporte_Cantidad_Vendida1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_Reporte_Cantidad_Vendida1BindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.SP_Reporte_Cantidad_Vendida1TableAdapter SP_Reporte_Cantidad_Vendida1TableAdapter;
    }
}