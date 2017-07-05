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
    public partial class frmReportePedidos : Form
    {
        private int _Idpedido;
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public int Idpedido
        {
            get { return _Idpedido; }
            set { _Idpedido = value; }
        }


        public frmReportePedidos()
        {
            InitializeComponent();
        }

        private void frmReportePedidos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.SP_Reporte_Pedido' Puede moverla o quitarla según sea necesario.
            this.SP_Reporte_PedidoTableAdapter.Fill(this.dsPrincipal.SP_Reporte_Pedido,this.Idpedido,this.Usuario);


            this.reportViewer1.RefreshReport();
        }
    }
}
