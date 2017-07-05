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
    public partial class frmReporteVentas : Form
    {
        private string _FechaInicial;
        private string _FechaFinal;
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }
        public string FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.SP_Reporte_Ventas' Puede moverla o quitarla según sea necesario.
                this.SP_Reporte_VentasTableAdapter.Fill(this.dsPrincipal.SP_Reporte_Ventas, FechaInicial, FechaFinal,Usuario);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }

            
            
        }
    }
}
