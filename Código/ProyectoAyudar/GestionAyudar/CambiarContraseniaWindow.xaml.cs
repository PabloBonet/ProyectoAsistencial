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
    /// Lógica de interacción para CambiarContraseniaWindow.xaml
    /// </summary>
    public partial class CambiarContraseniaWindow : Window
    {
        public UsuarioClass usuario;
        public bool b_ok = false;
        public CambiarContraseniaWindow(UsuarioClass usu)
        {

            InitializeComponent();
            if(usu != null)
            {
                usuario = usu;

                lblNombreUsuario.Content = usuario.Nombre_usuario.ToString();

            }
        }



        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            this.usuario = null;
            this.Owner.Focus();
            this.Close();

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtContraseniaAnt.TabIndex = 0;
            txtContrasenia.TabIndex = 1;
            txtRepetirContrasenia.TabIndex = 2;
            btnAceptar.TabIndex = 3;
            btnCancelar.TabIndex = 4;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                MessageBoxResult msg;
                msg = MessageBox.Show("¿Seguro que desea modificar la contraseña?", "Confirme cambiar contraseña", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (msg == MessageBoxResult.Yes)
                {
                    string pass = txtContrasenia.Password.ToString();
                    string passAnterior = txtContraseniaAnt.Password.ToString();
                    if(usuario.ValidarPassword(passAnterior))
                    {
                        usuario.Contrasenia = pass;
                        if (usuario.ModificarUsuario())
                        {
                            MessageBox.Show("Contraseña de usuario " + usuario.Nombre_usuario + " modificada con éxito", "Cambiar contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                            b_ok = true;
                            this.Close();
                            this.Owner.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al modificar la contraeña del usuario " + usuario.Nombre_usuario + "", "Cambiar contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                            b_ok = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña anterio no es correcta", "Error de contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                        b_ok = false;
                    }
                    
                }
                else
                {
                    b_ok = false;
                }


            }
        }
        private bool Validar()
        {
            bool r = true;

            foreach (TextBox t in FindVisualChildren<TextBox>(this))
            {

                //MessageBox.Show(t.ToString(),t.Name);

                if (t.Name != "txtMal" && t.Name != "txtBien")
                {

                    t.Background = txtBien.Background;
                    t.ToolTip = "";

                }
            }




            //  Blanquear();


            foreach (TextBox t in FindVisualChildren<TextBox>(this))
            {

                //MessageBox.Show(t.ToString(),t.Name);

                if (t.Name != "txtMal" && t.Name != "txtBien")
                {


                    if (t.Text == "")
                    {
                        t.Background = txtMal.Background;
                        t.ToolTip = "No puede quedar vacío";
                        r = false;
                    }
                }
            }


            foreach (PasswordBox t in FindVisualChildren<PasswordBox>(this))
            {


                if (t.Name != "txtContraseniaAnt")
                {
                    if (t.Password == "")
                    {
                        t.Background = txtMal.Background;
                        t.ToolTip = "No puede quedar vacío";
                        r = false;
                    }

                }


            }

            /*if (!usuario.ValidarPassword(txtRepetirContrasenia.Password))
             {
                 txtRepetirContrasenia.Background = txtMal.Background;
                 txtRepetirContrasenia.ToolTip = "La contraseña no es correcta";
                 r = false;
             }*/
            

            if (!txtContrasenia.Password.ToString().Equals( txtRepetirContrasenia.Password))
            {
                txtRepetirContrasenia.Background = txtMal.Background;
                txtRepetirContrasenia.ToolTip = "Las contraseñas son distintas";
                txtContrasenia.Background = txtMal.Background;
                txtContrasenia.ToolTip = "Las contraseñas son distintas";
                r = false;
            }




            return r;

        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void txtContraseniaAnt_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtContraseniaAnt.Password.Length > 0)
            {
                if (txtContraseniaAnt.Password.Length < 8)
                {
                    //hay error si tiene menos de 8 caracteres
                    txtContraseniaAnt.Background = txtMal.Background;
                    txtContraseniaAnt.ToolTip = "Debe tener 8 o más caracteres";
                    e.Handled = true;
                }
                else
                {
                    txtContraseniaAnt.Background = txtBien.Background;
                    txtContraseniaAnt.ToolTip = "Ingrese la contraseña";
                }
            }
            else
            {
                txtContraseniaAnt.Background = txtBien.Background;
                txtContraseniaAnt.ToolTip = "Ingrese la contraseña";
            }
        }

        private void txtContrasenia_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtContrasenia.Password.Length > 0)
            {
                if (txtContrasenia.Password.Length < 8)
                {
                    //hay error si tiene menos de 8 caracteres
                    txtContrasenia.Background = txtMal.Background;
                    txtContrasenia.ToolTip = "Debe tener 8 o más caracteres";
                    e.Handled = true;
                }
                else
                {
                    txtContrasenia.Background = txtBien.Background;
                    txtContrasenia.ToolTip = "Ingrese la contraseña";
                }
            }
            else
            {
                txtContrasenia.Background = txtBien.Background;
                txtContrasenia.ToolTip = "Ingrese la contraseña";
            }
        }

        private void txtRepetirContrasenia_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtRepetirContrasenia.Password.Length > 0)
            {
                if (txtRepetirContrasenia.Password.Length < 8)
                {
                    //hay error si tiene menos de 8 caracteres
                    txtRepetirContrasenia.Background = txtMal.Background;
                    txtRepetirContrasenia.ToolTip = "Debe tener 8 o más caracteres";
                    e.Handled = true;
                }
                else
                {
                    txtRepetirContrasenia.Background = txtBien.Background;
                    txtRepetirContrasenia.ToolTip = "Ingrese la contraseña";
                }

                if (txtContrasenia.Password != txtRepetirContrasenia.Password)
                {
                    txtRepetirContrasenia.Background = txtMal.Background;
                    txtRepetirContrasenia.ToolTip = "Las contraseñas no son iguales";
                    e.Handled = true;
                }
                else
                {
                    txtRepetirContrasenia.Background = txtBien.Background;
                    txtRepetirContrasenia.ToolTip = "Ingrese la contraseña";
                }

            }
            else
            {
             txtRepetirContrasenia.Background = txtBien.Background;
                txtRepetirContrasenia.ToolTip = "Ingrese la contraseña";
            }
            
        }
    }

    
}
