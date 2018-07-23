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
    /// Lógica de interacción para TipoArticuloWindows.xaml
    /// </summary>
    public partial class TipoArticuloWindows : Window
    {
        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public TipoArticuloClass tipoArticulo;
        public bool b_ok = false;
        private List<TipoArticuloWindows> _ventanas;
        public TipoArticuloWindows(Opcion op, TipoArticuloClass tipoArticulo, ref List<TipoArticuloWindows> ventanas)
        {
            InitializeComponent();

            opcion = op;
            this.tipoArticulo = null;
            if (op != Opcion.nuevo)
            {
                this.tipoArticulo = tipoArticulo;
            }

            _ventanas = ventanas;
            

            //Inicializar componentes de la pantalla
            switch (op)
            {
                case Opcion.nuevo:
                    this.InicializarComponentesNuevo();
                    

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
            ckEsDinero.IsEnabled = true;


            //Botones

            btnEliminarTipoArticulo.IsEnabled = false;
            btnGuardarTipoArticulo.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
        }

        private void InicializarComponentesModificar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            ckEsDinero.IsEnabled = true;


            //Botones

            btnEliminarTipoArticulo.IsEnabled = true;
            btnGuardarTipoArticulo.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
        }

        private void CargarDatosModificar()
        {
            if(tipoArticulo != null)
            {
                txtNombre.Text = this.tipoArticulo.Nombre_TipoArticulo;
                ckEsDinero.IsChecked = this.tipoArticulo.EsDinero;
            }
        }
        private void InicializarComponentesConsultar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            ckEsDinero.IsEnabled = false;


            //Botones

            btnEliminarTipoArticulo.IsEnabled = false;
            btnGuardarTipoArticulo.IsEnabled = false;
            btnCancelarCambios.IsEnabled = true;
        }
        private void CargarDatosConsultar()
        {
            if (tipoArticulo != null)
            {
                txtNombre.Text = this.tipoArticulo.Nombre_TipoArticulo;
                ckEsDinero.IsChecked = this.tipoArticulo.EsDinero;
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombre.TabIndex = 0;
            ckEsDinero.TabIndex = 1;
            btnEliminarTipoArticulo.TabIndex = 2;
            btnGuardarTipoArticulo.TabIndex = 3;
            btnCancelarCambios.TabIndex = 4;
        }

        private void btnEliminarTipoArticulo_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult mr;
            mr = MessageBox.Show("¿Confirma Eliminar el Tipo de articulo?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (mr == MessageBoxResult.Yes)
            {
                if (tipoArticulo.Eliminar())
                {
                    MessageBox.Show("Se ha eliminado el tipo de artículo correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                    b_ok = true;
                    tipoArticulo = null;
                    this.Close();
                    this.Owner.Focus();
                }
            }
        }

        private void btnGuardarTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (validar())
            {

                if (opcion == Opcion.nuevo)
                {
                    TipoArticuloClass nuevoTipoArticulo = new TipoArticuloClass();
                    nuevoTipoArticulo.Nombre_TipoArticulo = txtNombre.Text.ToString();
                    nuevoTipoArticulo.EsDinero = (bool)ckEsDinero.IsChecked;
                 
                    if (nuevoTipoArticulo.NuevoTipoArticulo())
                    {
                        MessageBox.Show("Tipo Artículo " + nuevoTipoArticulo.Nombre_TipoArticulo + " creado con éxito", "Crear Tipo de artículo", MessageBoxButton.OK, MessageBoxImage.Information);
                        b_ok = true;
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El Tipo de Artículo " + nuevoTipoArticulo.Nombre_TipoArticulo + " no se pudo crear", "Crear Tipo de Artículo", MessageBoxButton.OK, MessageBoxImage.Information);
                        b_ok = false;
                    }
                }
                else
                {
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Tipo de Artículo " + this.tipoArticulo.Nombre_TipoArticulo+ "?", "Confirme modificar Tipo de Artículo", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                            this.tipoArticulo.Nombre_TipoArticulo = txtNombre.Text.ToString();
                            this.tipoArticulo.EsDinero = (bool)ckEsDinero.IsChecked;
                         
                            if (this.tipoArticulo.ModificarTipoArticulo())
                            {
                                MessageBox.Show("Tipo de Artículo " + tipoArticulo.Nombre_TipoArticulo + " modificado con éxito", "Modificar Tipo de Artículo", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El Tipo de Artículo" + this.tipoArticulo.Nombre_TipoArticulo + " no se pudo modificar", "Modificar Tipo de Artículo", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = false;
                            }
                        }

                    }
                }

            }
        }

        private bool validar()
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
            this.Close();
            this.Owner.Focus();
        }
    }
}
