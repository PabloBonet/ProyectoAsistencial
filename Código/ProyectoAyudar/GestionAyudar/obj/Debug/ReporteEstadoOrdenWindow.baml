   M S B A M L   `   `   `  ����H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  5   	   E    ?Processar.ProyectoAyudar.GestionAyudar.ReporteEstadoOrdenWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GestionBeneficiarios     5   	   -   5          � Title$/  )Reporte por estados - Comuna de Margarita��5      $	��720��6:   $
��1050��6G    � WindowStartupLocation$ CenterScreen=�6T    � Icon$ Graficos/logo.png��6�    � 	Resources 5
       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Reporte por Estado��6   $��88��65   $	��Top=�6A   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEstado��5      $��Estado��63   $	��0,1q�6C   $	��200��6P   .@�5      �� -   5         ��Name$ chAutorizado��5        CheckBoxVerde#��[ 65   $��
Autorizado��6\   $
��Left=�6q   $��
10,10,-1,0q�6�   $	��Top=�6�   �� 5      -   5        $ chEntregado��5      #��[ 64   $��	Entregado��6\   $
��Left=�6p   $��
10,10,-1,0q�6�   $	��Top=�6�   �� 5      -   5        $ chCancelado��5      #��[ 65   $��	Cancelado��6\   $
��Left=�6p   $��
10,10,-1,0q�6�   $	��Top=�6�   �� 5      -   5        $ 
chIniciado��5      #��[ 63   $��Iniciado��6Z   $
��Left=�6m   $��
10,10,-1,0q�6�   $	��Top=�6�   5        5      -   5        $ grupoPeriodoBusqueda��5      $��Período��6<   $	��0,1q�6M   $	��410��6Z   .@�5      (  "System.Windows.Controls.DatePicker  -   5        	  Name$	 dpFechaDesde��5   !   $��10,10,-160,3q�67   �� 5      -	   5        
 ��Name$
 lblDesde��5      $��Desde��6.   $��25��6>   $��50,-3,-103,3q�6J     5!      -
   5        $	 dpFechaHasta��5!   !   $��180,10,-330,1q�67   �� 5"      -   5        $
 lblHasta��5"      $��Hasta��6.   $��25��6>   $��220,-1,-267,1q�6J   1  +System.Windows.Controls.Ribbon.RibbonButton  5#      -   5          Name$ btnBuscarOrdenes��5#   #      Label$ Buscar��6=      LargeImageSource$ Graficos/buscar.png��6L   $��55��6s   $��340,10,-340,-10q�6�   5$        5%      -   5        $ grupoImprimir��5%      $��Imprimir��65   $	��0,1q�6G   $	��215��6T   .@�5&        -   5        $ grupoOpciones��5&   "   $��Opciones��69   $��0,1,6,1q�6K   .@�5'      �� -   5        $ chImprimirArticulos��5'      #��[ 6<   $��Imprimir Artículos��6c   $
��Left=�6�   $��
10,10,-1,0q�6�   $	��Top=�6�   5(        5*      -   5        $ btnImprimir��5*   #   $ Imprimir��68   $ Graficos/imprimir.png��6I   $��55��6r   $��10,10,-10,-10q�6�   5-      5.      5/      � 51   
   -   5         �Name$ gridOrdenes��51        	GridVerde#��[ 6$   $��10,163,10,10q�6G   .+�52      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaOrdenes��52       	 Tabla#��[ 6.     CeldaGrilla   	CellStyle# [ 6M   $
��Left=�6v   $��10,39,0,253q�6�   $
��1002��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 	Nº Orden��6q    	  
Visibility$ Visible=�6�   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6)   �� *Id_orden_entrega+ 
  ClipboardContentBinding 6N   Z� 6�     55      $ DNI Beneficiario��6w    6)   �� *Beneficiario.Documento+ 6T   Z� 6w     57      $ Descripción��6m   $ Visible=�6�    6*   �� *Descripcion+ 6J   Z� 6�     58      $ Fecha creado��6v    6)   �� *FechaCreadoFormateada+ 6S   Z� 6v     59      $ Entregado por��6    6)   �� * UsuarioEntrega.Nombre_completo+ 6\   Z� 6     5:      $ Autorizado por��6�    6)   �� *!UsuarioAutoriza.Nombre_completo+ 6]   Z� 6�     5;      $ Estado��6t    6)   �� *EstadoActual.Estado+ 6Q   Z� 6t     5<      $ Fecha estado��6}    6)   �� *EstadoActual.FechaFormateada+ 6Z   Z� 6}   5?      �� 5@      -   5        $
 lblReporteEstados��5@        Label_Comun#��[ 6/   $��Ordenes por estados��6T   $
��Left=�6r   $��	10,10,0,0q�6�   $	��Top=�6�   $	��163��6�     5A      -   5        $ grillaArticulos��5A      #��[ 60   # [ 6O   $
��Left=�6x   $��
10,297,0,9q�6�   $
��1002��6�    .  .   6�   ��  5B        5C      $ IdItem��6p   $ Hidden=�6�    6)   �� *Id_item_entrega+ 6M   Z� 6�     5D      $ Cantidad��6i    6)   �� *
Cantidad+ 6F   Z� 6i     5E      $ Nombre��6y    6)   �� *Articulo.Nombre_articulo+ 6V   Z� 6y     5F      $ Descripción��6~    6)   �� *Articulo.Descripcion_articulo+ 6[   Z� 6~     5G      $ Tipo Artículo��6�    6)   �� *,*Articulo.Tipo_articulo.Nombre_TipoArticulo+ 6h   Z� 6�   5K      �� 5L      -   5        $
 lblItems��5L      #��[ 6&   $$��Articulos por orden de entrega��6K   $
��Left=�6t   $��
10,268,0,0q�6�   $	��Top=�6�   $	��203��6�   5N      5O      5P      