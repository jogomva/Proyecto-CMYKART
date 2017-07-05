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
    public partial class frmReporteIngresos : Form
    {
        private string _TextoBuscar1;
        private string _TextoBuscar2;

        
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string TextoBuscar1
        {
            get { return _TextoBuscar1; }
            set { _TextoBuscar1 = value; }
        }
        public string TextoBuscar2
        {
            get { return _TextoBuscar2; }
            set { _TextoBuscar2 = value; }
        }
        public frmReporteIngresos()
        {
            InitializeComponent();
        }

        private void frmReporteIngresos_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.SP_Reporte_Ingresos1' Puede moverla o quitarla según sea necesario.
                this.SP_Reporte_Ingresos1TableAdapter.Fill(this.dsPrincipal.SP_Reporte_Ingresos1, TextoBuscar1, TextoBuscar2, Usuario);

                this.reportViewer1.RefreshReport();

            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }
            
        }
    }
}
