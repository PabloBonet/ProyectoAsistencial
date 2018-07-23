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

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para ArticuloWindow.xaml
    /// </summary>
    public partial class ArticuloWindow : Window
    {

        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public ArticuloClass articulo;
        public bool b_ok = false;
        private List<ArticuloWindow> _ventanas;
        private List<TipoArticuloClass> _tipoArticulos;
        public ArticuloWindow(Opcion op, ArticuloClass articulo, ref List<ArticuloWindow> ventanas)
        {
            InitializeComponent();

            opcion = op;
            this.articulo = new ArticuloClass();
            
            if (op != Opcion.nuevo)
            {
                this.articulo = articulo;
            }

            
            _ventanas = ventanas;
            _tipoArticulos = TipoArticuloClass.ListarTipoArticulos();


            //Items Source de el combo Tipo Articulo
            cmbTipoArticulo.ItemsSource = _tipoArticulos;
            

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
        }

        private void InicializarComponentesNuevo()
        {
            //txtBoxes
            txtNombre.IsReadOnly = false;
            txtDescripcion.IsReadOnly = false;

            cmbTipoArticulo.IsEnabled = true;
            

            //Botones

            btnEliminarArticulo.IsEnabled = false;
            btnGuardarArticulo.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
        }

        private void InicializarComponentesModificar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;

            cmbTipoArticulo.IsEnabled = true;



            //Botones

            btnEliminarArticulo.IsEnabled = true;
            btnGuardarArticulo.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
        }

        private void CargarDatosModificar()
        {
            if(articulo != null)
            {
                txtNombre.Text = articulo.Nombre_articulo.ToString();
                txtDescripcion.Text = articulo.Descripcion_articulo.ToString();

                seleccionarTipoArticulo();
            }
            
            


        }
        private void InicializarComponentesConsultar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtDescripcion.IsReadOnly = true;

            cmbTipoArticulo.IsEnabled = true;



            //Botones

            btnEliminarArticulo.IsEnabled = false;
            btnGuardarArticulo.IsEnabled = false;
            btnCancelarCambios.IsEnabled = true;
            
        }

        private void CargarDatosConsultar()
        {
            if (articulo != null)
            {
                txtNombre.Text = articulo.Nombre_articulo.ToString();
                txtDescripcion.Text = articulo.Descripcion_articulo.ToString();

                seleccionarTipoArticulo();
            }


        }


        private void seleccionarTipoArticulo()
        {
            foreach (TipoArticuloClass a in cmbTipoArticulo.Items)
            {
                if(a.Id_TipoArticulo == articulo.Tipo_articulo.Id_TipoArticulo)
                {
                    cmbTipoArticulo.SelectedItem = a;
                    
                }
            }

        }

        private void CargarDatosNuevo()
        {
            cmbTipoArticulo.Items.Refresh();
        }


        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombre.TabIndex = 0;
            txtDescripcion.TabIndex = 1;
            cmbTipoArticulo.TabIndex = 2;

        }
        

        private void btnEliminarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (articulo != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Artículo?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (articulo.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el artículo correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el artículo", "Eliminar Beneficiario", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnGuardarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                if (opcion == Opcion.nuevo)
                {

                    ArticuloClass nuevoArticulo = new ArticuloClass();
                    nuevoArticulo.Nombre_articulo = txtNombre.Text.ToString();
                    nuevoArticulo.Descripcion_articulo = txtDescripcion.Text.ToString();
                    nuevoArticulo.Tipo_articulo = (TipoArticuloClass)cmbTipoArticulo.SelectedItem;

                    if (nuevoArticulo.NuevoArticulo())
                    {
                        MessageBox.Show("Artículo " + nuevoArticulo.Nombre_articulo + " creado con éxito", "Crear Artículo", MessageBoxButton.OK, MessageBoxImage.Information);
                        articulo = nuevoArticulo;
                        b_ok = true;
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El artículo" + nuevoArticulo.Nombre_articulo + " no se pudo crear", "Crear Artículo", MessageBoxButton.OK, MessageBoxImage.Error);
                        b_ok = false;
                    }
                }
                else
                {
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Artículo " + articulo.Nombre_articulo + "?", "Confirme modificar Artículo", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                            articulo.Nombre_articulo = txtNombre.Text.ToString();
                            articulo.Descripcion_articulo = txtDescripcion.Text.ToString();

                            articulo.Tipo_articulo = (TipoArticuloClass)cmbTipoArticulo.SelectedItem;

                            if (articulo.ModificarArticulo())
                            {
                                MessageBox.Show("Artículo " + articulo.Nombre_articulo + " modificado con éxito", "Modificar artículo", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El artículo " + articulo.Nombre_articulo + " no se pudo modificar", "Modificar artículo", MessageBoxButton.OK, MessageBoxImage.Error);
                                b_ok = false;
                            }
                        }

                    }
                }
            }
        }

        private bool Validar()
        {
            bool r = true;

            blanquear();


            foreach (TextBox t in FindVisualChildren<TextBox>(this))
            {



                if (t.Name != "txtMal" && t.Name != "txtBien")
                {


                    if (t.Text == "")
                    {
                        t.Background = txtMal.Background;
                        t.ToolTip = "No puede quedar vacío";
                        r = false;
                    }
                }
            }
            if(cmbTipoArticulo.SelectedItem == null)
            {
                cmbTipoArticulo.ToolTip = "No puede quedar vacío";
                r = false;
            }


            return r;

        }
        private void blanquear()
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
        private void btnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            articulo = null;
            this.Close();
            this.Owner.Focus();
        }
    }
}
