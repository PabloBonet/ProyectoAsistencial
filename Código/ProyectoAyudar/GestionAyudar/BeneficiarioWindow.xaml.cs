﻿using System;
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
using Processar.ProyectoAyudar.DatosLibrary;
using Processar.ProyectoAyudar.ReportesLibrary;

namespace Processar.ProyectoAyudar.GestionAyudar
{
    /// <summary>
    /// Lógica de interacción para BeneficiarioWindow.xaml
    /// </summary>
    public partial class BeneficiarioWindow : Window
    {
        public enum Opcion
        {
            nuevo = 1, modificar, consultar

        };

        public Opcion opcion;
        public BeneficiarioClass beneficiario;
        public bool b_ok = false;
        private List<BeneficiarioWindow> _ventanas;
        private List<BarrioClass> _barrios;
        private List<GrupoBeneficiarioClass> _grupos;
        private List<BeneficioBeneficiarioClass> _beneficiosAsignados;
        private List<BeneficioClass> _beneficios;
        private BeneficioBeneficiarioClass _beneficioBeneficiarioSeleccionado;
        
        public BeneficiarioWindow(Opcion op, BeneficiarioClass beneficiario, ref List<BeneficiarioWindow> ventanas)
        {
            InitializeComponent();

            opcion = op;
            this.beneficiario = null;
            if (op != Opcion.nuevo)
            {
                this.beneficiario = beneficiario;
               // beneficiario.Beneficios = BeneficioBeneficiarioClass.ListarBeneficioPorBeneficiario(beneficiario.Id_beneficiario);
            }
          
                
            
    
            _ventanas = ventanas;
            _barrios = BarrioClass.ListarBarrios();
            _grupos = new List<GrupoBeneficiarioClass>();
            _beneficiosAsignados = new List<BeneficioBeneficiarioClass>();
            _beneficioBeneficiarioSeleccionado = null;
            //Carga de beneficios
            _beneficios = BeneficioClass.ListarBeneficios();
            cmbBeneficios.ItemsSource = _beneficios;

            //Items Source de el combo Barrio
            cmbBarrio.ItemsSource = _barrios;
            grillaGrupos.ItemsSource = _grupos;

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
            txtNombre.IsReadOnly = false;
            txtDireccion.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
            txtDocumento.IsReadOnly = false;
            txtCuitCuil.IsReadOnly = false;
            cmbBarrio.IsEnabled = true;

            //Botones
           
            btnEliminarBeneficiario.IsEnabled = false;
            btnGuardarBeneficiario.IsEnabled = true;
            btnGuardarBeneficiario.Label = "Crear";
            btnCancelarCambios.IsEnabled = true;
            btnAgregarBeneficio.IsEnabled = true;
            btnQuitarBeneficio.IsEnabled = true;
            btnBuscarBeneficio.IsEnabled = true;
        }

        private void CargarDatosNuevo()
        {
            cmbBeneficios.Items.Refresh();
            cmbBarrio.Items.Refresh();
            grillaGrupos.Items.Refresh();
        }


        private void InicializarComponentesModificar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = false;
            txtDireccion.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
            txtDocumento.IsReadOnly = true;
            txtCuitCuil.IsReadOnly = false;

            cmbBarrio.IsEnabled = true;
      

            //Botones

            btnEliminarBeneficiario.IsEnabled = true;
            btnGuardarBeneficiario.IsEnabled = true;
            btnGuardarBeneficiario.Label = "Guardar";
            btnCancelarCambios.IsEnabled = true;
            btnAgregarBeneficio.IsEnabled = true;
            btnQuitarBeneficio.IsEnabled = true;
            btnBuscarBeneficio.IsEnabled = true;
        }
        private void CargarDatosModificar()
        {
            txtNombre.Text = beneficiario.Nombre.ToString();
            txtDireccion.Text = beneficiario.Direccion.ToString();
            txtDocumento.Text = beneficiario.Documento.ToString();
            txtTelefono.Text = beneficiario.Telefono.ToString();
            txtCuitCuil.Text = beneficiario.Cuit_Cuil;
            dpFechaNac.DisplayDate = beneficiario.FechaNac;
            dpFechaNac.Text = beneficiario.FechaNac.Date.ToShortDateString();
            seleccionarBarrio();
            _grupos = GrupoBeneficiarioClass.ListarGruposPorBeneficiario(beneficiario.Id_beneficiario);
            grillaGrupos.ItemsSource = _grupos;

            _beneficiosAsignados = beneficiario.Beneficios;
            grillaBeneficios.ItemsSource = _beneficiosAsignados;

        }

        private void seleccionarBarrio()
        {
            foreach(BarrioClass b in cmbBarrio.Items)
            {
                if(b.IdBarrio == beneficiario.Barrio.IdBarrio)
                {
                    cmbBarrio.SelectedItem = b;
                }
            }
            
        }

        private void InicializarComponentesConsultar()
        {
            //txtBoxes
            txtNombre.IsReadOnly = true;
            txtDireccion.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;
            txtDocumento.IsReadOnly = true;
            txtCuitCuil.IsReadOnly = true;
            cmbBarrio.IsEnabled = false;
          

            //Botones

            btnEliminarBeneficiario.IsEnabled = false;
            btnGuardarBeneficiario.IsEnabled = false;
            btnGuardarBeneficiario.Label = "Guardar";
            btnCancelarCambios.IsEnabled = true;
        }

        private void CargarDatosConsultar()
        {
            txtNombre.Text = beneficiario.Nombre.ToString();
            txtDireccion.Text = beneficiario.Direccion.ToString();
            txtDocumento.Text = beneficiario.Documento.ToString();
            txtTelefono.Text = beneficiario.Telefono.ToString();
            txtCuitCuil.Text = beneficiario.Cuit_Cuil.ToString();
            dpFechaNac.DisplayDate = beneficiario.FechaNac;
            dpFechaNac.Text = beneficiario.FechaNac.Date.ToShortDateString();
            seleccionarBarrio();

            _grupos = GrupoBeneficiarioClass.ListarGruposPorBeneficiario(beneficiario.Id_beneficiario);
            grillaGrupos.ItemsSource = _grupos;


            _beneficiosAsignados = beneficiario.Beneficios;
            grillaBeneficios.ItemsSource = _beneficiosAsignados;

        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            // Orden de Tabulación
            txtDocumento.TabIndex = 0;
            txtNombre.TabIndex = 1;
            dpFechaNac.TabIndex = 2;
            txtCuitCuil.TabIndex = 3;
            txtDireccion.TabIndex = 4;
            txtTelefono.TabIndex = 5;
            cmbBarrio.TabIndex = 6;

            btnGuardarBeneficiario.TabIndex = 7;
            btnEliminarBeneficiario.TabIndex = 8;

        }

       

        private void btnEliminarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            if (beneficiario != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Beneficiario?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (beneficiario.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el beneficiario correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el beneficiario", "Eliminar Beneficiario", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnGuardarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                if (opcion == Opcion.nuevo)
                {
                    BeneficiarioClass nuevoBeneficiario = new BeneficiarioClass();
                    nuevoBeneficiario.Documento = txtDocumento.Text.ToString();
                    nuevoBeneficiario.Nombre = txtNombre.Text.ToString();
                    nuevoBeneficiario.Direccion = txtDireccion.Text.ToString();
                    nuevoBeneficiario.Telefono = txtTelefono.Text.ToString();
                    nuevoBeneficiario.Cuit_Cuil = txtCuitCuil.Text.ToString();
                    nuevoBeneficiario.FechaNac = dpFechaNac.DisplayDate.Date;
                    nuevoBeneficiario.Barrio = (BarrioClass)cmbBarrio.SelectedItem;
                    
                    if (nuevoBeneficiario.NuevoBeneficiario())
                    {
                        MessageBox.Show("Beneficiario " + nuevoBeneficiario.Nombre + " creado con éxito", "Crear Beneficiario", MessageBoxButton.OK, MessageBoxImage.Information);
                        b_ok = true;
                        beneficiario = nuevoBeneficiario;
                        this.Close();
                        this.Owner.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El beneficiario " + nuevoBeneficiario.Nombre + " no se pudo crear", "Crear Beneficiario", MessageBoxButton.OK, MessageBoxImage.Error);
                        b_ok = false;
                    }
                }
                else
                {
                    if (opcion == Opcion.modificar)
                    {
                        MessageBoxResult msg;
                        msg = MessageBox.Show("¿Seguro que desea modificar el Beneficiario " + beneficiario.Nombre + "?", "Confirme modificar Beneficiario", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                        if (msg == MessageBoxResult.Yes)
                        {
                            beneficiario.Documento = txtDocumento.Text.ToString();
                            beneficiario.Nombre = txtNombre.Text.ToString();
                            beneficiario.Direccion = txtDireccion.Text.ToString();
                            beneficiario.Telefono = txtTelefono.Text.ToString();
                            beneficiario.Cuit_Cuil = txtCuitCuil.Text.ToString();
                            beneficiario.FechaNac = dpFechaNac.DisplayDate.Date;
                            beneficiario.Barrio = (BarrioClass)cmbBarrio.SelectedItem;
                            if (beneficiario.Modificar())
                            {
                                MessageBox.Show("Beneficiario " + beneficiario.Nombre + " modificado con éxito", "Modificar Beneficiario", MessageBoxButton.OK, MessageBoxImage.Information);
                                b_ok = true;
                                this.Close();
                                this.Owner.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El beneficiario " + beneficiario.Nombre + " no se pudo modificar", "Modificar Beneficiario", MessageBoxButton.OK, MessageBoxImage.Error);
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


            //validar txtDocumento

            if (ValidacionesClass.ValidarNumericoTextBox(txtDocumento))
            {
                txtDocumento.Background = txtBien.Background;
                txtDocumento.ToolTip = "";
                
            }
            else
            {
                r = false;
                txtDocumento.Background = txtMal.Background;
                txtDocumento.ToolTip = "No es correcto";
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
        private void Blanquear()
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

        private void btnCancelarCambios_Click(object sender, RoutedEventArgs e)
        {
            b_ok = false;
            this.Close();
            this.Owner.Focus();
        }

        private void btnAgregarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            BeneficioClass nuevoBeneficio = null;
            nuevoBeneficio = (BeneficioClass)cmbBeneficios.SelectedItem;


            if (nuevoBeneficio != null)
            {
                DateTime fechaAsignacion = dpFechaAsignacion.DisplayDate.Date;

                BeneficioBeneficiarioClass nuevoBB = new BeneficioBeneficiarioClass();

                nuevoBB.Id_beneficiario = beneficiario.Id_beneficiario;
                nuevoBB.Id_beneficio = nuevoBeneficio.Id_beneficio;
                nuevoBB.Nombre_beneficio = nuevoBeneficio.Nombre_beneficio;
                nuevoBB.Descripcion_beneficio = nuevoBeneficio.Descripcion_beneficio;
                nuevoBB.Fecha_asignacion = fechaAsignacion;

                _beneficiosAsignados.Add(nuevoBB);
                grillaBeneficios.ItemsSource = _beneficiosAsignados;
                grillaBeneficios.Items.Refresh();
                

                
               
            }
        }

        private void btnBuscarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            BuscarBeneficioWindow buscarBenWin = new BuscarBeneficioWindow();

            buscarBenWin.Owner = this;

            buscarBenWin.ShowDialog();

            if (buscarBenWin.b_ok && buscarBenWin.beneficioSeleccionado.Id_beneficio != 0)
            {
                if (buscarBenWin.b_ok)
                {
                    seleccionarBeneficio(buscarBenWin.beneficioSeleccionado); //Selecciona el beneficio pasado como paràmetro

                   
                }
                else
                {
                    _beneficios = BeneficioClass.ListarBeneficios();
                    cmbBeneficios.ItemsSource = _beneficios;
                }

               

                
            }

            buscarBenWin  = null;
        }

        private void btnQuitarBeneficio_Click(object sender, RoutedEventArgs e)
        {
            if (_beneficioBeneficiarioSeleccionado != null)
            {
                _beneficiosAsignados.Remove(_beneficioBeneficiarioSeleccionado);

                grillaBeneficios.ItemsSource = _beneficiosAsignados;

                grillaBeneficios.Items.Refresh();
                
            }
        }

        private void grillaBeneficios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _beneficioBeneficiarioSeleccionado = (BeneficioBeneficiarioClass)grillaBeneficios.SelectedItem;
        }

        /// <summary>
        /// Selecciona el beneficio pasado como parámetro en el comboBeneficios
        /// </summary>
        /// <param name="beneficio">beneficio a seleccionar</param>
        private void seleccionarBeneficio(BeneficioClass benef)
        {
            foreach (BeneficioClass b in cmbBeneficios.Items)
            {
                if (b.Id_beneficio == benef.Id_beneficio)
                {
                    cmbBeneficios.SelectedItem = b;
                    break;
                }

            }

        }

       
    }
}
