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
    /// Lógica de interacción para AdministrarBeneficiosWindow.xaml
    /// </summary>
    public partial class AdministrarBeneficiosWindow : Window
    {
        private List<BeneficioWindow> _ventanasBeneficios;
        public BeneficioClass beneficioSeleccionado;
        private List<BeneficioClass> _beneficios;
        private CriterioBusqueda _criterio_de_busqueda;
        public bool b_ok = false;
      
        public AdministrarBeneficiosWindow()
        {
            InitializeComponent();

           
            _ventanasBeneficios  = new List<BeneficioWindow>();
            beneficioSeleccionado = null;
            
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            _beneficios = new List<BeneficioClass>();

            grillaBeneficios.ItemsSource = _beneficios;
            
            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnAbrirBeneficio.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnModificarBeneficio.IsEnabled = false;
        }

       

      

        

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }


        private void rdbTipo_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Tipo;
        }

       

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

      
      

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaBeneficio.Focus();
            txtBusquedaBeneficio.TabIndex = 0;
            btnBuscarBeneficio.TabIndex = 1;
            btnAbrirBeneficio.TabIndex = 2;
            btnNuevoBeneficio.TabIndex = 3;
            btnModificarBeneficio.TabIndex = 4;
            btnEliminar.TabIndex = 5;
        }

        private void btnNuevoBeneficio_Click(object sender, RoutedEventArgs e)
        {
            BeneficioWindow beneficioWin = new BeneficioWindow(BeneficioWindow.Opcion.nuevo, null, ref _ventanasBeneficios);

            beneficioWin.Owner = this;
            _ventanasBeneficios.Add(beneficioWin);
            beneficioWin.Show();
        }

        private void btnModificarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            if (beneficioSeleccionado != null)
            {

                BeneficioWindow beneficioWin = new BeneficioWindow(BeneficioWindow.Opcion.modificar, beneficioSeleccionado, ref _ventanasBeneficios);

                beneficioWin.Owner = this;
                _ventanasBeneficios.Add(beneficioWin);
                beneficioWin.Show();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (beneficioSeleccionado != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Beneficio?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (beneficioSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el beneficio correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _beneficios.Remove(beneficioSeleccionado);
                        grillaBeneficios.Items.Refresh();

                    }
                }
            }
        }

        private void txtBusquedaBeneficio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarBeneficiario();
            }
        }

        private void btnBuscarBeneficio_Click(object sender, RoutedEventArgs e)
        {

            BuscarBeneficiario();
        }

        private void btnAbrirBeneficio_Click(object sender, RoutedEventArgs e)
        {
            if (beneficioSeleccionado != null)
            {

                BeneficioWindow beneficioWin = new BeneficioWindow(BeneficioWindow.Opcion.consultar, beneficioSeleccionado, ref _ventanasBeneficios);

                beneficioWin.Owner = this;
                _ventanasBeneficios.Add(beneficioWin);
                beneficioWin.Show();
            }
        }

        private void grillaBeneficios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficioSeleccionado = (BeneficioClass)grillaBeneficios.SelectedItem;
        }


        private void BuscarBeneficiario()
        {
            bool todo_ok = false;

            _beneficios = new List<BeneficioClass>();
            grillaBeneficios.ItemsSource = _beneficios;


            string beneficioBuscar = txtBusquedaBeneficio.Text.ToString().Trim();

            if (txtBusquedaBeneficio.Text.Length == 0)
            {
                _beneficios = BeneficioClass.ListarBeneficios();

                grillaBeneficios.ItemsSource = _beneficios;


                if (_beneficios.Count == 0)
                {
                    btnAbrirBeneficio.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                    btnModificarBeneficio.IsEnabled = false;

                    MessageBox.Show("No se encuentran Beneficios con esos criterios de busqueda", "No se encuentran beneficios", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaBeneficios.ItemsSource = _beneficios;

                }
                else
                {
                    grillaBeneficios.SelectedItem = grillaBeneficios.Items[0];
                    beneficioSeleccionado = (BeneficioClass)grillaBeneficios.Items[0];

                    btnAbrirBeneficio.IsEnabled = true;
                    btnEliminar.IsEnabled = true;
                    btnModificarBeneficio.IsEnabled = true;

                    grillaBeneficios.Items.Refresh();

                }
            }
            else
            {

                todo_ok = true;
                if (todo_ok)
                {
                    if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                    {
                        _beneficios = BeneficioClass.ListarBeneficiosPorNombre(txtBusquedaBeneficio.Text.ToString());
                    }
                    else
                    {

                    }


                    grillaBeneficios.ItemsSource = _beneficios;

                    if (_beneficios.Count == 0)
                    {
                        btnAbrirBeneficio.IsEnabled = false;
                        btnEliminar.IsEnabled = false;
                        btnModificarBeneficio.IsEnabled = false;


                        MessageBox.Show("No se encuentran beneficios con esos criterios de busqueda", "No se encuentran beneficios", MessageBoxButton.OK, MessageBoxImage.Warning);

                        grillaBeneficios.Items.Refresh();

                    }
                    else
                    {
                        grillaBeneficios.SelectedItem = grillaBeneficios.Items[0];

                        beneficioSeleccionado = (BeneficioClass)grillaBeneficios.Items[0];

                        btnAbrirBeneficio.IsEnabled = true;
                        btnEliminar.IsEnabled = true;
                        btnModificarBeneficio.IsEnabled = true;

                        grillaBeneficios.Items.Refresh();

                    }
                }

                //}


            }
        }
     
    }
}
