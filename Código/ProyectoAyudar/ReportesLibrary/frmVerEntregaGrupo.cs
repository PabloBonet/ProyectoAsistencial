using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processar.ProyectoAyudar.ReportesLibrary
{
    public partial class frmVerEntregaGrupo : Form
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
            public long idBeneficiario;
            public string documento;
            public string nombreBeneficiario;
        }

        public List<articulo> datos = new List<articulo>();

      
        public string direccion;
        public string telefono;
        public string barrio;
        public string fechaDesde;
        public string fechaHasta;
        public string nombreGrupo;

        public frmVerEntregaGrupo()
        {
            InitializeComponent();
        }

        private void frmVerEntregaGrupo_Load(object sender, EventArgs e)
        {

            foreach (articulo a in datos)
            {
                if (a.nombreArticulo != null)
                {
                    dataSetBenefeciarios.EntregaPorGrupo.AddEntregaPorGrupoRow(a.idBeneficiario.ToString(), a.documento, a.nombreBeneficiario, direccion, telefono,
                    barrio, a.cantidad, a.nombreArticulo, a.descripcionArticulo, a.tipoArticulo, a.numeroOrden.ToString(), a.fechaEntrega, fechaDesde, fechaHasta, a.horaEntrega, a.autorizado, a.entregado, nombreGrupo);
                }


            }


         

            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
