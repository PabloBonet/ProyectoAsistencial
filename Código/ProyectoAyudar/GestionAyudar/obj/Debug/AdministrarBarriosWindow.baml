   M S B A M L   `   `   `  ����  GestionAyudarE    ?Processar.ProyectoAyudar.GestionAyudar.AdministrarBarriosWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$/  )Administrar Barrios - Comuna de Margarita��5       � WindowStartupLocation$ CenterScreen=�6=   $	��720��6b   $
��1024��6o    � 
ResizeMode$ NoResize=�6|    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5
      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarBarrio��5      $��Editar��69   $	��0,1q�6I   $
��Auto��6V   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnNuevoBarrio��5   #   
   Label$
 Nuevo��6;      LargeImageSource$ Graficos/barrio_nuevo.png��6I   $��55��6v   $��
0,10,0,-10q�6�     5      -   5        $	 btnModificarBarrio��5   #   $
 	Modificar��6?   $  Graficos/barrio_editar.png��6Q   $��55��6   $��
0,10,0,-10q�6�     5      -   5        $	 btnEliminarBarrio��5   #   $
 Eliminar��6>   $" Graficos/barrio_eliminar.png��6O   $��55��6   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoConsultarBarrio��5      $��	Consultar��6<   $	��0,1q�6O   $	��590��6\   .@�5        -   5        $ grupoCriterio��5   "   $��	Criterios��69   $	��0,1q�6L   $��90��6Y   .@�5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5          Name$ 	rdbNombre��5   ,      Label$ Nombre��6?   6N   5       2  ,System.Windows.Controls.Ribbon.RibbonTextBox  5$      -	   5          Name$ txtBusquedaBarrio��5$   $     CajadeTexto#��[ 6?      Label$ Buscar:��6d   $��10,10,-325,0q�6t    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   6�     5%      -
   5        $	 btnBuscarBarrio��5%   #   $
 Buscar��6<   $ Graficos/buscar.png��6K   $��55��6r   $��333,10,-333,-10q�6�     5&      -   5        $	 btnAbrirBarrio��5&   #   $
 	Consultar��6;   $ Graficos/consultar.png��6M   $��55��6w   $��343,10,-333,-10q�6�   5)      5+      5-      � 5/   
   -   5         �Name$ 
gridBarrio��5/        	GridVerde#��[ 6#   $��10,163,10,10q�6F   .+�50      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaBarrios��50       	 Tabla#��[ 6.     CeldaGrilla   	CellStyle# [ 6M   $
��Left=�6v   $��
10,40,0,11q�6�   $	��750��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 51      0	  *System.Windows.Controls.DataGridTextColumn	  52      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6i    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
IdBarrio+   ClipboardContentBinding 6F   Z� 6�   	  53      $ Barrio��6g    6)   �� *Nombre+ 6D   Z� 6g   	  54      $ Ciudad��6g    6)   �� *Ciudad+ 6D   Z� 6g   57      �� 58      $��Barrios:��6     Label_Comun#��[ 6'   $
��Left=�6L   $��	10,11,0,0q�6g   $	��Top=�6z   59      5:      5;      