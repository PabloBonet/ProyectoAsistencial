   M S B A M L   `   `   `  ����  GestionAyudarG    AProcessar.ProyectoAyudar.GestionAyudar.AdministrarArticulosWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$1  +Administrar Articulos - Comuna de Margarita��5   	    � WindowStartupLocation$ CenterScreen=�6=   $	��720��6b   $
��1024��6o    � 
ResizeMode$ NoResize=�6}    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5
      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarArticulos��5      $��Editar��6<   $	��0,1q�6L   $
��Auto��6Y   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnNuevoArticulo��5   #   
   Label$
 Nuevo��6=      LargeImageSource$ Graficos/nuevo.png��6K   $��55��6q   $��
0,10,0,-10q�6�     5      -   5        $	 btnModificarArticulo��5   #   $
 	Modificar��6A   $ Graficos/modificar.png��6S   $��55��6}   $��
0,10,0,-10q�6�     5      -   5        $	 btnEliminarArticulo��5   #   $
 Eliminar��6@   $ Graficos/delete.png��6Q   $��55��6x   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoConsultarArticulo��5      $��	Consultar��6>   $	��0,1q�6Q   $	��590��6^   .@�5        -   5        $ grupoCriterio��5   "   $��	Criterios��69   $	��0,1q�6L   $��90��6Y   .@�5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5          Name$ 	rdbNombre��5   ,      Label$ Nombre��6?   6N     5      -	   5        $ rdbTipo��5   ,   $
 Tipo��6=   6J   5!      2  ,System.Windows.Controls.Ribbon.RibbonTextBox  5%      -
   5          Name$ txtBusquedaArticulo��5%   $     CajadeTexto#��[ 6B      Label$ Buscar:��6g   $��10,10,-325,0q�6w    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   6�     5&      -   5        $	 btnBuscarArticulo��5&   #   $
 Buscar��6>   $ Graficos/buscar.png��6M   $��55��6t   $��333,10,-333,-10q�6�     5(      -   5        $	 btnAbrirArticulo��5(   #   $
 	Consultar��6=   $ Graficos/consultar.png��6O   $��55��6y   $��343,10,-333,-10q�6�   5+      5/      51      � 52   
   -   5         �Name$ gridArticulos��52        	GridVerde#��[ 6&   $��10,163,10,10q�6I   .+�53      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaArticulos��53       	 Tabla#��[ 60     CeldaGrilla   	CellStyle# [ 6O   $
��Left=�6x   $��
10,40,0,11q�6�   $	��976��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 54      0	  *System.Windows.Controls.DataGridTextColumn	  55      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6l    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id_articulo+   ClipboardContentBinding 6I   Z� 6�   	  56      $ Nombre��6p    6)   �� *Nombre_articulo+ 6M   Z� 6p   	  57      $ Descripción��6u    6)   �� *Descripcion_articulo+ 6R   Z� 6u   	  58      $ Tipo Artículo��6�    6)   �� *#!Tipo_articulo.Nombre_TipoArticulo+ 6_   Z� 6�   5<      �� 5=      $��
Articulos:��6     Label_Comun#��[ 6)   $
��Left=�6N   $��	10,11,0,0q�6i   $	��Top=�6|   5>      5@      5A      