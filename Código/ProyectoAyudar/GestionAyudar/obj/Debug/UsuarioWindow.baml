   M S B A M L   `   `   `  ����  GestionAyudar:    4Processar.ProyectoAyudar.GestionAyudar.UsuarioWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Usuario��5      $	��720��6   $
��1024��6"    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6w    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5	      �    	GridFondo#��[  6   .+�5
   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarUsuario��5      $��Editar��6:   $	��0,1q�6J   $
��Auto��6W   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnEliminarUsuario��5   #   
   Label$
 Eliminar��6?      LargeImageSource$# Graficos/usuario_eliminar.png��6P   $��55��6�   $��
0,10,0,-10q�6�     5      -   5        $	 btnCambiarContrasenia��5   #   $
 Contraseña��6B   $ Graficos/registro.png��6U   $��55��6~   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoCambios��5      $��Cambios��64   $	��0,1q�6E   $
��Auto��6R   .@�5        -   5        $	 btnGuardarUsuario��5   #   $
 Guardar��6>   $ Graficos/guardar.png��6N   $��55��6v   $��4,10,-4,-10q�6�     5      -   5        $	 btnCancelarCambios��5   #   $
 Cancelar��6?   $ Graficos/cancel.png��6P   $��55��6w   $��4,10,-4,-10q�6�   5      5      5      � 5   
   -   5         �Name$ gridUsuario��5        	GridVerde#��[ 6$   $��10,163,10,10q�6G    � ColumnDefinitions 5       �� 5!      $
��250* �6#   �� 5"      $
��250* �6#   .+�5$      �� -	   5         ��Name$ txtNombreCompleto��5$        CajadeTexto#��[ 61    �� 
IsReadOnly . $
��Left=�6h   $��23��6�   $��222,100,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5%      -
   5         ��Name$ lblNombreCompleto��5%      $��Nombre Completo:��6/     Label_Comun#��[ 6K   $
��Left=�6p   $��100,100,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.946,0.583&�6�   �� 5&      -   5        $ txtNombreUsuario��5&      #��[ 60    . $
��Left=�6g   $��23��6�   $��222,150,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5'      -   5        $ lblNombreUsuario��5'      $��Nombre de Usuario:��6.   #��[ 6L   $
��Left=�6q   $��100,150,0,0q�6�   $	��Top=�6�   $ 0.946,0.583&�6�   �� 5-      -   5        $ lblPermisos��5-      $��	Permisos:��6)   #��[ 6>   $
��Left=�6c   $��100,100,0,0q�6~   $	��Top=�6�   $ 0.946,0.583&�6�   $��1��6�   &   System.Windows.Controls.DataGrid  5.      -   5          Name$ grillaPermisos��5.       	 Tabla#��[ 6/     CeldaGrilla   	CellStyle# [ 6N   $��100,129,100,0q�6w   $	��Top=�6�   $	��300��6�      AutoGenerateColumns .  $��1��6  {�.    
IsReadOnly .     CanUserAddRows .     CanUserDeleteRows .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   � DataContext 6�   ��    Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6k      
Visibility$ Hidden=�6w   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6)   �� *
Id_permiso+ 	  ClipboardContentBinding 6H   Z� 6w     51      $ Función��6w       
IsReadOnly  .  6)   �� *Funcion.Nombre_funcion+ 6T   Z� 6�   4
  .System.Windows.Controls.DataGridCheckBoxColumn
  52      -   5        grillaColumnaPermitido��$ 	Permitido��52   �     .   6M   �� *	Permitido+ 6k   Z� 6�   54      �� 56      -   5        $ lblContraseña��56      $��Contraseña:��6+   #��[ 6B   $
��Left=�6g   $��136,200,0,0q�6�   $	��Top=�6�   $ 0.946,0.583&�6�   �� 58      -   5        $ lblContraseñaRepetir��58      $��Repetir Contraseña:��62   #��[ 6Q   $
��Left=�6v   $��
94,249,0,0q�6�   $	��Top=�6�   $ 0.946,0.583&�6�   G� 59      -   5        ! G�Name$! txtContraseña��59        CajadePassword#��[ 62   $
��Left=�6Z   $��222,200,0,0q�6u   $	��Top=�6�   $	��260��6�   $��22��6�   6�   G� 5:      -   5        $! txtContraseñaRepetir��5:      #��[ 69   $
��Left=�6a   $��222,249,0,0q�6|   $	��Top=�6�   $	��260��6�   $��22��6�   6�   5>      �� 5?   
   -   5        $��txtBien��5?      #��[ 6!   $y�Hidden=�6F   �� 5@   
   -   5        $��txtMal��5@        CajadeTextoError#��[ 6    $y�Hidden=�6J   5A      5C      