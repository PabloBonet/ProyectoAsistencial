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

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para ReporteEstadoOrdenWindow.xaml
    /// </summary>
    public partial class ReporteEstadoOrdenWindow : Window
    {
        private bool b_ok;
        private OrdenEntregaClass _ordenSeleccionada;
        private List<OrdenEntregaClass> _ordenes;
        private List<ItemEntregaClass> _itemsEntrega;
        public ReporteEstadoOrdenWindow()
        {
            InitializeComponent();

            _ordenSeleccionada = null;

            //Carga listas
            _ordenes = new List<OrdenEntregaClass>();
            grillaOrdenes.ItemsSource = _ordenes;

            _itemsEntrega = new List<ItemEntregaClass>();
            grillaArticulos.ItemsSource = _itemsEntrega;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            btnBuscarOrdenes.IsEnabled = true;
            btnImprimir.IsEnabled = false;
            chAutorizado.IsChecked = true;
            chIniciado.IsChecked = true;
            chEntregado.IsChecked = true;
            chCancelado.IsChecked = true;

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
            this.b_ok = false;
            this.Owner.Focus();
        }

       

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if(chImprimirArticulos.IsChecked == true)
            {


                //Imprime el listado con los artículos

                frmReporteEntregaConArticulo reporte = new frmReporteEntregaConArticulo();
                frmReporteEntregaConArticulo.dato d;

                reporte.fechaDesde = dpFechaDesde.DisplayDate.Date.ToShortDateString();
                reporte.fechaHasta = dpFechaHasta.DisplayDate.Date.ToShortDateString();


                //foreach(OrdenEntregaClass orden in _ordenes)
                foreach (OrdenEntregaClass orden in grillaOrdenes.Items)
                {
                    if(orden.Items_entrega != null)
                    {
                        foreach (ItemEntregaClass item in orden.Items_entrega)
                        {
                            d = new frmReporteEntregaConArticulo.dato();
                            d.cantidad = item.Cantidad.ToString();
                            d.descripcionArticulo = item.Articulo.Descripcion_articulo;
                            d.nombreArticulo = item.Articulo.Nombre_articulo;
                            d.tipoArticulo = item.Articulo.Tipo_articulo.Nombre_TipoArticulo;

                            d.idOrden = orden.Id_orden_entrega.ToString();
                            d.dniBeneficiario = orden.Beneficiario.Documento;
                            d.descripcion = orden.Descripcion;
                            d.fechaCreacion = orden.Fecha.ToShortDateString();
                            d.fechaEstado = orden.EstadoActual.Fecha.ToShortDateString();
                            d.estado = orden.EstadoActual.Estado.ToString();
                            if(orden.UsuarioAutoriza != null)
                            {
                                d.autorizado = orden.UsuarioAutoriza.Nombre_completo;
                            }
                            if(orden.UsuarioEntrega != null)
                            {
                                d.entregado = orden.UsuarioEntrega.Nombre_completo;
                            }
                            
                            
                            reporte.datos.Add(d);

                        }
                    }
                    
                }


                reporte.ShowDialog();
                reporte.Close();
                reporte = null;




            }
            else
            {
                //Imprime el listado sin los artículos

                
                frmReporteEntregaPorEstado reporte = new frmReporteEntregaPorEstado();
                frmReporteEntregaPorEstado.orden o;

                reporte.fechaDesde = dpFechaDesde.DisplayDate.Date.ToShortDateString();
                reporte.fechaHasta = dpFechaHasta.DisplayDate.Date.ToShortDateString();

                //foreach (OrdenEntregaClass orden in _ordenes)
                foreach (OrdenEntregaClass orden in grillaOrdenes.Items)
                {
                    if (orden.Items_entrega!= null)
                    {
                            o = new frmReporteEntregaPorEstado.orden();
                            o.cantidadArticulos = "";
                            o.descripcionArticulo = "";
                            o.nombreArticulo = "";
                            o.tipoArticulo = "";

                            o.idOrden = orden.Id_orden_entrega.ToString();
                            o.dniBeneficiario = orden.Beneficiario.Documento;
                            o.descripcion = orden.Descripcion;
                            o.fechaCreacion = orden.Fecha.ToShortDateString();
                            o.fechaEstado = orden.EstadoActual.Fecha.ToShortDateString();
                            o.estado = orden.EstadoActual.Estado.ToString();
                            if (orden.UsuarioAutoriza != null)
                            {
                                o.autoriza = orden.UsuarioAutoriza.Nombre_completo;
                            }

                            if (orden.UsuarioEntrega != null)
                            {
                                o.entregado = orden.UsuarioEntrega.Nombre_completo;
                            }


                            reporte.ordenes.Add(o);

                        
                       
                    }

                }


                reporte.ShowDialog();
                reporte.Close();
                reporte = null;


            }
        }

        

        private void grillaOrdenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ordenSeleccionada = (OrdenEntregaClass) grillaOrdenes.SelectedItem;

            if(_ordenSeleccionada != null)
            {
                _itemsEntrega = _ordenSeleccionada.Items_entrega;
                grillaArticulos.ItemsSource = _itemsEntrega;
            }
            else
            {
                _itemsEntrega = new List<ItemEntregaClass>();
                grillaArticulos.ItemsSource = _itemsEntrega;

            }

        }

        private void btnBuscarOrdenes_Click(object sender, RoutedEventArgs e)
        {
            
                if (validarFechas())
                {

                    DateTime fechaDesde = (DateTime)dpFechaDesde.SelectedDate;
                    DateTime fechaHasta = (DateTime)dpFechaHasta.SelectedDate;

               

                cargarOrdenes(fechaDesde, fechaHasta);

                   

                    if (_ordenes.Count == 0)
                    {

                        btnImprimir.IsEnabled = false;

                        MessageBox.Show("No se encuentran artículos con esos criterios de busqueda", "No se encuentran artículos", MessageBoxButton.OK, MessageBoxImage.Warning);

                        grillaOrdenes.Items.Refresh();

                    }
                    else
                    {
                        btnImprimir.IsEnabled = true;
                        grillaOrdenes.Items.Refresh();
                    }
                }
            
           
        }

        private void cargarOrdenes(DateTime fechaDesde, DateTime fechaHasta)
        {

            _ordenes = new List<OrdenEntregaClass>();

            DateTime fechaD = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day,0,0,0);
            DateTime fechaH = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23,59,59);

            List<OrdenEntregaClass> listaOrdenes = OrdenEntregaClass.ListarOrdenesEntregaDesdeHasta(fechaD, fechaH, true);


            foreach (OrdenEntregaClass orden in listaOrdenes)
            {
                switch (orden.EstadoActual.Estado)
                {
                    case EstadoOrden.AUTORIZADO:
                        if (chAutorizado.IsChecked == true)
                        {
                            _ordenes.Add(orden);
                        }
                        break;
                    case EstadoOrden.CANCELADO:
                        if (chCancelado.IsChecked == true)
                        {
                            _ordenes.Add(orden);
                        }
                        break;

                    case EstadoOrden.ENTREGADO:
                        if (chEntregado.IsChecked == true)
                        {
                            _ordenes.Add(orden);
                        }
                        break;
                    case EstadoOrden.INICIADO:
                        if (chIniciado.IsChecked == true)
                        {
                            _ordenes.Add(orden);
                        }
                        break;
                }
                grillaOrdenes.ItemsSource = _ordenes;

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
            chAutorizado.TabIndex = 0;
            chCancelado.TabIndex = 1;
            chEntregado.TabIndex = 2;
            chIniciado.TabIndex = 3;
            dpFechaDesde.TabIndex = 4;
            dpFechaHasta.TabIndex = 5;
            btnBuscarOrdenes.TabIndex = 6;
            chImprimirArticulos.TabIndex = 7;
            btnImprimir.TabIndex = 8;
        }
    }
}
