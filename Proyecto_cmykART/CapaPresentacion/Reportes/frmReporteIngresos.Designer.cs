namespace CapaPresentacion
{
    partial class frmReporteIngresos
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
            this.SP_Reporte_Ingresos1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_Reporte_Ingresos1TableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.SP_Reporte_Ingresos1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_Reporte_Ingresos1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_Reporte_Ingresos1BindingSource
            // 
            this.SP_Reporte_Ingresos1BindingSource.DataMember = "SP_Reporte_Ingresos1";
            this.SP_Reporte_Ingresos1BindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_Reporte_Ingresos1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptReporteIngresos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(715, 509);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_Reporte_Ingresos1TableAdapter
            // 
            this.SP_Reporte_Ingresos1TableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 509);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteIngresos";
            this.Text = "Reporte de Ingresos";
            this.Load += new System.EventHandler(this.frmReporteIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_Reporte_Ingresos1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_Reporte_Ingresos1BindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.SP_Reporte_Ingresos1TableAdapter SP_Reporte_Ingresos1TableAdapter;
    }
}