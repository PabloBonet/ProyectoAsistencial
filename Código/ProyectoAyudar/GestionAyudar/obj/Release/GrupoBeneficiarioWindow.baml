   M S B A M L   `   `   `  ����   GestionAyudarD    >Processar.ProyectoAyudar.GestionAyudar.GrupoBeneficiarioWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Grupos de Beneficiarios��$	��720��$
��1024�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  -     Name$ tabConsultaGrupo��$��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditarGrupo��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	  Name$	 btnEliminarGrupo��
   Label$
 Eliminar�� � ToolTip$ Eliminar Grupo��   LargeImageSource$ Graficos/delete.png��$��55��$��
0,10,0,-10q�  -   $ grupoCambios��$��Cambios��$	��0,1q�$
��Auto��.@�  -   $	 btnGuardarGrupo��$
 Guardar��$ Graficos/guardar.png��$ Guardar o crear Grupo��$��55��$��4,10,-4,-10q�  -   $	 btnCancelarCambios��$
 Cancelar��$ Graficos/cancel.png��$��55��$" Cancelar y cerrar la ventana��$��4,10,-4,-10q�� -    �Name$ gridOrdenes��  	GridVerde#��[ $��10,163,10,10q� � ColumnDefinitions �� $
��250* ��� $
��250* �.+��� -	    ��Name$ 
txtIdGrupo��  CajadeTexto#��[  �� 
IsReadOnly . $
��Left=�$��23��$��
163,61,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��260���� -
   $ txtDescripcion��#��[  . $
��Left=�$��63��$��163,175,0,0q�$
 Wrap=�$	��Top=�$	��260���� -    ��Name$ 
lblIdGrupo��$��Identificador:��  Label_Comun#��[ $
��Left=�$��	30,61,0,0q�$	��Top=��� -   $ lblDescripcion��$��Descripción:��#��[ $
��Left=�$��
30,175,0,0q�$	��Top=��� -   $ txtNombreGrupo��#��[  . $
��Left=�$��23��$��163,111,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblNombreGrupo��$��Nombre:��#��[ $
��Left=�$��
30,111,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ grillaBeneficiarios�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $��10,175,0,193q�   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��478��$��1�� � DataContext ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
Visibility$ Hidden=�1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id_Beneficiario+ 	  ClipboardContentBinding Z�   $ Nombre�� �� *Nombre+  $ 	Documento�� �� *	Documento+  $ 	Cuit/Cuil�� �� *	Cuit_Cuil+�� $��Agregar Beneficiarios��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��136��$	��478�����	#FFCADEB8$��1��.��� $��0,0,0,1q�.+��� -    ��Name$ cmbBeneficiarios��  ListaDesplegable#��[ $
��Left=�$��	10,36,0,0q�$	��Top=�$	��205������ .R��� .+��� ����  �� Path$ Nombre��� -   $ lblBeneficiarios��$��Beneficiarios��$
��Left=�$��10,5,0,0q�$	��Top=��� -    ��Name$ btnAgregarBeneficiario��  	BotonMenu#��[ $
��Left=�$��
290,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -   $��imgbtnAgregar��$��Graficos/add.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -   $ btnBuscarBeneficiario��#��[ $
��Left=�$��
220,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -   $��imgbtnBuscar��$��Graficos/find.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -   $ btnQuitarBeneficiario��#��[ $
��Left=�$��
360,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -   $��imgbtnQuitar��$��Graficos/quitar.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -   $ lblItems��$��Integrantes del grupo:��#��[ $
��Left=�$��
10,151,0,0q�$	��Top=�$��1���� -   $��txtBien��#��[ $y�Hidden=��� -   $��txtMal��  CajadeTextoError#��[ $y�Hidden=�