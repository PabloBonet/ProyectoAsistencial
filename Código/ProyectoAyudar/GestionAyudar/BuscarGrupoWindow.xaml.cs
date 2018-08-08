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
    public partial class BuscarGrupoWindow : Window
    {
        public GrupoBeneficiarioClass grupoSeleccionado;
        private List<GrupoBeneficiarioClass> _grupos;
        private CriterioBusqueda _criterio_de_busqueda;
        private List<GrupoBeneficiarioWindow> _ventanasGrupos;
        public bool b_ok = false;
        public BuscarGrupoWindow()
        {
            InitializeComponent();

            grupoSeleccionado = null;

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre_Grupo;

            _grupos = new List<GrupoBeneficiarioClass>();

            _ventanasGrupos = new List<GrupoBeneficiarioWindow>();

            grillaGrupos.ItemsSource = _grupos;

            cargarComponentes();
        }

        private void cargarComponentes()
        {
            rdbNombre.IsChecked = true;
            btnSeleccionar.IsEnabled = false;
            btnBuscarGrupo.IsEnabled = true;
          
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
        }

        private void rdbNombre_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre_Grupo;
        }

        private void rdbDocumento_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Dni;
        }

        private void rdbBeneficiario_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }
        private void btnBuscarGrupo_Click(object sender, RoutedEventArgs e)
        {
            this.BuscarGruposBeneficiario();
        }


        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

            grupoSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.SelectedItem;
            b_ok = true;
            this.Close();
            this.Owner.Focus();
        }

      
        

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            GrupoBeneficiarioWindow gruWin = new GrupoBeneficiarioWindow(GrupoBeneficiarioWindow.Opcion.nuevo, null, ref _ventanasGrupos);
            gruWin.Owner = this;
            _ventanasGrupos.Add(gruWin);
            gruWin.ShowDialog();

            if (gruWin.b_ok)
            {
                grupoSeleccionado = gruWin.grupo;
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            txtBusquedaGrupo.Focus();

            rdbNombre.TabIndex = 3;
            rdbDocumento.TabIndex = 4;
            txtBusquedaGrupo.TabIndex = 0;
            btnBuscarGrupo.TabIndex = 1;
            btnNuevo.TabIndex = 2;
        }

       

        private void grillaGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grupoSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.SelectedItem;
        }

        private void grillaGrupos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grupoSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.SelectedItem;
            if (grupoSeleccionado != null)
            {
                b_ok = true;
                this.Close();
                this.Owner.Focus();
            }

        }


        private void BuscarGruposBeneficiario()
        {
            bool todo_ok = false;

            _grupos = new List<GrupoBeneficiarioClass>();

            grillaGrupos.ItemsSource = _grupos;

            string beneficiarioBuscar = txtBusquedaGrupo.Text.ToString().Trim();

            if (txtBusquedaGrupo.Text.Length == 0)
            {
                _grupos = GrupoBeneficiarioClass.ListarGrupos();

                grillaGrupos.ItemsSource = _grupos;

                if (_grupos.Count == 0)
                {
                    btnSeleccionar.IsEnabled = false;
                  
                    MessageBox.Show("No se encuentran Grupos con esos criterios de busqueda", "No se encuentran Grupos", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaGrupos.ItemsSource = _grupos;
                }
                else
                {
                    grillaGrupos.SelectedItem = grillaGrupos.Items[0];
                    grupoSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.Items[0];

                    btnSeleccionar.IsEnabled = true;
                  
                 
                    grillaGrupos.ItemsSource = _grupos;
                    grillaGrupos.Items.Refresh();
                }
            }
            else
            {
                if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Nombre_Grupo)
                {
                    todo_ok = true;


                    if (todo_ok)
                    {
                        _grupos = GrupoBeneficiarioClass.ListarGrupoBeneficiariosPorNombre(txtBusquedaGrupo.Text.ToString());

                        grillaGrupos.ItemsSource = _grupos;

                        if (_grupos.Count == 0)
                        {
                            btnSeleccionar.IsEnabled = false;

                            MessageBox.Show("No se encuentran Grupos con esos criterios de busqueda", "No se encuentran Grupos", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaGrupos.Items.Refresh();
                        }
                        else
                        {
                            grillaGrupos.SelectedItem = grillaGrupos.Items[0];
                            grupoSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.Items[0];
                            btnSeleccionar.IsEnabled = true;
                         
                            grillaGrupos.ItemsSource = _grupos;
                            grillaGrupos.Items.Refresh();
                        }
                    }

                }
                else
                /*if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Dni)*/
                {
                    if (_criterio_de_busqueda == CriterioBusqueda.Busqueda_Dni)
                    {
                        if (ValidacionesClass.ValidarNumericoTextBox(txtBusquedaGrupo))
                        {
                            todo_ok = true;
                        }
                        else
                        {
                            todo_ok = false;
                        }
                    }
                    else
                    {
                        todo_ok = true;
                    }

                    if (todo_ok)
                    {

                        List<GrupoBeneficiarioClass> grupos = GrupoBeneficiarioClass.ListarGruposPorCriterio(txtBusquedaGrupo.Text, _criterio_de_busqueda);
                        foreach (GrupoBeneficiarioClass grupo in grupos)
                        {
                            _grupos.Add(grupo);


                        }

                        grillaGrupos.ItemsSource = _grupos;
                        if (_grupos.Count == 0)
                        {
                            btnSeleccionar.IsEnabled = false;

                            MessageBox.Show("No se encuentran Grupos con esos criterios de busqueda", "No se encuentran Grupos", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaGrupos.Items.Refresh();
                        }
                        else
                        {
                            grillaGrupos.SelectedItem = grillaGrupos.Items[0];
                            grupoSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.Items[0];
                            btnSeleccionar.IsEnabled = true;
                          
                            grillaGrupos.Items.Refresh();
                        }
                    }

                }

            }
        }

      
    }
}
