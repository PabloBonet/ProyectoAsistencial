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
    public partial class BuscarBeneficiarioWindow : Window
    {
        public BeneficiarioClass beneficiarioSeleccionado;
        private List<BeneficiarioClass> _beneficiarios;
        private CriterioBusqueda _criterio_de_busqueda;
        private List<BeneficiarioWindow> _ventanasBeneficiarios;
        public bool b_ok = false;
        public BuscarBeneficiarioWindow()
        {
            InitializeComponent();

            beneficiarioSeleccionado = null;

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            _beneficiarios = new List<BeneficiarioClass>();

            _ventanasBeneficiarios = new List<BeneficiarioWindow>();

            grillaBeneficiarios.ItemsSource = _beneficiarios;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnSeleccionar.IsEnabled = false;
            btnBuscarBeneficiario.IsEnabled = true;
          
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }

        private void rdbDocumento_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Dni;
        }

        private void btnBuscarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            bool todo_ok = false;

            _beneficiarios = new List<BeneficiarioClass>();

            grillaBeneficiarios.ItemsSource = _beneficiarios;

            string beneficiarioBuscar = txtBusquedaBeneficiario.Text.ToString().Trim();

            if (txtBusquedaBeneficiario.Text.Length == 0)
            {
                _beneficiarios = BeneficiarioClass.ListarBeneficiarios();

                grillaBeneficiarios.ItemsSource = _beneficiarios;

                if (_beneficiarios.Count == 0)
                {
                   
                    MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                    btnSeleccionar.IsEnabled = false;
                    grillaBeneficiarios.ItemsSource = _beneficiarios;
                }
                else
                {
                    grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                    beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];

                    btnSeleccionar.IsEnabled = true;
                    grillaBeneficiarios.Items.Refresh();
                }
            }
            else
            {
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                {
                    if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaBeneficiario))
                    {

                        todo_ok = true;

                    }
                    else
                    {
                        todo_ok = false;
                    }
                    if (todo_ok)
                    {
                        _beneficiarios = BeneficiarioClass.ListarBeneficiariosPorNombre(txtBusquedaBeneficiario.Text.ToString());

                        grillaBeneficiarios.ItemsSource = _beneficiarios;

                        if (_beneficiarios.Count == 0)
                        {
                            btnSeleccionar.IsEnabled = false;
                            MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);
                           
                            grillaBeneficiarios.Items.Refresh();
                        }
                        else
                        {
                            grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];
                            btnSeleccionar.IsEnabled = true;
                            grillaBeneficiarios.Items.Refresh();
                        }
                    }

                }
                else
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Dni)
                {


                    if (ValidacionesClass.ValidarNumericoTextBox(txtBusquedaBeneficiario))
                    {
                        todo_ok = true;
                    }
                    else
                    {
                        todo_ok = false;
                    }

                    if (todo_ok)
                    {
                        
                        List<BeneficiarioClass> beneficiarios = BeneficiarioClass.ListarBeneficiarioPorCriterio(txtBusquedaBeneficiario.Text, _criterio_de_busqueda);
                        foreach (BeneficiarioClass beneficiario in beneficiarios)
                        {
                            _beneficiarios.Add(beneficiario);


                        }

                        grillaBeneficiarios.ItemsSource = _beneficiarios;
                        if (_beneficiarios.Count == 0)
                        {
                            btnSeleccionar.IsEnabled = false;

                            MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaBeneficiarios.Items.Refresh();
                        }
                        else
                        {
                            grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];
                            btnSeleccionar.IsEnabled = true;
                            grillaBeneficiarios.Items.Refresh();
                        }
                    }

                    
                    
                  /*  if (todo_ok)
                    {
                        BeneficiarioClass beneficiario = BeneficiarioClass.BuscarBeneficiario(txtBusquedaBeneficiario.Text, _criterio_de_busqueda);

                        if (beneficiario != null)
                        {
                            _beneficiarios.Add(beneficiario);
                            grillaBeneficiarios.ItemsSource = _beneficiarios;

                        }

                        if (_beneficiarios.Count == 0)
                        {
                            btnSeleccionar.IsEnabled = false;

                            MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaBeneficiarios.Items.Refresh();
                        }
                        else
                        {
                            grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];
                            btnSeleccionar.IsEnabled = true;
                            grillaBeneficiarios.Items.Refresh();
                        }
                    }
                    */

                }

            }

        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.SelectedItem;
            b_ok = true;
            this.Close();
            this.Owner.Focus();
        }

        private void grillaBeneficiarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.SelectedItem;
        }

        private void grillaBeneficiarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.SelectedItem;
            if(beneficiarioSeleccionado != null)
            {
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }
            
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            BeneficiarioWindow benWin = new BeneficiarioWindow(BeneficiarioWindow.Opcion.nuevo, null, ref _ventanasBeneficiarios);
            benWin.Owner = this;
            _ventanasBeneficiarios.Add(benWin);
            benWin.ShowDialog();

            if (benWin.b_ok)
            {
                beneficiarioSeleccionado = benWin.beneficiario;
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaBeneficiario.Focus();

            rdbNombre.TabIndex = 3;
            rdbDocumento.TabIndex = 4;
            txtBusquedaBeneficiario.TabIndex = 0;
            btnBuscarBeneficiario.TabIndex = 1;
            btnNuevo.TabIndex = 2;
        }
    }
}
