   M S B A M L   `   `   `  ����   GestionAyudarE    ?Processar.ProyectoAyudar.GestionAyudar.AdministrarUsuarioWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$0  *Administrar Usuarios - Comuna de Margarita�� � WindowStartupLocation$ CenterScreen=�$	��720��$
��1024�� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditarUsuario��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	  Name$	 btnNuevoUsuario��
   Label$
 Nuevo��   LargeImageSource$" Graficos/usuario_agregar.png��$��55��$��
0,10,0,-10q�  -   $	 btnModificarUsuario��$
 	Modificar��$! Graficos/usuario_editar.png��$��55��$��
0,10,0,-10q�  -   $	 btnEliminarUsuario��$
 Eliminar��$# Graficos/usuario_eliminar.png��$��55��$��
0,10,0,-10q�  -   $ grupoConsultarUsuario��$��	Consultar��$	��0,1q�$	��590��.@�  -   $ grupoCriterio��$��	Criterios��$	��0,1q�$��90��.@�6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -     Name$ 	rdbNombre��   Label$ Nombre��2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -	     Name$ txtBusquedaUsuario��   Label$ Buscar:��$��10,10,-325,0q� �� TextWrapping$
 Wrap=�   TextBoxWidth$	 300Q�$	��Top=�  -
   $	 btnBuscarUsuario��$
 Buscar��$ Graficos/buscar.png��$��55��$��333,10,-333,-10q�  -   $	 btnAbrirUsuario��$
 	Consultar��$# Graficos/usuario_consulta.png��$��55��$��343,10,-333,-10q�� -    �Name$ gridUsuarios��  	GridVerde#��[ $��10,163,10,10q�.+�&   System.Windows.Controls.DataGrid  -     Name$ grillaUsuarios�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $
��Left=�$��
10,40,0,11q�$	��750��   
IsReadOnly .    AutoGenerateColumns .   � DataContext ��    Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Id_usuario+   ClipboardContentBinding Z� 	  $ Nombre�� �� *Nombre_usuario+ Z� 	  $ Nombre Completo�� �� *Nombre_completo+ Z� �� $��	Usuarios:��  Label_Comun#��[ $
��Left=�$��	10,11,0,0q�$	��Top=�