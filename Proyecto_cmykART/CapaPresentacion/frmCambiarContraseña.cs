using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaPresentacion.Clases;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCambiarContraseña : Form
    {
        #region Variables
        public int Idusuario;
        public string NombreUsuario;
        public string Usuario;

        #endregion
        public frmCambiarContraseña()
        {
            InitializeComponent();
        }



        #region Metodos

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Guardar()
        {
            string resultado = "";// Obtiene el ressultado de la verificacion de la contraseña
            string respuesta = "";//Obtiene el resultado del cambiode la contraseñla
            try
            {
                if(this.txtNuevaContraseña.Text == string.Empty || this.txtNuevoConfirmar.Text == string.Empty ||
                    this.txtContraseñaAnterior.Text == string.Empty)
                {
                    errorIcono.SetError(txtNuevaContraseña, "Debe de ingresar un Password");
                    errorIcono.SetError(txtNuevoConfirmar, "Debe de ingresar un Password");
                    errorIcono.SetError(txtContraseñaAnterior, "Debe de ingresar un Password");
                    return;
                }
                else
                {
                    if (!this.txtNuevaContraseña.Text.Equals(this.txtNuevoConfirmar.Text))
                    {
                        MessageBox.Show("Verifique las contraseñas, no coinciden ! ", "ERROR EN LA CONTRASEÑA",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        resultado = ValidarDatos(this.txtNuevaContraseña.Text);

                        if (resultado.Equals("OK"))
                        {
                            respuesta = NUsuario.CambiarContraseña(
                                Idusuario,
                                Idusuario,
                                CryptorEngine.Encrypt(this.txtContraseñaAnterior.Text,true),
                                CryptorEngine.Encrypt(this.txtNuevaContraseña.Text,true));

                            if (respuesta.Equals("OK"))
                            {
                                respuesta = NBitacora_Movimientos.Insertar("CAMBIO CONTRASEÑA",
                                                                            "USUARIOS",
                                                                            Idusuario,
                                                                            Idusuario,
                                                                            NombreUsuario);
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                            
                            

                        }
                        else
                        {
                            //Si la contraseña no es exitosa regresa al mismo formulario
                            return;
                        }

                        if(respuesta.Equals("OK"))
                        {
                            MessageBox.Show("Contraseña Cambiada Exitosamente", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Anterior Incorrecta", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }

                this.Hide();

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private string ValidarDatos(string password)
        {
            string resultado = "";
            int mayuscula = 0, minuscula = 0, numero = 0, espacio = 0;
            int total = 0;


            //ciclo for para obtener la longitud de la cadena
            //length obtiene el numero de caracteres de la cadena introducida
            for (int i = 0; i < password.Length; i++)
            {
                //con islower indica si un caracter se clasifica como minuscula
                if (char.IsLower(password[i]))
                {
                    minuscula++;
                }

                //con isupper indica si un caracter se clasifica como mayuscula
                if (char.IsUpper(password[i]))
                {
                    mayuscula++;
                }
                //con isnumber indica si un caracter se clasifica como numero
                if (char.IsNumber(password[i]))
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
            if (total <= 5 || total > 15)
            {
                MessageBox.Show("La contraseña debe tener 6 caracteres minimo y 15 caracteres maximo","Sistema CMYKART",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                resultado = "ERROR";

            }
            if (espacio >= 1)
            {
                MessageBox.Show("La contraseña no debe tener espacios", "Sistema CMYKART",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = "ERROR";
            }
            if (mayuscula >= 1 && minuscula >= 1 && numero >= 1 && espacio == 0)
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

        #endregion

        #region Eventos
        private void frmCambiarContraseña_Load(object sender, EventArgs e)
        {
            this.lblNombreUsuario.Text = this.NombreUsuario;
            this.lblUsuario.Text = this.Usuario;
        }
        private void linkCambioContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmContraseñas frm = new frmContraseñas();
            frm.ShowDialog();
        }

        private void txtNuevaContraseña_Enter(object sender, EventArgs e)
        {
            this.txtNuevaContraseña.UseSystemPasswordChar = true;
        }

        private void txtNuevoConfirmar_Enter_1(object sender, EventArgs e)
        {
            this.txtNuevoConfirmar.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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


        private void txtContraseñaAnterior_Enter(object sender, EventArgs e)
        {
            this.txtContraseñaAnterior.UseSystemPasswordChar = true;
        }
        #endregion

        




    }
}
