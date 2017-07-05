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
    public partial class frmArticulo : Form
    {
        #region Variables
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public int Idusuario;
        public string Usuario;
        public string[] ReglasVerificar { get; set; }
        
        frmMenuPrincipal frm = new frmMenuPrincipal();

        #endregion

        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtCodigo, "Ingrese el Nombre de la Presentación");
            
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.HabilitarCampos(false);
            this.Botones();
            this.BotonEliminar();
            this.BotonImprimir();
            this.BotonNuevo();
            this.BotonEditar();

        }

        #region Metodos
        //Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar campos
        private void Limpiar()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        //Ocultar las 2 primeras columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[4].Visible = false;
        }

        //Amplia las columnas de Nombre y Descripcion
        private void Columnas()
        {
            this.dgvListado.Columns[2].Width = 200;
            this.dgvListado.Columns[2].HeaderText = "Código";
            this.dgvListado.Columns[3].Width = 550;
            this.dgvListado.Columns[3].HeaderText = "Descripción";
        }

        //Habilita los campos de Nombre y Descripcion para Editar o solo Visualizar
        private void HabilitarCampos(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
        }

        //Metodo que habilita los controles a la hora de cargar el formulario o en caso de insertar 
        //o modificar un registro
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.HabilitarCampos(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                
            }
            else
            {
                this.HabilitarCampos(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                
            }
        }
        private void BotonEliminar()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;
            if (ver.TieneRegla("19"))
            {
                this.btnEliminar.Enabled = true;
            }
            else
            {
                this.btnEliminar.Enabled = false;
            }
        }
        private void BotonImprimir()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;

            if (ver.TieneRegla("20"))
            {
                this.btnImprimir.Enabled = true;
            }
            else
            {
                this.btnImprimir.Enabled = false;
            }
        }
        private void BotonNuevo()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;

            if (ver.TieneRegla("17"))
            {
                this.btnNuevo.Visible = true;

            }
            else
            {
                this.btnNuevo.Visible = false;

            }
        }
        private void BotonEditar()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;

            if (ver.TieneRegla("18"))
            {
                this.btnEditar.Visible = true;

            }
            else
            {
                this.btnEditar.Visible = false;

            }
        }



        private void Mostrar()
        {
            try
            {
                this.dgvListado.DataSource = NArticulos.Mostrar();
                this.OcultarColumnas();
                this.Columnas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToSingle(dgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Eliminar()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros ?", "SISTEMA CMYKART", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Respuesta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            
                            Respuesta = NArticulos.Eliminar(Convert.ToInt32(Codigo));
                            
                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el Registro");
                            }
                            else
                            {
                                if (Respuesta.Equals("ERROR"))
                                {
                                    this.MensajeError("El registro está siendo utilizado por otras funcionalidades del Sistema. Primero debe eliminar los registros asociados" +
                                    " con este registro.");
                                }
                                else
                                {
                                    this.MensajeError(Respuesta);
                                }
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Guardar()
        {
            try
            {
                string respuesta = "";

                if (this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("El campo Código es Obligatorio !");
                    errorIcono.SetError(txtCodigo, "Debe de ingresar un valor");
                    return;
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = NArticulos.Insertar(this.txtCodigo.Text.Trim(), this.txtDescripcion.Text.Trim(),this.Idusuario);
                    }
                    else
                    {
                        respuesta = NArticulos.Editar(Convert.ToInt32(this.txtIdArticulo.Text),this.txtCodigo.Text.Trim(),
                            this.txtDescripcion.Text.Trim(),this.Idusuario);
                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Transacción Realizada Satisfactoriamente!");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó Satisfactoriamente el Registro!");
                            this.tabControl1.SelectedIndex = 0;
                        }

                    }
                    else
                    {
                        MensajeError("EL Artículo ya existe, verifique !");
                        //this.MensajeError(respuesta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.errorIcono.Clear();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }


        }


        private void Buscar_Codigo_Articulo()
        {
            try
            {
                this.dgvListado.DataSource = NArticulos.Buscar_Codigo_Articulo(this.txtBuscar.Text);
                this.OcultarColumnas();
                this.Columnas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion


        #region Eventos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.HabilitarCampos(true);
            this.txtCodigo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtIdArticulo.Text.Equals(""))
                {
                    this.IsEditar = true;
                    this.Botones();
                    this.HabilitarCampos(true);
                }
                else
                {
                    this.MensajeError("Debe de seleccionar primero el registro a Modificar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Guardar();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.HabilitarCampos(false);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Elimina"].Index)
            {
                DataGridViewCheckBoxCell ckEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Elimina"];
                ckEliminar.Value = !Convert.ToBoolean(ckEliminar.Value);
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtIdArticulo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Idarticulo"].Value);
                this.txtCodigo.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Codigo"].Value);
                this.txtDescripcion.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Descripcion"].Value);
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ckEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEliminar.Checked)
            {
                this.dgvListado.Columns[0].Visible = true;

            }
            else
            {
                this.dgvListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ckEliminar.Checked)
                {
                    this.Eliminar();
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar la casilla de Eliminar", "SISTEMA CMYKART",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

          
                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Buscar_Codigo_Articulo();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Buscar_Codigo_Articulo();
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
                frmReporteArticulos frm = new frmReporteArticulos();
                frm.TextoBuscar = this.txtBuscar.Text;
                frm.Usuario = this.Usuario.ToString();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+ex.StackTrace) ;
            }
        }

        #endregion
    }
}
