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
    /// Lógica de interacción para OrdenEntregaWindow.xaml
    /// </summary>
    public partial class OrdenEntregaWindow : Window
    {
        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public OrdenEntregaClass ordenEntrega;
        public bool b_ok = false;
        private List<OrdenEntregaWindow> _ventanas;
        private List<ItemEntregaClass> _items;
        private BeneficiarioClass _beneficiario;
        private List<ArticuloClass> _articulos;
        private ItemEntregaClass _itemSeleccionado;
        

        private DataGrid grillaOrdenesIniciadas;
        private DataGrid grillaOrdenes;
        private DataGrid grillaOrdenesAutorizadas;

        private bool modifico = false;
        

        public OrdenEntregaWindow(Opcion op, OrdenEntregaClass ordenE, ref List<OrdenEntregaWindow> ventanasAbiertas, ref DataGrid grillaIniciadas, ref DataGrid grilla, ref DataGrid grillaAutorizadas)
        { 
            InitializeComponent();

            if(op != Opcion.nuevo)
            {
                //ordenEntrega = OrdenEntregaClass.BuscarOrdenEntregaPorId(ordenE.Id_orden_entrega, true);
                ordenEntrega = ordenE;
            }

            _ventanas = ventanasAbiertas;
            _items = new List<ItemEntregaClass>();
            _beneficiario = null;

            grillaOrdenesIniciadas = grillaIniciadas;
            grillaOrdenes = grilla;

           

            grillaOrdenesAutorizadas = grillaAutorizadas;
            grillaItemsEntrega.ItemsSource = _items;

            //Carga de articulos
            _articulos = ArticuloClass.ListarArticulos();
            cmbArticulos.ItemsSource = _articulos;

            _itemSeleccionado = null;
            opcion = op;

                     

            //Inicializar componentes de la pantalla
            switch (op)
            {
                case Opcion.nuevo:
                    this.InicializarComponentesNuevo();
                    this.CargarDatosNuevo();
                    break;

                case Opcion.modificar:
                    this.InicializarComponentesModificar();
                    this.CargarDatosModificar();
                    break;

                case Opcion.consultar:
                    this.InicializarComponentesConsultar();
                    this.CargarDatosConsultar();
                    break;

            }

           
             grillaItemsEntrega.ItemsSource = _items;
        

        }

        private void InicializarComponentesNuevo()
        {
            //Labels y txtBoxes
            lblIdOrden.Visibility = Visibility.Hidden;
            txtIdOrden.Visibility = Visibility.Hidden;

            txtIdOrden.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;
            txtFecha.IsReadOnly = true;
            txtUsuarioCrea.IsReadOnly = true;

            lblEstadoAct.Visibility = Visibility.Hidden;
            txtEstadoActual.Visibility = Visibility.Hidden;
            txtEstadoActual.IsReadOnly = true;
            txtFechaEstado.Visibility = Visibility.Hidden;
            txtFechaEstado.IsReadOnly = true;
            lblEl.Visibility = Visibility.Hidden;
            
            lblUsuarioModif.Visibility = Visibility.Hidden;
            txtUsuarioModifica.Visibility = Visibility.Hidden;
            txtUsuarioModifica.IsReadOnly = true;

            txtCantidad.IsEnabled = true;
            

            //Datos beneficiario
            txtNombre.IsReadOnly = true;
            txtDocumento.IsReadOnly = true;
            txtDireccion.IsReadOnly = true;
            txtBarrio.IsReadOnly = true;
            txtLocalidad.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;

            //Botones
           
            btnEliminarOrden.IsEnabled = false;

            btnAutorizarOrden.IsEnabled = false;
            btnEntregarOrden.IsEnabled = false;
            btnCancelarOrden.IsEnabled = false;
            btnGuardarOrden.Label = "Crear";
            btnAgregarBeneficiario.IsEnabled = true;
            btnImprimirOrden.IsEnabled = false;
            btnImprimirAutorizacion.IsEnabled = false;
            btnImprimirEntrega.IsEnabled = false;
            //btnAgregarItem.IsEnabled = true;
        }

        private void InicializarComponentesModificar()
        {
            //Labels y txtBoxes
            lblIdOrden.Visibility = Visibility.Visible;
            txtIdOrden.Visibility = Visibility.Visible;

            txtIdOrden.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;
            txtFecha.IsReadOnly = true;
            txtUsuarioCrea.IsReadOnly = true;

            lblEstadoAct.Visibility = Visibility.Visible;
            txtEstadoActual.Visibility = Visibility.Visible;
            txtEstadoActual.IsReadOnly = true;
            txtFechaEstado.Visibility = Visibility.Visible;
            txtFechaEstado.IsReadOnly = true;
            lblEl.Visibility = Visibility.Visible;

            lblUsuarioModif.Visibility = Visibility.Visible;
            txtUsuarioModifica.Visibility = Visibility.Visible;
            txtUsuarioModifica.IsReadOnly = true;

            txtCantidad.IsEnabled = true;

            //Datos beneficiario
            txtNombre.IsReadOnly = true;
            txtDocumento.IsReadOnly = true;
            txtDireccion.IsReadOnly = true;
            txtBarrio.IsReadOnly = true;
            txtLocalidad.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;

            //Botones
            btnGuardarOrden.Label = "Guardar";

            switch (ordenEntrega.EstadoActual.Estado)
            {
                case EstadoOrden.INICIADO:
                    btnEliminarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnEliminarOrden.Name);
                    btnAutorizarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnAutorizarOrden.Name);
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = false;
                    btnImprimirEntrega.IsEnabled = false;
                    // btnAgregarItem.IsEnabled = true;
                    break;

                case EstadoOrden.AUTORIZADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnEntregarOrden.Name);
                    btnCancelarOrden.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnCancelarOrden.Name);
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = true;
                    btnImprimirEntrega.IsEnabled = false;
                    // btnAgregarItem.IsEnabled = false;
                    break;

                case EstadoOrden.CANCELADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = false;
                    btnImprimirEntrega.IsEnabled = false;
                    //btnAgregarItem.IsEnabled = false;
                    break;

                case EstadoOrden.ELIMINADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnImprimirOrden.IsEnabled = false;
                    btnImprimirAutorizacion.IsEnabled = false;
                    btnImprimirEntrega.IsEnabled = false;
                    // btnAgregarItem.IsEnabled = false;
                    break;

                case EstadoOrden.ENTREGADO:
                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = true;
                    btnImprimirEntrega.IsEnabled = true;
                    //  btnAgregarItem.IsEnabled = false;
                    break;
            }

         
            btnAgregarBeneficiario.IsEnabled = false;

            
        }
        private void InicializarComponentesConsultar()
        {
            //Labels y txtBoxes
            lblIdOrden.Visibility = Visibility.Visible;
            txtIdOrden.Visibility = Visibility.Visible;

            txtIdOrden.IsReadOnly = true;
            txtDescripcion.IsReadOnly = true;
            txtFecha.IsReadOnly = true;
            txtUsuarioCrea.IsReadOnly = true;

            lblEstadoAct.Visibility = Visibility.Visible;
            txtEstadoActual.Visibility = Visibility.Visible;
            txtEstadoActual.IsReadOnly = true;
            txtFechaEstado.Visibility = Visibility.Visible;
            txtFechaEstado.IsReadOnly = true;
            lblEl.Visibility = Visibility.Visible;
            lblUsuarioModif.Visibility = Visibility.Visible;
            txtUsuarioModifica.Visibility = Visibility.Visible;
            
            txtUsuarioModifica.IsReadOnly = true;

            txtCantidad.IsEnabled = false;

            //Datos beneficiario
            txtNombre.IsReadOnly = true;
            txtDocumento.IsReadOnly = true;
            txtDireccion.IsReadOnly = true;
            txtBarrio.IsReadOnly = true;
            txtLocalidad.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;

            //Botones

                    btnEliminarOrden.IsEnabled = false;
                    btnAutorizarOrden.IsEnabled = false;
                    btnEntregarOrden.IsEnabled = false;
                    btnCancelarOrden.IsEnabled = false;
            btnGuardarOrden.Label = "Guardar";
            //  btnAgregarItem.IsEnabled = false;



            btnAgregarBeneficiario.IsEnabled = false;


            switch (ordenEntrega.EstadoActual.Estado)
            {
                case EstadoOrden.INICIADO:
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = false;
                    btnImprimirEntrega.IsEnabled = false;
                   
                    break;

                case EstadoOrden.AUTORIZADO:
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = true;
                    btnImprimirEntrega.IsEnabled = false;
                
                    break;

                case EstadoOrden.CANCELADO:
            
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = false;
                    btnImprimirEntrega.IsEnabled = false;
           
                    break;

                case EstadoOrden.ELIMINADO:
            
                    btnImprimirOrden.IsEnabled = false;
                    btnImprimirAutorizacion.IsEnabled = false;
                    btnImprimirEntrega.IsEnabled = false;
           
                    break;

                case EstadoOrden.ENTREGADO:
                  
                    btnImprimirOrden.IsEnabled = true;
                    btnImprimirAutorizacion.IsEnabled = true;
                    btnImprimirEntrega.IsEnabled = true;
                    break;
            }
        }

        private void CargarDatosNuevo()
        {
            // DateTime fechaActual = DateTime.Today.Date;
            DateTime fechaActual = DateTime.Now;
            txtFecha.Text = fechaActual.ToString();
            txtUsuarioCrea.Text = MainWindow.usuario_logueado.Nombre_completo;
            txtUsuarioModifica.Text = MainWindow.usuario_logueado.Nombre_completo;
            txtCantidad.Text = "0";


            //combo articulos
            cmbArticulos.Items.Refresh();
            
            
        }

        private void CargarDatosModificar()
        {

            txtIdOrden.Text = ordenEntrega.Id_orden_entrega.ToString();
            txtDescripcion.Text = ordenEntrega.Descripcion.ToString();
            txtFecha.Text = ordenEntrega.Fecha.Date.ToString();
            txtEstadoActual.Text = ordenEntrega.EstadoActual.Estado.ToString();
            txtFechaEstado.Text = ordenEntrega.EstadoActual.Fecha.ToString();
            txtUsuarioCrea.Text = ordenEntrega.UsuarioCreador.Nombre_completo;
            txtUsuarioModifica.Text = ordenEntrega.UltimoUsuario.Nombre_completo;

            txtCantidad.Text = "0";

            _items = ordenEntrega.Items_entrega;
            grillaItemsEntrega.ItemsSource = _items;

            //Beneficiario
            txtNombre.Text = ordenEntrega.Beneficiario.Nombre.ToString();
            txtDocumento.Text = ordenEntrega.Beneficiario.Documento.ToString();
            txtDireccion.Text = ordenEntrega.Beneficiario.Direccion.ToString();
            txtBarrio.Text = ordenEntrega.Beneficiario.Barrio.Nombre.ToString();
            txtLocalidad.Text = ordenEntrega.Beneficiario.Barrio.Ciudad.ToString();
            txtTelefono.Text = ordenEntrega.Beneficiario.Telefono.ToString();
        }

        private void CargarDatosConsultar()
        {
            
            txtFecha.Text = ordenEntrega.Fecha.ToString();
            
            txtUsuarioCrea.Text = ordenEntrega.UsuarioCreador.Nombre_completo;
            txtUsuarioModifica.Text = ordenEntrega.UltimoUsuario.Nombre_completo;

            txtIdOrden.Text = ordenEntrega.Id_orden_entrega.ToString();
            txtDescripcion.Text = ordenEntrega.Descripcion.ToString();
            //txtFecha.Text = ordenEntrega.Fecha.Date.ToString();
            txtEstadoActual.Text = ordenEntrega.EstadoActual.Estado.ToString();
            txtFechaEstado.Text = ordenEntrega.EstadoActual.Fecha.ToString();
            txtUsuarioCrea.Text = ordenEntrega.UsuarioCreador.Nombre_completo;
            txtUsuarioModifica.Text = ordenEntrega.UltimoUsuario.Nombre_completo;

            txtCantidad.Text = "0";

            _items = ordenEntrega.Items_entrega;
            grillaItemsEntrega.ItemsSource = _items;

            //Beneficiario
            txtNombre.Text = ordenEntrega.Beneficiario.Nombre.ToString();
            txtDocumento.Text = ordenEntrega.Beneficiario.Documento.ToString();
            txtDireccion.Text = ordenEntrega.Beneficiario.Direccion.ToString();
            txtBarrio.Text = ordenEntrega.Beneficiario.Barrio.Nombre.ToString();
            txtLocalidad.Text = ordenEntrega.Beneficiario.Barrio.Ciudad.ToString();
            txtTelefono.Text = ordenEntrega.Beneficiario.Telefono.ToString();
            
        }

        
        private void Window_Initialized(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
            
            txtDescripcion.TabIndex = 1;
            txtFecha.TabIndex = 2;
            txtUsuarioCrea.TabIndex = 3;
            txtEstadoActual.TabIndex = 4;
            txtFechaEstado.TabIndex = 5;
            txtUsuarioModifica.TabIndex = 6;
            cmbArticulos.TabIndex = 7;
            btnBuscarArticulo.TabIndex = 8;
            txtCantidad.TabIndex = 9;
            btnAgregarArticulo.TabIndex = 10;
            btnQuitarArticulo.TabIndex = 11;
        
            btnEliminarOrden.TabIndex = 12;
            btnAutorizarOrden.TabIndex = 13;
            btnEntregarOrden.TabIndex = 14;
            btnCancelarOrden.TabIndex = 15;
            btnAgregarBeneficiario.TabIndex = 16;
            btnGuardarOrden.TabIndex = 17;
            btnCancelarOrden.TabIndex = 18;
      


        }

      
        private void btnEliminarOrden_Click(object sender, RoutedEventArgs e)
        {
            if (ordenEntrega != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Seguro que desea eliminar la orden " + ordenEntrega.Id_orden_entrega + "?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (ordenEntrega.Eliminar(MainWindow.usuario_logueado))
                    {
                        MessageBox.Show("Se ha eliminado la orden correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        this.Owner.Focus();
                        ordenEntrega = null;
                        actualizarGrillasVentanaPrincipal();

                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar la orden", "Eliminar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            
        }

        private void btnAutorizarOrden_Click(object sender, RoutedEventArgs e)
        {

            /*OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();

            if (ordenEntrega != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea autorizar la orden" + ordenEntrega.Id_orden_entrega + "?", "Confirme autorizar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    nuevoEstado.IdOrdenEntrega = ordenEntrega.Id_orden_entrega;
                    nuevoEstado.Usuario = MainWindow.usuario_logueado;
                    nuevoEstado.Estado = EstadoOrden.Autorizado;
                    nuevoEstado.Fecha = DateTime.Now;

                    if (nuevoEstado.NuevaOrdenEstado())
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " fue autorizada con éxito!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Information);
                        ordenEntrega.Estados.Add(nuevoEstado);
                        
                        actualizarGrillasVentanaPrincipal();
                        InicializarComponentesModificar();
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " No se puedo autorizar!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                

            }
            */
            if (opcion == Opcion.modificar)
            {
                if (modifico)
                {
                    MessageBoxResult msg2;
                    msg2 = MessageBox.Show("¿Desea guardar los cambios?", "Confirme guardar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (msg2 == MessageBoxResult.Yes)
                    {

                        guardar();
                    }
                }

                if (ordenEntrega != null)
                {
                    MessageBoxResult msg;
                    msg = MessageBox.Show("¿Seguro que desea autorizar la orden" + ordenEntrega.Id_orden_entrega + "?", "Confirme autorizar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (msg == MessageBoxResult.Yes)
                    {
                        DateTime fecha = DateTime.Now;
                        if (ordenEntrega.Autorizar(MainWindow.usuario_logueado, fecha))
                        {
                            MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " fue autorizada con éxito!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Information);

                            //Actualiza la grilla
                            actualizarGrillasVentanaPrincipal();



                            //Genera comprobante  para firmar

                            frmInformeAutorizacion formulario = new frmInformeAutorizacion();

                            formulario.idOrden = ordenEntrega.Id_orden_entrega;
                            formulario.usuario = ordenEntrega.EstadoActual.Usuario.Nombre_completo;
                            formulario.fechaAutorizado = fecha.ToShortDateString();
                            formulario.horaAutorizado = fecha.ToShortTimeString();
                            formulario.nombreBeneficiario = ordenEntrega.Beneficiario.Nombre;
                            formulario.dniBeneficiario = ordenEntrega.Beneficiario.Documento;
                            formulario.descripcion = ordenEntrega.Descripcion;

                            formulario.ShowDialog();
                            formulario.Close();
                            formulario = null;


                            actualizarGrillasVentanaPrincipal();
                            InicializarComponentesModificar();
                        }
                        else
                        {
                            MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " No se puedo autorizar!", "Autorizar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            
                
        }

        private void btnEntregarOrden_Click(object sender, RoutedEventArgs e)
        {/*
            OrdenEstadoClass nuevoEstado = new OrdenEstadoClass();

            if (ordenEntrega != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea entregar la orden " + ordenEntrega.Id_orden_entrega + "?", "Confirmar entregar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    nuevoEstado.IdOrdenEntrega = ordenEntrega.Id_orden_entrega;
                    nuevoEstado.Usuario = MainWindow.usuario_logueado;
                    nuevoEstado.Estado = EstadoOrden.Entregado;
                    nuevoEstado.Fecha = DateTime.Now;

                    if (nuevoEstado.NuevaOrdenEstado())
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " fue entregada con éxito!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Information);
                        ordenEntrega.Estados.Add(nuevoEstado);

                        actualizarGrillasVentanaPrincipal();
                        InicializarComponentesModificar();
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " No se puedo entregar!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }*/
            if (ordenEntrega != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea entregar la orden " + ordenEntrega.Id_orden_entrega + "?", "Confirmar entregar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {

                    DateTime fecha = new DateTime();

                    if (ordenEntrega.Entregar(MainWindow.usuario_logueado, fecha))
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " fue entregada con éxito!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Information);

                        //Genera comprobante para firmar

                        frmInformeEntrega formulario = new frmInformeEntrega();

                        formulario.idOrden = ordenEntrega.Id_orden_entrega;
                        formulario.usuario = ordenEntrega.EstadoActual.Usuario.Nombre_completo;
                        formulario.fechaEntregado = fecha.ToShortDateString();
                        formulario.horaEntregado = fecha.ToShortTimeString();
                        formulario.dniBeneficiario = ordenEntrega.Beneficiario.Documento;
                        formulario.nombreBeneficiario = ordenEntrega.Beneficiario.Nombre;
                        formulario.descripcion = ordenEntrega.Descripcion;

                        formulario.ShowDialog();
                        formulario.Close();
                        formulario = null;


                        actualizarGrillasVentanaPrincipal();
                        InicializarComponentesModificar();
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " No se puedo entregar!", "Entregar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            }

        private void btnCancelarOrden_Click(object sender, RoutedEventArgs e)
        {

            if (ordenEntrega != null)
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea cancelar la orden " + ordenEntrega.Id_orden_entrega + "?", "Confirmar cancelar orden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {

                    if (ordenEntrega.Cancelar(MainWindow.usuario_logueado))
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " fue cancelada con éxito!", "Cancelar orden", MessageBoxButton.OK, MessageBoxImage.Information);


                        actualizarGrillasVentanaPrincipal();
                        InicializarComponentesModificar();
                        this.Close();
                        this.Owner.Focus();
                        ordenEntrega = null;
                    }
                    else
                    {
                        MessageBox.Show("La orden " + ordenEntrega.Id_orden_entrega + " No se puedo cancelar!", "Cancelar orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        
           
        }

        private void btnAgregarBeneficiario_Click(object sender, RoutedEventArgs e)
        {

            /*AdministrarBeneficiariosWindow adminBenWin = new AdministrarBeneficiariosWindow(true);
            adminBenWin.Owner = this;
            adminBenWin.ShowDialog();

            _beneficiario = adminBenWin.beneficiarioSeleccionado;
            
            adminBenWin = null;
            */

            BuscarBeneficiarioWindow buscarBenWin = new BuscarBeneficiarioWindow();
            
            buscarBenWin.Owner = this;
            buscarBenWin.ShowDialog();
            if(buscarBenWin.b_ok)
            {
                _beneficiario = buscarBenWin.beneficiarioSeleccionado;
                txtNombre.Text = _beneficiario.Nombre.ToString();
                txtDocumento.Text = _beneficiario.Documento.ToString();
                txtDireccion.Text = _beneficiario.Direccion.ToString();
                txtBarrio.Text = _beneficiario.Barrio.Nombre.ToString();
                txtLocalidad.Text = _beneficiario.Barrio.Ciudad.ToString();
                txtTelefono.Text = _beneficiario.Telefono.ToString();
                modifico = true;

            }

            buscarBenWin = null;

            

        }

        

        private void grillaItemsEntrega_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _itemSeleccionado = (ItemEntregaClass)grillaItemsEntrega.SelectedItem;
        }

        private void btnAbrirItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuitarItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardarOrden_Click(object sender, RoutedEventArgs e)
        {
            guardar();
        }


        private void guardar()
        {
            if (Validar())
            {
                if (opcion == Opcion.nuevo)
                {


                    OrdenEntregaClass nuevaOrden = new OrdenEntregaClass();
                    nuevaOrden.Beneficiario = _beneficiario;
                    nuevaOrden.Descripcion = txtDescripcion.Text.ToString();
                    DateTime fecha;
                    string stringFecha = txtFecha.Text.ToString();
                    if (DateTime.TryParse(stringFecha, out fecha))
                    {
                        nuevaOrden.Fecha = fecha;
                    }
                    nuevaOrden.Items_entrega = _items;
                    // UsuarioClass ultimoUsuario = UsuarioClass.BuscarUsuarioPorNombre(MainWindow.usuario_logueado.Nombre_usuario);
                    // nuevaOrden.UltimoUsuario = ultimoUsuario;

                    UsuarioClass usuarioCrea = UsuarioClass.BuscarUsuarioPorNombre(MainWindow.usuario_logueado.Nombre_usuario);
                    nuevaOrden.UsuarioCreador = usuarioCrea;

                    MessageBoxResult msg2;
                    msg2 = MessageBox.Show("¿Seguro que desea crear la Orden de entrega ?", "Confirme crear Orden de entrega", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (msg2 == MessageBoxResult.Yes)
                    {
                        if (nuevaOrden.NuevaOrdenEntrega(_beneficiario.Id_beneficiario))
                        {
                            MessageBox.Show("Orden de entrega " + nuevaOrden.Id_orden_entrega + " creada con éxito", "Crear Orden de Entrega", MessageBoxButton.OK, MessageBoxImage.Information);
                            b_ok = true;
                            ordenEntrega = nuevaOrden;
                            // IMprimo la orden
                            imprimirOrden();
                            actualizarGrillasVentanaPrincipal();
                            this.Close();
                            this.Owner.Focus();

                           

                        }
                        else
                        {
                            MessageBox.Show("La Orden de Entrega no se pudo crear", "Crear Orden de Entrega", MessageBoxButton.OK, MessageBoxImage.Error);
                            b_ok = false;
                        }
                    }

                   
                }
                else
                { //Solo se va a poder modificar si la Orden esta Iniciada
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar la Orden de entrega " + ordenEntrega.Id_orden_entrega + "?", "Confirme modificar Orden de entrega", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                                if(_beneficiario != null)
                            {
                                ordenEntrega.Beneficiario = _beneficiario;
                            }
                            
                            ordenEntrega.Descripcion = txtDescripcion.Text.ToString();
                            /* DateTime fecha;
                             if (DateTime.TryParse(txtFecha.ToString(), out fecha))
                             {
                                 nuevaOrden.Fecha = fecha;
                             }*/
                            ordenEntrega.Items_entrega = _items;

                            // UsuarioClass ultimoUsuario = UsuarioClass.BuscarUsuarioPorNombre(txtUsuarioModifica.Text.ToString());
                            // nuevaOrden.UltimoUsuario = ultimoUsuario;

                            //UsuarioClass usuarioCrea = UsuarioClass.BuscarUsuarioPorNombre(txtUsuarioCrea.Text.ToString());
                            //nuevaOrden.UsuarioCreador = usuarioCrea;

                            if (ordenEntrega.ModificarOrdenEntrega())
                            {
                                MessageBox.Show("Orden Entrega " + ordenEntrega.Id_orden_entrega + " modificada con éxito", "Modificar Orden Entrega", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;

                                //Actualiza Grilla de ventana principal

                                actualizarGrillasVentanaPrincipal();

                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("La orden de entrega " + ordenEntrega.Id_orden_entrega + " no se pudo modificar", "Modificar Orden Entrega", MessageBoxButton.OK, MessageBoxImage.Error);
                                b_ok = false;
                            }
                        }

                    }
                }

            }
            else
            {
                MessageBox.Show("Hay Errores en la ventana. Corregir antes de continuar", "Existen Errores", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private bool Validar()
        {
            bool r = true;

            foreach (TextBox t in FindVisualChildren<TextBox>(this))
            {

                //MessageBox.Show(t.ToString(),t.Name);

                if (t.Name != "txtMal" && t.Name != "txtBien")
                {

                    t.Background = txtBien.Background;
                    t.ToolTip = "";

                }
            }


            //validar txtDocumento. Si no hay documento no hay beneficiario seleccionado

            if (ValidacionesClass.ValidarNumericoTextBox(txtDocumento))
            {
                txtDocumento.Background = txtBien.Background;
                txtDocumento.ToolTip = "";

            }
            else
            {
                r = false;
               txtDocumento.Background = txtMal.Background;
                
                txtDocumento.ToolTip = "No es correcto";
            }


            //valida el txtDescripción
                if (txtDescripcion.Text == "")
                {
                txtDescripcion.Background = txtMal.Background;
                txtDescripcion.ToolTip = "No puede quedar vacío";
                    r = false;
                }
             
            
                //valida que haya elementos en la grilla
                if(grillaItemsEntrega.Items.Count == 0)
                {
                r = false;
                MessageBox.Show("Faltan items en la orden. Corrija esto para poder continuar", "Existen Errores", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }



            return r;

        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        private void Blanquear()
        {

            foreach (TextBox r in FindVisualChildren<TextBox>(this))
            {
                if (r.Name != "txtMal" && r.Name != "txtBien")
                {
                    r.Background = txtBien.Background;
                    r.ToolTip = "";
                }



            }
        }

        private void btnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            ordenEntrega = null;
            this.Close();
            this.Owner.Focus();
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void btnAgregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            ArticuloClass nuevoArticulo = null;
            nuevoArticulo = (ArticuloClass)cmbArticulos.SelectedItem;

            
            if(nuevoArticulo != null)
            {
                string cant = txtCantidad.Text.ToString();
                float cantidad = 0;
                if (float.TryParse(cant, out cantidad))
                {
                    ItemEntregaClass nuevoItem = new ItemEntregaClass();

                    nuevoItem.Articulo = nuevoArticulo;
                    nuevoItem.Cantidad = cantidad;

                    if (nuevoItem.Cantidad > 0)
                    {
                        _items.Add(nuevoItem);
                        grillaItemsEntrega.ItemsSource = _items;

                        grillaItemsEntrega.Items.Refresh();

                        modifico = true;
                    }


                }

                txtCantidad.Text = "0";
            }
            
        }

        private void btnQuitarArticulo_Click(object sender, RoutedEventArgs e)
        {
            
            if(_itemSeleccionado != null)
            {
                _items.Remove(_itemSeleccionado);

                grillaItemsEntrega.ItemsSource = _items;

                grillaItemsEntrega.Items.Refresh();
                modifico = true;
            }
        }

        private void btnBuscarArticulo_Click(object sender, RoutedEventArgs e)
        {
            BuscarArticuloWindow buscarArticuloWin = new BuscarArticuloWindow();

            buscarArticuloWin.Owner = this;

            buscarArticuloWin.ShowDialog();

            if(buscarArticuloWin.b_ok && buscarArticuloWin.articuloSeleccionado.Id_articulo != 0)
            {
                if(buscarArticuloWin.es_agregado)
                {
                    _articulos = ArticuloClass.ListarArticulos();
                    cmbArticulos.ItemsSource = _articulos;
                }
                
                    seleccionarArticulo(buscarArticuloWin.articuloSeleccionado); //Selecciona el articulo pasado como paràmetro
                
                
                //cmbArticulos.SelectedItem = buscarArticuloWin.articuloSeleccionado;
            }

            buscarArticuloWin = null;
        }

        /// <summary>
        /// Selecciona el artículo pasado como parámetro en el comboArticulo
        /// </summary>
        /// <param name="articulo">artículo a seleccionar</param>
        private void seleccionarArticulo(ArticuloClass articulo)
        {
            foreach (ArticuloClass a in cmbArticulos.Items)
            {
                if(a.Id_articulo == articulo.Id_articulo)
                {
                    cmbArticulos.SelectedItem = a;
                    break;
                }
                
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

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            modifico = true;
        }

        private void btnImprimirOrden_Click(object sender, RoutedEventArgs e)
        {
            imprimirOrden();
            
        }

        private void imprimirOrden()
        {
            //Genera Orden de entrega 
            frmOrdenEntrega formulario = new frmOrdenEntrega();

            frmOrdenEntrega.articulo a;

            formulario.idOrden = ordenEntrega.Id_orden_entrega;
            // formulario.usuario = ordenEntrega.EstadoActual.Usuario.Nombre_completo;
            formulario.usuario = ordenEntrega.UsuarioCreador.Nombre_completo;
            formulario.fecha = ordenEntrega.Fecha.ToShortDateString();
            // formulario.horaEntregado = fecha.ToShortTimeString();
            formulario.dniBeneficiario = ordenEntrega.Beneficiario.Documento;
            formulario.nombreBeneficiario = ordenEntrega.Beneficiario.Nombre;
            formulario.descripcion = ordenEntrega.Descripcion;
            if (ordenEntrega.UsuarioAutoriza == null)
            {
                formulario.usuarioAutoriza = "";
            }
            else
            {
                formulario.usuarioAutoriza = ordenEntrega.UsuarioAutoriza.Nombre_completo;
            }

            if (ordenEntrega.UsuarioEntrega == null)
            {
                formulario.usuarioEntrega = "";
            }
            else
            {
                formulario.usuarioEntrega = ordenEntrega.UsuarioEntrega.Nombre_completo;
            }
           
        
            formulario.estadoActual = ordenEntrega.EstadoActual.Estado.ToString();



            List<ItemEntregaClass> items = ItemEntregaClass.ListarItemEntregaPorOrden(ordenEntrega.Id_orden_entrega);

            //List<ArticuloClass> articulos = ArticuloClass.listarArticulosPorOrden(ordenSeleccionada.Id_orden_entrega);

            foreach (ItemEntregaClass item in items)
            {
                a = new frmOrdenEntrega.articulo();


                a.cantidad = item.Cantidad.ToString();
                a.descripcionArticulo = item.Articulo.Descripcion_articulo;
                a.nombreArticulo = item.Articulo.Nombre_articulo;
                a.tipoArticulo = item.Articulo.Tipo_articulo.Nombre_TipoArticulo;

                formulario.datos.Add(a);
            }

            formulario.ShowDialog();
            formulario.Close();
            formulario = null;


        }
        private void imprimirAutorizar()
        {
            //Genera comprobante  para firmar
            List<OrdenEstadoClass> listaEstados = OrdenEstadoClass.ListarPorOrden(ordenEntrega.Id_orden_entrega);


            OrdenEstadoClass ultEstadoAutorizado = listaEstados.FindLast(x => x.Estado == EstadoOrden.AUTORIZADO);
            DateTime fecha = ultEstadoAutorizado.Fecha;
            frmInformeAutorizacion formulario = new frmInformeAutorizacion();

            formulario.idOrden = ordenEntrega.Id_orden_entrega;
            formulario.usuario = ordenEntrega.EstadoActual.Usuario.Nombre_completo;
            formulario.fechaAutorizado = fecha.ToShortDateString();
            formulario.horaAutorizado = fecha.ToShortTimeString();
            formulario.nombreBeneficiario = ordenEntrega.Beneficiario.Nombre;
            formulario.dniBeneficiario = ordenEntrega.Beneficiario.Documento;
            formulario.descripcion = ordenEntrega.Descripcion;

            formulario.ShowDialog();
            formulario.Close();
            formulario = null;



        }

        private void btnImprimirAutorizacion_Click(object sender, RoutedEventArgs e)
        {
            
            imprimirAutorizar();
        }
        private void imprimirEntregar()
        {
            //Genera comprobante para firmar
            List<OrdenEstadoClass> listaEstados = OrdenEstadoClass.ListarPorOrden(ordenEntrega.Id_orden_entrega);


            OrdenEstadoClass ultEstadoAutorizado = listaEstados.FindLast(x => x.Estado == EstadoOrden.ENTREGADO);
            DateTime fecha = ultEstadoAutorizado.Fecha;
            frmInformeEntrega formulario = new frmInformeEntrega();
            frmInformeEntrega.articulo a;

            formulario.idOrden = ordenEntrega.Id_orden_entrega;
            formulario.usuario = ordenEntrega.EstadoActual.Usuario.Nombre_completo;
            formulario.fechaEntregado = fecha.ToShortDateString();
            formulario.horaEntregado = fecha.ToShortTimeString();
            formulario.dniBeneficiario = ordenEntrega.Beneficiario.Documento;
            formulario.nombreBeneficiario = ordenEntrega.Beneficiario.Nombre;
            formulario.descripcion = ordenEntrega.Descripcion;



            List<ItemEntregaClass> items = ItemEntregaClass.ListarItemEntregaPorOrden(ordenEntrega.Id_orden_entrega);

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
        }


        private void btnImprimirEntrega_Click(object sender, RoutedEventArgs e)
        {
            imprimirEntregar();
        }
    }
}
