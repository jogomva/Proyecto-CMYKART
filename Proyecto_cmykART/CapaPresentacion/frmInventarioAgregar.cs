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
    public partial class frmInventarioAgregar : Form
    {
        private static frmInventarioAgregar _instancia;

        public static frmInventarioAgregar GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmInventarioAgregar();
            }
            return _instancia;
        }

        public frmInventarioAgregar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmInventarioAgregar_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.MostrarInventario();
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

        public void MostrarInventario()
        {
            try
            {
                this.dgvListado.DataSource = NPresentacion.MostrarInventario();
                this.dgvListado.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            frmAgregarStock frm = new frmAgregarStock();
            frm.Idpresentacion = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["Idpresentacion"].Value);
            frm.Presentacion = Convert.ToString(this.dgvListado.CurrentRow.Cells["Presentación"].Value);
            frm.Stock = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["Stock"].Value);
            frm.Show();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInventario();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteInventario frm = new frmReporteInventario();
                frm.Show();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
    }
}
