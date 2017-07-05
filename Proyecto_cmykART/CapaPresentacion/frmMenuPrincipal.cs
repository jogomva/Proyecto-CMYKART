using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.MemoryMappedFiles;
using CapaNegocio;
using System.Diagnostics;


namespace CapaPresentacion
{
    public partial class frmMenuPrincipal : Form
    {
        private int childFormNumber = 0;

        public string IdUsuario = "";
        public string Nombre = "";
        public string Apellidos = "";
        public string Usuario = "";
        public string Password = "";
        public string Idperfil = "";
        public string[] ReglasVerificar { get; set; }
        VerificarReglasUsuario ver = new VerificarReglasUsuario();

        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MnuPresentaciones_Click(object sender, EventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            frm.MdiParent = this;
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.Usuario = this.Usuario;
            //envia los id de los permisos del usuario
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
        }

        private void MnuArticulos_Click(object sender, EventArgs e)
        {
            frmArticulo frm = new frmArticulo();
            frm.MdiParent = this;
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.Usuario = this.Usuario;
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
        }

        private void MnuPerfiles_Click(object sender, EventArgs e)
        {
            frmPerfil_Usuario frm = new frmPerfil_Usuario();
            frm.MdiParent = this;
            frm.Usuario = this.Usuario;
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
            
        }

        
        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            //carga imagen en contenedor mdi
            this.cargarimagen();
            this.lblEstadoUsuario.Text = this.Nombre + " " + this.Apellidos+ "  "+"Usuario: "+ this.Usuario;
            this.DesactivarMenu();
            //Se asigna el Id de la regla que el usuario contiene
            this.AsignarReglas();

            
        }

        private void AsignarReglas()
        {
            

            ver.ReglasVerificar = this.ReglasVerificar;

            //SEGURIDAD
            MnuSeguridad.Visible = ver.TieneRegla("1,2,3,4,5,6,7,8,9,10,11,12");
            MnuPerfiles.Visible = ver.TieneRegla("1,2,3,4");
            MnuRoles.Visible = ver.TieneRegla("5");
            MnuUsuarios.Visible = ver.TieneRegla("6,7,8,9");
            MnuBitacoraMovimientos.Visible = ver.TieneRegla("10");
            MnuBitacoraIngresosSalidas.Visible = ver.TieneRegla("11");
            MnuCambiarContraseña.Visible = ver.TieneRegla("12");
            //ALMACEN
            MnuAlmacen.Visible = ver.TieneRegla("13,14,15,16");
            MnuPresentaciones.Visible = ver.TieneRegla("13,14,15,16");

            //VENTAS
            MnuVentas.Visible = ver.TieneRegla("17,18,19,20,21,22,23,24");
            MnuClientes.Visible = ver.TieneRegla("17,18,19,20");
            MnuPedido.Visible = ver.TieneRegla("21,22,23,24");

            //INGRESOS
            MnuCompras.Visible = ver.TieneRegla("25");
            mnuInventario.Visible = ver.TieneRegla("25");

            //REPORTES
            MnuReportes.Visible = ver.TieneRegla("26,27");
            MnuReporteStock.Visible = ver.TieneRegla("26");
            MnuReporteVentas.Visible = ver.TieneRegla("27");
            MnuReporteSeguimiento.Visible = ver.TieneRegla("");
        }

        private void cargarimagen()
        {
            //Ruta donde se encuentra nuestra imagen
            //string ruta = "C:\\Users\\JOSE\\Documents\\Visual Studio 2013\\Projects\\Proyecto_cmykART\\CapaPresentacion\\Resources\\CMYKART-(LOGOTIPO)1.png";
            //string ruta = "C:\\Users\\JOSE\\Documents\\Visual Studio 2013\\Projects\\Proyecto_cmykART\\CapaPresentacion\\Resources\\Fondo.png";
            //Comprobamos que la ruta exista
            string ruta = Path.Combine( Application.StartupPath,"Fondo.png");
            if (File.Exists(ruta))
            {
                //Creamos un Bitmap con la imagen
                Bitmap bmp = new Bitmap(ruta);
                //Se la colocamos de fondo al formulario
                this.BackgroundImage = bmp;
                this.BackgroundImageLayout = ImageLayout.Stretch;

               

            }

        }


        private void DesactivarMenu()
        {
            //MODULO SEGURIDAD
            MnuSeguridad.Visible = true;
            MnuPerfiles.Visible = false;
            MnuRoles.Visible = false;
            MnuUsuarios.Visible = false;
            MnuBitacoraMovimientos.Visible = false;
            MnuBitacoraIngresosSalidas.Visible = false;
            //MODULO ALMACEN
            MnuAlmacen.Visible = true;
            MnuPresentaciones.Visible = false;
            MnuArticulos.Visible = false;
            
            //MODULO VENTAS
            MnuVentas.Visible = true;
            MnuPedido.Visible = false;
            MnuClientes.Visible = false;
            //MODULO COMPRAS
            MnuCompras.Visible = true;
            mnuInventario.Visible = false;
            MnuIngresos.Visible = false;
            //MODULO REPORTES
            MnuReportes.Visible = true;
            MnuReporteStock.Visible = false;
            MnuReporteVentas.Visible = false;
            MnuReporteSeguimiento.Visible = false;
        }

        //public bool TieneRegla(string reglasVerificar)
        //{
        //    string[] aReglas_a_verificar = reglasVerificar.Split(',');
        //    foreach (string s in aReglas_a_verificar)
        //    {
        //        if (s != "" && ReglasVerificar.Contains(s))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private void MnuClientes_Click_1(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.MdiParent = this;
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.Usuario = this.Usuario;
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
        }

        private void MnuPedido_Click(object sender, EventArgs e)
        {
            frmPedidos frm = frmPedidos.GetInstancia();
            frm.MdiParent = this;
            frm.Usuario = this.Usuario;
            frm.Idusuario =Convert.ToInt32( this.IdUsuario);
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
        }

        private void MnuMantenimiento_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             
            
            try
            {
                //string fecha = DateTime.Now.ToString();
                //string rpta = "";
                //rpta = NBitacora_Ent_Sal.Insertar(Convert.ToInt32( IdUsuario),Convert.ToDateTime(fecha),"SALIDA");

                //if(!rpta.Equals("OK"))
                //{
                //    MessageBox.Show(rpta);
                //}

                Application.Exit();
               
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles frm = new frmRoles();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = frmUsuario.GetInstancia();
            frm.MdiParent = this;
            frm.Idusuario_creacion = Convert.ToInt32(this.IdUsuario);
            frm.Usuario = this.Usuario;
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
        }

        private void MnuAcercade_Click(object sender, EventArgs e)
        {
            frmAcerca frm = new frmAcerca();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MnuManual_Click(object sender, EventArgs e)
        {
            string pdfManual = Path.Combine(Application.StartupPath, "MANUAL DE USUARIO.pdf");
            Process.Start(pdfManual);

            
        }

        private void MnuIngresos_Click(object sender, EventArgs e)
        {
            frmIngresos frm = new frmIngresos();
            frm.MdiParent = this;
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.Usuario = this.Usuario;
            frm.ReglasVerificar = this.ReglasVerificar;
            frm.Show();
            

        }

        private void MnuReporteStock_Click(object sender, EventArgs e)
        {
            frmReporteCantidadVendida frm = new frmReporteCantidadVendida();
            frm.MdiParent = this;
            frm.Usuario = this.Usuario;
            frm.Show();
        }

        private void tsPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frm = frmPedidos.GetInstancia();
            frm.MdiParent = this;
            frm.Usuario = this.Usuario;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                //string fecha = DateTime.Now.ToString();
                //string rpta = "";
                //rpta = NBitacora_Ent_Sal.Insertar(Convert.ToInt32(IdUsuario), Convert.ToDateTime(fecha), "SALIDA");

                //if (!rpta.Equals("OK"))
                //{
                //    MessageBox.Show(rpta);
                //}
                Application.Exit();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void MnuBitacoraIngresosSalidas_Click(object sender, EventArgs e)
        {
            frmBitacora_Entrada_Salida frm = new frmBitacora_Entrada_Salida();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void frmMenuPrincipal_SizeChanged(object sender, EventArgs e)
        //{
        //    //Ruta donde se encuentra nuestra imagen
        //    string ruta ="C:\\Users\\JOSE\\Documents\\Visual Studio 2013\\Projects\\Proyecto_cmykART\\CapaPresentacion\\Resources\\CMYKART2.png";
        //    //Comprobamos que la ruta exista
        //    if (File.Exists(ruta))
        //    {
        //        //Limpiamos la imagen actual
        //        this.BackgroundImage = null;

        //        //Creamos un Bitmap con la imagen
        //        Bitmap bmp = new Bitmap(ruta);

        //        //Se la colocamos de fondo al formulario
        //        this.BackgroundImage = bmp;
        //    }
        //}

        private void MnuReporteVentas_Click(object sender, EventArgs e)
        {
            frmConsultaVentas frm = new frmConsultaVentas();
            frm.MdiParent = this;
            frm.Usuario = this.Usuario;
            frm.Show();
        }

        private void MnuBitacoraMovimientos_Click(object sender, EventArgs e)
        {
            frmBitacoraMovimientos frm = new frmBitacoraMovimientos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void linkCambiarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCambiarContraseña frm = new frmCambiarContraseña();
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.NombreUsuario = this.Nombre + " " + this.Apellidos;
            frm.Usuario = Usuario;
            frm.ShowDialog();
        }

        //private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        //{
            
        //    //frmLogin frm = new frmLogin();
        //    //frm.Show();
        //    try
        //    {
        //        string fecha = DateTime.Now.ToString();
        //        string rpta = "";
        //        rpta = NBitacora_Ent_Sal.Insertar(Convert.ToInt32(IdUsuario), Convert.ToDateTime(fecha), "SALIDA");

        //        if (rpta.Equals("OK"))
        //        {
        //            Application.Exit();
        //        }
        //        else
        //        {
        //            MessageBox.Show(rpta);
        //        }
                

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message + ex.StackTrace);
        //    }
        //}

        private void MnuCambiarContraseña_Click(object sender, EventArgs e)
        {
            frmCambiarContraseña frm = new frmCambiarContraseña();
        }

        private void MnuCambiarContraseña_Click_1(object sender, EventArgs e)
        {
            frmCambiarContraseña frm = new frmCambiarContraseña();
            frm.Idusuario = Convert.ToInt32(this.IdUsuario);
            frm.NombreUsuario = this.Nombre + " " + this.Apellidos;
            frm.Usuario = Usuario;
            frm.ShowDialog();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            string pdfManual = Path.Combine(Application.StartupPath, "MANUAL DE USUARIO.pdf");
            Process.Start(pdfManual);
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string fecha = DateTime.Now.ToString();
                string rpta = "";
                rpta = NBitacora_Ent_Sal.Insertar(Convert.ToInt32(IdUsuario), Convert.ToDateTime(fecha), "SALIDA");

                if (rpta.Equals("OK"))
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(rpta);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmMenuPrincipal_SizeChanged(object sender, EventArgs e)
        {
            this.cargarimagen();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioAgregar frm = new frmInventarioAgregar();
            frm.MdiParent = this;
            frm.Show();
        }




    }
}
