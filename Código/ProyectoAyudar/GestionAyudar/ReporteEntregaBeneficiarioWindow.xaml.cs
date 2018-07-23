using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Processar.ProyectoAyudar.ClasesLibrary;
using Processar.ProyectoAyudar.ReportesLibrary;
//using System.Windows.Forms;

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para ReporteEntregaBeneficiarioWindow.xaml
    /// </summary>
    public partial class ReporteEntregaBeneficiarioWindow : Window
    {


        private BeneficiarioClass _beneficiarioSeleccionado;
        public bool b_ok = false;
        // private List<ArticuloClass> _articulos;
        private List<GrillaReporteEntregaClass> _itemsGrilla;
        public ReporteEntregaBeneficiarioWindow()
        {
            InitializeComponent();

            _beneficiarioSeleccionado = null;
            _itemsGrilla = new List<GrillaReporteEntregaClass>();
            grillaArticulos.ItemsSource = _itemsGrilla;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            btnBuscarArticulos.IsEnabled = true;
            btnBuscarBeneficiario.IsEnabled = true;
            btnImprimir.IsEnabled = false;

            /*
            Establece como fechas predeterminadas: 
            Fecha desde: primer dia del año anterior. 
            Fecha hasta: fecha actual.
            */
            dpFechaDesde.SelectedDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
            dpFechaHasta.SelectedDate = DateTime.Now;
           
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
            b_ok = false;
         
        }

        private void btnBuscarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            BuscarBeneficiarioWindow buscarWin = new BuscarBeneficiarioWindow();
            buscarWin.Owner = this;
            buscarWin.ShowDialog();
            if (buscarWin.b_ok)
            {
                if (buscarWin.beneficiarioSeleccionado != null)
                {
                    _beneficiarioSeleccionado = buscarWin.beneficiarioSeleccionado;

                    txtDocumento.Text = _beneficiarioSeleccionado.Documento.ToString();
                    txtNombre.Text = _beneficiarioSeleccionado.Nombre.ToString();
                    txtDireccion.Text = _beneficiarioSeleccionado.Direccion.ToString();
                    txtBarrio.Text = _beneficiarioSeleccionado.Barrio.Nombre.ToString();
                    txtTelefono.Text = _beneficiarioSeleccionado.Telefono.ToString();
                }
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            
            frmVerEntregaBeneficiario entrega = new frmVerEntregaBeneficiario();
            frmVerEntregaBeneficiario.articulo a;

            entrega.idBeneficiario = _beneficiarioSeleccionado.Id_beneficiario;
            entrega.documento = _beneficiarioSeleccionado.Documento;
            entrega.nombreBeneficiario = _beneficiarioSeleccionado.Nombre;
            entrega.barrio = _beneficiarioSeleccionado.Barrio.Nombre;
            entrega.direccion = _beneficiarioSeleccionado.Direccion;
            entrega.telefono = _beneficiarioSeleccionado.Telefono;
            entrega.fechaDesde = dpFechaDesde.DisplayDate.Date.ToShortDateString();
            entrega.fechaHasta = dpFechaHasta.DisplayDate.Date.ToShortDateString();
            

           
            foreach (GrillaReporteEntregaClass art in grillaArticulos.Items)
            {
                a = new frmVerEntregaBeneficiario.articulo();

                a.cantidad = art.Cantidad_articulo;
                a.descripcionArticulo = art.Descripcion_articulo;
                a.fechaEntrega = art.FechaEntrega_orden_entrega;
                a.horaEntrega = art.HoraEntrega_orden_entrega;

                a.nombreArticulo = art.Nombre_articulo;
                a.numeroOrden = art.Id_orden_entrega;
                a.tipoArticulo = art.Tipo_articulo;
                a.autorizado = art.Autorizado_por;
                a.entregado = art.Entregado_por;
                entrega.datos.Add(a);
            }

            entrega.ShowDialog();
            entrega.Close();
            entrega = null;
        }

        private void grillaArticulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBuscarArticulos_Click(object sender, RoutedEventArgs e)
        {
            if(_beneficiarioSeleccionado != null)
            {
                if (validarFechas())
                {

                    DateTime fechaDesde = (DateTime)dpFechaDesde.SelectedDate;
                    DateTime fechaHasta = (DateTime)dpFechaHasta.SelectedDate;
                    
                    

                    /*_articulos = ArticuloClass.ListarArticulosPorBeneficiarioEntreFechas(_beneficiarioSeleccionado.Id_beneficiario, fechaDesde, fechaHasta,(int)EstadoOrden.ENTREGADO ,true);
                    grillaArticulos.ItemsSource = _articulos;
                    */

                    _itemsGrilla = ArticuloClass.ListarArticulosPorBeneficiarioEntreFechasParaGrilla(_beneficiarioSeleccionado.Id_beneficiario, fechaDesde, fechaHasta, (int)EstadoOrden.ENTREGADO, true);
                    grillaArticulos.ItemsSource = _itemsGrilla;

                    if (_itemsGrilla.Count == 0)
                    {

                        btnImprimir.IsEnabled = false;

                        MessageBox.Show("No se encuentran artículos con esos criterios de busqueda", "No se encuentran artículos", MessageBoxButton.OK, MessageBoxImage.Warning);

                        grillaArticulos.Items.Refresh();

                    }
                    else
                    {
                        btnImprimir.IsEnabled = true;
                        grillaArticulos.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el beneficiario para la busqueda", "No se han seleccionado el beneficiario", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        /// <summary>
        /// Valida que las fechas seleccionadas comprueba que fechaDesde sea menor o igual que fechaHasta
        /// </summary>
        /// <returns>Retorna true si la fechaDesde es menor que fechaHasta</returns>
        private bool validarFechas()
        {
            bool r = false;
            if (dpFechaDesde.SelectedDate != null && dpFechaHasta.SelectedDate != null)
            {
                DateTime fechaDesde = (DateTime)dpFechaDesde.SelectedDate;
                DateTime fechaHasta = (DateTime)dpFechaHasta.SelectedDate;
           
                if (fechaDesde.Date <= fechaHasta.Date)
                {
                    r = true;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar las fechas para establecer el período de busqueda", "No se han seleccionado las fechas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return r;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            btnBuscarBeneficiario.Focus();
            btnBuscarBeneficiario.TabIndex = 0;
            dpFechaDesde.TabIndex = 1;
            dpFechaHasta.TabIndex = 2;
                     
            btnImprimir.TabIndex = 9;
        }
    }
}
