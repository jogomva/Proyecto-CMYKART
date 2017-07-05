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
    public partial class frmBitacoraMovimientos : Form
    {
        public frmBitacoraMovimientos()
        {
            InitializeComponent();
        }

        private void frmBitacoraMovimientos_Load(object sender, EventArgs e)
        {
            this.CargarUsuario();
            this.Top = 0;
            this.Left = 0;
            this.SetBordesyLineasGrid();
        }

        #region Metodos
        //Metodo para cargar usuarios en el combo
        private void CargarUsuario()
        {
            try
            {
                this.cmbUsuario.ValueMember = "Idusuario";
                this.cmbUsuario.DisplayMember = "Usuario";
                this.cmbUsuario.DataSource = NUsuario.Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo para ahustar el tamaño de las columnas en el datagrid
        private void AjustarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Width = 170;
            this.dgvListado.Columns[2].Width = 120;
            this.dgvListado.Columns[3].Width = 120;
            this.dgvListado.Columns[4].Width = 120;
            this.dgvListado.Columns[5].Width = 100;
            this.dgvListado.Columns[6].Width = 150;
            //this.dgvListado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        //Metodo para buscar por fechas
        private void BuscarBitacoraMovimientosFecha()
        {
            try
            {
                if (this.dtInicio.Value >= this.dtFinal.Value)
                {
                    MessageBox.Show("Fecha de Inicio no puede ser Mayor o Igual a Fecha Final", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvListado.DataSource = NBitacora_Movimientos.BuscarBitacoraMovimientosFecha(
                        Convert.ToInt32(this.cmbUsuario.SelectedValue),
                        this.dtInicio.Value.ToString("yyyyMMdd"),
                        this.dtFinal.Value.ToString("yyyyMMdd"));
                    this.AjustarColumnas();
                    this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(this.dgvListado.Rows.Count);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

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

        #endregion

        #region Eventos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarBitacoraMovimientosFecha();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
        #endregion
    }
}
