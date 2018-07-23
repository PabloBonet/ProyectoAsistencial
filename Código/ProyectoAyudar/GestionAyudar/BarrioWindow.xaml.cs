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
using Processar.ProyectoAyudar.DatosLibrary;
using Processar.ProyectoAyudar.ClasesLibrary;

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para BarrioWindow.xaml
    /// </summary>
    /// 
    public partial class BarrioWindow : Window
    {
        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public BarrioClass barrio;

        public bool b_ok = false;
        private bool modifico;
        private List<BarrioWindow> _ventanas;

        public BarrioWindow(Opcion op, BarrioClass barrio, ref List<BarrioWindow> ventanas)
        {
            InitializeComponent();

            opcion = op;
           
            if (op != Opcion.nuevo)
            {
                
                this.barrio = barrio;
            }
            else
            {
                barrio = null;
            }

            _ventanas = ventanas;
            modifico = false;

            //Inicializar componentes de la pantalla
            switch (op)
            {
                case Opcion.nuevo:
                    this.InicializarComponentesNuevo();
                    this.modifico = true;
                    
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
            txtCiudad.IsReadOnly = false;

            
            //Botones
            
            btnEliminarBarrio.IsEnabled = false;
            btnGuardarBarrio.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
        }
        private void InicializarComponentesModificar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtCiudad.IsReadOnly = false;


            //Botones
           
            btnEliminarBarrio.IsEnabled = true;
            btnGuardarBarrio.IsEnabled = true;
            btnCancelarCambios.IsEnabled = true;
        }

        private void InicializarComponentesConsultar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtCiudad.IsReadOnly = true;


            //Botones
           
            btnEliminarBarrio.IsEnabled = false;
            btnGuardarBarrio.IsEnabled = false;
            btnCancelarCambios.IsEnabled = true;
        }

        private void CargarDatosModificar()
        {
            if(barrio != null)
            {
                txtNombre.Text = barrio.Nombre.ToString();
                txtCiudad.Text = barrio.Ciudad.ToString();
            }
            
        }

        private void CargarDatosConsultar()
        {
            if(barrio != null)
            {
                txtNombre.Text = barrio.Nombre.ToString();
                txtCiudad.Text = barrio.Ciudad.ToString();
            }
            
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtNombre.TabIndex = 0;
            txtCiudad.TabIndex = 1;
            btnGuardarBarrio.TabIndex = 2;
            btnCancelarCambios.TabIndex = 3;

        }

        
        

        private void btnEliminarBarrio_Click(object sender, RoutedEventArgs e)
        {
            //BarrioClass b = new BarrioClass();
            //b = BarrioClass.BuscarBarrioPorId(barrio.IdBarrio);
            

            MessageBoxResult mr;
            mr = MessageBox.Show("¿Confirma Eliminar el Barrio?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (mr == MessageBoxResult.Yes)
            {
                if (barrio.Eliminar())
                {
                    MessageBox.Show("Se ha eliminado el barrio correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                    b_ok = true;
                    barrio = null;
                    this.Close();
                    this.Owner.Focus();
                }
            }
        }

        private void btnGuardarBarrio_Click(object sender, RoutedEventArgs e)
        {
         
            if(modifico && validar())
            {
               
                if (opcion == Opcion.nuevo)
                {
                    BarrioClass nuevoBarrio = new BarrioClass();
                    nuevoBarrio.Nombre = txtNombre.Text.ToString();
                    nuevoBarrio.Ciudad = txtCiudad.Text.ToString();

                    if(nuevoBarrio.NuevoBarrio())
                    {
                        MessageBox.Show("Barrio " + nuevoBarrio.Nombre + " creado con éxito", "Crear Barrio", MessageBoxButton.OK, MessageBoxImage.Information);
                        b_ok = true;
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El barrio " + nuevoBarrio.Nombre + " no se pudo crear", "Crear Barrio", MessageBoxButton.OK, MessageBoxImage.Information);
                        b_ok = false;
                    }
                }
                else
                {
                    if(opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Barrio " + barrio.Nombre + "?", "Confirme modificar Barrio", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                            barrio.Nombre = txtNombre.Text.ToString();
                            barrio.Ciudad = txtCiudad.Text.ToString();
                            if (barrio.ModificarBarrio())
                            {
                                MessageBox.Show("Barrio " + barrio.Nombre + " modificado con éxito", "Modificar Barrio", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El barrio " + barrio.Nombre + " no se pudo modificar", "Modificar Barrio", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = false;
                            }
                        }

                        }
                }
                
            }   
        }

        private void btnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            b_ok = false;
            this.Owner.Focus();
        }

        private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Indica que alguno de los campos se modificó
            modifico = true;
        }

        private bool validar()
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
    }
}
