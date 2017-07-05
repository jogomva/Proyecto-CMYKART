using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteInventario : Form
    {
        public frmReporteInventario()
        {
            InitializeComponent();
        }

        private void frmReporteInventario_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.SP_Mostrar_Inventario' Puede moverla o quitarla según sea necesario.
                this.SP_Mostrar_InventarioTableAdapter.Fill(this.dsPrincipal.SP_Mostrar_Inventario);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport(); ;
            }
            
        }
    }
}
