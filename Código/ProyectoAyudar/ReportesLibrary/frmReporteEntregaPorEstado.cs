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
    public partial class frmReporteEntregaPorEstado : Form
    {
        public struct orden
        {
            public string idOrden;
            public string dniBeneficiario;
            public string descripcion;
            public string fechaCreacion;
            public string estado;
            public string fechaEstado;
            public string cantidadArticulos;
            public string descripcionArticulo;
            public string nombreArticulo;
            public string tipoArticulo;
            public string autoriza;
            public string entregado;

        }

        public List<orden> ordenes = new List<orden>();

        public string fechaDesde;
        public string fechaHasta;
        public frmReporteEntregaPorEstado()
        {
            InitializeComponent();
        }

        private void frmReporteEntregaPorEstado_Load(object sender, EventArgs e)
        {

            foreach (orden o in ordenes)
            {
                if (o.dniBeneficiario != null)
                {
                    DataSetBenefeciarios.EntregaOrdenes.AddEntregaOrdenesRow(o.idOrden, o.dniBeneficiario, o.fechaCreacion, o.descripcion, o.estado, o.fechaEstado, o.cantidadArticulos,
                        o.descripcionArticulo, o.nombreArticulo, o.tipoArticulo, fechaDesde, fechaHasta,o.autoriza, o.entregado);
                   
                }

            }


            




            this.reportViewer1.RefreshReport();
        }
    }
}
