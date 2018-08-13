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
    /// Lógica de interacción para BuscarBeneficiarioWindow.xaml
    /// </summary>
    public partial class BuscarBeneficioWindow : Window
    {
        public BeneficioClass beneficioSeleccionado;
        private List<BeneficioClass> _beneficios;
        private CriterioBusqueda _criterio_de_busqueda;
        private List<BeneficioWindow> _ventanasBeneficios;
        public bool b_ok = false;
        public BuscarBeneficioWindow()
        {
            InitializeComponent();

            beneficioSeleccionado = null;

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            _beneficios = new List<BeneficioClass>();

            _ventanasBeneficios = new List<BeneficioWindow>();

            grillaBeneficios.ItemsSource = _beneficios;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnSeleccionar.IsEnabled = false;
            btnBuscarBeneficio.IsEnabled = true;
          
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }


        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

            beneficioSeleccionado = (BeneficioClass)grillaBeneficios.SelectedItem;
            b_ok = true;
            this.Close();
            this.Owner.Focus();
        }

       

       

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            BeneficioWindow benWin = new BeneficioWindow(BeneficioWindow.Opcion.nuevo, null, ref _ventanasBeneficios);
            benWin.Owner = this;
            _ventanasBeneficios.Add(benWin);
            benWin.ShowDialog();

            if (benWin.b_ok)
            {
                beneficioSeleccionado = benWin.beneficio;
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaBeneficio.Focus();

           
           
            txtBusquedaBeneficio.TabIndex = 0;
            btnBuscarBeneficio.TabIndex = 1;
            btnNuevo.TabIndex = 2;
            rdbNombre.TabIndex = 3;
        }

        private void btnBuscarBeneficio_Click(object sender, RoutedEventArgs e)
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

                    MessageBox.Show("No se encuentran beneficios con esos criterios de busqueda", "No se encuentran beneficios", MessageBoxButton.OK, MessageBoxImage.Warning);

                    btnSeleccionar.IsEnabled = false;
                    grillaBeneficios.ItemsSource = _beneficios;
                }
                else
                {
                    grillaBeneficios.SelectedItem = grillaBeneficios.Items[0];
                    beneficioSeleccionado = (BeneficioClass)grillaBeneficios.Items[0];

                    btnSeleccionar.IsEnabled = true;
                    grillaBeneficios.Items.Refresh();
                }
            }
            else
            {
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                {
                    if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaBeneficio))
                    {

                        todo_ok = true;

                    }
                    else
                    {
                        todo_ok = false;
                    }
                    if (todo_ok)
                    {
                        _beneficios = BeneficioClass.ListarBeneficiosPorNombre(txtBusquedaBeneficio.Text.ToString());

                        grillaBeneficios.ItemsSource = _beneficios;

                        if (_beneficios.Count == 0)
                        {
                            btnSeleccionar.IsEnabled = false;
                            MessageBox.Show("No se encuentran beneficios con esos criterios de busqueda", "No se encuentran beneficios", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaBeneficios.Items.Refresh();
                        }
                        else
                        {
                            grillaBeneficios.SelectedItem = grillaBeneficios.Items[0];
                            beneficioSeleccionado = (BeneficioClass)grillaBeneficios.Items[0];
                            btnSeleccionar.IsEnabled = true;
                            grillaBeneficios.Items.Refresh();
                        }
                    }

                }
            }  
        }

        private void grillaBeneficios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficioSeleccionado = (BeneficioClass)grillaBeneficios.SelectedItem;
        }

        private void grillaBeneficios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            beneficioSeleccionado = (BeneficioClass)grillaBeneficios.SelectedItem;
            if (beneficioSeleccionado != null)
            {
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }
        }
    }
}
