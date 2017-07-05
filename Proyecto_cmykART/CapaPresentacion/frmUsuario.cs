using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using capaPresentacion.Clases;



namespace CapaPresentacion
{
    public partial class frmUsuario : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public int Idusuario_creacion;
        public string Usuario;
        public string[] ReglasVerificar { get; set; }
        private static frmUsuario _instancia;
        public frmUsuario()
        {
            InitializeComponent();
            this.CargarPerfiles();
            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre del Usuario");
            this.ttMensaje.SetToolTip(txtApellidos, "Ingrese el Apellido del Usuario");
            this.ttMensaje.SetToolTip(txtUsuario, "Ingrese el Nombre del Usuario");
            this.ttMensaje.SetToolTip(txtPassword, "Ingrese el Nombre del Usuario");
            this.ttMensaje.SetToolTip(cmbPerfil, "Ingrese el Nombre del Usuario");
        }

        public static frmUsuario GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmUsuario();
            }
            return _instancia;
        }



        public void SetNuevaContraseña(string nuevacontraseña)
        {
            this.txtPassword.Text = nuevacontraseña;
        }

        //Mensaje de Confirmacion
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
            this.txtIdUsuario.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtConfirmar.Text = string.Empty;
        }

        //Ocultar las 2 primeras columnas
        private void OcultarColumnas()
        {
            this.dgvListado.Columns[0].Visible = false;
            this.dgvListado.Columns[1].Visible = false;
            this.dgvListado.Columns[7].Visible = false;
            
        }

        //Amplia las columnas de Nombre y Descripcion
        private void Columnas()
        {
            this.dgvListado.Columns[2].Width = 200;
            this.dgvListado.Columns[3].Width = 200;
            this.dgvListado.Columns[4].Width = 150;
            this.dgvListado.Columns[5].Width = 150;
            this.dgvListado.Columns[6].Width = 150;
        }

        //Habilita los campos de Nombre y Descripcion para Editar o solo Visualizar
        private void HabilitarCampos(bool valor)
        {

            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
            this.txtConfirmar.ReadOnly = !valor;
            this.cmbPerfil.Enabled = valor;
        }

        //Metodo que habilita los controles a la hora de cargar el formulario o en caso de insertar 
        //o modificar un registro


        private void BotonEliminar()
        {
            VerificarReglasUsuario ver = new VerificarReglasUsuario();
            ver.ReglasVerificar = this.ReglasVerificar;
            if (ver.TieneRegla("8"))
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

            if (ver.TieneRegla("9"))
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

            if (ver.TieneRegla("6"))
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

            if (ver.TieneRegla("7"))
            {
                this.btnEditar.Visible = true;

            }
            else
            {
                this.btnEditar.Visible = false;

            }
        }


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

        //Método Mostrar los perfiles
        private void Mostrar()
        {
            try
            {
                this.dgvListado.DataSource = NUsuario.Mostrar();
                this.OcultarColumnas();
                this.Columnas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToSingle(dgvListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo que valida los caracteres de la creación de contraseñas
        private string ValidarDatos(string password)
        {
            string resultado = "";
            int mayuscula = 0, minuscula = 0, numero = 0, espacio=0;
            int total = 0;


            //ciclo for para obtener la longitud de la cadena
            //length obtiene el numero de caracteres de la cadena introducida
            for(int i=0;i<password.Length;i++)
            {
                //con islower indica si un caracter se clasifica como minuscula
                if(char.IsLower(password[i]))
                {
                    minuscula++;
                }
                
                //con isupper indica si un caracter se clasifica como mayuscula
                if (char.IsUpper(password[i]))
                {
                        mayuscula++;
                }
                //con isnumber indica si un caracter se clasifica como numero
                if(char.IsNumber(password[i]))
                {
                    numero++;
                }
                //con isseparatoe indica si un caracter se clasifica como un separador(espacio)
                if (char.IsSeparator(password[i]))
                {
                    espacio++;
                }
                
            }
            //MessageBox.Show("Mayusculas: "+mayuscula.ToString()+"  Minusculas: "+minuscula.ToString()+" Numeros: "+numero+ " Espacio:"+espacio);
            total = mayuscula + minuscula + numero + espacio;
            if(total <=5 || total > 15)
            {
                MessageBox.Show("La contraseña debe tener 6 caracteres minimo y 15 caracteres maximo","Sistema CMYKART",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                resultado="ERROR";

            }
            if (espacio >= 1)
            {
                MessageBox.Show("La contraseña no debe tener espacios","Sistema CMYKART",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = "ERROR";
            }
            if(mayuscula >= 1 && minuscula >= 1 && numero >= 1 && espacio == 0)
            {
                MessageBox.Show("Contraseña Exitosa !!!", "Sistema CMYKART",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                resultado = "OK";
            }
                else
                {
                    MessageBox.Show("Contraseña debe contener al menos una Mayuscula, una Minuscula y un Numero", "Sistema CMYKART",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultado = "ERROR";
                }

            return resultado;

        }

        //Metodo para Guardar datos
        private void Guardar()
        {
         
            string respuesta = ""; // respuesta del insert
            string resultado = ""; // respuesta de la verificacion de la contraseña

            try
            {
                
                
                    //Se validan que los campos no queden vacios
                    if (txtNombre.Text == string.Empty || txtApellidos.Text == string.Empty || txtUsuario.Text == string.Empty ||
                           txtPassword.Text == string.Empty)
                    {
                        MessageBox.Show("Los datos remarcados son obligatorios, no deben de estar vacios!");
                            errorIcono.SetError(txtNombre, "Debe de ingresar un Nombre");
                            errorIcono.SetError(txtApellidos, "Debe de ingresar un Apellido");
                            errorIcono.SetError(txtUsuario, "Debe de ingresar un Usuario");
                            errorIcono.SetError(txtPassword, "Debe de ingresar un Password");
                            return;
                    }
                    else //else 1
                    {
                        //Validar que la confirmacion de la contraseña sea exitosa
                        if (!txtPassword.Text.Equals(this.txtConfirmar.Text) && IsNuevo )
                        {
                            MessageBox.Show("Verifique las contraseñas, no coinciden ! ", "ERROR EN LA CONTRASEÑA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else// else 2
                        {


                            if (IsNuevo)
                            {
                                //validar caracteres de la contraseña
                                resultado = ValidarDatos(this.txtPassword.Text);

                                if (resultado.Equals("OK"))
                                {
                                    //Se va a insertar un usuario nuevo
                                    respuesta = NUsuario.Insertar(this.txtNombre.Text, this.txtApellidos.Text,
                                        this.txtUsuario.Text, CryptorEngine.Encrypt(txtPassword.Text, true),
                                        Convert.ToInt32(cmbPerfil.SelectedValue),
                                        this.Idusuario_creacion);
                                }
                                else
                                {
                                    //Si el cambio de clave no es exitoso, retorne a efectuarlo nuevamente
                                    return;
                                }// else 3
                            }
                            else
                            {
                                
                                    respuesta = NUsuario.Editar(Convert.ToInt32(this.txtIdUsuario.Text),
                                    this.txtNombre.Text,
                                    this.txtApellidos.Text,
                                    this.txtUsuario.Text,
                                    Convert.ToInt32(this.cmbPerfil.SelectedValue),
                                    this.txtPassword.Text,
                                    this.Idusuario_creacion);
                                    
                                    //alimentar la tabla de bitacora de movimientos de edicion

                                    if (respuesta.Equals("OK"))
                                    {
                                        respuesta = NBitacora_Movimientos.Insertar("UPDATE",
                                                                                    "USUARIOS",
                                                                                    Idusuario_creacion,
                                                                                    Convert.ToInt32(this.txtIdUsuario.Text),
                                                                                    this.txtUsuario.Text);
                                    }
                                    else
                                    {
                                        this.MensajeError(respuesta);
                                    }



                                

                            }
                                
                            
                            

                        }//end if 2
                        if (respuesta.Equals("OK"))
                        {
                            if (this.IsNuevo)
                            {
                                this.MensajeOk("Usuario Registrado Satisfactoriamente !");
                            }
                            else
                            {
                                this.MensajeOk("Usuario Actualizado Satisfactoriamente !");
                                this.tabControl1.SelectedIndex = 0;
                                
                            }
                        }
                        else
                        {

                            if (respuesta.Equals("ERROR"))
                            {
                                this.MensajeError("El dato ingresado en Usuario ya existe!");
                                return;
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                            
                        }
                    }//end if 1


                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.errorIcono.Clear();
                    this.linkRestablecer.Visible = false;
                    
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Metodo para cargar perfiles
        private void CargarPerfiles()
        {
            try
            {
                
                this.cmbPerfil.ValueMember = "Idperfil";
                this.cmbPerfil.DisplayMember = "Nombre_perfil";
                this.cmbPerfil.DataSource = NPerfiles.Mostrar();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void Buscar_Nombre_Usuario()
        {
            try
            {
                this.dgvListado.DataSource = NUsuario.Buscar_Nombre_Usuario(this.txtBuscar.Text);
                this.OcultarColumnas();
                this.Columnas();
                this.lblCuenta.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

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
                    string Usuario;
                    string Respuesta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Usuario = Convert.ToString(row.Cells[4].Value);
                            Respuesta = NUsuario.Eliminar(Convert.ToInt32(Codigo));

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el Registro");

                                if (Respuesta.Equals("OK"))
                                {
                                    Respuesta = NBitacora_Movimientos.Insertar("DELETE",
                                                                                "USUARIOS",
                                                                                Idusuario_creacion,
                                                                                Convert.ToInt32(Codigo),
                                                                                Usuario);
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


        
        private void frmUsuario_Load(object sender, EventArgs e)
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
            this.linkRestablecer.Visible = false;
            this.SetBordesyLineasGrid();
        }

        

        private void btnGuardar_Click_1(object sender, EventArgs e)
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtIdUsuario.Text.Equals(""))
                {
                    this.IsEditar = true;
                    this.Botones();
                    this.HabilitarCampos(true);
                    //Deshabilita los campos para que no se puedan modificar
                    this.txtPassword.ReadOnly = true;
                    this.txtConfirmar.ReadOnly = true;
                    //Habilita la opcion de restablecer la contraseña
                    this.linkRestablecer.Visible = true;
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
                this.linkRestablecer.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Buscar_Nombre_Usuario();
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
                this.Buscar_Nombre_Usuario();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
  
                this.txtIdUsuario.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Idusuario"].Value);
                this.txtNombre.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Nombre"].Value);
                this.txtApellidos.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Apellidos"].Value);
                this.txtUsuario.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Usuario"].Value);
                this.cmbPerfil.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Perfil"].Value);
                this.txtPassword.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Password"].Value);
                //this.txtConfirmar.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["Password"].Value);

                this.tabControl1.SelectedIndex = 1;
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
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteUsuarios frm = new frmReporteUsuarios();
                frm.Usuario = this.Usuario;
                frm.TextoBuscar = this.txtBuscar.Text;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void linkContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmContraseñas frm = new frmContraseñas();
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRestablecerContraseña frm = new frmRestablecerContraseña();
            frm.Idusuario = Convert.ToInt32(this.txtIdUsuario.Text);
            frm.ShowDialog();
        }

        private void frmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar = true;
        }

        private void txtConfirmar_Enter(object sender, EventArgs e)
        {
            this.txtConfirmar.UseSystemPasswordChar = true;
        }

        

        //private void txtPassword_Click(object sender, EventArgs e)
        //{
        //    string pass;
        //    pass =  CryptorEngine.Decrypt(this.txtPassword.Text,false);
        //    this.txtPassword.Text = pass;
        //    this.txtConfirmar.Text = pass;
        //}

        

        

        
    }
}
