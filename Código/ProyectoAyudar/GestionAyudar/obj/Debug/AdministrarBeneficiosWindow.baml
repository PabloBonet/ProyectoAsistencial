   M S B A M L   `   `   `  ����  GestionAyudarH    BProcessar.ProyectoAyudar.GestionAyudar.AdministrarBeneficiosWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$2  ,Administrar Beneficios - Comuna de Margarita��5   	    � WindowStartupLocation$ CenterScreen=�6>   $	��720��6c   $
��1024��6p    � 
ResizeMode$ NoResize=�6~    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5
      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarBeneficios��5      $��Editar��6=   $	��0,1q�6M   $
��Auto��6Z   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnNuevoBeneficio��5   #   
   Label$
 Nuevo��6>      LargeImageSource$ Graficos/nuevo.png��6L   $��55��6r   $��
0,10,0,-10q�6�     5      -   5        $	 btnModificarBeneficio��5   #   $
 	Modificar��6B   $ Graficos/modificar.png��6T   $��55��6~   $��
0,10,0,-10q�6�     5      -   5        $	 btnEliminar��5   #   $
 Eliminar��68   $ Graficos/delete.png��6I   $��55��6p   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoConsultarBeneficio��5      $��	Consultar��6?   $	��0,1q�6R   $	��590��6_   .@�5        -   5        $ grupoCriterio��5   "   $��	Criterios��69   $	��0,1q�6L   $��90��6Y   .@�5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5          Name$ 	rdbNombre��5   ,      Label$ Nombre��6?   6N   5      2  ,System.Windows.Controls.Ribbon.RibbonTextBox  5#      -	   5          Name$ txtBusquedaBeneficio��5#   $     CajadeTexto#��[ 6C      Label$ Buscar:��6h   $��10,10,-325,0q�6x    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   6�     5$      -
   5        $	 btnBuscarBeneficio��5$   #   $
 Buscar��6?   $ Graficos/buscar.png��6N   $��55��6u   $��333,10,-333,-10q�6�     5&      -   5        $	 btnAbrirBeneficio��5&   #   $
 	Consultar��6>   $ Graficos/consultar.png��6P   $��55��6z   $��343,10,-333,-10q�6�   5)      5-      5/      � 50   
   -   5         �Name$ gridArticulos��50        	GridVerde#��[ 6&   $��10,163,10,10q�6I   .+�51      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaBeneficios��51       	 Tabla#��[ 61     CeldaGrilla   	CellStyle# [ 6P   $
��Left=�6y   $��
10,40,0,11q�6�   $	��976��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 52      0	  *System.Windows.Controls.DataGridTextColumn	  53      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6m    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id_beneficio+   ClipboardContentBinding 6J   Z� 6�   	  54      $ Nombre��6q    6)   �� *Nombre_beneficio+ 6N   Z� 6q   	  55      $ Descripción��6v    6)   �� *Descripcion_beneficio+ 6S   Z� 6v   59      �� 5:      $��Beneficios:��6     Label_Comun#��[ 6*   $
��Left=�6O   $��	10,11,0,0q�6j   $	��Top=�6}   5;      5=      5>      