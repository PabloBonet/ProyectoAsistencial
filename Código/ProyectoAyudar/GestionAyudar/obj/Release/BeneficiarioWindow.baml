   M S B A M L   `   `   `  ����   GestionAyudar?    9Processar.ProyectoAyudar.GestionAyudar.BeneficiarioWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Beneficiario��$	��720��$
��1024�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  -     Name$ tabConsultaBeneficiario��$��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -   	  Name$	 grupoEditarBeneficiario��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   
  Name$
 btnEliminarBeneficiario��   Label$ Eliminar��   LargeImageSource$( "Graficos/beneficiario_eliminar.png��$��55��$��
0,10,0,-10q�  -   $	 grupoCambios��$��Cambios��$	��0,1q�$
��Auto��.@�  -   $
 btnGuardarBeneficiario��$ Guardar��$ Graficos/guardar.png��$��55��$��4,10,-4,-10q�  -   $
 btnCancelarCambios��$ Cancelar��$ Graficos/cancel.png��$��55��$��4,10,-4,-10q�� -    �Name$ gridBeneficiarios��  	GridVerde#��[ $��10,163,10,10q�.+��� -	    ��Name$ 	txtNombre��  CajadeTexto#��[  �� 
IsReadOnly . $
��Left=�$��23��$��
180,53,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��260���� -
    ��Name$ 	lblNombre��$��Nombre:��  Label_Comun#��[ $
��Left=�$��
100,53,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.946,0.583&��� -   $ txtDocumento��#��[  . $
��Left=�$��23��$��
180,25,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblDocumento��$��
Documento:��#��[ $
��Left=�$��
100,25,0,0q�$	��Top=��� -   $ txtDireccion��#��[  . $
��Left=�$��23��$��180,139,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblDireccion��$��
Dirección��#��[ $
��Left=�$��
99,139,0,0q�$	��Top=�$ 0.517,-0.667&��� -   $ txtTelefono��#��[  . $
��Left=�$��23��$��180,167,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblTelefono��$��
Teléfono:��#��[ $
��Left=�$��100,167,0,0q�$	��Top=��� -   $ 	lblBarrio��$��Barrio:��#��[ $
��Left=�$��100,195,0,0q�$	��Top=��� -    ��Name$ 	cmbBarrio��  ListaDesplegable#��[ $
��Left=�$��180,195,0,0q�$	��Top=�$	��260������ .R��� .+��� ����  �� Path$ Nombre��� -   $ txtCuitCuil��#��[  . $
��Left=�$��23��$��180,111,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblFechaNac��$��Fecha Nac.:��#��[ $
��Left=�$��
100,82,0,0q�$	��Top=�$ 0.946,0.583&��� -   $ lblCuitCuil��$��
CUIT/CUIL:��#��[ $
��Left=�$��100,112,0,0q�$	��Top=�$ 0.946,0.583&�(  "System.Windows.Controls.DatePicker  -     Name$ 
dpFechaNac��$��180,81,668,407q�&   System.Windows.Controls.DataGrid  -     Name$ grillaGrupos�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $��100,299,0,44q�   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��340�� � DataContext ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Id�� 	  
Visibility$ Hidden=�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *
Id_grupo+ 
  ClipboardContentBinding Z�   $ Nombre�� �� *Nombre+  $ Descripción�� �� *Descripcion+�� -   $ 	lblGrupos��$!��Grupos a los que pertenece:��#��[ $
��Left=�$��100,270,0,0q�$	��Top=��� $��Agregar Beneficios��$
��Left=�$��509,112,0,0q�$	��Top=�$	��153��$	��433�����	#FFCADEB8.��� $��0,0,-2,1q�.+��� -   $ cmbBeneficios��#��[ $
��Left=�$��	10,36,0,0q�$	��Top=�$	��205������ .R��� .+��� ���� *Nombre_beneficio+�� -   $ lblBeneficio��$��
Beneficios��$
��Left=�$��10,5,0,0q�$	��Top=��� -   $ lblFecha��$��Fecha de asignación��$
��Left=�$��	10,55,0,0q�$	��Top=��� -     ��Name$  btnAgregarBeneficio��  	BotonMenu#��[ $
��Left=�$��
290,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -   ! ��Name$! imgbtnAgregar��$��Graficos/add.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -   $  btnBuscarBeneficio��#��[ $
��Left=�$��
220,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -   $! imgbtnBuscar��$��Graficos/find.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -    $  btnQuitarBeneficio��#��[ $
��Left=�$��
360,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -!   $! imgbtnQuitar��$��Graficos/quitar.png��$��32��$��32��$
��Left=�$��0,0,0,0q�  -"   $ dpFechaAsignacion��$��10,81,306,21q�  -#   $ grillaBeneficios��#��[ # [ $��509,299,0,44q� .  .  $
��Left=�$	��433�� ��    $ Id��$ Hidden=� �� *Id_beneficio+ Z�   $ Cantidad�� �� *Nombre_beneficio+  $ 	Artículo�� �� *Descripcion_beneficio+  $ Descripción�� �� *Fecha_asignado+�� -$   $ lblBeneficios��$��Beneficios asignados:��#��[ $
��Left=�$��509,270,0,0q�$	��Top=�$��22���� -%   $��txtBien��#��[ $y�Hidden=��� -&   $��txtMal��  CajadeTextoError#��[ $y�Hidden=�