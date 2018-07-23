using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ReportesLibrary
{
    public partial class frmVerEntregaBeneficiario : Form
    {
        public struct articulo
        {
            public string cantidad;
            public string nombreArticulo;
            public string descripcionArticulo;
            public string tipoArticulo;
            public long numeroOrden;
            public string fechaEntrega;
            public string horaEntrega;
            public string autorizado;
            public string entregado;
        }

        public List<articulo> datos = new List<articulo>();

        public long idBeneficiario;
        public string documento;
        public string nombreBeneficiario;
        public string direccion;
        public string telefono;
        public string barrio;
        public string fechaDesde;
        public string fechaHasta;


        public frmVerEntregaBeneficiario()
        {
            InitializeComponent();
        }

        private void frmVerEntregaBeneficiario_Load(object sender, EventArgs e)
        {

            foreach (articulo a in datos)
            {
                if(a.nombreArticulo != null)
                {
                    dataSetBenefeciarios.EntregaPorBeneficiario.AddEntregaPorBeneficiarioRow(idBeneficiario.ToString(), documento, nombreBeneficiario, direccion, telefono,
                    barrio, a.cantidad, a.nombreArticulo, a.descripcionArticulo, a.tipoArticulo, a.numeroOrden.ToString(), a.fechaEntrega, fechaDesde, fechaHasta, a.horaEntrega, a.autorizado, a.entregado);
                }
                
               
            }


          /*  this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("idBeneficiario", idBeneficiario.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("documento", documento));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nombre", nombreBeneficiario));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("direccion", direccion));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("barrio", barrio));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("telefono", telefono));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("fechaDesde", fechaDesde));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("fechaHasta", fechaHasta));
            */

            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
