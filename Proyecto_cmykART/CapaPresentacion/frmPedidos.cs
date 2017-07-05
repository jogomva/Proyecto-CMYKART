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
    public partial class frmPedidos : Form
    {
        

        #region Variables 

        private bool IsNuevo = false;
        private bool IsEditar = false;
        public string Usuario;
        public int Idusuario;
        private decimal totalPagado = 0;
        private DataTable dtDetalleVenta;
        private static frmPedidos _instancia;
        public string[] ReglasVerificar { get; set; }

        private int Idpedido;

        #endregion

        
        
        public frmPedidos()
        {
            InitializeComponent();
            this.txtIdIngreso.Visible = false;
            this.txtPresentacion.ReadOnly = true;
            this.txtIdPresentacion.Visible = true;
            this.CargarClientes();
            this.txtIdPresentacion.Visible = false;
            this.txtStockActual.Visible = false;


            
        }

        


        #region Metodos

        public static frmPedidos GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmPedidos();
            }
            return _instancia;
        }

        
        private void CargarClientes()
        {
            try
            {
                this.cmbCliente.ValueMember = "Idcliente";
                this.cmbCliente.DisplayMember = "Nombre";
                this.cmbCliente.DataSource = NClientes.Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        public void RemarcarFilaTrazabilidad()
        {
            bool arteHecho;
            bool arteAprobado;
            bool sublimado;
            bool entregado;

            foreach (DataGridViewRow row in dgvListadoDetalle.Rows)
            {
                arteHecho = Convert.ToBoolean(row.Cells[8].Value);
                arteAprobado = Convert.ToBoolean(row.Cells[9].Value);
                sublimado = Convert.ToBoolean(row.Cells[10].Value);
                entregado = Convert.ToBoolean(row.Cells[11].Value);

                if (arteHecho == true && arteAprobado == false )
                {
                    row.DefaultCellStyle.BackColor = Color.DodgerBlue;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if(arteHecho == true && arteAprobado == true && sublimado == false && entregado == false)
                {
                    row.DefaultCellStyle.BackColor = Color.MediumVioletRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if(arteHecho == true && arteAprobado == true && sublimado == true && entregado == false)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if(arteHecho == true && arteAprobado == true && sublimado == true && entregado == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }



            }
            
        }

        //Obtiene las variables pasadas por parametros
        public void setPresentacion(int idpresentacion, int stockactual,string presentacion)
        {
            //this.txtIdIngreso.Text = idingreso;
            this.txtPresentacion.Text = presentacion;
            this.txtStockActual.Text = Convert.ToString(stockactual);
            this.txtIdPresentacion.Text = Convert.ToString(idpresentacion);
            //this.txtIdPresentacion.Text = idpresentacion;

        }

        //Metodo para crear una tabla de detalle de los pedidos
        private void CrearTabla()
        {
            try
            {
                this.dtDetalleVenta = new DataTable("DetalleVenta");
                this.dtDetalleVenta.Columns.Add("Idpresentacion", System.Type.GetType("System.Int32"));
                this.dtDetalleVenta.Columns.Add("Diseño", System.Type.GetType("System.String"));
                this.dtDetalleVenta.Columns.Add("Presentacion", System.Type.GetType("System.String"));
                this.dtDetalleVenta.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
                this.dtDetalleVenta.Columns.Add("Precio", System.Type.GetType("System.Decimal"));
                this.dtDetalleVenta.Columns.Add("Estado", System.Type.GetType("System.String"));
                this.dtDetalleVenta.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
                this.dgvListadoDetalle.DataSource = this.dtDetalleVenta;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //Campos
            this.dtFecha.Enabled = valor;
            this.cmbCliente.Enabled = valor;
            this.txtDiseño.ReadOnly= !valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtStockActual.ReadOnly = valor;
            //Botones
            this.btnBuscarPresentacion.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }


        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }



        private void BotonAnular()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;
            if (ver.TieneRegla("23"))
            {
                this.btnAnular.Enabled = true;
            }
            else
            {
                this.btnAnular.Enabled = false;
            }
        }
        private void BotonImprimir()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;

            if (ver.TieneRegla("24"))
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

            if (ver.TieneRegla("21"))
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

            if (ver.TieneRegla("22"))
            {
                this.btnEditar.Visible = true;

            }
            else
            {
                this.btnEditar.Visible = false;

            }
        }

        private void Limpiar()
        {
            //Campos
            this.txtIdPedido.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtStockActual.Text = string.Empty;
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdPresentacion.Text = string.Empty;
            this.txtPresentacion.Text = string.Empty;
            

            this.lblTotal.Text = "0.00";
            this.totalPagado = 0;
            this.CrearTabla();

        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[8].Visible = false;
            this.dgvListado.Columns[10].Visible = false;
            this.dgvListado.Columns[11].Visible = false;

        }
        //Ocultar columnas del grid del detalle del pedido
        private void OcultarColumnasGridDetalle()
        {
            this.dgvListadoDetalle.Columns[5].Visible = false;
            this.dgvListadoDetalle.Columns[7].Visible = false;
            

        }

        //Amplia las columnas de Nombre y Descripcion
        private void AjustarColumnas()
        {
            this.dgvListado.Columns[2].Width = 170;
            this.dgvListado.Columns[3].Width = 200;
            this.dgvListado.Columns[4].Width = 80;
            this.dgvListado.Columns[5].Width = 130;
            this.dgvListado.Columns[6].Width = 130;
        }
        private void Mostrar()
        {
            try
            {
                this.dgvListado.DataSource = NPedidos.Mostrar();
                this.OcultarColumnas();
                this.AjustarColumnas();
                //this.RemarcarFilas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToSingle(dgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //remarcar las filas con articulos anulados
        private void RemarcarFilas()
        {
            string Estado;
           
            

            foreach(DataGridViewRow row in dgvListado.Rows)
            {
                Estado = Convert.ToString(row.Cells[8].Value);//Obtener estado del articulo
                if(Estado.Equals("ANULADO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                
            }
        }


        private void ObtenerIdPedido()
        {

            int max = int.MaxValue;


            foreach (DataGridViewRow row in dgvListado.Rows)
            {
                
                if (Convert.ToInt32(row.Cells["# Pedido"].Value) < max)
                {
                    Idpedido = Convert.ToInt32(row.Cells["# Pedido"].Value);
                    break;
                }
            }
        }





        //Metodo que agrega en la tabla los datos del articulo 
        private void AgregarArticulo()
        {
            try
            {

                if (this.txtPresentacion.Text== string.Empty || this.txtCantidad.Text == string.Empty
                    ||  this.txtPrecio.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtPresentacion, "Seleccione un Presentación");
                    errorIcono.SetError(txtCantidad, "Ingrese una Cantidad");
                    errorIcono.SetError(txtPrecio, "Ingrese un Precio");
                    errorIcono.SetError(txtDiseño, "Ingrese un Diseño");
                }
                else
                {
                    bool registrar = true;
                    //foreach (DataRow row in dtDetalleVenta.Rows)
                    //{
                    //    if (Convert.ToInt32(row["Articulo"]) == Convert.ToInt32(this.cmbArticulos.Text))
                    //    {
                    //        registrar = false;
                    //        MessageBox.Show("El articulo ya se encuentra en el detalle");
                    //    }
                    //}
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecio.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal.Text = totalPagado.ToString("0.00");
                        //Agregar el detalle al dgvlistadodetalle
                        DataRow row = this.dtDetalleVenta.NewRow();
                        row["Idpresentacion"] = Convert.ToInt32(this.txtIdPresentacion.Text);
                        row["Diseño"] = this.txtDiseño.Text;
                        row["Presentacion"] = this.txtPresentacion.Text;
                        row["Cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["Precio"] = Convert.ToDecimal(this.txtPrecio.Text);
                        row["Estado"] = "EMITIDO";
                        row["Subtotal"] = subTotal;
                        this.dtDetalleVenta.Rows.Add(row);
                        //Limpia los controles para insertar un nuevo pedido
                        this.LimpiarDetallePedido();
                        //En caso de error limpia las validaciones
                        this.errorIcono.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No hay Stock suficiente,verifique","Sistema CMYKART", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }



                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void AjustarColumnasDetalleListado()
        {
            this.dgvListadoDetalle.Columns[0].Visible = false;
            this.dgvListadoDetalle.Columns[1].Width = 200;
            this.dgvListadoDetalle.Columns[2].Width = 200;
            this.dgvListadoDetalle.Columns[3].Width = 100;
            this.dgvListadoDetalle.Columns[4].Width = 170;
            this.dgvListadoDetalle.Columns[5].Width = 170;
            this.dgvListadoDetalle.Columns[6].Width = 170;
            this.dgvListado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        // Metodo para guardar datos de los pedidos nuevos y editados
        private void Guardar()
        {
            
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    if (!this.dgvListadoDetalle.Rows.Count.Equals(0))
                    {
                        rpta = NPedidos.Insertar(Convert.ToInt32(this.cmbCliente.SelectedValue),
                        this.dtFecha.Value,
                        this.Idusuario, dtDetalleVenta);

                        
                    }
                    else
                    {
                        this.MensajeError("Debe de ingresar al menos 1 Artículo");
                        return;
                    }
                    

                }
                else
                {
                    rpta = NPedidos.Editar(Convert.ToInt32(this.txtIdPedido.Text),
                        Convert.ToInt32(this.cmbCliente.SelectedValue),
                        this.dtFecha.Value);

                    
                }


                if (rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro !");
                        
                    }
                    else
                    {
                        this.MensajeOk("Registro Actualizado Satisfactoriamente !");
                        rpta = NBitacora_Movimientos.Insertar("UPDATE", "PEDIDOS", Idusuario, Convert.ToInt32(this.txtIdPedido.Text), "");
                    }


                }
                else
                {
                    this.MensajeError(rpta);
                }

                
                //Limpia todos los controles , los deja vacíos
                this.Limpiar();
                //Limpia los 
                this.LimpiarDetallePedido();
                this.Mostrar();
                this.ObtenerIdPedido();
                
                if(IsNuevo && rpta.Equals("OK"))
                {
                    rpta = NBitacora_Movimientos.Insertar("INSERT", "PEDIDOS", Idusuario, Idpedido, "");
                }
                


                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.errorIcono.Clear();
                this.dtDetalleVenta = null;
                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void LimpiarDetallePedido()
        {
            this.txtPresentacion.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtStockActual.Text = string.Empty;
            this.txtDiseño.Text = string.Empty;
            
        }

        public void MostrarDetallePedido()
        {
            
            this.dgvListadoDetalle.DataSource = NPedidos.MostrarDetallePedido(this.txtIdPedido.Text);
            this.OcultarColumnasGridDetalle();

        }


        private void QuitarFila()
        {
            try
            {
                int indiceFila = this.dgvListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalleVenta.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Subtotal"].ToString());
                this.lblTotal.Text = totalPagado.ToString("#0.00#");
                //Remover la fila
                this.dtDetalleVenta.Rows.Remove(row);
            }
            catch (Exception)
            {
                MensajeError("No hay fila para remover");
            }
        }


        private void BuscarPedidoFecha()
        {
            try
            {
                string fechaHoy = DateTime.Now.ToString();

                if (this.dtInicial.Value >= this.dtFinal.Value)
                {
                    MessageBox.Show("Fecha de Inicio no puede ser Mayor o Igual a Fecha Final","Sistema CMYKART",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvListado.DataSource = NPedidos.BuscarPedidoFecha(this.dtInicial.Value.ToString("yyyyMMdd"),
                    this.dtFinal.Value.ToString("yyyyMMdd"));
                    this.OcultarColumnas();
                    this.AjustarColumnas();
                    this.RemarcarFilas();
                    this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(this.dgvListado.Rows.Count);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void AnularPedido()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular el/los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string CodigoPresentacion;
                    string Cantidad;
                    string Estado;
                    string CodigoPedido;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[11].Value);//Obtener id de la tabla detalle pedidos
                                CodigoPresentacion = Convert.ToString(row.Cells[10].Value);//Obtener id de la tabla de Presentacion
                                Cantidad = Convert.ToString(row.Cells[6].Value);//Obtener cantidad 
                                Estado = Convert.ToString(row.Cells[8].Value);//Obtener estado del articulo
                                CodigoPedido = Convert.ToString(row.Cells[1].Value);//Obtener el codigo de pedido
                            
                                if(!Estado.Equals("ANULADO"))
                                {
                                    Rpta = NPedidos.Anular(Convert.ToInt32(Codigo));

                                    if (Rpta.Equals("OK"))
                                    {
                                        this.MensajeOk("Se Anuló Correctamente el Ingreso");
                                        Rpta = NPedidos.AumentarStock(Convert.ToInt32(CodigoPresentacion), Convert.ToInt32(Cantidad));//Devuelve la cantidad al stock actual

                                        if (Rpta.Equals("OK"))
                                        {
                                            this.MensajeOk("Cantidad se ha devuelto al stock actual: " + Cantidad);
                                            Rpta = NBitacora_Movimientos.Insertar("ANULAR","PEDIDOS",Idusuario,Convert.ToInt32( CodigoPedido),"");
                                        }
                                        else
                                        {
                                            this.MensajeError(Rpta);
                                        }

                                    }
 
                                }
                                else
                                {
                                    this.MensajeError("El Artículo ya se encuentra ANULADO");
                                }
                            
                            }
                            
                            
                        }
                        
                        
                    }
                    this.Mostrar();
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

            //datadrid detalle
            this.dgvListadoDetalle.DefaultCellStyle.Font = new Font("Verdana", 10);
            this.dgvListadoDetalle.GridColor = Color.DeepSkyBlue;
            this.dgvListadoDetalle.ClearSelection();
            
        }



        #endregion 

        
        #region Eventos

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.BotonNuevo();
            this.BotonEditar();
            this.BotonAnular();
            this.BotonImprimir();
            this.CrearTabla();
            this.AjustarColumnasDetalleListado();
            this.SetBordesyLineasGrid();
            
        }

        private void btnBuscarPresentacion_Click(object sender, EventArgs e)
        {
            frmVista_Presentacion_Pedido vista = new frmVista_Presentacion_Pedido();
            vista.ShowDialog();
        }

        private void frmPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AgregarArticulo();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsNuevo = true;
                this.Botones();
                this.Habilitar(true);
                this.Limpiar();
                this.CrearTabla();
                //ACTUALIZAR FECHA AL DIA DE HOY
                this.dtFecha.Value = DateTime.Now;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
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
            if (ckAnular.Checked)
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
            if (e.ColumnIndex == dgvListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ckEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Anular"];
                ckEliminar.Value = !Convert.ToBoolean(ckEliminar.Value);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.QuitarFila();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarPedidoFecha();
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
                this.txtIdPedido.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["# Pedido"].Value);
                this.cmbCliente.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Cliente"].Value);
                this.dtFecha.Value = Convert.ToDateTime(this.dgvListado.CurrentRow.Cells["Fecha"].Value);
                this.MostrarDetallePedido();
                this.tabControl1.SelectedIndex = 1;
                this.RemarcarFilaTrazabilidad();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtIdPedido.Text.Equals(""))
                {
                    this.IsEditar = true;
                    this.Botones();
                    //Bloquer todos los controles
                    this.Habilitar(false);
                    //Bloquear el datagrid de detalle para que no se pueda modificar
                    this.dgvListadoDetalle.Enabled = false;
                    this.dtFecha.Enabled = true;
                    this.cmbCliente.Enabled = true;
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

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckAnular.Checked)
                {
                    this.AnularPedido();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.Habilitar(false);
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
                
                    frmReportePedidos frm = new frmReportePedidos();
                    frm.Idpedido = Convert.ToInt32(this.dgvListado.CurrentRow.Cells["# Pedido"].Value);
                    frm.Usuario = this.Usuario;
                    frm.ShowDialog();
               
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCampos valida = new ValidarCampos();
            valida.ValidarControlesEnteros((TextBox)sender);
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCampos valida = new ValidarCampos();
            valida.ValidarControlesEnteros((TextBox)sender);
        }


        private void dgvListado_Sorted(object sender, EventArgs e)
        {
            this.RemarcarFilas();
        }
        #endregion

        private void dgvListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListadoDetalle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtIdPedido.Text.Equals(""))
                {
                    frmTrazabilidad frm = new frmTrazabilidad();
                    frm.Idpedido = Convert.ToInt32(this.dgvListadoDetalle.CurrentRow.Cells["Iddetalle_pedido"].Value );
                    frm.ArteHecho = Convert.ToBoolean(this.dgvListadoDetalle.CurrentRow.Cells["ArteHecho"].Value);
                    frm.ArteAprobado = Convert.ToBoolean(this.dgvListadoDetalle.CurrentRow.Cells["ArteAprobado"].Value);
                    frm.Sublimado = Convert.ToBoolean(this.dgvListadoDetalle.CurrentRow.Cells["Sublimado"].Value);
                    frm.Entregado = Convert.ToBoolean(this.dgvListadoDetalle.CurrentRow.Cells["Entregado"].Value);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Debe de ingresar el Pedido para poder asignarle la trazabilidad", "Sistema CMYKART",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
            
        }


        
    }
}
