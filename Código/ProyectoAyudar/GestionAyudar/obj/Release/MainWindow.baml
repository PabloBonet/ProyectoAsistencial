   M S B A M L   `   `   `  ����   GestionAyudar7    1Processar.ProyectoAyudar.GestionAyudar.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  ventanaPrincipal�� � Title$; 5Processar - Módulo Asistencial - Comuna de Margarita��$	��720��$
��1050�� � WindowState$ 	Maximized=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  -     Name$ ribbonPrincipal��$	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $��50�����	#FF4AA200���	#FFCADEB8.@�>  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   	  Name$	 menuUsuarioIniciarSesion��$��Iniciar sesión��  -   $#	 menuUsuarioCambiarContrasenia��$��Cambiar contraseña��  -   $	 menuUsuarioCerrarSesion��$��Cerrar sesión��  -   $	 	menuSalir��$��Salir��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  -   
  Name$
 tabOrdenesEntrega��$��Ordenes de Entrega��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditarOrden��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -	     Name$ btnAgregarOrden�� � ToolTip$ Crear una orden��   Label$ Nueva��   LargeImageSource$ Graficos/nuevo.png��$��55��$��
0,10,0,-10q�  -
   $ btnModificarOrden��$" Modificar orden seleccionada��$ 	Modificar��$ Graficos/modificar.png��$��55��$��
0,10,0,-10q�  -   $ btnEliminarOrden��$! Eliminar orden seleccionada��$ Eliminar��$ Graficos/delete.png��$��55��$��
0,10,0,-10q�  $��
Buscar Por��$
��Auto��.@�6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   $��opIdentificador��   Label$ Identificador��$9 3Número de identificador como criterio de búsqueda��  -   $��opBeneficiario��$ Beneficiario��$8 2Nombre del beneficiario como criterio de búsqueda��  -   $��opFecha��$ Fecha Creación��$3 -Fecha de creación como criterio de búsqueda��  -   $ grupoConsultarOrden��$��	Consultar��$	��0,1q�$	��500��.@�2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -     Name$ txtBusquedaOrden��  CajadeTexto#��[    Label$ Buscar:��$��10,10,-325,0q� �� TextWrapping$
 Wrap=�   TextBoxWidth$	 300Q�$	��Top=�$y�Visible=�(	  "System.Windows.Controls.DatePicker	  -    	 Name$ dpFechaDesde��$��-39,10,-111,3q�$y�Hidden=��� -    ��Name$ lblDesde��$��Desde��$��25��$��
0,-3,-53,3q�$y�Hidden=�	  -   $ dpFechaHasta��$��125,10,-275,1q�$y�Hidden=��� -   $ lblHasta��$��Hasta��$��25��$��178,-1,-225,1q�$y�Hidden=�  -   $ btnBuscarOrden��$ Buscar��$ Graficos/buscar.png��$��55��$��333,10,-333,-10q�  -   $ btnAbrirOrden��$  Abre la orden seleccionada��$ 	Consultar��$ Graficos/consultar.png��$��55��$��343,10,-345,-10q�  -   $ grupoTratamientoOrden��$��Tratamiento��$	��0,1q�$
��Auto��.@�  -   $ btnAutorizarOrden��$" Autorizar orden seleccionada��$ 	Autorizar��$ Graficos/autorizar.png��$��55��$��
0,10,0,-10q�  -   $ btnEntregarOrden��$! Entregar orden seleccionada��$ Entregar��$ Graficos/entrega.png��$��55��$��
0,10,0,-10q�  -   $ btnCancelarOrden��$! Cancelar orden seleccionada��$ Cancelar��$ Graficos/cancelar.png��$��55��$��
0,10,0,-10q�  -   $ grupoReportesOrden��$��Reportes��$	��0,1q�$
��Auto��.@�  -   $ btnReporteEstadosOrden��$; 5Genera un reporte por estados y fechas de las ordenes��$ Estados��$ Graficos/reportes.png��$��55��$��
0,10,0,-10q�  -   $
 tabBeneficiarios��$��Beneficiarios��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�  -   $ grupoEditarBeneficiario��$��Editar��$	��0,1q�$
��Auto��.@�  -   $ btnNuevoBeneficiario��$ Crea un beneficiario��$ Nuevo��$' !Graficos/beneficiario_agregar.png��$��55��$��
0,10,0,-10q�  -    $  btnAdministrarBeneficiario��$? 9Abre una nueva ventana para administrar los beneficiarios��$ Administrar��$+ %Graficos/beneficiario_administrar.png��$��55��$��
0,10,0,-10q�  -!   $ grupoGruposBeneficiario��$��Grupos��$	��0,1q�$
��Auto��.@�  -"   $ btnNuevoGrupoBeneficiario��$$ Crea un grupo de beneficiarios��$ Nuevo��$' !Graficos/beneficiario_agregar.png��$��55��$��
0,10,0,-10q�  -#   $% btnAdministrarGrupoBeneficiario��$I CAbre una nueva ventana para administrar los grupos de beneficiarios��$ Administrar��$+ %Graficos/beneficiario_administrar.png��$��55��$��
0,10,0,-10q�  -$   $ grupoBeneficios��$��
Beneficios��$	��0,1q�$
��Auto��.@�  -%   $ btnNuevoBeneficio��$ Crea un Beneficio��$ Nuevo��$' !Graficos/beneficiario_agregar.png��$��55��$��
0,10,0,-10q�  -&   $ btnAdministrarBeneficio��$< 6Abre una nueva ventana para administrar los beneficios��$ Administrar��$+ %Graficos/beneficiario_administrar.png��$��55��$��
0,10,0,-10q�  -'   $ grupoReportesBeneficiario��$��Reportes��$	��0,1q�$
��Auto��.@�  -(   $# btnReporteEntregaBeneficiario��$4 .Genera un reporte de entregas por beneficiario��$ Beneficiario��$ Graficos/reportes.png��$��55��$��
0,10,0,-10q�  -)   $ btnReporteEntregaGrupo��$- 'Genera un reporte de entregas por grupo��$ Grupo��$ Graficos/reportes.png��$��55��$��
0,10,0,-10q�  -*   $
 tabArticulos��$��	Articulos��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�  -+   $ grupoEditarArticulo��$��Editar��$	��0,1q�$
��Auto��.@�  -,   $ btnNuevoArticulo��$ Crea un artículo��$ Nuevo��$ Graficos/nuevo.png��$��55��$��
0,10,0,-10q�  --   $ btnAdministrarArticulo��$ Administrar��$2 ,Abre una ventana para administrar artículos��$ Graficos/administrar.png��$��55��$��
0,10,0,-10q�  -.   $ grupoEditarTipoArticulo��$��Tipo de Articulos��$	��0,1q�$
��Auto��.@�  -/   $ btnNuevoTipoArticulo��$ Nuevo��$ Crea un Tipo de artículo��$ Graficos/nuevo.png��$��55��$��
0,10,0,-10q�  -0   $  btnAdministrarTipoArticulo��$ Administrar��$? 9Abre una ventana para administrar los tipos de artículos��$ Graficos/administrar.png��$��55��$��
0,10,0,-10q�  -1   $
 tabOtros��$��Otros��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�  -2   $ grupoEditarBarrio��$��Barrio��$	��0,1q�$
��Auto��.@�  -3   $ btnAgregarBarrio��$ Crea un barrio��$ Nuevo��$ Graficos/barrio_nuevo.png��$��55��$��
0,10,0,-10q�  -4   $ btnAdministrarBarrios��$ Administrar��$3 -Abre una ventana para administrar los barrios��$% Graficos/barrio_administrar.png��$��55��$��
0,10,0,-10q�  -5   $
 tabAvanzado��$��Avanzado��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�  -6   $ grupoEditarUsuario��$��Usuario��$	��0,1q�$
��Auto��.@�  -7   $ btnAgregarUsuario��$ Crea un usuario��$ Nuevo��$" Graficos/usuario_agregar.png��$��55��$��
0,10,0,-10q�  -8   $ btnAdministrarUsuario��$ Administrar��$4 .Abre una ventana para administrar los usuarios��$&  Graficos/usuario_administrar.png��$��55��$��
0,10,0,-10q�� -9    �Name$ gridOrdenes��  	GridVerde#��[ $��10,163,10,10q�.+�&
   System.Windows.Controls.DataGrid
  -:    
 Name$ grillaOrdenes�� 	 Tabla#��[   CeldaGrilla 
  	CellStyle# [ $
��Left=�$��
10,40,0,11q�$	��750�� 
  
IsReadOnly .  
  AutoGenerateColumns .   � DataContext ��  
  Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Identificador��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id_orden_entrega+    ClipboardContentBinding  Z�   $ Descripción�� �� *Descripcion+  Z�   $ Beneficiario�� �� *Beneficiario.Nombre+  Z�   $ Fecha Creación�� �� *Fecha+! �� StringFormat$! {0:dd/MM/yyyy HH:mm:ss }��  Z�   $ Estado�� �� *EstadoActual.Estado+  Z� 
  -;   $ grillaOrdenesIniciadas��#��[ # [ $��766,40,10,0q�$	��Top=�$	��211�� .  .   ��    $ Identificador�� �� *Id_orden_entrega+  Z�   $ Descripción�� �� *Descripcion+  Z�   $ Beneficiario�� �� *Beneficiario.Nombre+  Z� 
  -<   $ grillaOrdenesAutorizadas��#��[ # [ $��766,285,10,11q� .  .   ��    $ Identificador�� �� *Id_orden_entrega+  Z�   $ Descripción�� �� *Descripcion+  Z�   $ Beneficiario�� �� *Beneficiario.Nombre+  Z� �� -=   $ lblOrdenesDeEntrega��$��Ordenes de Entrega��  Label_Comun#��[ $
��Left=�$��	10,11,0,0q�$	��Top=��� $��Ordenes Iniciadas��#��[ $
��Left=�$��
766,11,0,0q�$	��Top=��� $��Ordenes Autorizadas��#��[ $
��Left=�$��766,256,0,0q�$	��Top=�