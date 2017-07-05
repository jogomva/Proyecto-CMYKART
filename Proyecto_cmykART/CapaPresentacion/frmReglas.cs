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
    public partial class frmReglas : Form
    {
        private bool IsNuevo = false;
        public frmReglas()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.InsertarNuevaRegla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
           
        }


        private void InsertarNuevaRegla()
        {
            this.IsNuevo = true;
            string respuesta = "";

            try
            {
                if (txtNombre.Text == string.Empty )
                {
                    errorIcono.SetError(txtNombre, "Debe de ingresar un valor!");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = NReglas.Insertar(this.txtNombre.Text, this.txtDescripcion.Text);
                    }

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Transacción Realizada Correctamente!!");
                    }
                    else
                    {
                        MessageBox.Show("No se guardó el registro");
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
