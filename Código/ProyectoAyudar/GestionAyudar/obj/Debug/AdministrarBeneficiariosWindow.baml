   M S B A M L   `   `   `  ����  GestionAyudarK    EProcessar.ProyectoAyudar.GestionAyudar.AdministrarBeneficiariosWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$5  /Administrar Beneficiarios - Comuna de Margarita��5       � WindowStartupLocation$ CenterScreen=�6@   $	��720��6e   $
��1024��6r    � 
ResizeMode$ NoResize=�6�    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5
      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditarBeneficiario��5      $��Editar��6?   $	��0,1q�6O   $
��Auto��6\   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnNuevoBeneficiario��5   #   
   Label$
 Nuevo��6A      LargeImageSource$' !Graficos/beneficiario_agregar.png��6O   $��55��6�   $��
0,10,0,-10q�6�     5      -   5        $	 btnModificarBeneficiario��5   #   $
 	Modificar��6E   $) #Graficos/beneficiario_modificar.png��6W   $��55��6�   $��
0,10,0,-10q�6�     5      -   5        $	 btnEliminarBeneficiario��5   #   $
 Eliminar��6D   $( "Graficos/beneficiario_eliminar.png��6U   $��55��6�   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoCriterio��5      $��	Criterios��65   $
��auto��6H   $��66��6U   .@�5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5          Name$ 	rdbNombre��5   (      Label$ Nombre��6;   6J     5      -   5        $ rdbDocumento��5   (   $ 	Documento��6>   6P   5        5      -	   5        $  grupoConsultarBeneficiario��5      $��	Consultar��6B   $	��590��6V   .@�5"      2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -
   5          Name$ txtBusquedaBeneficiario��5"   $     CajadeTexto#��[ 6F      Label$ Buscar:��6k   $��10,10,-325,0q�6{    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   6�     5#      -   5        $	 btnBuscarBeneficiario��5#   #   $
 Buscar��6B   $ Graficos/buscar.png��6Q   $��55��6x   $��333,10,-333,-10q�6�     5$      -   5        $	 btnAbrirBeneficiario��5$   #   $
 	Consultar��6A   $+ %Graficos/beneficiario_seleccionar.png��6S   $��55��6�   $��343,10,-333,-10q�6�   5&      5-      5/      � 50   
   -   5         �Name$ gridBeneficiarios��50        	GridVerde#��[ 6*   $��10,163,10,10q�6M   .+�51      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaBeneficiarios��51       	 Tabla#��[ 64     CeldaGrilla   	CellStyle# [ 6S   $
��Left=�6|   $��
10,40,0,11q�6�   $	��976��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 52      0	  *System.Windows.Controls.DataGridTextColumn	  53      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6p    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id_beneficiario+   ClipboardContentBinding 6M   Z� 6�   	  54      $ Nombre��6g    6)   �� *Nombre+ 6D   Z� 6g   	  55      $ 	Documento��6j    6)   �� *	Documento+ 6G   Z� 6j   	  56      $ 
Dirección��6j    6)   �� *	Direccion+ 6G   Z� 6j   	  57      $ 	Teléfono��6i    6)   �� *
Telefono+ 6F   Z� 6i   	  58      $ Barrio��6n    6)   �� *Barrio.Nombre+ 6K   Z� 6n   5;      �� 5<      $��Beneficiarios:��6     Label_Comun#��[ 6-   $
��Left=�6R   $��	10,11,0,0q�6m   $	��Top=�6�   5=      5?      5@      