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
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = btnIngresar;
            lblHora.Text = DateTime.Now.ToString();
            
        }


        //Metodo para validar los password de los usuarios, permite el acceso al sistema
        private void Login ()
        {
           
            string rpta = "";
            int idusuario;
            
            try
            {
                if(this.txtUsuario.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Los campos no pueden estar vacíos","Sistema CMYKART",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    errorIcono.SetError(txtUsuario, "Debe de ingresar un valor");
                    errorIcono.SetError(txtPassword, "Debe de ingresar un valor");
                    return;
                }
                else
                {
                    



                    DataTable Datos = CapaNegocio.NUsuario.Login(this.txtUsuario.Text, CryptorEngine.Encrypt(this.txtPassword.Text, true));
                    //DataTable Datos = CapaNegocio.NUsuario.Login(this.txtUsuario.Text,this.txtPassword.Text);
                    //Evaluar si el usuario existe
                    if (Datos.Rows.Count == 0 )
                    {
                        MessageBox.Show("Usuario o contraseña no existen , verifique!", "Error en Usuario o Contraseña", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        frmMenuPrincipal frm = new frmMenuPrincipal();
                        frm.IdUsuario = Datos.Rows[0][0].ToString();
                        frm.Nombre = Datos.Rows[0][1].ToString();
                        frm.Apellidos = Datos.Rows[0][2].ToString();
                        frm.Usuario = Datos.Rows[0][3].ToString();
                        frm.Password = Datos.Rows[0][4].ToString();
                        frm.ReglasVerificar = Datos.Rows[0][6].ToString().Split(',');
                       
                        //Insertar Ingreso en la tabla de bitacoras
                        idusuario = Convert.ToInt32(Datos.Rows[0][0].ToString());
                        rpta = NBitacora_Ent_Sal.Insertar(idusuario, Convert.ToDateTime(this.lblHora.Text), "INGRESO");

                        //Ocultar el login
                        this.Hide();
                        //Mostrar el menú principal
                        frm.Show();
                        

                    }
                }

                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }



        #region Eventos
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Login();
                this.timer1.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.ToString();
            this.iTalk_ProgressIndicator1.Visible = true;

            

            this.progressLogin.Increment(1);
            if (progressLogin.Value == progressLogin.Maximum)
            {
                
                this.timer1.Stop();
                this.Login();
                this.progressLogin.Value = 0;
                this.iTalk_ProgressIndicator1.Visible = false;

            }

        }

  
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.textBox1.Select();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "";

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Text = "";
            
        }



        private void txtPassword_Enter(object sender, EventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Text = "";
        }

        #endregion



    }
}
