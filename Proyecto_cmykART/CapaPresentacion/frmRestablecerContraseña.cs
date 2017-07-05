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
using capaPresentacion.Clases;

namespace CapaPresentacion
{
    public partial class frmRestablecerContraseña : Form
    {


        public int Idusuario;

        public frmRestablecerContraseña()
        {
            InitializeComponent();
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


        private void Guardar()
        {
            string resultado = ""; //Obtiene el resultado de la verificacion de la contraseña
           // string respuesta = ""; //Obtiene el resultado del insert
            try
            {
                if(this.txtNuevaContraseña.Text == string.Empty || this.txtNuevoConfirmar.Text == string.Empty)
                {
                    errorIcono.SetError(txtNuevaContraseña, "Debe de ingresar un Password");
                    errorIcono.SetError(txtNuevoConfirmar, "Debe de ingresar un Password");
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

                        if(resultado.Equals("OK"))
                        {
                            string nuevaContraseña;
                            //respuesta = NUsuario.EditarContraseña(Idusuario,CryptorEngine.Encrypt(this.txtNuevaContraseña.Text,true));
                            frmUsuario frm =  frmUsuario.GetInstancia();
                            nuevaContraseña = this.txtNuevaContraseña.Text;
                            frm.SetNuevaContraseña(CryptorEngine.Encrypt(nuevaContraseña,true));
                            MessageBox.Show("Contraseña Restablecida Exitosamente", "Sistema CMYKART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            
                        }
                        else
                        {
                            //Si la contraseña no es exitosa regresa al mismo formulario
                            return; 
                        }
                        
                    }

                    
                }

                
                
               
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void frmRestablecerContraseña_Load(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNuevaContraseña_Enter(object sender, EventArgs e)
        {
            this.txtNuevaContraseña.UseSystemPasswordChar = true;
        }

        private void txtNuevoConfirmar_Enter(object sender, EventArgs e)
        {
            this.txtNuevoConfirmar.UseSystemPasswordChar = true;
        }
    }
}
