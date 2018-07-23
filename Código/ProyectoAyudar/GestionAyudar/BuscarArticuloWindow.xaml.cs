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
    /// Lógica de interacción para BuscarArticuloWindow.xaml
    /// </summary>
    public partial class BuscarArticuloWindow : Window
    {
        public ArticuloClass articuloSeleccionado;
        private List<ArticuloClass> _articulos;
        private CriterioBusqueda _criterio_de_busqueda;
        private List<ArticuloWindow> _ventanasArticulos;
        public bool b_ok = false;
        public bool es_agregado = false;

        public BuscarArticuloWindow()
        {
            InitializeComponent();

            articuloSeleccionado = null;

            _ventanasArticulos = new List<ArticuloWindow>();

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            _articulos = new List<ArticuloClass>();

            grillaArticulos.ItemsSource = _articulos;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnBuscarArticulo.IsEnabled = true;
            
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }

        private void rdbTipo_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Tipo;
        }

        private void btnBuscarArticulo_Click(object sender, RoutedEventArgs e)
        {
            BuscarArticulo();
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
           articuloSeleccionado = (ArticuloClass)grillaArticulos.SelectedItem;
            b_ok = true;
            this.Close();
            this.Owner.Focus();
        }

        private void grillaArticulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            articuloSeleccionado = (ArticuloClass)grillaArticulos.SelectedItem;
        }

        private void grillaArticulos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            articuloSeleccionado = (ArticuloClass)grillaArticulos.SelectedItem;
            if (articuloSeleccionado != null)
            {
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ArticuloWindow articuloWin = new ArticuloWindow(ArticuloWindow.Opcion.nuevo, null, ref _ventanasArticulos);

            articuloWin.Owner = this;
            _ventanasArticulos.Add(articuloWin);
            articuloWin.ShowDialog();

            if(articuloWin.b_ok)
            {
                articuloSeleccionado = articuloWin.articulo;
                b_ok = true;
                es_agregado = true;
                this.Close();
                this.Owner.Focus();
                
            }
            
        }

        private void txtBusquedaArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
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

                    btnSeleccionar.IsEnabled = false;
                    MessageBox.Show("No se encuentran artículos con esos criterios de busqueda", "No se encuentran artículos", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaArticulos.ItemsSource = _articulos;

                }
                else
                {
                    grillaArticulos.SelectedItem = grillaArticulos.Items[0];
                    articuloSeleccionado = (ArticuloClass)grillaArticulos.Items[0];

                    btnSeleccionar.IsEnabled = true;

                    grillaArticulos.Items.Refresh();

                }
            }
            else
            {
                
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
                        btnSeleccionar.IsEnabled = false;


                        MessageBox.Show("No se encuentran artículos con esos criterios de busqueda", "No se encuentran artículos", MessageBoxButton.OK, MessageBoxImage.Warning);

                        grillaArticulos.Items.Refresh();

                    }
                    else
                    {
                        grillaArticulos.SelectedItem = grillaArticulos.Items[0];

                        articuloSeleccionado = (ArticuloClass)grillaArticulos.Items[0];

                        btnSeleccionar.IsEnabled = true;

                        grillaArticulos.Items.Refresh();

                    }
                }

            


            }
            }

        private void txtBusquedaArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarArticulo();
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaArticulo.Focus();

            rdbNombre.TabIndex = 3;
            rdbTipo.TabIndex = 4;
            txtBusquedaArticulo.TabIndex = 0;
            btnBuscarArticulo.TabIndex = 1;
            btnNuevo.TabIndex = 2;
            
        }
    }
}
