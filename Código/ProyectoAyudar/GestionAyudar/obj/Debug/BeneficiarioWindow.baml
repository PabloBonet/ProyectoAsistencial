   M S B A M L   `   `   `  ����  GestionAyudar?    9Processar.ProyectoAyudar.GestionAyudar.BeneficiarioWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Beneficiario��5      $	��720��6%   $
��1024��62    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�6�    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5	      �    	GridFondo#��[  6   .+�5
   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  -   5          Name$ tabConsultaBeneficiario��5      $��Editar��69   $��88��6I   $	��Top=�6U   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5        	  Name$	 grupoEditarBeneficiario��5      $��Editar��6?   $	��0,1q�6O   $
��Auto��6\   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        
  Name$
 btnEliminarBeneficiario��5   #      Label$ Eliminar��6D      LargeImageSource$( "Graficos/beneficiario_eliminar.png��6U   $��55��6�   $��
0,10,0,-10q�6�   5        5      -   5        $	 grupoCambios��5      $��Cambios��64   $	��0,1q�6E   $
��Auto��6R   .@�5        -   5        $
 btnGuardarBeneficiario��5   #   $ Guardar��6C   $ Graficos/guardar.png��6S   $��55��6{   $��4,10,-4,-10q�6�     5      -   5        $
 btnCancelarCambios��5   #   $ Cancelar��6?   $ Graficos/cancel.png��6P   $��55��6w   $��4,10,-4,-10q�6�   5      5      5      � 5   
   -   5         �Name$ gridBeneficiarios��5        	GridVerde#��[ 6*   $��10,163,10,10q�6M   .+�5       �� -	   5         ��Name$ 	txtNombre��5         CajadeTexto#��[ 6)    �� 
IsReadOnly . $
��Left=�6`   $��23��6{   $��
180,53,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5!      -
   5         ��Name$ 	lblNombre��5!      $��Nombre:��6'     Label_Comun#��[ 6:   $
��Left=�6_   $��
100,53,0,0q�6z   $	��Top=�6�    J� RenderTransformOrigin$ 0.946,0.583&�6�   �� 5"      -   5        $ txtDocumento��5"      #��[ 6,    . $
��Left=�6c   $��23��6~   $��
180,25,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5#      -   5        $ lblDocumento��5#      $��
Documento:��6*   #��[ 6@   $
��Left=�6e   $��
100,25,0,0q�6�   $	��Top=�6�   �� 5$      -   5        $ txtDireccion��5$      #��[ 6,    . $
��Left=�6c   $��23��6~   $��180,139,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5%      -   5        $ lblDireccion��5%      $��
Dirección��6*   #��[ 6?   $
��Left=�6d   $��
99,139,0,0q�6   $	��Top=�6�   $ 0.517,-0.667&�6�   �� 5&      -   5        $ txtTelefono��5&      #��[ 6+    . $
��Left=�6b   $��23��6}   $��180,167,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 5'      -   5        $ lblTelefono��5'      $��
Teléfono:��6)   #��[ 6>   $
��Left=�6c   $��100,167,0,0q�6~   $	��Top=�6�   �� 5(      -   5        $ 	lblBarrio��5(      $��Barrio:��6'   #��[ 6:   $
��Left=�6_   $��100,195,0,0q�6z   $	��Top=�6�   �� 5)      -   5         ��Name$ 	cmbBarrio��5)        ListaDesplegable#��[ 6*   $
��Left=�6T   $��180,195,0,0q�6o   $	��Top=�6�   $	��260��6�   ��5*      �� 5+      .R�5,      �� .+�5-      �� ��6(   ��  �� Path$ Nombre�5.      5/      51      �� 52      -   5        $ txtCuitCuil��52      #��[ 6+    . $
��Left=�6b   $��23��6}   $��180,111,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   �� 53      -   5        $ lblFechaNac��53      $��Fecha Nac.:��6)   #��[ 6@   $
��Left=�6e   $��
100,82,0,0q�6�   $	��Top=�6�   $ 0.946,0.583&�6�   �� 54      -   5        $ lblCuitCuil��54      $��
CUIT/CUIL:��6)   #��[ 6?   $
��Left=�6d   $��100,112,0,0q�6   $	��Top=�6�   $ 0.946,0.583&�6�   (  "System.Windows.Controls.DatePicker  55      -   5          Name$ 
dpFechaNac��55      $��180,81,668,407q�6-   &   System.Windows.Controls.DataGrid  56      -   5          Name$ grillaGrupos��56       	 Tabla#��[ 6-     CeldaGrilla   	CellStyle# [ 6L   $��100,299,0,44q�6u      
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6�   $	��340��6�    � DataContext 6�   ��    Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Id��6j    	  
Visibility$ Hidden=�6v   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6*   �� *
Id_grupo+ 
  ClipboardContentBinding 6G   Z� 6v     59      $ Nombre��6D    6)   �� *Nombre+6D     5:      $ Descripción��6I    6)   �� *Descripcion+6I   5=      �� 5>      -   5        $ 	lblGrupos��5>      $!��Grupos a los que pertenece:��6'   #��[ 6N   $
��Left=�6s   $��100,270,0,0q�6�   $	��Top=�6�   �� 5?      $��Agregar Beneficios��6   $
��Left=�63   $��509,112,0,0q�6N   $	��Top=�6c   $	��153��6{   $	��433��6�   ���	#FFCADEB8.��5@      � $��0,0,-2,1q�6   .+�5A      �� -   5        $ cmbBeneficios��5A      #��[ 66   $
��Left=�6`   $��	10,36,0,0q�6{   $	��Top=�6�   $	��205��6�   ��5B      �� 5C      .R�5D   "   �� .+�5E   &   �� ��60   �� *Nombre_beneficio+5F   #   5G      5I      �� 5J      -   5        $ lblBeneficio��5J      $��
Beneficios��62   $
��Left=�6G   $��10,5,0,0q�6b   $	��Top=�6t   �� 5K      -   5        $ lblFecha��5K      $��Fecha de asignación��6.   $
��Left=�6L   $��	10,55,0,0q�6g   $	��Top=�6z   �� 5L      -   5          ��Name$  btnAgregarBeneficio��5L        	BotonMenu#��[ 6:   $
��Left=�6]   $��
290,25,0,0q�6x   $	��Top=�6�   $��40��6�   $��40��6�   .��5M      � .+�5N      �� -   5        ! ��Name$! imgbtnAgregar��5N   $   $��Graficos/add.png��6;   $��32��6U   $��32��6a   $
��Left=�6l   $��0,0,0,0q�6�   5P      5Q      �� 5R      -   5        $  btnBuscarBeneficio��5R      #��[ 69   $
��Left=�6\   $��
220,25,0,0q�6w   $	��Top=�6�   $��40��6�   $��40��6�   .��5S      � .+�5T      �� -   5        $! imgbtnBuscar��5T   $   $��Graficos/find.png��6:   $��32��6U   $��32��6a   $
��Left=�6l   $��0,0,0,0q�6�   5V      5W      �� 5Z      -    5        $  btnQuitarBeneficio��5Z      #��[ 69   $
��Left=�6\   $��
360,25,0,0q�6w   $	��Top=�6�   $��40��6�   $��40��6�   .��5[      � .+�5\      �� -!   5        $! imgbtnQuitar��5\   $   $��Graficos/quitar.png��6:   $��32��6W   $��32��6c   $
��Left=�6n   $��0,0,0,0q�6�   5^      5_        5`      -"   5        $ dpFechaAsignacion��5`   !   $��10,81,306,21q�6<   5b      5d        5e      -#   5        $ grillaBeneficios��5e      #��[ 61   # [ 6P   $��509,299,0,44q�6y    .  .  $
��Left=�6  $	��433��6&   6�   ��  5f        5g      $ Id��6n   $ Hidden=�6z    6*   �� *Id_beneficio+ 6K   Z� 6z     5h      $ Cantidad��6N    6)   �� *Nombre_beneficio+6N     5i      $ 	Artículo��6S    6)   �� *Descripcion_beneficio+6S     5j      $ Descripción��6L    6)   �� *Fecha_asignado+6L   5l      �� 5m      -$   5        $ lblBeneficios��5m      $��Beneficios asignados:��6+   #��[ 6L   $
��Left=�6q   $��509,270,0,0q�6�   $	��Top=�6�   $��22��6�   5n      �� 5o   
   -%   5        $��txtBien��5o      #��[ 6!   $y�Hidden=�6F   �� 5p   
   -&   5        $��txtMal��5p        CajadeTextoError#��[ 6    $y�Hidden=�6J   5r      5s      