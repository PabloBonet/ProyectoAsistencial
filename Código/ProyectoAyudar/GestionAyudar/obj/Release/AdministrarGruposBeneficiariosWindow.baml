   M S B A M L   `   `   `  ����   GestionAyudarQ    KProcessar.ProyectoAyudar.GestionAyudar.AdministrarGruposBeneficiariosWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$<  6Administrar Grupos Beneficiarios - Comuna de Margarita�� � WindowStartupLocation$ CenterScreen=�$	��720��$
��1024�� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditaGrupo��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	  Name$	 btnNuevoGrupo��
   Label$
 Nuevo��   LargeImageSource$' !Graficos/beneficiario_agregar.png��$��55��$��
0,10,0,-10q�  -   $	 btnModificarGrupo��$
 	Modificar��$) #Graficos/beneficiario_modificar.png��$��55��$��
0,10,0,-10q�  -   $	 btnEliminarGrupo��$
 Eliminar��$( "Graficos/beneficiario_eliminar.png��$��55��$��
0,10,0,-10q�  -   $ grupoCriterio��$��	Criterios��$��0,12,0,0q�$��90��.@�6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -     Name$ rdbNombreGrupo��   Label$ Grupo��  -   $ rdbDocumento��$ 	Documento��  -	   $ rdbNombreBeneficiario��$ Beneficiario��  -
   $ grupoConsultarGrupo��$��	Consultar��$	��0,1q�$	��590��.@�2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -     Name$ txtBusquedaGrupo��  CajadeTexto#��[    Label$ Buscar:��$��10,10,-325,0q� �� TextWrapping$
 Wrap=�   TextBoxWidth$	 300Q�$	��Top=�  -   $	 btnBuscarGrupo��$
 Buscar��$ Graficos/buscar.png��$��55��$��333,10,-333,-10q�  -   $	 btnAbrirGrupo��$
 	Consultar��$+ %Graficos/beneficiario_seleccionar.png��$��55��$��343,10,-333,-10q�� -    �Name$ 
gridGrupos��  	GridVerde#��[ $��10,163,10,10q�.+�&   System.Windows.Controls.DataGrid  -     Name$ grillaGrupos�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $
��Left=�$��
10,40,0,11q�$	��976��   
IsReadOnly .    AutoGenerateColumns .   � DataContext ��    Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador�� 
  
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Id_grupo+   ClipboardContentBinding Z� 	  $ Nombre�� �� *Nombre+ Z� 	  $ 	Documento�� �� *Descripcion+ Z� �� $��Grupos:��  Label_Comun#��[ $
��Left=�$��	10,11,0,0q�$	��Top=�