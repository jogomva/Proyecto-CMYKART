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
    public partial class frmReporteClientes : Form
    {

        private string _Textobuscar;
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Textobuscar
        {
            get { return _Textobuscar; }
            set { _Textobuscar = value; }
        }

        


        public frmReporteClientes()
        {
            InitializeComponent();
        }

        private void frmReporteClientes_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.SP_Buscar_Cliente' Puede moverla o quitarla según sea necesario.
                this.SP_Reporte_ClientesTableAdapter.Fill(this.dsPrincipal.SP_Reporte_Clientes, Textobuscar, Usuario);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }



            this.reportViewer1.RefreshReport();
        }
    }
}
