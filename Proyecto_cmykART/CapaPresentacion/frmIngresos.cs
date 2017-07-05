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
    public partial class frmIngresos : Form
    {
        #region Variables

        //variable que almacena el valor del id del usuario al validarse el acceso al sistema
        public int Idusuario;
        public string Usuario;
        //Variable que se activa cuando se va a ingresar un nuevo registro
        private bool IsNuevo;

        public string[] ReglasVerificar { get; set; }

        #endregion

        public frmIngresos()
        {
            InitializeComponent();
            this.CargarComboPresentaciones();
        }

        private void frmIngresos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.BotonNuevo();
            this.BotonImprimir();
            this.BotonAnular();
        }

        #region Metodos


        



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

        //Metodo para limpiar los campos
        private void Limpiar()
        {
            this.txtIdingreso.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtStockInicial.Text = string.Empty;
        }
        //Metodo para cargar combo de presentaciones
        private void CargarComboPresentaciones()
        {
            this.cmbPresentacion.ValueMember = "Idpresentacion";
            this.cmbPresentacion.DisplayMember = "Nombre";
            this.cmbPresentacion.DataSource = NPresentacion.Mostrar();

        }

        //Metodo para ajustar el tamaño de las columnas del datagrid
        private void AjustarColumnas()
        {
            this.dgvListado.Columns[2].Width = 200;
            this.dgvListado.Columns[3].Width = 200;
            this.dgvListado.Columns[4].Width = 100;
            this.dgvListado.Columns[4].HeaderText = "Stock Inicial";
            this.dgvListado.Columns[5].Width = 150;
            this.dgvListado.Columns[6].Width = 200;
            this.dgvListado.Columns[7].Width = 200;
        }


        //Metodo que oculta las 2 primeras columnas de los registros
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;

        }
        //Metodo para mostrar los regsitros de ingresos
        private void Mostrar()
        {
            this.dgvListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            this.AjustarColumnas();
            this.RemarcarFilas();
            lblCuenta.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
        }
        //remarcar las filas anuladas con color
        private void RemarcarFilas()
        {
            string Estado;

            foreach (DataGridViewRow row in dgvListado.Rows)
            {
                Estado = Convert.ToString(row.Cells[5].Value);//Obtener estado del articulo
                if (Estado.Equals("ANULADO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void Habilitar(bool valor)
        {
            this.txtIdingreso.ReadOnly = valor;
            this.cmbPresentacion.Enabled = valor;
            this.dtFecha.Enabled = valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtStockInicial.ReadOnly = !valor;
            
        }
            
        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void BotonAnular()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;
            if (ver.TieneRegla("30"))
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

            if (ver.TieneRegla("31"))
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

            if (ver.TieneRegla("29"))
            {
                this.btnNuevo.Visible = true;

            }
            else
            {
                this.btnNuevo.Visible = false;

            }
        }
        
        private void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtStockInicial.Text == string.Empty || this.txtPrecio.Text == string.Empty)
                    
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtPrecio, "Ingrese un Valor");
                    errorIcono.SetError(txtStockInicial, "Ingrese un Valor");
                    return;
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(Idusuario, Convert.ToInt32(this.cmbPresentacion.SelectedValue),
                            Convert.ToInt32(txtStockInicial.Text),Convert.ToInt32(txtStockInicial.Text),"EMITIDO",
                            Convert.ToDecimal(this.txtPrecio.Text),this.dtFecha.Value);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }


                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.tcIngresos.SelectedIndex = 0;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Anular()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;// Obtener el codigo del Id de la tabla para anular el ingreso 
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anuló Correctamente el Ingreso");
                                Rpta = NBitacora_Movimientos.Insertar("ANULAR","INGRESOS",Idusuario,Convert.ToInt32(Codigo),"");
                                
                                if(Rpta.Equals("OK"))
                                {
                                    this.Mostrar();
                                    return;
                                }
                                else
                                {
                                    this.MensajeError(Rpta);
                                }
                            }
                            //else
                            //{
                                
                            //}

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

        private void BuscarIngresoFechas()
        {
            if (this.dtInicial.Value >= this.dtFinal.Value)
            {
                MessageBox.Show("Fecha de Inicio no puede ser Mayor o Igual a Fecha Final", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.dgvListado.DataSource = NIngreso.BuscarIngresosFecha(this.dtInicial.Value.ToString("yyyyMMdd"),
                this.dtFinal.Value.ToString("yyyyMMdd"));
                this.OcultarColumnas();
                this.RemarcarFilas();
                lblCuenta.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            
        }

        #endregion

        #region Eventos
        private void ckAnular_CheckedChanged(object sender, EventArgs e)
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

        private void ckAnular_CheckedChanged_1(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            //acutalida fecha añ dia de hoy cada vez que se haga un nuevo ingreso
            this.dtFecha.Value = DateTime.Now;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Guardar();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsNuevo = false;
                this.Botones();
                this.Limpiar();
                this.Habilitar(false);

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Anula"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Anula"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ckAnular.Checked)
                {
                    this.Anular();
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar la casilla de Eliminar", "SISTEMA CMYKART",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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
                this.BuscarIngresoFechas();
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
                frmReporteIngresos frm = new frmReporteIngresos();
                frm.Usuario = this.Usuario;
                frm.TextoBuscar1 = this.dtInicial.Value.ToString("yyyyMMdd");
                frm.TextoBuscar2 = this.dtFinal.Value.ToString("yyyyMMdd");
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void txtStockInicial_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCampos campo = new ValidarCampos();
            campo.ValidarControlesEnteros((TextBox) sender);
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCampos campo = new ValidarCampos();
            campo.ValidarControlesDecimales((TextBox)sender);
        }

        private void dgvListado_Sorted(object sender, EventArgs e)
        {
            this.RemarcarFilas();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtIdingreso.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Idingreso"].Value);
                this.dtFecha.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Fecha"].Value);
                this.cmbPresentacion.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Presentación"].Value);
                this.txtStockInicial.Text= Convert.ToString(this.dgvListado.CurrentRow.Cells["Stock_inicial"].Value);
                this.txtPrecio.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Precio Compra"].Value);
                this.tcIngresos.SelectedIndex = 1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion
    }


}
