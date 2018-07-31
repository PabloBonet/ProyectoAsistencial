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
using Processar.ProyectoAyudar.DatosLibrary;

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para GrupoBeneficiarioWindow.xaml
    /// </summary>
    public partial class GrupoBeneficiarioWindow : Window
    {

        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public GrupoBeneficiarioClass grupo;
        public bool b_ok = false;
        private List<GrupoBeneficiarioWindow> _ventanas;
        private List<BeneficiarioClass> _beneficiarios;     //Lista de beneficiarios para la lista desplegable
        private List<BeneficiarioClass> _listaBeneficiarios; // Lista de beneficiarios para la grilla
        private BeneficiarioClass _beneficiarioSeleccionado;


        private bool modifico = false;

        /// <summary>
        /// Constructor de la clase controladora de la ventana Grupo de Beneficiario
        /// </summary>
        /// <param name="op"></param>
        /// <param name="grupo"></param>
        /// <param name="ventanas"></param>
        public GrupoBeneficiarioWindow(Opcion op, GrupoBeneficiarioClass grupo, ref List<GrupoBeneficiarioWindow> ventanas)
        {
            InitializeComponent();

            opcion = op;
            this.grupo = null;
            if (op != Opcion.nuevo)
            {
                this.grupo = grupo;
            }

            _ventanas = ventanas;
            _beneficiarios = new List<BeneficiarioClass>();
            _listaBeneficiarios = new List<BeneficiarioClass>();
            _beneficiarioSeleccionado = null;

            grillaBeneficiarios.ItemsSource = _listaBeneficiarios;

            //Carga de articulos
            _beneficiarios = BeneficiarioClass.ListarBeneficiarios();
            cmbBeneficiarios.ItemsSource = _beneficiarios;

            _beneficiarioSeleccionado = null;
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


            grillaBeneficiarios.ItemsSource = _listaBeneficiarios;

        }

        /// <summary>
        /// Método para iniciar los componentes al crear
        /// </summary>
        private void InicializarComponentesNuevo()
        {
            //Labels y txtBoxes
            lblIdGrupo.Visibility = Visibility.Hidden;
            txtIdGrupo.Visibility = Visibility.Hidden;

            txtIdGrupo.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;
            txtNombreGrupo.IsReadOnly = false;
        

            //Botones

            btnEliminarGrupo.IsEnabled = false;
            
            btnGuardarGrupo.Label = "Crear";
                   
        }

        /// <summary>
        /// Método para iniciar los componentes al modificar
        /// </summary>
        private void InicializarComponentesModificar()
        {


            //Labels y txtBoxes
            lblIdGrupo.Visibility = Visibility.Visible;
            txtIdGrupo.Visibility = Visibility.Visible;

            txtIdGrupo.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;
            txtNombreGrupo.IsReadOnly = true;


            //Botones

            btnEliminarGrupo.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnEliminarGrupo.Name);

            btnGuardarGrupo.Label = "Guardar";

            

        }

        /// <summary>
        /// Método para iniciar los componentes al consultar
        /// </summary>
        private void InicializarComponentesConsultar()
        {


            //Labels y txtBoxes
            lblIdGrupo.Visibility = Visibility.Visible;
            txtIdGrupo.Visibility = Visibility.Visible;

            txtIdGrupo.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;
            txtNombreGrupo.IsReadOnly = true;


            //Botones

            btnEliminarGrupo.IsEnabled = PermisoClass.TienePermiso(MainWindow.usuario_logueado.Id_usuario, btnEliminarGrupo.Name);

            btnGuardarGrupo.Label = "Guardar";



        }

        /// <summary>
        /// Carga los datos en las listas y combos al crear
        /// </summary>
        private void CargarDatosNuevo()
        {

            txtNombreGrupo.Text = "";
            txtDescripcion.Text = "";
            
            //combo articulos
            cmbBeneficiarios.Items.Refresh();

            

        }

        /// <summary>
        /// Carga los datos en las listas y combos al modificar
        /// </summary>
        private void CargarDatosModificar()
        {

            txtIdGrupo.Text = grupo.Id_grupo.ToString();
            txtNombreGrupo.Text = grupo.Nombre;
            txtDescripcion.Text = grupo.Descripcion;

            _beneficiarios = grupo.Beneficiarios;
            
            grillaBeneficiarios.ItemsSource = _beneficiarios;

        
        }

        /// <summary>
        /// Carga los datos en las listas y combos al consultar
        /// </summary>
        private void CargarDatosConsultar()
        {

            txtIdGrupo.Text = grupo.Id_grupo.ToString();
            txtNombreGrupo.Text = grupo.Nombre;
            txtDescripcion.Text = grupo.Descripcion;

            _beneficiarios = grupo.Beneficiarios;

            grillaBeneficiarios.ItemsSource = _beneficiarios;

        }

        /// <summary>
        /// Método controlador el evento Inicializar ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombreGrupo.Focus();

            txtNombreGrupo.TabIndex = 1;
            txtDescripcion.TabIndex = 2;
            cmbBeneficiarios.TabIndex = 3;
            btnBuscarBeneficiario.TabIndex = 4;
            btnAgregarBeneficiario.TabIndex = 5;
            btnQuitarBeneficiario.TabIndex = 6;
            btnGuardarGrupo.TabIndex = 7;
            btnCancelarCambios.TabIndex = 8;
            btnEliminarGrupo.TabIndex = 9;

          
        }

        /// <summary>
        /// Método para controlar el evento de Cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        /// <summary>
        /// Metodo para controlar el botón para eliminar Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarGrupo_Click(object sender, RoutedEventArgs e)
        {
            if (grupo != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Seguro que desea eliminar el Grupo " + grupo.Id_grupo+ "?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (grupo.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el Grupo correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        this.Owner.Focus();
                        grupo = null;
                  
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el grupo", "Eliminar Grupo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Método para controlar el botón Guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarGrupo_Click(object sender, RoutedEventArgs e)
        {
            guardar();

        }

        /// <summary>
        /// Método para Guardar el Grupo
        /// </summary>
        private void guardar()
        {
            if (Validar())
            {
                if (opcion == Opcion.nuevo)
                {


                    GrupoBeneficiarioClass nuevoGrupo = new GrupoBeneficiarioClass();
                    nuevoGrupo.Nombre = txtNombreGrupo.Text.ToString();
                    nuevoGrupo.Descripcion = txtDescripcion.Text.ToString();
                    nuevoGrupo.Beneficiarios = _listaBeneficiarios;
                   
                  
                 
                    MessageBoxResult msg2;
                    msg2 = MessageBox.Show("¿Seguro que desea crear el grupo?", "Confirme crear Grupo", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (msg2 == MessageBoxResult.Yes)
                    {
                        if (nuevoGrupo.NuevoGrupoBeneficiario())
                        {
                            MessageBox.Show("Grupo " + nuevoGrupo.Id_grupo + " creado con éxito", "Crear Grupo", MessageBoxButton.OK, MessageBoxImage.Information);
                            b_ok = true;

                           
                            this.Close();
                            this.Owner.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El Grupo no se pudo crear", "Crear Grupo", MessageBoxButton.OK, MessageBoxImage.Error);
                            b_ok = false;
                        }
                    }

                }
                else
                { 
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Grupo " + grupo.Id_grupo + "?", "Confirme modificar Grupo", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                            if (_listaBeneficiarios!= null)
                            {
                                grupo.Beneficiarios= _listaBeneficiarios;
                            }

                            grupo.Descripcion = txtDescripcion.Text.ToString();
                           

                            if (grupo.Modificar())
                            {
                                MessageBox.Show("Grupo  " + grupo.Id_grupo+ " modificado con éxito", "Modificar Grupo", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;

                              
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El Grupo " + grupo.Id_grupo + " no se pudo modificar", "Modificar Grupo", MessageBoxButton.OK, MessageBoxImage.Error);
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

        /// <summary>
        /// Método para validar los campos de la ventana
        /// </summary>
        /// <returns></returns>
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


            //validar txtNombre. Valida que el grupo tenga nombre

            if (ValidacionesClass.ValidarNumericoTextBox(txtNombreGrupo))
            {
                txtNombreGrupo.Background = txtBien.Background;
                txtNombreGrupo.ToolTip = "";

            }
            else
            {
                r = false;
                txtNombreGrupo.Background = txtMal.Background;

                txtNombreGrupo.ToolTip = "No es correcto";
            }


            //valida el txtDescripción
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Background = txtMal.Background;
                txtDescripcion.ToolTip = "No puede quedar vacío";
                r = false;
            }


           
            return r;

        }

        /// <summary>
        /// Busca los tipos de elementos pasados como parametros en la ventana
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Blanquea todos los  TextBox de la ventana
        /// </summary>
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

        /// <summary>
        /// Método para controlar el botón que cancela los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            grupo = null;
            this.Close();
            this.Owner.Focus();
        }

        /// <summary>
        /// Método para controlar el botón que agrega un beneficiario a la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            BeneficiarioClass nuevoBeneficiario = null;
            nuevoBeneficiario = (BeneficiarioClass)cmbBeneficiarios.SelectedItem;


            if (nuevoBeneficiario != null)
            {
          
                if (_listaBeneficiarios.Contains(nuevoBeneficiario))
                {
                    MessageBox.Show("El Beneficiario ya se encuentra en la grilla", "No se puede agregar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    _listaBeneficiarios.Add(nuevoBeneficiario);
                    grillaBeneficiarios.ItemsSource = _listaBeneficiarios;

                    grillaBeneficiarios.Items.Refresh();

                    modifico = true;
                }
               
  

            }
        }

        /// <summary>
        /// Método para controla el boón para la busqueda del beneficiario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            BuscarBeneficiarioWindow buscarBeneficiarioWin = new BuscarBeneficiarioWindow();

            buscarBeneficiarioWin.Owner = this;

            buscarBeneficiarioWin.ShowDialog();

            if (buscarBeneficiarioWin.b_ok && buscarBeneficiarioWin.beneficiarioSeleccionado.Id_beneficiario != 0)
            {
                if (buscarBeneficiarioWin.b_ok)
                {
                    _beneficiarios = BeneficiarioClass.ListarBeneficiarios();
                    cmbBeneficiarios.ItemsSource = _beneficiarios;
                }
                
                seleccionarBeneficiario(buscarBeneficiarioWin.beneficiarioSeleccionado); //Selecciona el beneficiario pasado como parámetro


                //cmbArticulos.SelectedItem = buscarArticuloWin.articuloSeleccionado;
            }

            buscarBeneficiarioWin = null;
        }

        /// <summary>
        /// Selecciona el beneficiario pasado como parámetro
        /// </summary>
        /// <param name="beneficiario">beneficiario a seleccionar</param>
        private void seleccionarBeneficiario(BeneficiarioClass beneficiario)
        {
            foreach (BeneficiarioClass b in cmbBeneficiarios.Items)
            {
                if (b.Id_beneficiario == beneficiario.Id_beneficiario)
                {
                    cmbBeneficiarios.SelectedItem = b;
                    break;
                }

            }

        }

        /// <summary>
        /// Método para controlar el botón que quita un beneficiario de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            if (_beneficiarioSeleccionado != null)
            {
                _listaBeneficiarios.Remove(_beneficiarioSeleccionado);

                grillaBeneficiarios.ItemsSource = _listaBeneficiarios;

                grillaBeneficiarios.Items.Refresh();
                modifico = true;
            }
        }

        /// <summary>
        /// Método para controlar el evento de tecla en la descripción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            modifico = true;
        }

      /// <summary>
      /// Método para manejar el evento de Cambio de selección en la grilla
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void grillaBeneficiarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.SelectedItem;
        }
    }
}
