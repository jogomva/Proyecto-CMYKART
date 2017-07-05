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
    public partial class frmAgregarStock : Form
    {
        public string Presentacion;
        public int Stock;
        public int Idpresentacion;

        public frmAgregarStock()
        {
            InitializeComponent();
        }

        private void frmAgregarStock_Load(object sender, EventArgs e)
        {
            this.txtPresentacion.Text = Presentacion;
            this.lblStockActual.Text= Convert.ToString(Stock);
            this.btnGuardar.Select();
        }

        



        private void Guardar()
        {
            

            try
            {

                frmInventarioAgregar frm = frmInventarioAgregar.GetInstancia();

                if(this.txtPresentacion.Text == string.Empty || this.txtStockNuevo.Text == string.Empty)
                {
                    MessageBox.Show("Los campos no deben de estar vacíos","Sistema CMYKART",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string rpta = "";
                    rpta = NPresentacion.AgregarInventario
                        (Idpresentacion,
                        Convert.ToInt32(this.txtStockNuevo.Text));

                    if(rpta.Equals("OK"))
                    {
                        MessageBox.Show("Stock Actualizado Satisfactoriamente","Sistema CMYKART",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(rpta);
                    }

                    
                    this.Hide();
                }
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
                
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
    }
}
