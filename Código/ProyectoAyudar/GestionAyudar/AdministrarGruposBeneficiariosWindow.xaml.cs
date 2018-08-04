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
    /// Lógica de interacción para AdministrarGruposBeneficiariosWindow.xaml
    /// </summary>
    public partial class AdministrarGruposBeneficiariosWindow : Window
    {
        private List<GrupoBeneficiarioWindow> _ventanasGrupos;
        private GrupoBeneficiarioClass grupoBeneficiarioSeleccionado;
        private List<GrupoBeneficiarioClass> _grupos;
        private CriterioBusqueda _criterio_de_busqueda;
        public bool b_ok = false;

        /// <summary>
        /// Constructor de la clase controladora de la venta de administración de Grupos de Beneficiarios
        /// </summary>
        public AdministrarGruposBeneficiariosWindow()
        {
            InitializeComponent();

            _ventanasGrupos = new List<GrupoBeneficiarioWindow>();
            grupoBeneficiarioSeleccionado = null;

            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;


            _grupos = new List<GrupoBeneficiarioClass>();

            grillaGrupos.ItemsSource = _grupos;

            cargarComponentes();
        }

        /// <summary>
        /// Inicia los componentes de la ventana
        /// </summary>
        private void cargarComponentes()
        {

            rdbNombreGrupo.IsChecked = true;
            btnAbrirGrupo.IsEnabled = false;
            btnEliminarGrupo.IsEnabled = false;
            // btnSeleccionar.IsEnabled = _con_seleccion;
            btnModificarGrupo.IsEnabled = false;
        }

        /// <summary>
        /// Método controlador del botón modificar Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarGrupo_Click(object sender, RoutedEventArgs e)
        {
            if (grupoBeneficiarioSeleccionado != null)
            {
                //Verifica que el beneficiario no este abierto, si no esta abierta crea la ventana y la agrega a la lista

                GrupoBeneficiarioWindow GrupoBeneficiarioWin = new GrupoBeneficiarioWindow(GrupoBeneficiarioWindow.Opcion.modificar, grupoBeneficiarioSeleccionado, ref _ventanasGrupos);

                GrupoBeneficiarioWin.Owner = this;
                _ventanasGrupos.Add(GrupoBeneficiarioWin);
                GrupoBeneficiarioWin.Show();

            }
        }

        /// <summary>
        /// Método controlador del botón Nuevo Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoGrupo_Click(object sender, RoutedEventArgs e)
        {
            GrupoBeneficiarioWindow grubenWin = new GrupoBeneficiarioWindow(GrupoBeneficiarioWindow.Opcion.nuevo, null, ref _ventanasGrupos);
            grubenWin.Owner = this;
            _ventanasGrupos.Add(grubenWin);
            grubenWin.Show();
        }

        /// <summary>
        /// Método controlador del botón Eliminar Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarGrupo_Click(object sender, RoutedEventArgs e)
        {
            if (grupoBeneficiarioSeleccionado != null)
            {

                MessageBoxResult mr;
                mr = MessageBox.Show("¿Confirma Eliminar el Grupo?", "Confirme Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (mr == MessageBoxResult.Yes)
                {
                    if (grupoBeneficiarioSeleccionado.Eliminar())
                    {
                        MessageBox.Show("Se ha eliminado el grupo correctamente", "Eliminar Confirmado", MessageBoxButton.OK, MessageBoxImage.Information);
                        _grupos.Remove(grupoBeneficiarioSeleccionado);
                        grillaGrupos.Items.Refresh();


                    }
                }
            }
        }

        /// <summary>
        /// Método controlador del campo de busqueda para avento del teclado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBusquedaGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarGruposBeneficiario();
            }
        }

        /// <summary>
        /// Método cotrolador del botón Buscar Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarGrupo_Click(object sender, RoutedEventArgs e)
        {
            BuscarGruposBeneficiario();
        }

        /// <summary>
        /// Método controlador del botón abrir Grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrirGrupo_Click(object sender, RoutedEventArgs e)
        {
            if (grupoBeneficiarioSeleccionado != null)
            {
                GrupoBeneficiarioWindow grubenWin = new GrupoBeneficiarioWindow(GrupoBeneficiarioWindow.Opcion.consultar, grupoBeneficiarioSeleccionado, ref _ventanasGrupos);
                grubenWin.Owner = this;
                _ventanasGrupos.Add(grubenWin);
                grubenWin.Show();
            }
        }

        /// <summary>
        /// Método controlador del evento SelectionCHanged de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grillaGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grupoBeneficiarioSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.SelectedItem;
        }

        /// <summary>
        /// Controlador del evento para Inicializar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Initialized(object sender, EventArgs e)
        {
            
            txtBusquedaGrupo.Focus();
            txtBusquedaGrupo.TabIndex = 0;
            btnBuscarGrupo.TabIndex = 1;
            btnAbrirGrupo.TabIndex = 2;
            btnNuevoGrupo.TabIndex = 3;
            btnModificarGrupo.TabIndex = 4;
            btnEliminarGrupo.TabIndex = 5;
        }

        /// <summary>
        /// Método para controlar el RadioButtom de la busqueda por nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbNombreGrupo_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre_Grupo;
        }

        /// <summary>
        /// Método para controla el radioButtom de la busqueda por documento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbDocumento_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Dni;
        }

        /// <summary>
        /// Controlador del Evento de Cierre de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Focus();
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
                    btnAbrirGrupo.IsEnabled = false;
                    btnEliminarGrupo.IsEnabled = false;
                    btnModificarGrupo.IsEnabled = false;
                    MessageBox.Show("No se encuentran Grupos con esos criterios de busqueda", "No se encuentran Grupos", MessageBoxButton.OK, MessageBoxImage.Warning);

                    grillaGrupos.ItemsSource = _grupos;
                }
                else
                {
                    grillaGrupos.SelectedItem = grillaGrupos.Items[0];
                    grupoBeneficiarioSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.Items[0];

                    btnEliminarGrupo.IsEnabled = true;
                    btnAbrirGrupo.IsEnabled = true;
                    btnModificarGrupo.IsEnabled = true;
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
                            btnAbrirGrupo.IsEnabled = false;
                            btnEliminarGrupo.IsEnabled = false;
                            btnModificarGrupo.IsEnabled = false;

                            MessageBox.Show("No se encuentran Grupos con esos criterios de busqueda", "No se encuentran Grupos", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaGrupos.Items.Refresh();
                        }
                        else
                        {
                            grillaGrupos.SelectedItem = grillaGrupos.Items[0];
                            grupoBeneficiarioSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.Items[0];
                            btnAbrirGrupo.IsEnabled = true;
                            btnEliminarGrupo.IsEnabled = true;
                            btnModificarGrupo.IsEnabled = true;
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
                            btnAbrirGrupo.IsEnabled = false;
                            btnEliminarGrupo.IsEnabled = false;
                            btnModificarGrupo.IsEnabled = false;

                            MessageBox.Show("No se encuentran Grupos con esos criterios de busqueda", "No se encuentran Grupos", MessageBoxButton.OK, MessageBoxImage.Warning);

                            grillaGrupos.Items.Refresh();
                        }
                        else
                        {
                            grillaGrupos.SelectedItem = grillaGrupos.Items[0];
                            grupoBeneficiarioSeleccionado = (GrupoBeneficiarioClass)grillaGrupos.Items[0];
                            btnAbrirGrupo.IsEnabled = true;
                            btnEliminarGrupo.IsEnabled = true;
                            btnModificarGrupo.IsEnabled = true;
                            grillaGrupos.Items.Refresh();
                        }
                    }

                }

            }
        }

        private void rdbNombreBeneficiario_Checked(object sender, RoutedEventArgs e)
        {
            _criterio_de_busqueda = CriterioBusqueda.Busqueda_Nombre;
        }
    }
}
