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
    /// Lógica de interacción para AdministrarBarriosWindow.xaml
    /// </summary>
    public partial class AdministrarBarriosWindow : Window
    {
        private BarrioClass _barrioSeleccionado;
        private List<BarrioClass> _barrios;
        private List<BarrioWindow> _ventanasBarrios;
        private CriterioBusqueda _criterio_de_busqueda;
        public AdministrarBarriosWindow()
        {
            InitializeComponent();

            _barrioSeleccionado = null;
            _ventanasBarrios = new List<BarrioWindow>();
            _barrios = new List<BarrioClass>();
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnAbrirBarrio.IsEnabled = false;
            btnEliminarBarrio.IsEnabled = false;
            btnModificarBarrio.IsEnabled = false;
        }

        private void btnNuevoBarrio_Click(object sender, RoutedEventArgs e)
        {
            //Verifica que el barrio no este abierto, si no esta abierta crea la ventana y la agrega a la lista
            BarrioWindow barrioWin = new BarrioWindow(BarrioWindow.Opcion.nuevo, null, ref _ventanasBarrios);

            barrioWin.Owner = this;
            _ventanasBarrios.Add(barrioWin);
            barrioWin.Show();

           
        }

        private void btnAbrirBarrio_Click(object sender, RoutedEventArgs e)
        {
            if(_barrioSeleccionado != null)
            {
                //Verifica que el barrio no este abierto, si no esta abierta crea la ventana y la agrega a la lista
                BarrioWindow barrioWin = new BarrioWindow(BarrioWindow.Opcion.consultar, _barrioSeleccionado, ref _ventanasBarrios);

                barrioWin.Owner = this;
                _ventanasBarrios.Add(barrioWin);
                barrioWin.Show();
            }
            
        }

        private void btnEliminarBarrio_Click(object sender, RoutedEventArgs e)
        {
            if(_barrioSeleccionado != null)
            {
                
                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Barrio?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (_barrioSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el barrio correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _barrios.Remove(_barrioSeleccionado);
                        grillaBarrios.Items.Refresh();

                    }
                }
            }

        }

   

        private void btnBuscarBarrio_Click(object sender, RoutedEventArgs e)
        {
            BuscarBarrio();
        }

        private void grillaBarrios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _barrioSeleccionado = (BarrioClass) grillaBarrios.SelectedItem;
        }

       
        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
            txtBusquedaBarrio.Clear();
        }

        private void btnModificarBarrio_Click(object sender, RoutedEventArgs e)
        {
            if (_barrioSeleccionado != null)
            {
                //Verifica que el barrio no este abierto, si no esta abierta crea la ventana y la agrega a la lista
                BarrioWindow barrioWin = new BarrioWindow(BarrioWindow.Opcion.modificar, _barrioSeleccionado, ref _ventanasBarrios);

                barrioWin.Owner = this;
                _ventanasBarrios.Add(barrioWin);
                barrioWin.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void txtBusquedaBarrio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarBarrio();
            }
        }

        private void BuscarBarrio()
        {
            bool todo_ok = false;

            string barrioBuscar = txtBusquedaBarrio.Text.ToString().Trim();

            if (txtBusquedaBarrio.Text.Length == 0)
            {
                _barrios = BarrioClass.ListarBarrios();

                grillaBarrios.ItemsSource = _barrios;

                if (_barrios.Count == 0)
                {
                    btnAbrirBarrio.IsEnabled = false;
                    btnEliminarBarrio.IsEnabled = false;
                    btnModificarBarrio.IsEnabled = false;
                    MessageBox.Show("No se encuentran barrios con esos criterios de busqueda", "No se encuentran barrios", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    grillaBarrios.SelectedItem = grillaBarrios.Items[0];
                    _barrioSeleccionado = (BarrioClass)grillaBarrios.Items[0];

                    btnEliminarBarrio.IsEnabled = true;
                    btnAbrirBarrio.IsEnabled = true;
                    btnModificarBarrio.IsEnabled = true;
                }
            }
            else
            {
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                {
                    if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaBarrio))
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

                    _barrios = BarrioClass.BuscarBarrioPorNombre(txtBusquedaBarrio.Text);


                    grillaBarrios.ItemsSource = _barrios;

                    if (_barrios.Count == 0)
                    {
                        btnAbrirBarrio.IsEnabled = false;
                        btnEliminarBarrio.IsEnabled = false;
                        btnModificarBarrio.IsEnabled = false;

                        MessageBox.Show("No se encuentran barrios con esos criterios de busqueda", "No se encuentran barrios", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        grillaBarrios.SelectedItem = grillaBarrios.Items[0];
                        _barrioSeleccionado = (BarrioClass)grillaBarrios.Items[0];
                        btnAbrirBarrio.IsEnabled = true;
                        btnEliminarBarrio.IsEnabled = true;
                        btnModificarBarrio.IsEnabled = true;
                    }
                }
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaBarrio.Focus();
            txtBusquedaBarrio.TabIndex = 0;
            btnBuscarBarrio.TabIndex = 1;
            btnAbrirBarrio.TabIndex = 2;
            btnNuevoBarrio.TabIndex = 3;
            btnModificarBarrio.TabIndex = 4;
            btnEliminarBarrio.TabIndex = 5;
        }
    }
}
