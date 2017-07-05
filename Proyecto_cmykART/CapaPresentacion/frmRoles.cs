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
using CapaDatos;


namespace CapaPresentacion
{
    public partial class frmRoles : Form
    {
        
        public frmRoles()
        {
            InitializeComponent();
            
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
          
            this.CargarComboPerfiles();
            this.Top = 0;
            this.Left = 0;
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

        private void MostrarReglas()
        {
            try
            {
                this.dgvListado.DataSource = NRoles.Mostrar(Convert.ToInt32(cmbPerfil.SelectedValue));
                this.AjustarColumnas();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void AjustarColumnas()
        {

            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[2].Width = 600;
            this.dgvListado.Columns[2].HeaderText = "Descripción";
        }

        private void CargarComboPerfiles()
        {
            try
            {
                this.cmbPerfil.ValueMember = "Idperfil";
                this.cmbPerfil.DisplayMember = "Nombre_perfil";
                this.cmbPerfil.DataSource = NPerfiles.Mostrar();
 
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        //e.RowIndex != -1 && 
        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccione"].Index)
            {
                DataGridViewCheckBoxCell chkSeleccionado = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccione"];
                chkSeleccionado.Value = !Convert.ToBoolean(chkSeleccionado.Value);
            }
        }

       

        private void cmbPerfil_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
               this.MostrarReglas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dgvListado.Rows)
                {
                    
                    DataGridViewCheckBoxCell chkSeleccionado =
                    (DataGridViewCheckBoxCell)row.Cells["Seleccione"];
                    chkSeleccionado.Value = chkSeleccionarTodos.Checked;
                    
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string respuestaElimina = "";
            string respuestaInserta = "";
            try
            {
                string codigo;
                //string sSeparador = "";
                //string sReglaIds = "";
                respuestaElimina = NRoles.Eliminar(Convert.ToInt32(cmbPerfil.SelectedValue));
                foreach(DataGridViewRow row in dgvListado.Rows)
                {


                    if(Convert.ToBoolean(row.Cells["Seleccione"].Value))
                    {
                        //sReglaIds += sSeparador + row.Cells["Id Regla"].Value;
                        //sSeparador = ",";
                        codigo = Convert.ToString(row.Cells[1].Value);
                        respuestaInserta = NRoles.Insertar(Convert.ToInt32(cmbPerfil.SelectedValue), Convert.ToInt32(codigo));
                        
                    }
                    
                }

                if(respuestaInserta.Equals( "OK") || respuestaInserta.Equals(""))
                {
                    MessageBox.Show("Guardado con Éxito!!","SISTEMA CMYKART",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuestaInserta);
                }

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        



    }
}
