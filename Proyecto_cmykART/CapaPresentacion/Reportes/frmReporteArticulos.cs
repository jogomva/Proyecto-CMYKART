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
    public partial class frmReporteArticulos : Form
    {
        private string _TextoBuscar;
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public frmReporteArticulos()
        {
            InitializeComponent();
        }

        private void frmReporteArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                this.SP_Reporte_ArticulosTableAdapter.Fill(this.dsPrincipal.SP_Reporte_Articulos,TextoBuscar,Usuario);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }
            
        }
    }
}
