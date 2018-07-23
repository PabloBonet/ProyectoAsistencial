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
    /// Lógica de interacción para AdministrarBeneficiariosWindow.xaml
    /// </summary>
    public partial class AdministrarBeneficiariosWindow : Window
    {
        private List<BeneficiarioWindow> _ventanasBeneficiarios;
        private BeneficiarioClass beneficiarioSeleccionado;
        private List<BeneficiarioClass> _beneficiarios;
        private CriterioBusqueda _criterio_de_busqueda;
        public bool b_ok = false;
        //private bool _con_seleccion;
        public AdministrarBeneficiariosWindow()
        {

            InitializeComponent();
          
            _ventanasBeneficiarios = new List<BeneficiarioWindow>();
            beneficiarioSeleccionado = null;
            
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
           

            _beneficiarios = new List<BeneficiarioClass>();

            grillaBeneficiarios.ItemsSource = _beneficiarios;

            cargarComponentes();
            
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnAbrirBeneficiario.IsEnabled = false;
            btnEliminarBeneficiario.IsEnabled = false;
           // btnSeleccionar.IsEnabled = _con_seleccion;
            btnModificarBeneficiario.IsEnabled = false;
        }

        private void btnNuevoBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            BeneficiarioWindow benWin = new BeneficiarioWindow(BeneficiarioWindow.Opcion.nuevo, null,ref _ventanasBeneficiarios);
            benWin.Owner = this;
            _ventanasBeneficiarios.Add(benWin);
            benWin.Show();
        }

        private void btnAbrirBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            if(beneficiarioSeleccionado != null)
            {
                BeneficiarioWindow benWin = new BeneficiarioWindow(BeneficiarioWindow.Opcion.consultar, beneficiarioSeleccionado, ref _ventanasBeneficiarios);
                benWin.Owner = this;
                _ventanasBeneficiarios.Add(benWin);
                benWin.Show();
            }
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (beneficiarioSeleccionado != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Beneficiario?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (beneficiarioSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el beneficiario correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _beneficiarios.Remove(beneficiarioSeleccionado);
                        grillaBeneficiarios.Items.Refresh();
                        

                    }
                }
            }
        }

    

        private void btnBuscarBeneficiario_Click(object sender, RoutedEventArgs e)
        {

            BuscarBeneficiario();

        }

        private void grillaBeneficiarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.SelectedItem;
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.SelectedItem;
            b_ok = true;
            this.Close();
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }

        private void rdbDocumento_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Dni;
        }

        private void btnModificarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            if (beneficiarioSeleccionado != null)
            {
                //Verifica que el beneficiario no este abierto, si no esta abierta crea la ventana y la agrega a la lista

                BeneficiarioWindow BeneficiarioWin = new BeneficiarioWindow(BeneficiarioWindow.Opcion.modificar, beneficiarioSeleccionado, ref _ventanasBeneficiarios);

                BeneficiarioWin.Owner = this;
                _ventanasBeneficiarios.Add(BeneficiarioWin);
                BeneficiarioWin.Show();
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void txtBusquedaBeneficiario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarBeneficiario();
            }
        }

        private void BuscarBeneficiario()
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
                    btnAbrirBeneficiario.IsEnabled = false;
                    btnEliminarBeneficiario.IsEnabled = false;
                    btnModificarBeneficiario.IsEnabled = false;
                    MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaBeneficiarios.ItemsSource = _beneficiarios;
                }
                else
                {
                    grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                    beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];

                    btnEliminarBeneficiario.IsEnabled = true;
                    btnAbrirBeneficiario.IsEnabled = true;
                    btnModificarBeneficiario.IsEnabled = true;
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
                            btnAbrirBeneficiario.IsEnabled = false;
                            btnEliminarBeneficiario.IsEnabled = false;
                            btnModificarBeneficiario.IsEnabled = false;

                            MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaBeneficiarios.Items.Refresh();
                        }
                        else
                        {
                            grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];
                            btnAbrirBeneficiario.IsEnabled = true;
                            btnEliminarBeneficiario.IsEnabled = true;
                            btnModificarBeneficiario.IsEnabled = true;
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
                        BeneficiarioClass beneficiario = BeneficiarioClass.BuscarBeneficiario(txtBusquedaBeneficiario.Text, _criterio_de_busqueda);

                        if (beneficiario != null)
                        {
                            _beneficiarios.Add(beneficiario);
                            grillaBeneficiarios.ItemsSource = _beneficiarios;

                        }

                        if (_beneficiarios.Count == 0)
                        {
                            btnAbrirBeneficiario.IsEnabled = false;
                            btnEliminarBeneficiario.IsEnabled = false;
                            btnModificarBeneficiario.IsEnabled = false;

                            MessageBox.Show("No se encuentran beneficiarios con esos criterios de busqueda", "No se encuentran beneficiarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaBeneficiarios.Items.Refresh();
                        }
                        else
                        {
                            grillaBeneficiarios.SelectedItem = grillaBeneficiarios.Items[0];
                            beneficiarioSeleccionado = (BeneficiarioClass)grillaBeneficiarios.Items[0];
                            btnAbrirBeneficiario.IsEnabled = true;
                            btnEliminarBeneficiario.IsEnabled = true;
                            btnModificarBeneficiario.IsEnabled = true;
                            grillaBeneficiarios.Items.Refresh();
                        }
                    }

                }

            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaBeneficiario.Focus();
            txtBusquedaBeneficiario.TabIndex = 0;
            btnBuscarBeneficiario.TabIndex = 1;
            btnAbrirBeneficiario.TabIndex = 2;
            btnNuevoBeneficiario.TabIndex = 3;
            btnModificarBeneficiario.TabIndex = 4;
            btnEliminarBeneficiario.TabIndex = 5;
        }
    }
}
