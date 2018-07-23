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
    /// Lógica de interacción para AdministrarArticulosWindow.xaml
    /// </summary>
    public partial class AdministrarArticulosWindow : Window
    {
        private List<ArticuloWindow> _ventanasArticulos;
        public ArticuloClass articuloSeleccionado;
        private List<ArticuloClass> _articulos;
        private CriterioBusqueda _criterio_de_busqueda;
        public bool b_ok = false;
      
        public AdministrarArticulosWindow()
        {
            InitializeComponent();

           
            _ventanasArticulos  = new List<ArticuloWindow>();
            articuloSeleccionado = null;
            
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            _articulos = new List<ArticuloClass>();

            grillaArticulos.ItemsSource = _articulos;
            
            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnAbrirArticulo.IsEnabled = false;
            btnEliminarArticulo.IsEnabled = false;
            btnModificarArticulo.IsEnabled = false;
        }

        private void btnNuevoArticulo_Click(object sender, RoutedEventArgs e)
        {
            ArticuloWindow articuloWin = new ArticuloWindow(ArticuloWindow.Opcion.nuevo, null, ref _ventanasArticulos);

            articuloWin.Owner = this;
            _ventanasArticulos.Add(articuloWin);
            articuloWin.Show();
        }

        private void btnAbrirArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (articuloSeleccionado != null)
            {

                ArticuloWindow articuloWin = new ArticuloWindow(ArticuloWindow.Opcion.consultar, articuloSeleccionado, ref _ventanasArticulos);

                articuloWin.Owner = this;
                _ventanasArticulos.Add(articuloWin);
                articuloWin.Show();
            }
        }

        private void btnEliminarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (articuloSeleccionado != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Artículo?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (articuloSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el artículo correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _articulos.Remove(articuloSeleccionado);
                        grillaArticulos.Items.Refresh();
                        
                    }
                }
            }
        }

      

        private void btnBuscarArticulo_Click(object sender, RoutedEventArgs e)
        {
            BuscarArticulo();
        }

        private void grillaArticulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            articuloSeleccionado = (ArticuloClass)grillaArticulos.SelectedItem;
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }


        private void rdbTipo_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Tipo;
        }

        private void btnModificarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (articuloSeleccionado != null)
            {

                ArticuloWindow articuloWin = new ArticuloWindow(ArticuloWindow.Opcion.modificar, articuloSeleccionado, ref _ventanasArticulos);

                articuloWin.Owner = this;
                _ventanasArticulos.Add(articuloWin);
                articuloWin.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void txtBusquedaArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarArticulo();
            }
        }

        private void BuscarArticulo()
        {
            bool todo_ok = false;

            _articulos = new List<ArticuloClass>();
            grillaArticulos.ItemsSource = _articulos;


            string articuloBuscar = txtBusquedaArticulo.Text.ToString().Trim();

            if (txtBusquedaArticulo.Text.Length == 0)
            {
                _articulos = ArticuloClass.ListarArticulos();

                grillaArticulos.ItemsSource = _articulos;


                if (_articulos.Count == 0)
                {
                    btnAbrirArticulo.IsEnabled = false;
                    btnEliminarArticulo.IsEnabled = false;
                    btnModificarArticulo.IsEnabled = false;

                    MessageBox.Show("No se encuentran artículos con esos criterios de busqueda", "No se encuentran artículos", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaArticulos.ItemsSource = _articulos;

                }
                else
                {
                    grillaArticulos.SelectedItem = grillaArticulos.Items[0];
                    articuloSeleccionado = (ArticuloClass)grillaArticulos.Items[0];

                    btnAbrirArticulo.IsEnabled = true;
                    btnEliminarArticulo.IsEnabled = true;
                    btnModificarArticulo.IsEnabled = true;

                    grillaArticulos.Items.Refresh();

                }
            }
            else
            {
                // if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                //{
                /*if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaArticulo))
                {

                    todo_ok = true;

                }
                else
                {
                    todo_ok = false;
                }*/
                todo_ok = true;
                if (todo_ok)
                {
                    if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                    {
                        _articulos = ArticuloClass.ListarArticulosPorNombre(txtBusquedaArticulo.Text.ToString());
                    }
                    else
                    {
                        if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Tipo)
                        {
                            _articulos = ArticuloClass.ListarArticulosPorNombreTipo(txtBusquedaArticulo.Text.ToString());
                        }
                    }


                    grillaArticulos.ItemsSource = _articulos;

                    if (_articulos.Count == 0)
                    {
                        btnAbrirArticulo.IsEnabled = false;
                        btnEliminarArticulo.IsEnabled = false;
                        btnModificarArticulo.IsEnabled = false;


                        MessageBox.Show("No se encuentran artículos con esos criterios de busqueda", "No se encuentran artículos", MessageBoxButton.OK, MessageBoxImage.Warning);

                        grillaArticulos.Items.Refresh();

                    }
                    else
                    {
                        grillaArticulos.SelectedItem = grillaArticulos.Items[0];

                        articuloSeleccionado = (ArticuloClass)grillaArticulos.Items[0];

                        btnAbrirArticulo.IsEnabled = true;
                        btnEliminarArticulo.IsEnabled = true;
                        btnModificarArticulo.IsEnabled = true;

                        grillaArticulos.Items.Refresh();

                    }
                }

                //}


            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaArticulo.Focus();
            txtBusquedaArticulo.TabIndex = 0;
            btnBuscarArticulo.TabIndex = 1;
            btnAbrirArticulo.TabIndex = 2;
            btnNuevoArticulo.TabIndex = 3;
            btnModificarArticulo.TabIndex = 4;
            btnEliminarArticulo.TabIndex = 5;
        }
    }
}
