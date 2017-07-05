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
    public partial class frmTrazabilidad : Form
    {
        public int Idpedido;
        public bool ArteHecho;
        public bool ArteAprobado;
        public bool Sublimado;
        public bool Entregado;

        public frmTrazabilidad()
        {
            InitializeComponent();
            
            

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //frmPedidos form = new frmPedidos();
            //    frmPedidos form = frmPedidos.GetInstancia();
                
            //    bool arteHecho;

            //    if(chkArteHecho.Checked)
            //    {
            //        arteHecho = true;
            //        form.RemarcarFilaTrazabilidad(arteHecho);
            //    }
                
            //    this.Hide();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message + ex.StackTrace);
            //}
        }

        private void iTalk_ControlBox1_Click(object sender, EventArgs e)
        {

        }

        
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            try
            {


                //frmPedidos form = new frmPedidos();
                frmPedidos frm = frmPedidos.GetInstancia();
                string rpta = "";

                if(Idpedido >= 1)
                {
                    rpta = NPedidos.ActualizarTrazabilidad(Idpedido, 
                                                            this.chkArteHecho.Checked, 
                                                            this.chkArteAprobado.Checked, 
                                                            this.chkSublimado.Checked, 
                                                            this.chkEntregado.Checked);
                }

                if(rpta.Equals("OK"))
                {
                    MessageBox.Show("Guardado con Exito", "Sistema CMYKART", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(rpta);
                }


                frm.MostrarDetallePedido();
                frm.RemarcarFilaTrazabilidad();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmTrazabilidad_Load(object sender, EventArgs e)
        {
            this.chkArteHecho.Checked = ArteHecho;
            this.chkArteAprobado.Checked = ArteAprobado;
            this.chkSublimado.Checked = Sublimado;
            this.chkEntregado.Checked = Entregado;
        }

        private void chkArteAprobado_Click(object sender, EventArgs e)
        {
            if (this.chkArteHecho.Checked == false)
            {
                MessageBox.Show("No Valido");
                this.chkArteAprobado.Checked = false;
            }
            
        }

        private void chkSublimado_Click(object sender, EventArgs e)
        {
            if(this.chkArteAprobado.Checked == false)
            {
                MessageBox.Show("No Valido");
                this.chkSublimado.Checked = false;
            }
        }

        private void chkEntregado_Click(object sender, EventArgs e)
        {
            if(this.chkSublimado.Checked == false)
            {
                MessageBox.Show("No Valido");
                this.chkEntregado.Checked = false;
            }
        }

        
    }
}
