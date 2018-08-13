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
    /// Lógica de interacción para BeneficioWindow.xaml
    /// </summary>
    public partial class BeneficioWindow : Window
    {

        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public BeneficioClass beneficio;
        public bool b_ok = false;
        private List<BeneficioWindow> _ventanas;
        
        public BeneficioWindow(Opcion op, BeneficioClass beneficio, ref List<BeneficioWindow> ventanas)
        {
            InitializeComponent();

            opcion = op;
            this.beneficio = new BeneficioClass();
            
            if (op != Opcion.nuevo)
            {
                this.beneficio = beneficio;
            }

            
            _ventanas = ventanas;
            

            //Inicializar componentes de la pantalla
            switch (op)
            {
                case Opcion.nuevo:
                    this.InicializarComponentesNuevo();
                  
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
            txtNombre.IsReadOnly = false;
            txtDescripcion.IsReadOnly = false;

            

            //Botones

            btnEliminarBeneficio.IsEnabled = false;
            btnGuardarBeneficio.IsEnabled = true;
            btnCancelarBeneficio.IsEnabled = true;
        }

        private void InicializarComponentesModificar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtDescripcion.IsReadOnly = false;

           

            //Botones

            btnEliminarBeneficio.IsEnabled = true;
            btnGuardarBeneficio.IsEnabled = true;
            btnCancelarBeneficio.IsEnabled = true;
        }

        private void CargarDatosModificar()
        {
            if(beneficio != null)
            {
                txtNombre.Text = beneficio.Nombre_beneficio.ToString();
                txtDescripcion.Text = beneficio.Descripcion_beneficio.ToString();

               
            }
            
            


        }
        private void InicializarComponentesConsultar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtDescripcion.IsReadOnly = true;

        
            //Botones

            btnEliminarBeneficio.IsEnabled = false;
            btnGuardarBeneficio.IsEnabled = false;
            btnCancelarBeneficio.IsEnabled = true;
            
        }

        private void CargarDatosConsultar()
        {
            if (beneficio != null)
            {
                txtNombre.Text = beneficio.Nombre_beneficio.ToString();
                txtDescripcion.Text = beneficio.Descripcion_beneficio.ToString();

            
            }


        }


      
        

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombre.TabIndex = 0;
            txtDescripcion.TabIndex = 1;
           

        }
        

        
        private bool Validar()
        {
            bool r = true;

            blanquear();


            foreach (TextBox t in FindVisualChildren<TextBox>(this))
            {



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
            
            return r;

        }
        private void blanquear()
        {
            foreach (TextBox r in FindVisualChildren<TextBox>(this))
            {
                if (r.Name != "txtMal" && r.Name != "txtBien")
                {
                    r.Background = txtBien.Background;
                    r.ToolTip = "";
                }



            }
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
    
        private void btnEliminarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            if (beneficio != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Beneficio?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (beneficio.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el beneficio correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);

                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el beneficio", "Eliminar Beneficio", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnGuardarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                if (opcion == Opcion.nuevo)
                {

                    BeneficioClass nuevoBeneficio = new BeneficioClass();
                    nuevoBeneficio.Nombre_beneficio = txtNombre.Text.ToString();
                    nuevoBeneficio.Descripcion_beneficio = txtDescripcion.Text.ToString();
                    
                    if (nuevoBeneficio.NuevoBeneficio())
                    {
                        MessageBox.Show("Beneficio " + nuevoBeneficio.Nombre_beneficio + " creado con éxito", "Crear Beneficio", MessageBoxButton.OK, MessageBoxImage.Information);
                        beneficio = nuevoBeneficio;
                        b_ok = true;
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El Beneficio" + nuevoBeneficio.Nombre_beneficio + " no se pudo crear", "Crear Beneficio", MessageBoxButton.OK, MessageBoxImage.Error);
                        b_ok = false;
                    }
                }
                else
                {
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Beneficio " + beneficio.Nombre_beneficio + "?", "Confirme modificar Beneficio", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                            beneficio.Nombre_beneficio = txtNombre.Text.ToString();
                            beneficio.Descripcion_beneficio = txtDescripcion.Text.ToString();

                            

                            if (beneficio.ModificarBeneficio())
                            {
                                MessageBox.Show("Beneficio " + beneficio.Nombre_beneficio + " modificado con éxito", "Modificar Beneficio", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El Beneficio " + beneficio.Nombre_beneficio + " no se pudo modificar", "Modificar Beneficio", MessageBoxButton.OK, MessageBoxImage.Error);
                                b_ok = false;
                            }
                        }

                    }
                }
            }
        }

        private void btnCancelarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            beneficio = null;
            this.Close();
            this.Owner.Focus();
        }
    }
}
