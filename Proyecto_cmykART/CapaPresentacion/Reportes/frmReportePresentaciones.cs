﻿using System;
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
    public partial class frmReportePresentaciones : Form
    {

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public frmReportePresentaciones()
        {
            InitializeComponent();
        }

        private void frmReportePresentaciones_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.SP_Reporte_Presentaciones' Puede moverla o quitarla según sea necesario.
                this.SP_Reporte_PresentacionesTableAdapter.Fill(this.dsPrincipal.SP_Reporte_Presentaciones,TextoBuscar,Usuario);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }
            
        }
    }
}