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
    public partial class frmBitacora_Entrada_Salida : Form
    {
        public frmBitacora_Entrada_Salida()
        {
            InitializeComponent();
        }

        private void frmBitacora_Entrada_Salida_Load(object sender, EventArgs e)
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

        //Metodo para ocultar las columnas en datagrid
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
        }

        //Metodo para ajustar el tamaño de lals columnas en el datagrid
        private void AjustarColumnas()
        {
            this.dgvListado.Columns[0].Width = 150;
            this.dgvListado.Columns[1].Width = 100;
            this.dgvListado.Columns[2].Width = 200;
            this.dgvListado.Columns[3].Width = 200;
            this.dgvListado.Columns[4].Width = 200;
            //this.dgvListado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        //Metodo para buscar
        private void BuscarBitacora_Ent_Sal()
        {
            try
            {
                
                {
                    this.dgvListado.DataSource = NBitacora_Ent_Sal.BuscarBitacora_Ent_Sal(Convert.ToInt32(this.cmbUsuario.SelectedValue));
                    this.AjustarColumnas();
                    this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(this.dgvListado.Rows.Count);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        //Metodo para buscar por fechas
        private void BuscarBitacora_Ent_Sal_Fecha()
        {
            try
            {
                if (this.dtInicio.Value >= this.dtFinal.Value)
                {
                    MessageBox.Show("Fecha de Inicio no puede ser Mayor o Igual a Fecha Final", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvListado.DataSource = NBitacora_Ent_Sal.BuscarBitacora_Ent_Sal_Fecha(Convert.ToInt32(this.cmbUsuario.SelectedValue),
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
        private void cmbPerfil_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //this.BuscarBitacora_Ent_Sal();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarBitacora_Ent_Sal_Fecha();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
        #endregion
    }
}
