   M S B A M L   `   `   `  ����  GestionAyudar9    3Processar.ProyectoAyudar.GestionAyudar.BarrioWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Barrio��5   	   $	��500��6   $
��1024��6%    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6y    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5	      �    	GridFondo#��[  6   .+�5
   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  -   5          Name$ tabConsultaBarrio��5      $��Editar��63   $��88��6C   $	��Top=�6O   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5        	  Name$	 grupoEditarBarrio��5      $��Editar��69   $	��0,1q�6I   $
��Auto��6V   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        
  Name$
 btnEliminarBarrio��5   #      Label$ Eliminar��6>      LargeImageSource$ Graficos/delete.png��6O   $��55��6v   $��
0,10,0,-10q�6�   5        5      -   5        $	 grupoCambios��5      $��Cambios��64   $	��0,1q�6E   $
��Auto��6R   .@�5        -   5        $
 btnGuardarBarrio��5   #   $ Guardar��6=   $ Graficos/guardar.png��6M   $��55��6u   $��4,10,-4,-10q�6�     5      -   5        $
 btnCancelarCambios��5   #   $ Cancelar��6?   $ Graficos/cancel.png��6P   $��55��6w   $��4,10,-4,-10q�6�   5      5      5      � 5   
   -   5         �Name$ gridBeneficiarios��5        	GridVerde#��[ 6*   $��10,163,10,10q�6M   .+�5      �� -	   5         ��Name$ 	txtNombre��5        CajadeTexto#��[ 6)    �� 
IsReadOnly . $
��Left=�6`   $��23��6{   $��243,100,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��260��6�   6�   �� 5      -
   5         ��Name$ 	lblNombre��5      $��Nombre:��6'     Label_Comun#��[ 6:   $
��Left=�6_   $��150,100,0,0q�6z   $	��Top=�6�    J� RenderTransformOrigin$ 0.946,0.583&�6�   �� 5       -   5        $ 	txtCiudad��5       #��[ 6)    . $
��Left=�6`   $��23��6{   $��243,150,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��260��6�   6�   �� 5!      -   5        $ 	lblCiudad��5!      $��Ciudad:��6'   #��[ 6:   $
��Left=�6_   $��150,150,0,0q�6z   $	��Top=�6�   �� 5"      -   5        $ txtBien��5"      #��[ 6'   $y�Hidden=�6L   $
��Left=�6`   $��23��6{   $��142,623,0,0q�6�   $
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��120��6�   �� 5#      -   5        $ txtMal��5#        CajadeTextoError#��[ 6&   $y�Hidden=�6P   $
��Left=�6d   $��23��6   $��302,646,0,0q�6�   $
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��120��6�   5%      5&      5'      