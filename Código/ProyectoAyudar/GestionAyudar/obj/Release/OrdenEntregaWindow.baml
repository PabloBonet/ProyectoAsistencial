   M S B A M L   `   `   `  ����   GestionAyudar?    9Processar.ProyectoAyudar.GestionAyudar.OrdenEntregaWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Orden de Entrega��$	��720��$
��1024�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  -     Name$ tabConsultaOrden��$��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEditarOrden��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	  Name$	 btnEliminarOrden��
   Label$
 Eliminar�� � ToolTip$ Eliminar orden��   LargeImageSource$ Graficos/delete.png��$��55��$��
0,10,0,-10q�  -   $ grupoTratamientoOrden��$��Tratamiento��$	��0,1q�$
��Auto��.@�  -   $	 btnAutorizarOrden��$
 	Autorizar��$ Autorizar orden��$ Graficos/autorizar.png��$��55��$��
0,10,0,-10q�  -   $	 btnEntregarOrden��$
 Entregar��$ Entregar orden��$ Graficos/entrega.png��$��55��$��
0,10,0,-10q�  -   $	 btnCancelarOrden��$
 Cancelar��$ Cancelar orden��$ Graficos/cancelar.png��$��55��$��
0,10,0,-10q�  -	   $ grupoBeneficiario��$��Beneficiario��$	��0,1q�$
��Auto��.@�  -
   $	 btnAgregarBeneficiario��$
 Agregar��$ Agregar un beneficiario��$' !Graficos/agregar_beneficiario.png��$��55��$��4,10,-4,-10q�  -   $ grupoCambios��$��Cambios��$	��0,1q�$
��Auto��.@�  -   $	 btnGuardarOrden��$
 Guardar��$ Graficos/guardar.png��$ Guardar o crear orden��$��55��$��4,10,-4,-10q�  -   $	 btnCancelarCambios��$
 Cancelar��$ Graficos/cancel.png��$��55��$" Cancelar y cerrar la ventana��$��4,10,-4,-10q�  -   $ grupoReimpresion��$��Imprimir��$	��0,1q�$
��Auto��.@�  -   $	 btnImprimirOrden��$
 Orden��$ Graficos/imprimir.png��$��55��$��4,10,-4,-10q�  -   $	 btnImprimirAutorizacion��$
 Autorización��$ Graficos/imprimir.png��$��55��$��4,10,-4,-10q�  -   $	 btnImprimirEntrega��$
 Entrega��$ Graficos/imprimir.png��$��55��$��4,10,-4,-10q�� -    �Name$ gridOrdenes��  	GridVerde#��[ $��10,163,10,10q� � ColumnDefinitions �� $
��250* ��� $
��250* �.+��� $��Beneficiario��$
��Left=�$��
10,248,0,0q�$	��Top=�$	��240��$	��430�����	#FFCADEB8.��� $��0,0,0,3q�.+��� -    ��Name$ 	lblNombre��$��Nombre:��  Label_Comun#��[ $
��Left=�$��	10,23,0,0q�$	��Top=��� -   $ lblDocumento��$��
Documento:��#��[ $
��Left=�$��	10,51,0,0q�$	��Top=��� -   $ lblDireccion��$��Dirección:��#��[ $
��Left=�$��	10,79,0,0q�$	��Top=��� -   $ lblLocalidad��$��
Localidad:��#��[ $
��Left=�$��
10,135,0,0q�$	��Top=��� -   $ lblTelefono��$��
Teléfono:��#��[ $
��Left=�$��
10,163,0,0q�$	��Top=��� -   $ 	lblBarrio��$��Barrio:��#��[ $
��Left=�$��
10,107,0,0q�$	��Top=��� -    ��Name$ txtDocumento��  CajadeTexto#��[  �� 
IsReadOnly . $
��Left=�$��23��$��
148,51,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��260���� -   $ 	txtNombre��#��[  . $
��Left=�$��23��$��
148,23,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ txtDireccion��#��[  . $
��Left=�$��23��$��
148,79,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ txtLocalidad��#��[  . $
��Left=�$��23��$��148,135,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ txtTelefono��#��[  . $
��Left=�$��23��$��148,163,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ 	txtBarrio��#��[  . $
��Left=�$��23��$��148,107,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ 
txtIdOrden��#��[  . $
��Left=�$��23��$��
163,23,0,0q�$
 Wrap=�$	��Top=�$	��260���� -    $ txtFecha��#��[  . $
��Left=�$��23��$��163,119,0,0q�$
 Wrap=�$	��Top=�$	��260���� -!   $ txtEstadoActual��#��[  . $
��Left=�$��23��$��163,175,0,0q�$
 Wrap=�$	��Top=�$	��100���� -"   $ txtUsuarioCrea��#��[  . $
��Left=�$��23��$��163,147,0,0q�$
 Wrap=�$	��Top=�$	��260���� -#   $ txtUsuarioModifica��#��[  . $
��Left=�$��22��$��163,203,0,0q�$
 Wrap=�$	��Top=�$	��260���� -$   $ txtDescripcion��#��[  . $
��Left=�$��63��$��
163,51,0,0q�$
 Wrap=�$	��Top=�$	��260���� -%   $ 
lblIdOrden��$��Identificador:��#��[ $
��Left=�$��	30,23,0,0q�$	��Top=��� -&   $ lblDescripcion��$��Descripción:��#��[ $
��Left=�$��	30,51,0,0q�$	��Top=��� -'   $ lblFecha��$��Fecha Creación:��#��[ $
��Left=�$��
30,119,0,0q�$	��Top=��� -(   $ lblEstadoAct��$��Estado:��#��[ $
��Left=�$��
30,175,0,0q�$	��Top=��� -)   $ lblUsuarioCrea��$��Usuario Creador:��#��[ $
��Left=�$��
30,147,0,0q�$	��Top=��� -*   $ lblUsuarioModif��$��Último Usuario:��#��[ $
��Left=�$��
30,203,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -+     Name$ grillaItemsEntrega�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $��10,175,0,10q�   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��478��$��1�� � DataContext ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
Visibility$ Hidden=�1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id_item_entrega+ 	  ClipboardContentBinding Z�   $ Cantidad�� �� *
Cantidad+  $ 	Artículo�� �� *Articulo.Nombre_articulo+  $ Descripción�� �� *Articulo.Descripcion_articulo+�� $��Agregar Items��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��136��$	��478�����	#FFCADEB8$��1��.��� $��0,0,0,1q�.+��� -,    ��Name$ cmbArticulos��  ListaDesplegable#��[ $
��Left=�$��	10,36,0,0q�$	��Top=�$	��205������ .R��� .+��� ����  �� Path$ Nombre_articulo��� --   $ lblArticulos��$��
Artículos��$
��Left=�$��10,5,0,0q�$	��Top=��� -.   $ txtCantidad��#��[ $
��Left=�$��23��$��	10,83,0,0q�$
 Wrap=�$	��Top=�$	��175���� -/   $ lblCantidad��$��Cantidad��$
��Left=�$��	10,55,0,0q�$	��Top=��� -0    ��Name$ btnAgregarArticulo��  	BotonMenu#��[ $
��Left=�$��
290,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -1   $��imgbtnAgregar��$��Graficos/add.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -2   $ btnBuscarArticulo��#��[ $
��Left=�$��
220,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -3   $��imgbtnBuscar��$��Graficos/find.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -4   $ btnQuitarArticulo��#��[ $
��Left=�$��
360,25,0,0q�$	��Top=�$��40��$��40��.��� .+��� -5   $��imgbtnQuitar��$��Graficos/quitar.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -6   $ lblItems��$��Items de la entrega:��#��[ $
��Left=�$��
10,151,0,0q�$	��Top=�$��1���� -7   $ lblEl��$��el��$
��Left=�$��268,172,0,0q�$	��Top=��� -8   $ txtFechaEstado��#��[  . $
��Left=�$��23��$��292,175,0,0q�$
 Wrap=�$	��Top=�$	��131���� -9   $��txtBien��#��[ $y�Hidden=��� -:   $��txtMal��  CajadeTextoError#��[ $y�Hidden=�