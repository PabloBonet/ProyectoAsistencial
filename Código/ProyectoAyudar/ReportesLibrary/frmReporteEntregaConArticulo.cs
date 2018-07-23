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
    public partial class frmReporteEntregaConArticulo : Form
    {

        public struct dato
        {
           
            public string idOrden;
            public string dniBeneficiario;
            public string descripcion;
            public string fechaCreacion;
            public string estado;
            public string fechaEstado;
            public string autorizado;
            public string entregado;

            public string cantidad;
            public string nombreArticulo;
            public string descripcionArticulo;
            public string tipoArticulo;
        }


       public List<dato> datos = new List<dato>();

        public string fechaDesde;
        public string fechaHasta;
        public frmReporteEntregaConArticulo()
        {
            InitializeComponent();
        }

        private void frmReporteEntregaConArticulo_Load(object sender, EventArgs e)
        {

            foreach (dato o in datos)
            {
                if (o.dniBeneficiario != null)
                {
                    DataSetBenefeciarios.EntregaOrdenes.AddEntregaOrdenesRow(o.idOrden, o.dniBeneficiario, o.fechaCreacion, o.descripcion, o.estado, o.fechaEstado, o.cantidad,
                        o.descripcionArticulo, o.nombreArticulo, o.tipoArticulo, fechaDesde, fechaHasta, o.autorizado, o.entregado);

                }

            }


            this.reportViewer1.RefreshReport();
        }
    }
}
