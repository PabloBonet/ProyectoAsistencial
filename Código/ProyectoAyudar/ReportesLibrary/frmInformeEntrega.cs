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
    public partial class frmInformeEntrega : Form
    {
        public struct articulo
        {
            public string cantidad;
            public string nombreArticulo;
            public string descripcionArticulo;
            public string tipoArticulo;
         }

        public List<articulo> datos = new List<articulo>();

        public long idOrden;
        public string usuario;
        public string fechaEntregado;
        public string horaEntregado;
        public string dniBeneficiario;
        public string nombreBeneficiario;
        public string descripcion;

        public frmInformeEntrega()
        {
            InitializeComponent();
        }

        private void frmInformeEntrega_Load(object sender, EventArgs e)
        {
            foreach(articulo a in datos)
            {
                if (a.nombreArticulo != null)
                {
                    DataSetBenefeciarios.InformeEntrega.AddInformeEntregaRow(idOrden.ToString(), usuario, fechaEntregado, horaEntregado, dniBeneficiario, nombreBeneficiario, descripcion,
                    a.cantidad, a.nombreArticulo, a.descripcionArticulo, a.tipoArticulo);
                }
                    
            }

            
            this.reportViewer1.RefreshReport();
        }
    }
}
