   M S B A M L   `   `   `  ����  GestionAyudarD    >Processar.ProyectoAyudar.GestionAyudar.GrupoBeneficiarioWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Grupos de Beneficiarios��5   	   $	��720��6)   $
��1024��66    � WindowStartupLocation$ CenterScreen=�6D    � 
ResizeMode$ NoResize=�6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5	      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  -   5          Name$ tabConsultaGrupo��5      $��Editar��62   $��88��6B   $	��Top=�6N   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarGrupo��5      $��Editar��68   $	��0,1q�6H   $
��Auto��6U   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnEliminarGrupo��5   #   
   Label$
 Eliminar��6=    � ToolTip$ Eliminar Grupo��6N      LargeImageSource$ Graficos/delete.png��6g   $��55��6�   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoCambios��5      $��Cambios��64   $	��0,1q�6E   $
��Auto��6R   .@�5        -   5        $	 btnGuardarGrupo��5   #   $
 Guardar��6<   $ Graficos/guardar.png��6L   $ Guardar o crear Grupo��6t   $��55��6�   $��4,10,-4,-10q�6�     5      -   5        $	 btnCancelarCambios��5   #   $
 Cancelar��6?   $ Graficos/cancel.png��6P   $��55��6w   $" Cancelar y cerrar la ventana��6�   $��4,10,-4,-10q�6�   5      5      5      � 5    
   -   5         �Name$ gridOrdenes��5         	GridVerde#��[ 6$   $��10,163,10,10q�6G    � ColumnDefinitions 5!      �� 5"      $
��250* �6#   �� 5#      $
��250* �6#   .+�5%      �� -	   5         ��Name$ 
txtIdGrupo��5%        CajadeTexto#��[ 6*    �� 
IsReadOnly . $
��Left=�6a   $��23��6|   $��
163,61,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5&      -
   5        $ txtDescripcion��5&      #��[ 6.    . $
��Left=�6e   $��63��6�   $��163,175,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5'      -   5         ��Name$ 
lblIdGrupo��5'      $��Identificador:��6(     Label_Comun#��[ 6B   $
��Left=�6g   $��	30,61,0,0q�6�   $	��Top=�6�   �� 5(      -   5        $ lblDescripcion��5(      $��Descripción:��6,   #��[ 6D   $
��Left=�6i   $��
30,175,0,0q�6�   $	��Top=�6�   �� 5)      -   5        $ txtNombreGrupo��5)      #��[ 6.    . $
��Left=�6e   $��23��6�   $��163,111,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5*      -   5        $ lblNombreGrupo��5*      $��Nombre:��6,   #��[ 6?   $
��Left=�6d   $��
30,111,0,0q�6   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5,      -   5          Name$ grillaBeneficiarios��5,       	 Tabla#��[ 64     CeldaGrilla   	CellStyle# [ 6S   $��10,175,0,193q�6|      
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6  $	��478��6,  $��1��68   � DataContext 6�   ��    Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6q      
Visibility$ Hidden=�6}   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6*   �� *Id_Beneficiario+ 	  ClipboardContentBinding 6N   Z� 6}     5/      $ Nombre��6D    6)   �� *Nombre+6D     50      $ 	Documento��6G    6)   �� *	Documento+6G     51      $ 	Cuit/Cuil��6G    6)   �� *	Cuit_Cuil+6G   53      �� 55      $��Agregar Beneficiarios��6   $
��Left=�66   $��	10,10,0,0q�6Q   $	��Top=�6d   $	��136��6|   $	��478��6�   ���	#FFCADEB8$��1��6�   .��56      � $��0,0,0,1q�6   .+�57      �� -   5         ��Name$ cmbBeneficiarios��57        ListaDesplegable#��[ 69   $
��Left=�6c   $��	10,36,0,0q�6~   $	��Top=�6�   $	��205��6�   ��58      �� 59      .R�5:   "   �� .+�5;   &   �� ��60   ��  �� Path$ Nombre�5<   #   5=      5?      �� 5@      -   5        $ lblBeneficiarios��5@      $��Beneficiarios��66   $
��Left=�6N   $��10,5,0,0q�6i   $	��Top=�6{   �� 5A      -   5         ��Name$ btnAgregarBeneficiario��5A        	BotonMenu#��[ 6=   $
��Left=�6`   $��
290,25,0,0q�6{   $	��Top=�6�   $��40��6�   $��40��6�   .��5B      � .+�5C      �� -   5        $��imgbtnAgregar��5C   $   $��Graficos/add.png��69   $��32��6S   $��32��6_   $
��Left=�6j   $��0,0,0,0q�6�   5E      5F      �� 5G      -   5        $ btnBuscarBeneficiario��5G      #��[ 6<   $
��Left=�6_   $��
220,25,0,0q�6z   $	��Top=�6�   $��40��6�   $��40��6�   .��5H      � .+�5I      �� -   5        $��imgbtnBuscar��5I   $   $��Graficos/find.png��68   $��32��6S   $��32��6_   $
��Left=�6j   $��0,0,0,0q�6�   5K      5L      �� 5O      -   5        $ btnQuitarBeneficiario��5O      #��[ 6<   $
��Left=�6_   $��
360,25,0,0q�6z   $	��Top=�6�   $��40��6�   $��40��6�   .��5P      � .+�5Q      �� -   5        $��imgbtnQuitar��5Q   $   $��Graficos/quitar.png��68   $��32��6U   $��32��6a   $
��Left=�6l   $��0,0,0,0q�6�   5S      5T      5V      5X      �� 5Z      -   5        $ lblItems��5Z      $��Integrantes del grupo:��6&   #��[ 6H   $
��Left=�6m   $��
10,151,0,0q�6�   $	��Top=�6�   $��1��6�   5[      �� 5\   
   -   5        $��txtBien��5\      #��[ 6!   $y�Hidden=�6F   �� 5]   
   -   5        $��txtMal��5]        CajadeTextoError#��[ 6    $y�Hidden=�6J   5^      5_      