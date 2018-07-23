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
    /// Lógica de interacción para IniciarSesionWindow.xaml
    /// </summary>
    public partial class IniciarSesionWindow : Window
    {
        public UsuarioClass usuario_logueado;
        public bool b_ok = false;
        public IniciarSesionWindow()
        {
            usuario_logueado = null;

            InitializeComponent();
        }

       
        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string nombre_usuario = txtUsuario.Text.ToString();
            UsuarioClass usuario = UsuarioClass.BuscarUsuarioPorNombre(nombre_usuario, true);

            string pass = txtContrasenia.Password.ToString();

            if(usuario != null)
            {
                if (usuario.ValidarPassword(pass))
                {
                    usuario_logueado = usuario;
                    b_ok = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta, verifique y vuelva a intentar", "Error al iniciar sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtContrasenia.Password = "";
                    txtContrasenia.Focus();
                    usuario_logueado = null;
                }
            }
            else
            {

                MessageBox.Show("El usuario no existe, verifique el usuario y vuelva a intentar", "Error al iniciar sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                usuario_logueado = null;
            }
            

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            usuario_logueado = null;
            this.Close();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtUsuario.Focus();
            txtUsuario.TabIndex = 0;
            txtContrasenia.TabIndex = 1;
            btnIniciarSesion.TabIndex = 2;
            btnCancelar.TabIndex = 3;
        }
    }
}
