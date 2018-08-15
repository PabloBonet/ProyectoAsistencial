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
    public partial class frmOrdenEntrega : Form
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
        public string fecha;
        public string horaEntregado = "";
        public string usuarioAutoriza;
        public string usuarioEntrega;
        public string dniBeneficiario;
        public string nombreBeneficiario;
        public string descripcion;
        public string estadoActual;

        public frmOrdenEntrega()
        {
            InitializeComponent();
        }

        private void frmOrdenEntrega_Load(object sender, EventArgs e)
        {
            foreach (articulo a in datos)
            {
                if (a.nombreArticulo != null)
                {
                    DataSetBenefeciarios.OrdenEntrega.AddOrdenEntregaRow(idOrden.ToString(), usuarioEntrega, fecha, horaEntregado, dniBeneficiario, nombreBeneficiario, descripcion,
                        a.cantidad, a.nombreArticulo, a.descripcionArticulo, a.tipoArticulo, estadoActual, usuario, usuarioAutoriza);
                }

            }
            this.reportViewer1.RefreshReport();
        }
    }
}
