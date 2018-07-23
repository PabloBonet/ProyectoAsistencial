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
    /// Lógica de interacción para AdministrarTipoArticuloWindow.xaml
    /// </summary>
    public partial class AdministrarTipoArticuloWindow : Window
    {
        private TipoArticuloClass _tipoArticuloSeleccionado;
        private List<TipoArticuloClass> _tipoArticulos;
        private List<TipoArticuloWindows> _ventanasTipoArticulo;
        private CriterioBusqueda _criterio_de_busqueda;
        public AdministrarTipoArticuloWindow()
        {
            InitializeComponent();

            _tipoArticuloSeleccionado = null;
            _ventanasTipoArticulo = new List<TipoArticuloWindows>();
            _tipoArticulos = new List<TipoArticuloClass>();
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
           

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnAbrirTipoArticulo.IsEnabled = false;
            btnEliminarTipoArticulo.IsEnabled = false;
            btnModificarTipoArticulo.IsEnabled = false;
        }

        private void btnModificarTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (_tipoArticuloSeleccionado != null)
            {
                //Verifica que el tipo de articulo no este abierto, si no esta abierta crea la ventana y la agrega a la lista
                TipoArticuloWindows tipoArticuloWin = new TipoArticuloWindows(TipoArticuloWindows.Opcion.modificar, _tipoArticuloSeleccionado, ref _ventanasTipoArticulo);

                tipoArticuloWin.Owner = this;
                _ventanasTipoArticulo.Add(tipoArticuloWin);
                tipoArticuloWin.Show();
            }
        }

        private void btnNuevoTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que el tipo de articulo no este abierto, si no esta abierta crea la ventana y la agrega a la lista
            TipoArticuloWindows tipoArticuloWin = new TipoArticuloWindows(TipoArticuloWindows.Opcion.nuevo, null, ref _ventanasTipoArticulo);

            tipoArticuloWin.Owner = this;
            _ventanasTipoArticulo.Add(tipoArticuloWin);
            tipoArticuloWin.Show();
        }

        private void btnEliminarTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (_tipoArticuloSeleccionado != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Tipo de Artículo?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (_tipoArticuloSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el tipo de artículo correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _tipoArticulos.Remove(_tipoArticuloSeleccionado);
                        grillaTipoArticulo.Items.Refresh();
                        
                    }
                }
            }
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
            txtBusquedaTipoArticulo.Clear();
        }

        private void btnBuscarTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            BuscarTipoArticulo();
        }

        private void btnAbrirTipoArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (_tipoArticuloSeleccionado != null)
            {
                //Verifica que el tipo de articulo no este abierto, si no esta abierta crea la ventana y la agrega a la lista
                TipoArticuloWindows tipoArticuloWin = new TipoArticuloWindows(TipoArticuloWindows.Opcion.consultar, _tipoArticuloSeleccionado, ref _ventanasTipoArticulo);

                tipoArticuloWin.Owner = this;
                _ventanasTipoArticulo.Add(tipoArticuloWin);
                tipoArticuloWin.Show();
            }
        }

        private void grillaTipoArticulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tipoArticuloSeleccionado = (TipoArticuloClass)grillaTipoArticulo.SelectedItem;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void txtBusquedaTipoArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarTipoArticulo();
            }
        }

        private void BuscarTipoArticulo()
        {
            bool todo_ok = false;

            string tipoArticuloBuscar = txtBusquedaTipoArticulo.Text.ToString().Trim();

            if (txtBusquedaTipoArticulo.Text.Length == 0)
            {
                _tipoArticulos = TipoArticuloClass.ListarTipoArticulos();

                grillaTipoArticulo.ItemsSource = _tipoArticulos;


                if (_tipoArticulos.Count == 0)
                {
                    btnAbrirTipoArticulo.IsEnabled = false;
                    btnEliminarTipoArticulo.IsEnabled = false;
                    btnModificarTipoArticulo.IsEnabled = false;

                    MessageBox.Show("No se encuentran Tipo de Artículos con esos criterios de busqueda", "No se encuentran Tipo de Artículos", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    grillaTipoArticulo.SelectedItem = grillaTipoArticulo.Items[0];
                    _tipoArticuloSeleccionado = (TipoArticuloClass)grillaTipoArticulo.Items[0];

                    btnEliminarTipoArticulo.IsEnabled = true;
                    btnAbrirTipoArticulo.IsEnabled = true;
                    btnModificarTipoArticulo.IsEnabled = true;

                }
            }
            else
            {
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                {
                    if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaTipoArticulo))
                    {

                        todo_ok = true;

                    }
                    else
                    {
                        todo_ok = false;
                    }
                }

                if (todo_ok)
                {

                    _tipoArticulos = TipoArticuloClass.BuscarTipoArticuloPorNombre(txtBusquedaTipoArticulo.Text);

                    grillaTipoArticulo.ItemsSource = _tipoArticulos;


                    if (_tipoArticulos.Count == 0)
                    {
                        btnAbrirTipoArticulo.IsEnabled = false;
                        btnEliminarTipoArticulo.IsEnabled = false;
                        btnModificarTipoArticulo.IsEnabled = false;


                        MessageBox.Show("No se encuentran Tipo de Artículos con esos criterios de busqueda", "No se encuentran Tipo de Artículos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        grillaTipoArticulo.SelectedItem = grillaTipoArticulo.Items[0];
                        _tipoArticuloSeleccionado = (TipoArticuloClass)grillaTipoArticulo.Items[0];

                        btnAbrirTipoArticulo.IsEnabled = true;
                        btnEliminarTipoArticulo.IsEnabled = true;
                        btnModificarTipoArticulo.IsEnabled = true;

                    }
                }
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaTipoArticulo.Focus();
            txtBusquedaTipoArticulo.TabIndex = 0;
            btnBuscarTipoArticulo.TabIndex = 1;
            btnAbrirTipoArticulo.TabIndex = 2;
            btnNuevoTipoArticulo.TabIndex = 3;
            btnModificarTipoArticulo.TabIndex = 4;
            btnEliminarTipoArticulo.TabIndex = 5;
        }
    }
}
