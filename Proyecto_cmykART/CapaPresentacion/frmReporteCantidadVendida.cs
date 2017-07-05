using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmReporteCantidadVendida : Form
    {
        public string Usuario;
        public frmReporteCantidadVendida()
        {
            InitializeComponent();
        }

        private void frmReporteStock_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.SetBordesyLineasGrid();
        }

        private void SetBordesyLineasGrid()
        {
            //Cambiar color de linea de la cuadricula
            this.dgvListado.GridColor = Color.DeepSkyBlue;
            //Cambiar el estilo del borde
            this.dgvListado.BorderStyle = BorderStyle.Fixed3D;
            //Centrar encabezados
            this.dgvListado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Centrar celdas
            this.dgvListado.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Cambiar la fuente para el control
            this.dgvListado.DefaultCellStyle.Font = new Font("Verdana", 11);
            //Cambiar color de la fuente
            this.dgvListado.DefaultCellStyle.ForeColor = Color.DimGray;
            //cambiar color de fila seleccionada
            this.dgvListado.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;

            
        }
        private void AjustarColumnas()
        {
            
            this.dgvListado.Columns[0].Width = 250;
            this.dgvListado.Columns[1].Width = 250;
            this.dgvListado.Columns[2].Visible = false;
            this.dgvListado.Columns[3].Visible = false;
            

            
        }
        private void Mostrar()
        {
            try
            {
                this.dgvListado.DataSource = NPedidos.ReporteCantidadVendida(this.txtBuscar.Text,Usuario);
                this.AjustarColumnas();
                this.SetBordesyLineasGrid();
                this.lblContador.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgvListado.DataSource = NPedidos.ReporteCantidadVendida(this.txtBuscar.Text,Usuario);
                this.AjustarColumnas();
                this.lblContador.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteStockVendido frm = new frmReporteStockVendido();
                frm.Buscar = this.txtBuscar.Text;
                frm.Usuario = this.Usuario;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
