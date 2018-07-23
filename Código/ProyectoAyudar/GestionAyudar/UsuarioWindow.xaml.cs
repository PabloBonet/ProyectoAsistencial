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
using System.Security.Cryptography;

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para UsuarioWindow.xaml
    /// </summary>
    public partial class UsuarioWindow : Window
    {
        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public UsuarioClass usuario;
        public bool b_ok = false;
        private List<UsuarioWindow> _ventanas;
        private List<PermisoClass> _permisos;
        
        public UsuarioWindow(Opcion op,UsuarioClass usuario, ref List<UsuarioWindow> ventanas)
        {
            InitializeComponent();

            opcion = op;
            this.usuario = null;
            if (op != Opcion.nuevo)
            {
                this.usuario = usuario;
            }

            _ventanas = ventanas;
            //_permisos = PermisoClass.ListarPermisos();

            _permisos = new List<PermisoClass>();
            //Items Source de la grilla
            grillaPermisos.ItemsSource = _permisos;


            //Inicializar componentes de la pantalla
            switch (op)
            {
                case Opcion.nuevo:
                    this.InicializarComponentesNuevo();
                    this.CargarDatosNuevo();
                    break;

                case Opcion.modificar:
                    this.InicializarComponentesModificar();
                    this.CargarDatosModificar();
                    break;

                case Opcion.consultar:
                    this.InicializarComponentesConsultar();
                    this.CargarDatosConsultar();
                    break;

            }
        }


        private void InicializarComponentesNuevo()
        {
            //txtBoxes
            txtNombreUsuario.IsReadOnly = false;
            txtNombreCompleto.IsReadOnly = false;
            txtContraseña.IsEnabled = true;
            txtContraseñaRepetir.IsEnabled = true;
            //txtContraseniaRep.IsEnabled = true;
            //txtContrasenia.IsEnabled = true;
            grillaPermisos.IsReadOnly = false;
            grillaColumnaPermitido.IsReadOnly = false;
            
            
            //Botones
            
            btnEliminarUsuario.IsEnabled = false;
            btnGuardarUsuario.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
            btnCambiarContrasenia.IsEnabled = false;
        }

        private void CargarDatosNuevo()
        {


            List<FuncionClass> funciones = FuncionClass.ListarFunciones();
            PermisoClass permiso  = null;

            foreach(FuncionClass f in funciones)
            {
                permiso = new PermisoClass();
                permiso.Permitido = false;
                permiso.Funcion = f;

                if(permiso != null)
                {
                    _permisos.Add(permiso);
                }

            }

            grillaPermisos.ItemsSource = _permisos;
            grillaPermisos.Items.Refresh();
        }


        private void InicializarComponentesModificar()
        {

            //txtBoxes
            txtNombreUsuario.IsReadOnly = true;
            txtNombreCompleto.IsReadOnly = false;
            txtContraseña.IsEnabled = false;
            txtContraseñaRepetir.IsEnabled = false;
            //txtContraseniaRep.IsEnabled = true;
            //txtContrasenia.IsEnabled = true;
            grillaPermisos.IsReadOnly = false;
            grillaColumnaPermitido.IsReadOnly = false;


            //Botones

            btnEliminarUsuario.IsEnabled = false;
            btnGuardarUsuario.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
            btnCambiarContrasenia.IsEnabled = true;

        }
        private void CargarDatosModificar()
        {
            txtNombreUsuario.Text = usuario.Nombre_usuario.ToString();
            txtNombreCompleto.Text = usuario.Nombre_completo.ToString();
            //txtContrasenia.Password = usuario.Contrasenia.ToString();
            //txtContraseniaRep.Password = usuario.Contrasenia.ToString();

            // _permisos = PermisoClass.ListarPermisosPorUsuario(usuario.Id_usuario);



            foreach(PermisoClass permiso in usuario.Permisos)
            {
                
                if (permiso != null)
                {
                    _permisos.Add(permiso);
                }
            }
            
            //_permisos = usuario.Permisos;
            grillaPermisos.ItemsSource = _permisos;
            grillaPermisos.Items.Refresh();

        }

        private void InicializarComponentesConsultar()
        {
            //txtBoxes
            txtNombreUsuario.IsReadOnly = true;
            txtNombreCompleto.IsReadOnly = true;
            txtContraseña.IsEnabled = false;
            txtContraseñaRepetir.IsEnabled = false;
            
            //txtContraseniaRep.IsEnabled = false;
            //txtContrasenia.IsEnabled = false;
            grillaPermisos.IsReadOnly = true;
            grillaColumnaPermitido.IsReadOnly = true;



            //Botones

            btnEliminarUsuario.IsEnabled = false;
            btnGuardarUsuario.IsEnabled = false;
            btnCancelarCambios.IsEnabled = true;
            btnCambiarContrasenia.IsEnabled = false;
        }

        private void CargarDatosConsultar()
        {
            txtNombreUsuario.Text = usuario.Nombre_usuario.ToString();
            txtNombreCompleto.Text = usuario.Nombre_completo.ToString();
            //txtContrasenia.Password = usuario.Contrasenia.ToString();
            //txtContraseniaRep.Password = usuario.Contrasenia.ToString();

            // _permisos = PermisoClass.ListarPermisosPorUsuario(usuario.Id_usuario);
            _permisos = usuario.Permisos;
            grillaPermisos.ItemsSource = _permisos;
            grillaPermisos.Items.Refresh();

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombreCompleto.TabIndex = 0;
            txtNombreUsuario.TabIndex = 1;
            btnEliminarUsuario.TabIndex = 2;
            btnCambiarContrasenia.TabIndex = 3;
            btnGuardarUsuario.TabIndex = 4;
            btnCancelarCambios.TabIndex = 5;
        }
        

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (usuario != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Usuario?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (usuario.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el usuario correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el usuario", "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            grillaPermisos.SelectedIndex = -1;
            grillaPermisos.CommitEdit();
            
            grillaPermisos.Items.Refresh();
            if (Validar())
            {
             
               
                if (opcion == Opcion.nuevo)
                {
                    UsuarioClass nuevoUsuario= new UsuarioClass();
                    nuevoUsuario.Nombre_completo = txtNombreCompleto.Text.ToString();
                    nuevoUsuario.Nombre_usuario = txtNombreUsuario.Text.ToString();
                    nuevoUsuario.Contrasenia = txtContraseña.Password.ToString();
                    //nuevoUsuario.Contrasenia = txtContrasenia.Password.ToString();

                    nuevoUsuario.Permisos = _permisos;

                    if (nuevoUsuario.NuevoUsuario())
                    {
                        MessageBox.Show("Usuario " + nuevoUsuario.Nombre_usuario + " creado con éxito", "Crear Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                        b_ok = true;
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + nuevoUsuario.Nombre_usuario + " no se pudo crear", "Crear Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                        b_ok = false;
                    }
                }
                else
                {
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Usuario " + usuario.Nombre_usuario+ "?", "Confirme modificar usuario", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                           
                           

                            usuario.Nombre_completo = txtNombreCompleto.Text.ToString();
                            usuario.Nombre_usuario = txtNombreUsuario.Text.ToString();
                            // usuario.Contrasenia = txtContrasenia.Password.ToString(); ;


                            usuario.Permisos = new List<PermisoClass>();
                            foreach(PermisoClass p in grillaPermisos.Items)
                            {
                                usuario.Permisos.Add(p);
                            }

                            //usuario.Permisos = _permisos;



                            if (usuario.ModificarUsuario())
                            {
                                MessageBox.Show("Usuario " + usuario.Nombre_usuario + " modificado con éxito", "Modificar usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El usuario " + usuario.Nombre_usuario + " no se pudo modificar", "Modificar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                                b_ok = false;
                            }
                        }

                    }
                }

            }
            else
            {
                MessageBox.Show("Hay Errores en la ventana. Corregir antes de continuar", "Existen Errores", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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


                if (t.Name != "txtContraseñaAnterior")
                {
                    if (t.Password == "")
                    {
                        t.Background = txtMal.Background;
                        t.ToolTip = "No puede quedar vacío";
                        r = false;
                    }

                }


            }

            if (opcion == Opcion.nuevo)
            {
                if (!txtContraseña.Password.ToString().Equals(txtContraseñaRepetir.Password) || txtContraseña.Password == "")
                {
                    txtContraseñaRepetir.Background = txtMal.Background;
                    txtContraseñaRepetir.ToolTip = "Las contraseñas son distintas";
                    txtContraseña.Background = txtMal.Background;
                    txtContraseña.ToolTip = "Las contraseñas son distintas";
                    r = false;
                }
              
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

        private void btnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            this.Owner.Focus();
        }

        private void btnModificarUsuario_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificarUsuario_Unchecked_1(object sender, RoutedEventArgs e)
        {

        }

        private void grillaOrdenesIniciadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void grillaPermisos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grillaPermisos.CommitEdit();
        }

        private void txtContrasenia_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            /*if (txtContrasenia.Password.Length > 0)
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
            }*/
        }

        private void txtContraseniaRep_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            /*if (txtContraseniaRep.Password.Length > 0)
            {
                if (txtContraseniaRep.Password.Length < 8)
                {
                    //hay error si tiene menos de 8 caracteres
                    txtContraseniaRep.Background = txtMal.Background;
                    txtContraseniaRep.ToolTip = "Debe tener 8 o más caracteres";
                    e.Handled = true;
                }
                else
                {
                    txtContraseniaRep.Background = txtBien.Background;
                    txtContraseniaRep.ToolTip = "Ingrese la contraseña";
                }

                if (txtContrasenia.Password != txtContraseniaRep.Password)
                {
                    txtContraseniaRep.Background = txtMal.Background;
                    txtContraseniaRep.ToolTip = "Las contraseñas no son iguales";
                    e.Handled = true;
                }
                else
                {
                    txtContraseniaRep.Background = txtBien.Background;
                    txtContraseniaRep.ToolTip = "Ingrese la contraseña";
                }

            }
            else
            {
                txtContraseniaRep.Background = txtBien.Background;
                txtContraseniaRep.ToolTip = "Ingrese la contraseña";
            }*/
        }

        private void btnCambiarContrasenia_Click(object sender, RoutedEventArgs e)
        {
            CambiarContraseniaWindow camConWin = new CambiarContraseniaWindow(usuario);

            camConWin.Owner = this;
            camConWin.ShowDialog();
            camConWin = null;
        }

        private void txtContraseña_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtContraseña.Password.Length > 0)
            {
                if (txtContraseña.Password.Length < 8)
                {
                    //hay error si tiene menos de 8 caracteres
                    txtContraseña.Background = txtMal.Background;
                    txtContraseña.ToolTip = "Debe tener 8 o más caracteres";
                    e.Handled = true;
                }
                else
                {
                    txtContraseña.Background = txtBien.Background;
                    txtContraseña.ToolTip = "Ingrese la contraseña";
                }
            }
            else
            {
                txtContraseña.Background = txtBien.Background;
                txtContraseña.ToolTip = "Ingrese la contraseña";
            }
        }

        private void txtContraseñaRepetir_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtContraseñaRepetir.Password.Length > 0)
            {
                if (txtContraseñaRepetir.Password.Length < 8)
                {
                    //hay error si tiene menos de 8 caracteres
                    txtContraseñaRepetir.Background = txtMal.Background;
                    txtContraseñaRepetir.ToolTip = "Debe tener 8 o más caracteres";
                    e.Handled = true;
                }
                else
                {
                    txtContraseñaRepetir.Background = txtBien.Background;
                    txtContraseñaRepetir.ToolTip = "Ingrese la contraseña";
                }

                if (txtContraseña.Password != txtContraseñaRepetir.Password)
                {
                    txtContraseñaRepetir.Background = txtMal.Background;
                    txtContraseñaRepetir.ToolTip = "Las contraseñas no son iguales";
                    e.Handled = true;
                }
                else
                {
                    txtContraseñaRepetir.Background = txtBien.Background;
                    txtContraseñaRepetir.ToolTip = "Ingrese la contraseña";
                }
            }
           }
    }
}
