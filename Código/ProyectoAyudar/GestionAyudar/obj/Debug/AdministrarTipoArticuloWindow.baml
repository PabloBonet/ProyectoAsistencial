   M S B A M L   `   `   `  ����H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  5   	   J    DProcessar.ProyectoAyudar.GestionAyudar.AdministrarTipoArticuloWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GestionBeneficiarios     5   	   -   5          � Title$:  4Administrar Tipo de Artículos - Comuna de Margarita��5   	    � WindowStartupLocation$ CenterScreen=�6E   $	��720��6j   $
��1024��6w    � 
ResizeMode$ NoResize=�6�    � Icon$ Graficos/logo.png��6�    � 	Resources 5
       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarTipoArticulo��5      $��Editar��6?   $	��0,1q�6O   $
��Auto��6\   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnNuevoTipoArticulo��5   #   
   Label$
 Nuevo��6A      LargeImageSource$ Graficos/nuevo.png��6O   $��55��6u   $��
0,10,0,-10q�6�     5      -   5        $	 btnModificarTipoArticulo��5   #   $
 	Modificar��6E   $ Graficos/modificar.png��6W   $��55��6�   $��
0,10,0,-10q�6�     5      -   5        $	 btnEliminarTipoArticulo��5   #   $
 Eliminar��6D   $ Graficos/delete.png��6U   $��55��6|   $��
0,10,0,-10q�6�   5        5      -   5        $  grupoConsultarTipoArticulo��5      $��	Consultar��6B   $	��0,1q�6U   $	��590��6b   .@�5        -   5        $ grupoCriterio��5   "   $��	Criterios��69   $	��0,1q�6L   $��90��6Y   .@�5!      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5          Name$ 	rdbNombre��5!   ,      Label$ Nombre��6?   6N   5$      2  ,System.Windows.Controls.Ribbon.RibbonTextBox  5(      -	   5          Name$ txtBusquedaTipoArticulo��5(   $     CajadeTexto#��[ 6E      Label$ Buscar:��6j   $��10,10,-325,0q�6z    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   6�     5)      -
   5        $	 btnBuscarTipoArticulo��5)   #   $
 Buscar��6B   $ Graficos/buscar.png��6Q   $��55��6x   $��333,10,-333,-10q�6�     5*      -   5        $	 btnAbrirTipoArticulo��5*   #   $
 	Consultar��6A   $ Graficos/consultar.png��6S   $��55��6}   $��343,10,-333,-10q�6�   5-      5/      51      � 53   
   -   5         �Name$ gridTipoArticulo��53        	GridVerde#��[ 6)   $��10,163,10,10q�6L   .+�54      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaTipoArticulo��54       	 Tabla#��[ 63     CeldaGrilla   	CellStyle# [ 6R   $
��Left=�6{   $��
10,40,0,11q�6�   $	��750��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 55      0	  *System.Windows.Controls.DataGridTextColumn	  56      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6p    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id_TipoArticulo+   ClipboardContentBinding 6M   Z� 6�   	  57      $ Nombre��6t    6)   �� *Nombre_TipoArticulo+ 6Q   Z� 6t   4  .System.Windows.Controls.DataGridCheckBoxColumn  58      $ Dinero��6r    
  Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6�    6-   ��  �� Path$ EsDinero� 6O   Z� 6�   5;      �� 5<      $��Tipo de Artículos:��6     Label_Comun#��[ 61   $
��Left=�6V   $��	10,11,0,0q�6q   $	��Top=�6�   5=      5>      5?      