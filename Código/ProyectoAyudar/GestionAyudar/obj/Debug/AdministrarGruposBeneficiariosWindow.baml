   M S B A M L   `   `   `  ����  GestionAyudarQ    KProcessar.ProyectoAyudar.GestionAyudar.AdministrarGruposBeneficiariosWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$<  6Administrar Grupos Beneficiarios - Comuna de Margarita��5       � WindowStartupLocation$ CenterScreen=�6G   $	��720��6l   $
��1024��6y    � 
ResizeMode$ NoResize=�6�    � Icon$ Graficos/logo.png��6�    � 	Resources 5       �� Source�� 5   
   $ recursosdic.xaml?�6   %    .��5
      �    	GridFondo#��[  6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�6   $	��148��6)   $��0,10,0,0q�68   "   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�Hidden=�6(   $��0��6<   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��6   $��88��6)   $	��Top=�65   ���	#FFCADEB8���	#FF4AA200.@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ grupoEditaGrupo��5      $��Editar��67   $	��0,1q�6G   $
��Auto��6T   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	  Name$	 btnNuevoGrupo��5   #   
   Label$
 Nuevo��6:      LargeImageSource$' !Graficos/beneficiario_agregar.png��6H   $��55��6}   $��
0,10,0,-10q�6�     5      -   5        $	 btnModificarGrupo��5   #   $
 	Modificar��6>   $) #Graficos/beneficiario_modificar.png��6P   $��55��6�   $��
0,10,0,-10q�6�     5      -   5        $	 btnEliminarGrupo��5   #   $
 Eliminar��6=   $( "Graficos/beneficiario_eliminar.png��6N   $��55��6�   $��
0,10,0,-10q�6�   5        5      -   5        $ grupoCriterio��5      $��	Criterios��65   $��0,12,0,0q�6H   $��90��6Z   .@�5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -   5          Name$ rdbNombreGrupo��5   (      Label$ Grupo��6@   6N     5      -   5        $ rdbDocumento��5   (   $ 	Documento��6>   6P     5      -	   5        $ rdbNombreBeneficiario��5   (   $ Beneficiario��6G   6\   5        5      -
   5        $ grupoConsultarGrupo��5      $��	Consultar��6;   $	��0,1q�6N   $	��590��6[   .@�5#      2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -   5          Name$ txtBusquedaGrupo��5#   $     CajadeTexto#��[ 6?      Label$ Buscar:��6d   $��10,10,-325,0q�6t    �� TextWrapping$
 Wrap=�6�      TextBoxWidth$	 300Q�6�   $	��Top=�6�   6�     5$      -   5        $	 btnBuscarGrupo��5$   #   $
 Buscar��6;   $ Graficos/buscar.png��6J   $��55��6q   $��333,10,-333,-10q�6�     5%      -   5        $	 btnAbrirGrupo��5%   #   $
 	Consultar��6:   $+ %Graficos/beneficiario_seleccionar.png��6L   $��55��6�   $��343,10,-333,-10q�6�   5'      5)      5+      � 5,   
   -   5         �Name$ 
gridGrupos��5,        	GridVerde#��[ 6#   $��10,163,10,10q�6F   .+�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ grillaGrupos��5-       	 Tabla#��[ 6-     CeldaGrilla   	CellStyle# [ 6L   $
��Left=�6u   $��
10,40,0,11q�6�   $	��976��6�      
IsReadOnly .    AutoGenerateColumns .   � DataContext 6�   ��    Columns 5.      0	  *System.Windows.Controls.DataGridTextColumn	  5/      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador��6i    
  
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
Id_grupo+   ClipboardContentBinding 6F   Z� 6�   	  50      $ Nombre��6g    6)   �� *Nombre+ 6D   Z� 6g   	  51      $ 	Documento��6l    6)   �� *Descripcion+ 6I   Z� 6l   54      �� 55      $��Grupos:��6     Label_Comun#��[ 6&   $
��Left=�6K   $��	10,11,0,0q�6f   $	��Top=�6y   56      58      59      