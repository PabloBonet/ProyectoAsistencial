   M S B A M L   `   `   `  ����H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  5   	   M    GProcessar.ProyectoAyudar.GestionAyudar.ReporteEntregaBeneficiarioWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GestionBeneficiarios     5   	   -   5          � Title$;  5Reporte Entrega a Beneficiarios - Comuna de Margarita��5   	    � WindowStartupLocation$ CenterScreen=�6G   $	��720��6l   $
��1050��6y    � Icon$ Graficos/logo.png��6�    � 	Resources 5
       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Entrega Beneficiario��6   $��88��67   $	��Top=�6C   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoBeneficiario��5      $��Beneficiario��69   $	��0,1q�6O   $��80��6\   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5          Name$ btnBuscarBeneficiario��5   #   	   Label$	 Seleccionar��6B   
   LargeImageSource$+
 %Graficos/seleccionar_beneficiario.png��6V   $��55��6�   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoPeriodoBusqueda��5      $��Período��6<   $	��0,1q�6M   $	��402��6Z   .@�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ dpFechaDesde��5   !   $��10,10,-160,3q�67   �� 5      -   5         ��Name$ lblDesde��5      $��Desde��6.   $��25��6>   $��50,-3,-103,3q�6J     5      -   5        $ dpFechaHasta��5   !   $��180,10,-330,1q�67   �� 5       -   5        $ lblHasta��5       $��Hasta��6.   $��25��6>   $��220,-1,-267,1q�6J     5!      -	   5        $ btnBuscarArticulos��5!   #   $	 Buscar��6?   $
 Graficos/buscar.png��6N   $��55��6u   $��340,10,-340,-10q�6�   5"        5#      -
   5        $ grupoImprimir��5#   "   $��Imprimir��69   $	��0,1q�6K   $��75��6X   .@�5$        -   5        $ btnImprimir��5$   #   $	 Imprimir��68   $
 Graficos/imprimir.png��6I   $��55��6r   $��4,10,-4,-10q�6�   5&      5'      5(      � 5*   
   -   5         �Name$ gridArticulo��5*        	GridVerde#��[ 6%   $��10,163,10,10q�6H   .+�5+      �� -   5        $ 	lblNombre��5+      $��Nombre:��6'     Label_Comun#��[ 6:   $
��Left=�6_   $��
520,50,0,0q�6z   $	��Top=�6�    J� RenderTransformOrigin$ 0.946,0.583&�6�   �� 5,      -   5        $ lblDocumento��5,      $��
Documento:��6*   #��[ 6@   $
��Left=�6e   $��
140,50,0,0q�6�   $	��Top=�6�   �� 5-      -   5        $ lblDireccion��5-      $��
Dirección��6*   #��[ 6?   $
��Left=�6d   $��140,100,0,0q�6   $	��Top=�6�   $ 0.517,-0.667&�6�   �� 5.      -   5        $ lblTelefono��5.      $��
Teléfono:��6)   #��[ 6>   $
��Left=�6c   $��140,150,0,0q�6~   $	��Top=�6�   �� 5/      -   5        $ 	lblBarrio��5/      $��Barrio:��6'   #��[ 6:   $
��Left=�6_   $��520,100,0,0q�6z   $	��Top=�6�   &   System.Windows.Controls.DataGrid  50      -   5          Name$ grillaArticulos��50       	 Tabla#��[ 60     CeldaGrilla   	CellStyle# [ 6O   $
��Left=�6x   $��
10,229,0,9q�6�   $
��1002��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ IdGrilla��6q    	  
Visibility$ Hidden=�6�   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6)   �� *Id_grillaReporte+ 
  ClipboardContentBinding 6N   Z� 6�     53      $ 
IdArticulo��6l   $ Hidden=�6�    6)   �� *Id_articulo+ 6I   Z� 6�     54      $ Cantidad��6r    6)   �� *Cantidad_articulo+ 6O   Z� 6r     55      $ Nombre��6p    6)   �� *Nombre_articulo+ 6M   Z� 6p     56      $ Descripción��6u    6)   �� *Descripcion_articulo+ 6R   Z� 6u     57      $ Tipo Artículo��6n    6)   �� *Tipo_articulo+ 6K   Z� 6n     58      $ 	Nº orden��6q    6)   �� *Id_orden_entrega+ 6N   Z� 6q     59      $ Autorizado por��6o    6)   �� *Autorizado_por+ 6L   Z� 6o     5:      $ Entregado por��6n    6)   �� *Entregado_por+ 6K   Z� 6n     5;      $ Fecha Entrega��6{    6)   �� *FechaEntrega_orden_entrega+ 6X   Z� 6{     5<      $ Hora Entrega��6z    6)   �� *HoraEntrega_orden_entrega+ 6W   Z� 6z   5A      �� 5B      -   5         ��Name$ 	txtNombre��5B        CajadeTexto#��[ 6)    �� 
IsReadOnly . $
��Left=�6`   $��23��6{   $��
590,50,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��251��6�   �� 5C      -   5        $ txtDocumento��5C      #��[ 6,    . $
��Left=�6c   $��23��6~   $��
220,50,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��250��6�   �� 5D      -   5        $ txtDireccion��5D      #��[ 6,    . $
��Left=�6c   $��23��6~   $��220,101,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��250��6�   �� 5E      -   5        $ txtTelefono��5E      #��[ 6+    . $
��Left=�6b   $��23��6}   $��220,150,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��250��6�   �� 5F      -   5        $ 	txtBarrio��5F      #��[ 6)    . $
��Left=�6`   $��23��6{   $��590,101,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��251��6�   �� 5G      -   5        $ lblArticulos��5G      #��[ 6*   $��Artículos entregados��6O   $
��Left=�6n   $��
10,200,0,0q�6�   $	��Top=�6�   �� 5H      -   5        $ lblBeneficiario��5H      #��[ 6-   $��Beneficiario��6R   $
��Left=�6i   $��	10,10,0,0q�6�   $	��Top=�6�   5J      5M      5N      