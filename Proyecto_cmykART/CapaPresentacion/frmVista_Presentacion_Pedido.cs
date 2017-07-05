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
    public partial class frmVista_Presentacion_Pedido : Form
    {
        public frmVista_Presentacion_Pedido()
        {
            InitializeComponent();
        }

        private void frmVista_Presentacion_Pedido_Load(object sender, EventArgs e)
        {
            this.SetBordesyLineasGrid();
            
  
        }

        private void AjustarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Width = 250;
            this.dgvListado.Columns[2].Width = 220;

        }
        private void SetBordesyLineasGrid()
        {
            //Cambiar color de linea de la cuadricula
            this.dgvListado.GridColor = Color.DarkBlue;
            //Cambiar el estilo del borde
            this.dgvListado.BorderStyle = BorderStyle.Fixed3D;
            //Centrar encabezados
            this.dgvListado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Centrar celdas
            this.dgvListado.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Cambiar la fuente para el control
            this.dgvListado.DefaultCellStyle.Font = new Font("Verdana", 11);
            //Cambiar colo de la fuente
            this.dgvListado.DefaultCellStyle.ForeColor = Color.DimGray;
        }
       

        private void Mostrar_Presentacion_Pedido_Nombre()
        {
            this.dgvListado.DataSource = NPedidos.Mostrar_Presentacion_Pedido_Nombre();
            this.SetBordesyLineasGrid();
            this.AjustarColumnas();
            lblContador.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Mostrar_Presentacion_Pedido_Nombre();
            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        

        

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //frmPedidos form = new frmPedidos();
                frmPedidos form = frmPedidos.GetInstancia();
                //string par1, par2,par4;
                int par1,par2;
                string par3;

                par1 = Convert.ToInt32(this.dgvListado.CurrentRow.Cells[0].Value);
                par2 = Convert.ToInt32(this.dgvListado.CurrentRow.Cells[2].Value);
                //par3 = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["Stock Actual"].Value);
                par3 = Convert.ToString(this.dgvListado.CurrentRow.Cells[1].Value);
                form.setPresentacion(par1, par2,par3);
                this.Hide();    
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
                this.Mostrar_Presentacion_Pedido_Nombre();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        
    }
}
