   M S B A M L   `   `   `  ����H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  5   	   >    8Processar.ProyectoAyudar.GestionAyudar.BuscarGrupoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GestionBeneficiarios     5   	   -   5          � Title$(  "Buscar Grupo - Comuna de Margarita��5      $	��620��62   $	��850��6?    � WindowStartupLocation$ CenterScreen=�6K    � 
ResizeMode$ NoResize=�6q    � Icon$ Graficos/logo.png��6�    � 	Resources 5
       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$  grupoConsultarBeneficiario��5      $��	Consultar��6B   $	��0,1q�6U   $	��510��6b   .@�5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5        	  Name$	 	rdbNombre��5   (   
   Label$
 Grupo��6;   6I     5      -   5        $	 rdbDocumento��5   (   $
 	Documento��6>   6P     5      -   5        $	 rdbBeneficiario��5   (   $
 Beneficiario��6A   6V   2  ,System.Windows.Controls.Ribbon.RibbonTextBox  5      -   5          Name$ txtBusquedaGrupo��5   $     CajadeTexto#��[ 6?      Label$ Buscar:��6d   $��10,10,-325,0q�6t    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   1  +System.Windows.Controls.Ribbon.RibbonButton  5      -   5          Name$ btnBuscarGrupo��5   #      Label$ Buscar��6;      LargeImageSource$ Graficos/buscar.png��6J   $��55��6q   $��333,10,-333,-10q�6�   5         5!      -   5        $ grupoSeleccionar��5!      $��Seleccionar��68   $	��0,1q�6M   $
��Auto��6Z   .@�5#        -	   5        $ btnSeleccionar��5#   #   $ Seleccionar��6;   $+ %Graficos/seleccionar_beneficiario.png��6O   $��55��6�   $��
0,10,0,-10q�6�   5$        5%      -
   5        $ 
grupoNuevo��5%      $��Administrar��62   $	��0,1q�6G   $
��Auto��6T   .@�5'        -   5        $ btnNuevo��5'   #   $ Nuevo��65   $ Graficos/nuevo.png��6C   $��55��6j   $��5,10,-5,-10q�6�   5(      5)      5+      � 5,   
   -   5         �Name$ 
gridGrupos��5,        	GridVerde#��[ 6#   $��10,163,10,10q�6F   .+�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaGrupos��5-       	 Tabla#��[ 6-     CeldaGrilla   	CellStyle# [ 6L   $
��Left=�6u   $��
10,40,0,11q�6�   $	��804��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 5.      0	  *System.Windows.Controls.DataGridTextColumn	  5/      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6i    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
Id_grupo+   ClipboardContentBinding 6F   Z� 6�   	  50      $ Nombre��6g    6)   �� *Nombre+ 6D   Z� 6g   	  51      $ Descripción��6l    6)   �� *Descripcion+ 6I   Z� 6l   55      �� 56      $��Grupos:��6     Label_Comun#��[ 6&   $
��Left=�6K   $��	10,11,0,0q�6f   $	��Top=�6y   57      59      5:      