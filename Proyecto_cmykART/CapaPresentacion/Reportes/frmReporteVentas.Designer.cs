namespace CapaPresentacion
{
    partial class frmReporteVentas
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
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.SP_Reporte_VentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_Reporte_VentasTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.SP_Reporte_VentasTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_Reporte_VentasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_Reporte_VentasBindingSource
            // 
            this.SP_Reporte_VentasBindingSource.DataMember = "SP_Reporte_Ventas";
            this.SP_Reporte_VentasBindingSource.DataSource = this.dsPrincipal;
            // 
            // SP_Reporte_VentasTableAdapter
            // 
            this.SP_Reporte_VentasTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_Reporte_VentasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptReportesVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(899, 469);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 469);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteVentas";
            this.Text = "Reporte de Ventas";
            this.Load += new System.EventHandler(this.frmReporteVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_Reporte_VentasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource SP_Reporte_VentasBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.SP_Reporte_VentasTableAdapter SP_Reporte_VentasTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

    }
}