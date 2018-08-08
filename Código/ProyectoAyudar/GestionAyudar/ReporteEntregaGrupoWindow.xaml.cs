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
    /// Lógica de interacción para ReporteEntregaGrupoWindow.xaml
    /// </summary>
    public partial class ReporteEntregaGrupoWindow : Window
    {


        private GrupoBeneficiarioClass _grupoSeleccionado;
        public bool b_ok = false;
        private List<GrillaReporteEntregaGruClass> _itemsGrilla;
        public ReporteEntregaGrupoWindow()
        {
            InitializeComponent();

            _grupoSeleccionado = null;
            _itemsGrilla = new List<GrillaReporteEntregaGruClass>();
            grillaArticulos.ItemsSource = _itemsGrilla;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            btnBuscarArticulos.IsEnabled = true;
            btnBuscarGrupo.IsEnabled = true;
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

      

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            
            frmVerEntregaGrupo entrega = new frmVerEntregaGrupo();
            frmVerEntregaGrupo.articulo a;

            
            entrega.nombreGrupo = _grupoSeleccionado.Nombre;
            //entrega.descripcion = _grupoSeleccionado.Descripcion;
         
            entrega.fechaDesde = dpFechaDesde.DisplayDate.Date.ToShortDateString();
            entrega.fechaHasta = dpFechaHasta.DisplayDate.Date.ToShortDateString();
            

           
            foreach (GrillaReporteEntregaGruClass art in grillaArticulos.Items)
            {
                a = new frmVerEntregaGrupo.articulo();

                a.cantidad = art.Cantidad_articulo;
                a.descripcionArticulo = art.Descripcion_articulo;
                a.fechaEntrega = art.FechaEntrega_orden_entrega;
                a.horaEntrega = art.HoraEntrega_orden_entrega;

                a.nombreArticulo = art.Nombre_articulo;
                a.numeroOrden = art.Id_orden_entrega;
                a.tipoArticulo = art.Tipo_articulo;
                a.autorizado = art.Autorizado_por;
                a.entregado = art.Entregado_por;
                a.documento = art.Documento_beneficiario;
                a.nombreBeneficiario = art.Nombre_beneficiario;
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
            if(_grupoSeleccionado != null)
            {
                if (validarFechas())
                {

                    DateTime fechaDesde = (DateTime)dpFechaDesde.SelectedDate;
                    DateTime fechaHasta = (DateTime)dpFechaHasta.SelectedDate;



                    /*_articulos = ArticuloClass.ListarArticulosPorBeneficiarioEntreFechas(_beneficiarioSeleccionado.Id_beneficiario, fechaDesde, fechaHasta,(int)EstadoOrden.ENTREGADO ,true);
                    grillaArticulos.ItemsSource = _articulos;
                    */
                    List<BeneficiarioClass> listaBeneficiarios = _grupoSeleccionado.Beneficiarios;

                   
                    _itemsGrilla = ArticuloClass.ListarArticulosPorGrupoEntreFechasParaGrilla(_grupoSeleccionado.Id_grupo, fechaDesde, fechaHasta, (int)EstadoOrden.ENTREGADO, true);
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
                MessageBox.Show("Debe seleccionar el grupo para la busqueda", "No se han seleccionado el grupo", MessageBoxButton.OK, MessageBoxImage.Error);
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
            btnBuscarGrupo.Focus();
            btnBuscarGrupo.TabIndex = 0;
            dpFechaDesde.TabIndex = 1;
            dpFechaHasta.TabIndex = 2;
                     
            btnImprimir.TabIndex = 9;
        }

        private void btnBuscarGrupo_Click(object sender, RoutedEventArgs e)
        {
            BuscarGrupoWindow buscarWin = new BuscarGrupoWindow();
            buscarWin.Owner = this;
            buscarWin.ShowDialog();
            if (buscarWin.b_ok)
            {
                if (buscarWin.grupoSeleccionado != null)
                {
                    _grupoSeleccionado = buscarWin.grupoSeleccionado;


                    txtNombre.Text = _grupoSeleccionado.Nombre.ToString();
                    txtDescripcion.Text = _grupoSeleccionado.Descripcion.ToString();
                }
            }
        }
    }
}
