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
    /// Lógica de interacción para AdministrarUsuarioWindow.xaml
    /// </summary>
    public partial class AdministrarUsuarioWindow : Window
    {

        private List<UsuarioWindow> _ventanasUsuarios;
        private UsuarioClass _usuarioSeleccionado;
        private List<UsuarioClass> _usuarios;
        private CriterioBusqueda _criterio_de_busqueda;
        public bool b_ok = false;
        public AdministrarUsuarioWindow()
        {
            InitializeComponent();

            _ventanasUsuarios = new List<UsuarioWindow>();
           _usuarioSeleccionado = null;

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;

            _usuarios = new List<UsuarioClass>();

            grillaUsuarios.ItemsSource = _usuarios;
            

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnAbrirUsuario.IsEnabled = false;
            btnEliminarUsuario.IsEnabled = false;
            
            btnModificarUsuario.IsEnabled = false;
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioWindow usuarioWin = new UsuarioWindow(UsuarioWindow.Opcion.nuevo, null, ref _ventanasUsuarios);
            usuarioWin.Owner = this;
            _ventanasUsuarios.Add(usuarioWin);
            usuarioWin.Show();
            
        }

        private void btnAbrirUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (_usuarioSeleccionado != null)
            {
                UsuarioWindow usuarioWin = new UsuarioWindow(UsuarioWindow.Opcion.consultar, _usuarioSeleccionado, ref _ventanasUsuarios);
                usuarioWin.Owner = this;
                _ventanasUsuarios.Add(usuarioWin);
                usuarioWin.Show();
                
            }
        }

     
      
        private void btnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            BuscarUsuario();
        }

       

        private void grillaUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           _usuarioSeleccionado = (UsuarioClass)grillaUsuarios.SelectedItem;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }

      

        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (_usuarioSeleccionado != null)
            {
                UsuarioWindow usuarioWin = new UsuarioWindow(UsuarioWindow.Opcion.modificar, _usuarioSeleccionado, ref _ventanasUsuarios);
                usuarioWin.Owner = this;
                _ventanasUsuarios.Add(usuarioWin);
                usuarioWin.Show();

            }
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (_usuarioSeleccionado != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Usuario?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (_usuarioSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el usuario correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _usuarios.Remove(_usuarioSeleccionado);
                        grillaUsuarios.Items.Refresh();

                    }
                }
            }
        }

        private void txtBusquedaUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarUsuario();
            }
        }

        private void BuscarUsuario()
        {
            bool todo_ok = false;


            _usuarios = new List<UsuarioClass>();
            grillaUsuarios.ItemsSource = _usuarios;

            string usuarioBuscar = txtBusquedaUsuario.Text.ToString().Trim();


            if (txtBusquedaUsuario.Text.Length == 0)
            {

                _usuarios = UsuarioClass.ListarUsuarios(true);

                grillaUsuarios.ItemsSource = _usuarios;


                if (_usuarios.Count == 0)
                {
                    btnAbrirUsuario.IsEnabled = false;
                    btnEliminarUsuario.IsEnabled = false;
                    btnModificarUsuario.IsEnabled = false;

                    MessageBox.Show("No se encuentran usuarios con esos criterios de busqueda", "No se encuentran usuarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaUsuarios.ItemsSource = _usuarios;
                }
                else
                {
                    grillaUsuarios.SelectedItem = grillaUsuarios.Items[0];
                    _usuarioSeleccionado = (UsuarioClass)grillaUsuarios.Items[0];


                    btnAbrirUsuario.IsEnabled = true;
                    btnEliminarUsuario.IsEnabled = true;
                    btnModificarUsuario.IsEnabled = true;
                    grillaUsuarios.Items.Refresh();
                }
            }
            else
            {
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre)
                {
                    if (ValidacionesClass.ValidarApellidoNombreTextBox(txtBusquedaUsuario))
                    {

                        todo_ok = true;

                    }
                    else
                    {
                        todo_ok = false;
                    }
                    if (todo_ok)
                    {
                        _usuarios = UsuarioClass.ListarUsuariosPorNombre(txtBusquedaUsuario.Text.ToString(), true);

                        grillaUsuarios.ItemsSource = _usuarios;


                        if (_usuarios.Count == 0)
                        {
                            btnAbrirUsuario.IsEnabled = false;
                            btnEliminarUsuario.IsEnabled = false;
                            btnModificarUsuario.IsEnabled = false;

                            MessageBox.Show("No se encuentran usuarios con esos criterios de busqueda", "No se encuentran usuarios", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaUsuarios.Items.Refresh();

                        }
                        else
                        {

                            grillaUsuarios.SelectedItem = grillaUsuarios.Items[0];
                            _usuarioSeleccionado = (UsuarioClass)grillaUsuarios.Items[0];

                            btnAbrirUsuario.IsEnabled = true;
                            btnEliminarUsuario.IsEnabled = true;
                            btnModificarUsuario.IsEnabled = true;
                            grillaUsuarios.Items.Refresh();
                        }
                    }

                }

            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaUsuario.Focus();
            txtBusquedaUsuario.TabIndex = 0;
            btnBuscarUsuario.TabIndex = 1;
            btnAbrirUsuario.TabIndex = 2;
            btnNuevoUsuario.TabIndex = 3;
            btnModificarUsuario.TabIndex = 4;
            btnEliminarUsuario.TabIndex = 5;
        }
    }
}
