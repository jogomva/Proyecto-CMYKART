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
    public partial class frmConsultaVentas : Form
    {
        public string Usuario;


        public frmConsultaVentas()
        {
            InitializeComponent();
        }

        #region Metodos

        //Metodo para ocultar columnas del datagrid
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[9].Visible = false;
            this.dgvListado.Columns[10].Visible = false;
        }

        //Metodo para ajustar tamaño de las columnas en el datagrid
        private void AjustarColumnas()
        {

            this.dgvListado.Columns[0].Width = 180;
            this.dgvListado.Columns[1].Width = 200;
            this.dgvListado.Columns[2].Width = 150;
            this.dgvListado.Columns[3].Width = 150;
            this.dgvListado.Columns[4].Width = 70;
            this.dgvListado.Columns[5].Width = 100;
            this.dgvListado.Columns[6].Width = 100;
            this.dgvListado.Columns[7].Width = 100;
            //this.dgvListado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


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


        //Metodo que muestra un reporte de los pedidpos efectuados
        private void ReporteVentas()
        {
            try
            {
                string fechaHoy = DateTime.Now.ToString();

                if (this.dtInicial.Value >= this.dtFinal.Value)
                {
                    MessageBox.Show("Fecha de Inicio no puede ser Mayor o Igual a Fecha Final", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvListado.DataSource = NPedidos.ReporteVentas(this.dtInicial.Value.ToString("yyyyMMdd"),
                    this.dtFinal.Value.ToString("yyyyMMdd"), this.Usuario);
                    this.OcultarColumnas();
                    this.AjustarColumnas();
                    this.SetBordesyLineasGrid();
                    this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(this.dgvListado.Rows.Count);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReporteVentas();
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
                this.timer1.Start();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void frmConsultaVentas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.barraProgreso.Visible = false;
            this.SetBordesyLineasGrid();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.barraProgreso.Visible = true;
            this.barraProgreso.Increment(1);
            if(this.barraProgreso.Value == this.barraProgreso.Maximum)
            {
                this.timer1.Stop();
                frmReporteVentas frm = new frmReporteVentas();
                frm.FechaInicial = this.dtInicial.Value.ToString("yyyyMMdd");
                frm.FechaFinal = this.dtFinal.Value.ToString("yyyyMMdd");
                frm.Usuario = this.Usuario;
                frm.ShowDialog();
                this.barraProgreso.Value = 0;
                this.barraProgreso.Visible = false;
            }
        }


        #endregion

        

    }
}
