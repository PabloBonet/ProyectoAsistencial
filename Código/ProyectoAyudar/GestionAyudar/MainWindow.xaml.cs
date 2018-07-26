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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Processar.ProyectoAyudar.ClasesLibrary;
using Processar.ProyectoAyudar.ReportesLibrary;
using Processar.ProyectoAyudar.GestionAyudar;
using System.Windows.Controls.Ribbon;



namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int CANTIDAD_BENEFICIARIOS_A_MOSTRAR = 10;
    
        
        public static UsuarioClass usuario_logueado;
        public static List<OrdenEntregaClass> ordenesIniciadas;
        public static List<OrdenEntregaClass> ordenes;
        public static List<OrdenEntregaClass> ordenesAutorizadas;

        public OrdenEntregaClass ordenSeleccionada;

        private List<OrdenEntregaWindow> _ventanasOrdenes;
        private List<BeneficiarioWindow> _ventanasBeneficiarios;
        private List<BarrioWindow> _ventanasBarrios;
        private List<TipoArticuloWindows> _ventanasTipoArticulos;
        private List<ArticuloWindow> _ventanasArticulos;
        private List<UsuarioWindow> _ventanasUsuarios;

        private List<PermisoClass> _listaPermisos;

        private CriterioBusqueda _criterio_de_busqueda;

        private bool errorInicio = false;
        
        public MainWindow()
        {
            InitializeComponent();



            /*** ATRIBUTOS PRIVADOS ***/
            _ventanasOrdenes = new List<OrdenEntregaWindow>();
            _ventanasBeneficiarios = new List<BeneficiarioWindow>();
            _ventanasBarrios = new List<BarrioWindow>();
            _ventanasTipoArticulos = new List<TipoArticuloWindows>();
            _ventanasArticulos = new List<ArticuloWindow>();
            _ventanasUsuarios = new List<UsuarioWindow>();
            _listaPermisos = new List<PermisoClass>();


            /*** ATRIBUTOS PUBLICOS ***/
            usuario_logueado = new UsuarioClass();

            ordenes = new List<OrdenEntregaClass>();
            ordenesIniciadas = new List<OrdenEntregaClass>();
            ordenesAutorizadas = new List<OrdenEntregaClass>();

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_ID;
            ordenSeleccionada = null;

            /*Cargar presentación*/

            PresentacionWindow presentacionWin = new PresentacionWindow();
            
            presentacionWin.Show();

            try
            {

                UsuarioClass.ListarUsuarios();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error:\n" + e.Message + "\n" + e.Data, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                errorInicio = true;

            }

            presentacionWin.Close();
            if(!errorInicio)
            {
                if (IniciarSesion())
                {
                    
                    InicializarComponentes();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar iniciar sesión. \nEl sistema se cerrará...", "Problemas al Iniciar Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }

            

            
        }

        private bool IniciarSesion()
        {
            bool r = false;

           /* usuario_logueado = UsuarioClass.BuscarUsuarioPorId(4, true);
            r = true;*/
            
            IniciarSesionWindow iniWin = new IniciarSesionWindow();
           

            iniWin.ShowDialog();
            
            if(iniWin.b_ok)
            {
                usuario_logueado = iniWin.usuario_logueado;
                r = true;
            }

            iniWin = null;

            
            return r;
        }

        private void InicializarComponentes(bool conSesionIniciada = true)
        {
            ventanaPrincipal.Title = "Processar - Módulo Asistencial - Comuna de Margarita";






            cargarPermisos(conSesionIniciada);
            deshabilitarBotonesSeleccion();

            //Combos

            //            cmbCriterioBusquedaOrden.Items.Add()

            opIdentificador.IsChecked = true;

            //Grillas
            //ordenes = OrdenEntregaClass.ListarOrdenesEntrega(true);
            ordenes = OrdenEntregaClass.ListarUltimasOrdenesEntrega(CANTIDAD_BENEFICIARIOS_A_MOSTRAR, true);
            lblOrdenesDeEntrega.Content = "Ordenes de Entrega (últimas " + CANTIDAD_BENEFICIARIOS_A_MOSTRAR + ")";

            grillaOrdenes.ItemsSource = ordenes;

            actualizarGrillasIniAut();
            
        }

        private void cargarPermisos(bool conSesionIniciada = true)
        {


            //Deshabilita todos los componentes

            foreach (RibbonTab tab in ribbonPrincipal.Items)
            {

                tab.IsEnabled = false;
                foreach (RibbonGroup grupo in tab.Items)
                {

                    foreach (var objeto in grupo.Items)
                    {
                        if (objeto.GetType() == typeof(RibbonButton))
                        {
                            ((RibbonButton)objeto).IsEnabled = false;
                        }

                    }

                }

                
            }
            //deshabilitar botones menu
            menuUsuarioCambiarContrasenia.IsEnabled = false;
            

            

            //vacia listas y grillas
            ordenes = new List<OrdenEntregaClass>();
            grillaOrdenes.ItemsSource = ordenes;
            ordenesAutorizadas = new List<OrdenEntregaClass>();
            grillaOrdenesAutorizadas.ItemsSource = ordenesAutorizadas;
            ordenesIniciadas = new List<OrdenEntregaClass>();
            grillaOrdenesIniciadas.ItemsSource = ordenesIniciadas;

            grillaOrdenes.IsEnabled = false;
            grillaOrdenesAutorizadas.IsEnabled = false;
            grillaOrdenesIniciadas.IsEnabled = false;

            if (conSesionIniciada)
            {
                //Habilitar grillas
                grillaOrdenes.IsEnabled = true;
                grillaOrdenesAutorizadas.IsEnabled = true;
                grillaOrdenesIniciadas.IsEnabled = true;

                //habilitar botones menu
                menuUsuarioCambiarContrasenia.IsEnabled = true;
                
                menuUsuarioIniciarSesion.IsEnabled = false;
                menuUsuarioCerrarSesion.IsEnabled = true;

                //habilita los componentes según el permiso
                _listaPermisos = PermisoClass.ListarPermisosPorUsuario(usuario_logueado.Id_usuario);

                foreach (PermisoClass permiso in _listaPermisos)
                {

                    string nombreBoton = permiso.Funcion.Nombre_funcion.ToString();
                    bool tienePermiso = permiso.Permitido;
                    RibbonButton boton = (RibbonButton)FindName(nombreBoton);

                    boton.IsEnabled = tienePermiso;
                }

                //Habilita los menues según el permiso
                foreach (RibbonTab tab in ribbonPrincipal.Items)
                {
                    bool menuHabilitado = PermisoClass.menuHabilitado(tab.Name, usuario_logueado.Id_usuario);
                    tab.IsEnabled = menuHabilitado;

                }
            }
            else
            {
                menuUsuarioIniciarSesion.IsEnabled = true;
                menuUsuarioCerrarSesion.IsEnabled = false;
            }
            
        }

        

        private void btnReporteEntregaBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            //Entregas por beneficiario
            ReporteEntregaBeneficiarioWindow reporteEntregaBenWin = new ReporteEntregaBeneficiarioWindow();
            reporteEntregaBenWin.Owner = this;
            reporteEntregaBenWin.Show();

        }

        private void btnAgregarOrden_Click(object sender, RoutedEventArgs e)
        {

            //Verifica que la orden no este abierta, si no esta abierta crea la ventana y la agrega a la lista

            OrdenEntregaWindow ordEntWinNueva = new OrdenEntregaWindow(OrdenEntregaWindow.Opcion.nuevo, null, ref _ventanasOrdenes, ref grillaOrdenesIniciadas, ref grillaOrdenes, ref grillaOrdenesAutorizadas);

            ordEntWinNueva.Owner = this;
            _ventanasOrdenes.Add(ordEntWinNueva);
            ordEntWinNueva.Show();

            
        }

        private void btnModificarOrden_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que la orden no este abierta, si no esta abierta crea la ventana y la agrega a la lista

            if(ordenSeleccionada != null)
            {
                OrdenEntregaWindow ordEntWinNueva = new OrdenEntregaWindow(OrdenEntregaWindow.Opcion.modificar, ordenSeleccionada, ref _ventanasOrdenes, ref grillaOrdenesIniciadas, ref grillaOrdenes, ref grillaOrdenesAutorizadas);

                ordEntWinNueva.Owner = this;
                _ventanasOrdenes.Add(ordEntWinNueva);
                ordEntWinNueva.Show();
            }
            
        }

        private void btnEliminarOrden_Click(object sender, RoutedEventArgs e)
        {
            if (ordenSeleccionada != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Seguro que desea eliminar la orden " + ordenSeleccionada.Id_orden_entrega +"?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (ordenSeleccionada.Eliminar(usuario_logueado))
                    {
                        MessageBox.Show("Se ha eliminado la orden correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        //actualizarGrillasIniAut();
                        actualizarGrillasVentanaPrincipal();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar la orden", "Eliminar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }


            
        }


        private void btnBuscarOrden_Click(object sender, RoutedEventArgs e)
        {
            BuscarOrdenes();
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

            return r;
        }


        /// <summary>
        /// Autoriza la orden para una posterior entrega, crea una nueva instancia de ordenEstado en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutorizarOrden_Click(object sender, RoutedEventArgs e)
        {
            /*OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();

            if(ordenSeleccionada != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea autorizar la orden" + ordenSeleccionada.Id_orden_entrega + "?", "Confirme autorizar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    nuevoEstado.IdOrdenEntrega = ordenSeleccionada.Id_orden_entrega;
                    nuevoEstado.Usuario = usuario_logueado;
                    nuevoEstado.Estado = EstadoOrden.Autorizado;
                    nuevoEstado.Fecha = DateTime.Now;

                    if (nuevoEstado.NuevaOrdenEstado())
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " fue autorizada con éxito!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Information);



                        actualizarGrillasIniAut();
                        habilitarBotonesSeleccion();

                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " No se puedo autorizar!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

              
            }*/
            if (ordenSeleccionada != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea autorizar la orden" + ordenSeleccionada.Id_orden_entrega + "?", "Confirme autorizar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    DateTime fecha = DateTime.Now;
                    if (ordenSeleccionada.Autorizar(MainWindow.usuario_logueado,fecha))
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " fue autorizada con éxito!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Information);

                        actualizarGrillasVentanaPrincipal();
                        //Genera comprobante  para firmar

                        frmInformeAutorizacion formulario = new frmInformeAutorizacion();

                        formulario.idOrden = ordenSeleccionada.Id_orden_entrega;
                        formulario.usuario = ordenSeleccionada.EstadoActual.Usuario.Nombre_completo;
                        formulario.fechaAutorizado = fecha.ToShortDateString();
                        formulario.horaAutorizado = fecha.ToShortTimeString();
                        formulario.nombreBeneficiario = ordenSeleccionada.Beneficiario.Nombre;
                        formulario.dniBeneficiario = ordenSeleccionada.Beneficiario.Documento;
                        formulario.descripcion = ordenSeleccionada.Descripcion;

                        formulario.ShowDialog();
                        formulario.Close();
                        formulario = null;
              

                        actualizarGrillasIniAut();
                        habilitarBotonesSeleccion();
                        grillaOrdenes.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " No se puedo autorizar!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        }

        private void actualizarGrillasIniAut()
        {

            ordenesIniciadas = OrdenEntregaClass.ListarOrdenesPorUltimoEstado(EstadoOrden.INICIADO, true);

            grillaOrdenesIniciadas.ItemsSource = ordenesIniciadas;
            ordenesAutorizadas = OrdenEntregaClass.ListarOrdenesPorUltimoEstado(EstadoOrden.AUTORIZADO, true);
            grillaOrdenesAutorizadas.ItemsSource = ordenesAutorizadas;

            

        }

        private void btnEntregarOrden_Click(object sender, RoutedEventArgs e)
        {
            /*
            OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();

            if (ordenSeleccionada != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea entregar la orden " + ordenSeleccionada.Id_orden_entrega + "?", "Confirmar entregar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    nuevoEstado.IdOrdenEntrega = ordenSeleccionada.Id_orden_entrega;
                    nuevoEstado.Usuario = MainWindow.usuario_logueado;
                    nuevoEstado.Estado = EstadoOrden.Entregado;
                    nuevoEstado.Fecha = DateTime.Now;

                    if (nuevoEstado.NuevaOrdenEstado())
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " fue entregada con éxito!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Information);
                        ordenSeleccionada.Estados.Add(nuevoEstado);

                        actualizarGrillasIniAut();
                        habilitarBotonesSeleccion();
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " No se puedo entregar!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }*/

            if (ordenSeleccionada != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea entregar la orden " + ordenSeleccionada.Id_orden_entrega + "?", "Confirmar entregar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    DateTime fecha = DateTime.Now;
                    if (ordenSeleccionada.Entregar(MainWindow.usuario_logueado, fecha))
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " fue entregada con éxito!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Information);

                        actualizarGrillasVentanaPrincipal();

                        //Genera comprobante para firmar

                        frmInformeEntrega formulario = new frmInformeEntrega();
                        frmInformeEntrega.articulo a;

                        formulario.idOrden = ordenSeleccionada.Id_orden_entrega;
                        formulario.usuario = ordenSeleccionada.EstadoActual.Usuario.Nombre_completo;
                        formulario.fechaEntregado = fecha.ToShortDateString();
                        formulario.horaEntregado = fecha.ToShortTimeString();
                        formulario.dniBeneficiario = ordenSeleccionada.Beneficiario.Documento;
                        formulario.nombreBeneficiario = ordenSeleccionada.Beneficiario.Nombre;
                        formulario.descripcion = ordenSeleccionada.Descripcion;

                       

                        List<ItemEntregaClass> items = ItemEntregaClass.ListarItemEntregaPorOrden(ordenSeleccionada.Id_orden_entrega);

                        //List<ArticuloClass> articulos = ArticuloClass.listarArticulosPorOrden(ordenSeleccionada.Id_orden_entrega);

                        foreach (ItemEntregaClass item in items)
                        {
                            a = new frmInformeEntrega.articulo();


                            a.cantidad = item.Cantidad.ToString();
                            a.descripcionArticulo = item.Articulo.Descripcion_articulo;
                            a.nombreArticulo = item.Articulo.Nombre_articulo;
                            a.tipoArticulo = item.Articulo.Tipo_articulo.Nombre_TipoArticulo;

                            formulario.datos.Add(a);
                        }

                        formulario.ShowDialog();
                        formulario.Close();
                        formulario = null;

                        actualizarGrillasIniAut();
                        habilitarBotonesSeleccion();
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " No se puedo entregar!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnCancelarOrden_Click(object sender, RoutedEventArgs e)
        {
            /*
            OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();

            
            if (ordenSeleccionada != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea cancelar la orden " + ordenSeleccionada.Id_orden_entrega + "?", "Confirmar cancelar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    nuevoEstado.IdOrdenEntrega = ordenSeleccionada.Id_orden_entrega;
                    nuevoEstado.Usuario = MainWindow.usuario_logueado;
                    nuevoEstado.Estado = EstadoOrden.Entregado;
                    nuevoEstado.Fecha = DateTime.Now;

                    if (nuevoEstado.NuevaOrdenEstado())
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " fue cancelada con éxito!", "Cancelar orden", MessageBoxButton.OK, MessageBoxImage.Information);
                        ordenSeleccionada.Estados.Add(nuevoEstado);

                        actualizarGrillasIniAut();
                        habilitarBotonesSeleccion();


                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " No se puedo cancelar!", "Cancelar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }*/
            if(ordenSeleccionada != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea cancelar la orden " + ordenSeleccionada.Id_orden_entrega + "?", "Confirmar cancelar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {

                    if (ordenSeleccionada.Cancelar(MainWindow.usuario_logueado))
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " fue cancelada con éxito!", "Cancelar orden", MessageBoxButton.OK, MessageBoxImage.Information);


                        //actualizarGrillasIniAut();
                        actualizarGrillasVentanaPrincipal();
                        habilitarBotonesSeleccion();
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenSeleccionada.Id_orden_entrega + " No se puedo cancelar!", "Cancelar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            
        }

        private void btnReporteEstadosOrden_Click(object sender, RoutedEventArgs e)
        {
            //Ordenes por estado
            ReporteEstadoOrdenWindow reporteEstadoWin = new ReporteEstadoOrdenWindow();
            reporteEstadoWin.Owner = this;
            reporteEstadoWin.Show();
            
        }

        private void btnReporteFechaOrden_Click(object sender, RoutedEventArgs e)
        {

        }
        

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que el usuario no este abierto, si no esta abierto crea la ventana y la agrega a la lista

            UsuarioWindow usuarioWin = new UsuarioWindow(UsuarioWindow.Opcion.nuevo, null, ref _ventanasUsuarios);
            usuarioWin.Owner = this;
            _ventanasUsuarios.Add(usuarioWin);
            usuarioWin.Show();
        }

        

        private void btnAdministrarUsuario_Click(object sender, RoutedEventArgs e)
        {

            AdministrarUsuarioWindow adminUsuarioWin = new AdministrarUsuarioWindow();
            adminUsuarioWin.Owner = this;
            adminUsuarioWin.Show();
            
        }


        private void grillaOrdenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            grillaOrdenesAutorizadas.SelectedItem = null;
            grillaOrdenesIniciadas.SelectedItem = null;

            if(grillaOrdenes.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.SelectedItem;

                //Habilita botones
                habilitarBotonesSeleccion();
            }
            else
            {
                deshabilitarBotonesSeleccion();
            }

                        


        }

        private void habilitarBotonesSeleccion()
        {
            /*btnModificarOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnModificarOrden.Name);
            btnEliminarOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnEliminarOrden.Name);
            btnAbrirOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnAbrirOrden.Name);

            btnAutorizarOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnAutorizarOrden.Name);
            btnCancelarOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnCancelarOrden.Name);
            btnEntregarOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnEntregarOrden.Name);
            */

            switch (ordenSeleccionada.EstadoActual.Estado)
            {
                case EstadoOrden.INICIADO:
                    btnEliminarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnEliminarOrden.Name);
                    btnAutorizarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnAutorizarOrden.Name);
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = true;
                   // btnCancelarOrden.IsEnabled = false;
                    btnModificarOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnModificarOrden.Name);
                    btnAbrirOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnAbrirOrden.Name);
                    // btnAgregarItem.IsEnabled = true;
                    break;

                case EstadoOrden.AUTORIZADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnEntregarOrden.Name);
                    btnCancelarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnCancelarOrden.Name);
                    btnModificarOrden.IsEnabled = false;
                    btnAbrirOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnAbrirOrden.Name);
                    // btnAgregarItem.IsEnabled = false;
                    break;

                case EstadoOrden.CANCELADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnModificarOrden.IsEnabled = false;
                    btnAbrirOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnAbrirOrden.Name);
                    //btnAgregarItem.IsEnabled = false;
                    break;

                case EstadoOrden.ELIMINADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnModificarOrden.IsEnabled = false;
                    btnAbrirOrden.IsEnabled = false;
                    // btnAgregarItem.IsEnabled = false;
                    break;

                case EstadoOrden.ENTREGADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnModificarOrden.IsEnabled = false;
                    btnAbrirOrden.IsEnabled = PermisoClass.TienePermiso(usuario_logueado.Id_usuario, btnAbrirOrden.Name);
                    //  btnAgregarItem.IsEnabled = false;
                    break;
            }
        }

        private void deshabilitarBotonesSeleccion()
        {
            btnModificarOrden.IsEnabled = false;
            btnEliminarOrden.IsEnabled = false;
            btnAbrirOrden.IsEnabled = false;

            btnAutorizarOrden.IsEnabled = false;
            btnCancelarOrden.IsEnabled = false;
            btnEntregarOrden.IsEnabled = false;
        }

        private void grillaOrdenesAutorizadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grillaOrdenes.SelectedItem = null;
            grillaOrdenesIniciadas.SelectedItem = null;

            if (grillaOrdenesAutorizadas.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenesAutorizadas.SelectedItem;
                //Habilita botones
                habilitarBotonesSeleccion();
            }
            else
            {
                deshabilitarBotonesSeleccion();
            }
        }

        private void grillaOrdenesIniciadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grillaOrdenes.SelectedItem = null;
            grillaOrdenesAutorizadas.SelectedItem = null;

            if (grillaOrdenesIniciadas.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenesIniciadas.SelectedItem;
                //Habilita botones
                habilitarBotonesSeleccion();
            }
            else
            {
                deshabilitarBotonesSeleccion();
            }
        }

       

        private void btnAbrirOrden_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que la orden no este abierta, si no esta abierta crea la ventana y la agrega a la lista

            if (ordenSeleccionada != null)
            {
                OrdenEntregaWindow ordEntWinNueva = new OrdenEntregaWindow(OrdenEntregaWindow.Opcion.consultar, ordenSeleccionada, ref _ventanasOrdenes, ref grillaOrdenesIniciadas, ref grillaOrdenes, ref grillaOrdenesAutorizadas);

                ordEntWinNueva.Owner = this;
                _ventanasOrdenes.Add(ordEntWinNueva);
                ordEntWinNueva.Show();
            }
        }

        private void btnNuevoBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que el beneficiario no este abierto, si no esta abierto crea la ventana y la agrega a la lista

            BeneficiarioWindow benWin = new BeneficiarioWindow(BeneficiarioWindow.Opcion.nuevo, null, ref _ventanasBeneficiarios);


            benWin.Owner = this;
            _ventanasBeneficiarios.Add(benWin); //¿ES necesario?
            benWin.Show();
        }

        private void btnNuevoArticulo_Click(object sender, RoutedEventArgs e)
        {

            //Verifica que el articulo no este abierto, si no esta abierto crea la ventana y la agrega a la lista

            ArticuloWindow articuloWin = new ArticuloWindow(ArticuloWindow.Opcion.nuevo, null, ref _ventanasArticulos);

            articuloWin.Owner = this;
            _ventanasArticulos.Add(articuloWin);
            articuloWin.Show();
            
        }

        private void btnAdministrarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            AdministrarBeneficiariosWindow adminBeneficiarioWin = new AdministrarBeneficiariosWindow();
            adminBeneficiarioWin.Owner = this;
            adminBeneficiarioWin.Show();
        }

        private void btnAdministrarArticulo_Click(object sender, RoutedEventArgs e)
        {
            AdministrarArticulosWindow adminArticulosWIn = new AdministrarArticulosWindow();
            adminArticulosWIn.Owner = this;
            adminArticulosWIn.Show();
        }

      
        private void btnAgregarBarrio_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que el barrio no este abierto, si no esta abierta crea la ventana y la agrega a la lista
            BarrioWindow barrioWin = new BarrioWindow(BarrioWindow.Opcion.nuevo, null, ref _ventanasBarrios);

            barrioWin.Owner = this;
            _ventanasBarrios.Add(barrioWin);
            barrioWin.Show();

        }

        private void btnAdministrarBarrios_Click(object sender, RoutedEventArgs e)
        {
            

            AdministrarBarriosWindow adminBarrioWin = new AdministrarBarriosWindow();

            adminBarrioWin.Owner = this;
            adminBarrioWin.Show();
            
        }

        private void opBeneficiario_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            //Habilita el txtBusqueda
            txtBusquedaOrden.Visibility = Visibility.Visible;

            //Deshabilitar fechas
            dpFechaDesde.Visibility = Visibility.Hidden;
            lblDesde.Visibility = Visibility.Hidden;
            dpFechaHasta.Visibility = Visibility.Hidden;
            lblHasta.Visibility = Visibility.Hidden;
        }

        private void opIdentificador_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_ID;
            //Habilita el txtBusqueda
            txtBusquedaOrden.Visibility = Visibility.Visible;

            //Deshabilitar fechas
            dpFechaDesde.Visibility = Visibility.Hidden;
            lblDesde.Visibility = Visibility.Hidden;
            dpFechaHasta.Visibility = Visibility.Hidden;
            lblHasta.Visibility = Visibility.Hidden;
        }

        private void opFecha_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Fecha;

            //Habilita el txtBusqueda
            txtBusquedaOrden.Visibility = Visibility.Hidden;

            //Deshabilitar fechas
            dpFechaDesde.Visibility = Visibility.Visible;
            lblDesde.Visibility = Visibility.Visible;
            dpFechaHasta.Visibility = Visibility.Visible;
            lblHasta.Visibility = Visibility.Visible;

        }

        private void btnNuevoTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que el tipo de articulo no este abierto, si no esta abierta crea la ventana y la agrega a la lista
            TipoArticuloWindows tipoArticuloWin = new TipoArticuloWindows(TipoArticuloWindows.Opcion.nuevo, null, ref _ventanasTipoArticulos);
            tipoArticuloWin.Owner = this;
            _ventanasTipoArticulos.Add(tipoArticuloWin);
            tipoArticuloWin.Show();
            
        }

        private void btnAdministrarTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            AdministrarTipoArticuloWindow adminTipoArticuloWin = new AdministrarTipoArticuloWindow();
            adminTipoArticuloWin.Owner = this;
            adminTipoArticuloWin.Show();
        }

        private void grillaOrdenes_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            grillaOrdenesAutorizadas.SelectedItem = null;
            grillaOrdenesIniciadas.SelectedItem = null;

            if (grillaOrdenes.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.SelectedItem;
            }
        }

        private void grillaOrdenesIniciadas_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            grillaOrdenes.SelectedItem = null;
            grillaOrdenesAutorizadas.SelectedItem = null;

            if (grillaOrdenesIniciadas.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenesIniciadas.SelectedItem;
            }
        }

        private void grillaOrdenesAutorizadas_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            grillaOrdenes.SelectedItem = null;
            grillaOrdenesIniciadas.SelectedItem = null;

            if (grillaOrdenesAutorizadas.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenesAutorizadas.SelectedItem;
            }
        }

        private void grillaOrdenes_GotFocus(object sender, RoutedEventArgs e)
        {
            grillaOrdenesAutorizadas.SelectedItem = null;
            grillaOrdenesIniciadas.SelectedItem = null;

            if (grillaOrdenes.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.SelectedItem;
            }
        }

        private void grillaOrdenesIniciadas_GotFocus(object sender, RoutedEventArgs e)
        {
            grillaOrdenes.SelectedItem = null;
            grillaOrdenesAutorizadas.SelectedItem = null;

            if (grillaOrdenesIniciadas.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenesIniciadas.SelectedItem;
            }
        }

        private void grillaOrdenesAutorizadas_GotFocus(object sender, RoutedEventArgs e)
        {
            grillaOrdenes.SelectedItem = null;
            grillaOrdenesIniciadas.SelectedItem = null;

            if (grillaOrdenesAutorizadas.SelectedItem != null)
            {
                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenesAutorizadas.SelectedItem;
            }
        }

        private void menuSalir_Click(object sender, RoutedEventArgs e)
        {
            if (verificarVentanasCerradas())
            {
                
               
                this.Close();
            }
            else
            {
                MessageBox.Show("No se puede salir, compruebe que todas las ventanas estén cerradas", "Salir", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            
        }

       

       

        private void menuUsuarioCambiarContrasenia_Click(object sender, RoutedEventArgs e)
        {
            CambiarContraseniaWindow camConWin = new CambiarContraseniaWindow(usuario_logueado);

            camConWin.Owner = this;
            camConWin.ShowDialog();
            camConWin = null;

        }

        private void menuUsuarioCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            if(verificarVentanasCerradas())
            {
                cargarPermisos(false);
                MessageBox.Show("Se ha cerrado la sesión del usuario " + usuario_logueado.Nombre_usuario, "Cerrar sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                usuario_logueado = null;
                
            }
            else
            {
                MessageBox.Show("No se puede cerrar sesión, compruebe que todas las ventanas estén cerradas", "Cerrar sesión", MessageBoxButton.OK, MessageBoxImage.Information);
            }
             
        }

        /// <summary>
        /// Verifica si todas las sub ventanas están cerradas
        /// </summary>
        /// <returns></returns>
        private bool verificarVentanasCerradas()
        {
            bool r = true;
            if(this.OwnedWindows.Count > 0)
            {
                r = false;
            }
            /*if(_ventanasOrdenes.Count > 0 || _ventanasBeneficiarios.Count > 0 || _ventanasBarrios.Count > 0 || _ventanasTipoArticulos.Count > 0 || _ventanasArticulos.Count > 0 || _ventanasUsuarios.Count > 0)
            {
                r = false;
            }
            */
            return r;
        }

        private void ventanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (usuario_logueado != null && usuario_logueado.Id_usuario != 0)
            {




                MessageBoxResult mr;
                mr = MessageBox.Show("¿Seguro que desea salir?", "Confirme salir", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (verificarVentanasCerradas())
                    {

                        usuario_logueado = null;

                    }
                    else
                    {
                        MessageBox.Show("No se puede salir, compruebe que todas las ventanas estén cerradas", "Salir", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (usuario_logueado != null && usuario_logueado.Id_usuario != 0)
                        {
                            e.Cancel = true;
                        }



                    }
                }
                else
                {

                    if (usuario_logueado != null && usuario_logueado.Id_usuario != 0)
                    {
                        e.Cancel = true;
                    }
                }
           }
            
        }

 

        private void menuUsuarioIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (IniciarSesion())
            {
                MessageBox.Show("Ha iniciado sesión con el usuario: " + usuario_logueado.Nombre_usuario, "Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                InicializarComponentes();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al intentar iniciar sesión", "Problemas al Iniciar Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }


        private void actualizarGrillasVentanaPrincipal()
        {
            //MainWindow.ordenes = OrdenEntregaClass.ListarOrdenesEntrega(true);
            //grillaOrdenes.ItemsSource = MainWindow.ordenes;

            MainWindow.ordenes = OrdenEntregaClass.ListarUltimasOrdenesEntrega(MainWindow.CANTIDAD_BENEFICIARIOS_A_MOSTRAR, true);
            grillaOrdenes.ItemsSource = MainWindow.ordenes;
            grillaOrdenes.Items.Refresh();

            MainWindow.ordenesIniciadas = OrdenEntregaClass.ListarOrdenesPorUltimoEstado(EstadoOrden.INICIADO, true);
            grillaOrdenesIniciadas.ItemsSource = MainWindow.ordenesIniciadas;
            grillaOrdenesIniciadas.Items.Refresh();

            MainWindow.ordenesAutorizadas = OrdenEntregaClass.ListarOrdenesPorUltimoEstado(EstadoOrden.AUTORIZADO, true);
            grillaOrdenesAutorizadas.ItemsSource = MainWindow.ordenesAutorizadas;
            grillaOrdenesIniciadas.Items.Refresh();
        }

        private void txtBusquedaOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarOrdenes();
            }
        }

        private void ventanaPrincipal_Initialized(object sender, EventArgs e)
        {
            btnAgregarOrden.TabIndex = 0;
            btnModificarOrden.TabIndex = 1;
            btnEliminarOrden.TabIndex = 2;
            opIdentificador.TabIndex = 3;
            opBeneficiario.TabIndex = 4;
            opFecha.TabIndex = 5;
            txtBusquedaOrden.TabIndex = 6;
            btnBuscarOrden.TabIndex = 7;
            btnAbrirOrden.TabIndex = 8;
            btnAutorizarOrden.TabIndex = 9;
            btnEntregarOrden.TabIndex = 10;
            btnCancelarOrden.TabIndex = 11;
            btnReporteEstadosOrden.TabIndex = 12;
            tabBeneficiarios.TabIndex = 13;
            btnNuevoBeneficiario.TabIndex = 14;
            btnAdministrarBeneficiario.TabIndex = 15;
            btnReporteEntregaBeneficiario.TabIndex = 16;
            tabArticulos.TabIndex = 17;
            btnNuevoArticulo.TabIndex = 18;
            btnAdministrarArticulo.TabIndex = 19;
            tabOtros.TabIndex = 20;
            btnNuevoTipoArticulo.TabIndex = 21;
            btnAdministrarTipoArticulo.TabIndex = 22;
            btnAgregarBarrio.TabIndex = 23;
            btnAdministrarBarrios.TabIndex = 24;
            tabAvanzado.TabIndex = 25;
            btnAgregarUsuario.TabIndex = 26;
            btnAdministrarUsuario.TabIndex = 27;
            tabOrdenesEntrega.TabIndex = 28;
        }

        private void BuscarOrdenes()
        {
            bool todo_ok = false;

            ordenes = new List<OrdenEntregaClass>();

            grillaOrdenes.ItemsSource = ordenes;



            string ordenBuscar = txtBusquedaOrden.Text.ToString().Trim();
            if (txtBusquedaOrden.Text.Length == 0 && _criterio_de_busqueda != CriterioBusqueda.Fecha)
            {

                ordenes = OrdenEntregaClass.ListarOrdenesEntrega();
                grillaOrdenes.ItemsSource = ordenes;


                if (ordenes.Count == 0)
                {
                    ordenSeleccionada = null;

                    deshabilitarBotonesSeleccion();

                    MessageBox.Show("No se encuentran ordenes con esos criterios de busqueda", "No se encuentran ordenes", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaOrdenes.ItemsSource = ordenes;

                }
                else
                {

                    grillaOrdenes.SelectedItem = grillaOrdenes.Items[0];
                    ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.Items[0];

                    habilitarBotonesSeleccion();
                    grillaOrdenes.Items.Refresh();
                }
            }
            else
            {

                switch (_criterio_de_busqueda)
                {
                    case CriterioBusqueda.Busqueda_ID:

                        if (ValidacionesClass.ValidarNumericoTextBox(txtBusquedaOrden))
                        {
                            todo_ok = true;
                        }
                        else
                        {
                            todo_ok = false;
                        }
                        if (todo_ok)
                        {
                            long idOrden = 0;

                            long.TryParse(txtBusquedaOrden.Text.ToString(), out idOrden);
                            OrdenEntregaClass ordenBuscada = OrdenEntregaClass.BuscarOrdenEntregaPorId(idOrden, true);


                            if (ordenBuscada != null)
                            {
                                ordenes.Add(ordenBuscada);
                                grillaOrdenes.ItemsSource = ordenes;

                            }

                            if (ordenes.Count == 0)
                            {
                                deshabilitarBotonesSeleccion();

                                MessageBox.Show("No se encuentran ordenes con esos criterios de busqueda", "No se encuentran ordenes", MessageBoxButton.OK, MessageBoxImage.Warning);

                                grillaOrdenes.Items.Refresh();

                            }
                            else
                            {
                                grillaOrdenes.SelectedItem = grillaOrdenes.Items[0];
                                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.Items[0];

                                habilitarBotonesSeleccion();
                                grillaOrdenes.Items.Refresh();
                            }
                        }


                        break;

                    case CriterioBusqueda.Busqueda_Nombre:

                        if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaOrden))
                        {

                            todo_ok = true;

                        }
                        else
                        {
                            todo_ok = false;
                        }
                        if (todo_ok)
                        {


                            ordenes = OrdenEntregaClass.ListarOrdenesPorNombreBeneficiario(txtBusquedaOrden.Text.ToString(), true);
                            grillaOrdenes.ItemsSource = ordenes;


                            if (ordenes.Count == 0)
                            {

                                deshabilitarBotonesSeleccion();

                                MessageBox.Show("No se encuentran ordenes con esos criterios de busqueda", "No se encuentran ordenes", MessageBoxButton.OK, MessageBoxImage.Warning);

                                grillaOrdenes.Items.Refresh();

                            }
                            else
                            {
                                grillaOrdenes.SelectedItem = grillaOrdenes.Items[0];
                                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.Items[0];
                                habilitarBotonesSeleccion();
                                grillaOrdenes.Items.Refresh();
                            }
                        }


                        break;

                    case CriterioBusqueda.Fecha:
                        if (validarFechas())
                        {

                            todo_ok = true;

                        }
                        else
                        {
                            todo_ok = false;
                        }
                        if (todo_ok)
                        {

                            DateTime fechaDesde = (DateTime)dpFechaDesde.SelectedDate;
                            DateTime fechaHasta = (DateTime)dpFechaHasta.SelectedDate;

                            DateTime fechaD = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, 0, 0, 0);
                            DateTime fechaH = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);
                            ordenes = OrdenEntregaClass.ListarOrdenesPorFecha(fechaD, fechaH, true);
                            grillaOrdenes.ItemsSource = ordenes;


                            if (ordenes.Count == 0)
                            {

                                deshabilitarBotonesSeleccion();

                                MessageBox.Show("No se encuentran ordenes con esos criterios de busqueda", "No se encuentran ordenes", MessageBoxButton.OK, MessageBoxImage.Warning);

                                grillaOrdenes.Items.Refresh();

                            }
                            else
                            {
                                grillaOrdenes.SelectedItem = grillaOrdenes.Items[0];
                                ordenSeleccionada = (OrdenEntregaClass)grillaOrdenes.Items[0];
                                habilitarBotonesSeleccion();
                                grillaOrdenes.Items.Refresh();
                            }
                        }

                        break;


                }


            }

            lblOrdenesDeEntrega.Content = "Ordenes de entrega";

        }
    }
}
