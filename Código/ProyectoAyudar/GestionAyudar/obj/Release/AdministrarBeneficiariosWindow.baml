   M S B A M L   `   `   `  ����   GestionAyudarK    EProcessar.ProyectoAyudar.GestionAyudar.AdministrarBeneficiariosWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$5  /Administrar Beneficiarios - Comuna de Margarita�� � WindowStartupLocation$ CenterScreen=�$	��720��$
��1024�� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditarBeneficiario��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	  Name$	 btnNuevoBeneficiario��
   Label$
 Nuevo��   LargeImageSource$' !Graficos/beneficiario_agregar.png��$��55��$��
0,10,0,-10q�  -   $	 btnModificarBeneficiario��$
 	Modificar��$) #Graficos/beneficiario_modificar.png��$��55��$��
0,10,0,-10q�  -   $	 btnEliminarBeneficiario��$
 Eliminar��$( "Graficos/beneficiario_eliminar.png��$��55��$��
0,10,0,-10q�  -   $ grupoCriterio��$��	Criterios��$
��auto��$��66��.@�6  0System.Windows.Controls.Ribbon.RibbonRadioButton  -     Name$ 	rdbNombre��   Label$ Nombre��  -   $ rdbDocumento��$ 	Documento��  -	   $  grupoConsultarBeneficiario��$��	Consultar��$	��590��.@�2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -
     Name$ txtBusquedaBeneficiario��  CajadeTexto#��[    Label$ Buscar:��$��10,10,-325,0q� �� TextWrapping$
 Wrap=�   TextBoxWidth$	 300Q�$	��Top=�  -   $	 btnBuscarBeneficiario��$
 Buscar��$ Graficos/buscar.png��$��55��$��333,10,-333,-10q�  -   $	 btnAbrirBeneficiario��$
 	Consultar��$+ %Graficos/beneficiario_seleccionar.png��$��55��$��343,10,-333,-10q�� -    �Name$ gridBeneficiarios��  	GridVerde#��[ $��10,163,10,10q�.+�&   System.Windows.Controls.DataGrid  -     Name$ grillaBeneficiarios�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $
��Left=�$��
10,40,0,11q�$	��976��   
IsReadOnly .    AutoGenerateColumns .   � DataContext ��    Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Identificador�� 
  
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id_beneficiario+   ClipboardContentBinding Z� 	  $ Nombre�� �� *Nombre+ Z� 	  $ 	Documento�� �� *	Documento+ Z� 	  $ 
Dirección�� �� *	Direccion+ Z� 	  $ 	Teléfono�� �� *
Telefono+ Z� 	  $ Barrio�� �� *Barrio.Nombre+ Z� �� $��Beneficiarios:��  Label_Comun#��[ $
��Left=�$��	10,11,0,0q�$	��Top=�