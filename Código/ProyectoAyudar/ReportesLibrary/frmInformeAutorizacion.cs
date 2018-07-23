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
    public partial class frmInformeAutorizacion : Form
    {

        public long idOrden;
        public string usuario;
        public string fechaAutorizado;
        public string horaAutorizado;
        public string dniBeneficiario;
        public string nombreBeneficiario;
        public string descripcion;
        public frmInformeAutorizacion()
        {
            InitializeComponent();
        }

        private void frmInformeAutorizacion_Load(object sender, EventArgs e)
        {
            DataSetBenefeciarios.InformeAutorizacion.AddInformeAutorizacionRow(idOrden.ToString(), usuario, fechaAutorizado, 
                horaAutorizado, dniBeneficiario, nombreBeneficiario, descripcion);

            this.reportViewer1.RefreshReport();
        }
    }
}
