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
    public partial class frmClientes : Form
    {

        #region Variables

        private bool IsNuevo = false;
        private bool IsEditar = false;
        public int Idusuario;
        public string Usuario;
        public string[] ReglasVerificar { get; set; }



        #endregion

        public frmClientes()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(txtDireccion, "Ingrese la Dirección del Cliente");
            this.ttMensaje.SetToolTip(txtTelefono, "Ingrese el Teléfono del Cliente");
            this.ttMensaje.SetToolTip(txtEmail, "Ingrese el Email del Cliente");
        }

        

        #region Eventos

        private void frmClientes_Load(object sender, EventArgs e)
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
            this.SetBordesyLineasGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsNuevo = true;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.HabilitarCampos(true);
                this.txtNombre.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace); ;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtIdCliente.Text.Equals(""))
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Guardar();
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

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Elimina"].Index)
            {
                DataGridViewCheckBoxCell ckEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Elimina"];
                ckEliminar.Value = !Convert.ToBoolean(ckEliminar.Value);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Buscar_Nombre_Cliente();
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
                this.Buscar_Nombre_Cliente();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckEliminar.Checked)
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

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtIdCliente.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Idcliente"].Value);
                this.txtNombre.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);
                this.txtDireccion.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Direccion"].Value);
                this.txtTelefono.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Telefono"].Value);
                this.txtEmail.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Email"].Value);
                this.tabControl1.SelectedIndex = 1;
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
                frmReporteClientes frm = new frmReporteClientes();
                frm.Textobuscar = this.txtBuscar.Text;
                frm.Usuario = this.Usuario;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Metodos

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
            this.txtIdCliente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        //Ocultar las 2 primeras columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[6].Visible = false;
            this.dgvListado.Columns[7].Visible = false;
            
        }

        //Amplia las columnas de Nombre y Descripcion
        private void Columnas()
        {
            this.dgvListado.Columns[2].Width = 300;
            
            this.dgvListado.Columns[3].Width = 300;
            this.dgvListado.Columns[3].HeaderText = "Dirección";
            this.dgvListado.Columns[4].Width = 150;
            this.dgvListado.Columns[4].HeaderText = "Teléfono";
            this.dgvListado.Columns[5].Width = 150;
        }

        //Habilita los campos de Nombre y Descripcion para Editar o solo Visualizar
        private void HabilitarCampos(bool valor)
        {

            this.txtNombre.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
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

        //Método Mostrar los perfiles
        private void Mostrar()
        {
            try
            {
                this.dgvListado.DataSource = NClientes.Mostrar();
                this.OcultarColumnas();
                this.Columnas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToSingle(dgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Método para insertar un nuevo perfil
        private void Guardar()
        {
            string fecha = DateTime.Now.ToString();

            try
            {
                string respuesta = "";
                //string bitacora = "";

                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("El campo Nombre de Cliente es Obligatorio!");
                    errorIcono.SetError(txtNombre, "Debe de ingresar un valor");
                    return;
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = NClientes.Insertar(this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                            this.txtTelefono.Text.Trim(),this.txtEmail.Text.Trim(),this.Idusuario);

                    }
                    else
                    {
                        respuesta = NClientes.Editar(Convert.ToInt32(this.txtIdCliente.Text), this.txtNombre.Text.Trim(),
                            this.txtDireccion.Text.Trim(),this.txtTelefono.Text.Trim(),this.txtEmail.Text.Trim(),this.Idusuario);

                        if (respuesta.Equals("OK"))
                        {
                            //Metodo para almacenar la tabla de bitacora de movimientos
                            respuesta = NBitacora_Movimientos.Insertar("UPDATE",
                                                                        "CLIENTES",
                                                                        Idusuario,
                                                                        Convert.ToInt32(this.txtIdCliente.Text),
                                                                        this.txtNombre.Text.Trim());
                        }
                        else
                        {
                            this.MensajeError(respuesta);
                        }
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
                        if(respuesta.Equals("ERROR"))
                        {
                            this.MensajeError("El dato ingresado en Nombre de Cliente ya existe!");
                        }
                        else
                        {
                            this.MensajeError(respuesta);  
                        }
                        
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


        //Metodo para buscar clientes por el nombre
        private void Buscar_Nombre_Cliente()
        {
            try
            {
                this.dgvListado.DataSource = NClientes.Buscar_Nombre_Cliente(this.txtBuscar.Text);
                this.OcultarColumnas();
                this.Columnas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Método para Eliminar registros
        private void Eliminar()
        {
            //string fecha = DateTime.Now.ToString();
            //string bitacora = "";
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros ?", "SISTEMA CMYKART", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Respuesta = "";
                    string Cliente;

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Cliente = Convert.ToString(row.Cells[2].Value);
                            Respuesta = NClientes.Eliminar(Convert.ToInt32(Codigo));

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el Registro");
                                
                                if(Respuesta.Equals("OK"))
                                {
                                    //Metodo para almacenar la tabla de bitacora de movimientos
                                    Respuesta = NBitacora_Movimientos.Insertar("DELETE",
                                                                                "CLIENTES",
                                                                                Idusuario,
                                                                                Convert.ToInt32(Codigo),
                                                                                Cliente);
                                }
                                else
                                {
                                    this.MensajeError(Respuesta);
                                }
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
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

        
    }
}
