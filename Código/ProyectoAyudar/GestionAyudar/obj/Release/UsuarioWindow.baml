   M S B A M L   `   `   `  ����   GestionAyudar:    4Processar.ProyectoAyudar.GestionAyudar.UsuarioWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Usuario��$	��720��$
��1024�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditarUsuario��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	  Name$	 btnEliminarUsuario��
   Label$
 Eliminar��   LargeImageSource$# Graficos/usuario_eliminar.png��$��55��$��
0,10,0,-10q�  -   $	 btnCambiarContrasenia��$
 Contraseña��$ Graficos/registro.png��$��55��$��
0,10,0,-10q�  -   $ grupoCambios��$��Cambios��$	��0,1q�$
��Auto��.@�  -   $	 btnGuardarUsuario��$
 Guardar��$ Graficos/guardar.png��$��55��$��4,10,-4,-10q�  -   $	 btnCancelarCambios��$
 Cancelar��$ Graficos/cancel.png��$��55��$��4,10,-4,-10q�� -    �Name$ gridUsuario��  	GridVerde#��[ $��10,163,10,10q� � ColumnDefinitions �� $
��250* ��� $
��250* �.+��� -	    ��Name$ txtNombreCompleto��  CajadeTexto#��[  �� 
IsReadOnly . $
��Left=�$��23��$��222,100,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��260���� -
    ��Name$ lblNombreCompleto��$��Nombre Completo:��  Label_Comun#��[ $
��Left=�$��100,100,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.946,0.583&��� -   $ txtNombreUsuario��#��[  . $
��Left=�$��23��$��222,150,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblNombreUsuario��$��Nombre de Usuario:��#��[ $
��Left=�$��100,150,0,0q�$	��Top=�$ 0.946,0.583&��� -   $ lblPermisos��$��	Permisos:��#��[ $
��Left=�$��100,100,0,0q�$	��Top=�$ 0.946,0.583&�$��1��&   System.Windows.Controls.DataGrid  -     Name$ grillaPermisos�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $��100,129,100,0q�$	��Top=�$	��300��   AutoGenerateColumns .  $��1��{�.    
IsReadOnly .     CanUserAddRows .     CanUserDeleteRows .  $ �� IsSynchronizedWithCurrentItem$
 TrueY� � DataContext ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   
Visibility$ Hidden=�1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *
Id_permiso+ 	  ClipboardContentBinding Z�   $ Función��    
IsReadOnly  .  �� *Funcion.Nombre_funcion+ Z� 4
  .System.Windows.Controls.DataGridCheckBoxColumn
  -   grillaColumnaPermitido��$ 	Permitido��  .   �� *	Permitido+ Z� �� -   $ lblContraseña��$��Contraseña:��#��[ $
��Left=�$��136,200,0,0q�$	��Top=�$ 0.946,0.583&��� -   $ lblContraseñaRepetir��$��Repetir Contraseña:��#��[ $
��Left=�$��
94,249,0,0q�$	��Top=�$ 0.946,0.583&�G� -   ! G�Name$! txtContraseña��  CajadePassword#��[ $
��Left=�$��222,200,0,0q�$	��Top=�$	��260��$��22��G� -   $! txtContraseñaRepetir��#��[ $
��Left=�$��222,249,0,0q�$	��Top=�$	��260��$��22���� -   $��txtBien��#��[ $y�Hidden=��� -   $��txtMal��  CajadeTextoError#��[ $y�Hidden=�