   M S B A M L   `   `   `  ���� H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  E    ?Processar.ProyectoAyudar.GestionAyudar.ReporteEstadoOrdenWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:GestionBeneficiarios     -     � Title$/  )Reporte por estados - Comuna de Margarita��$	��720��$
��1050�� � WindowStartupLocation$ CenterScreen=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Reporte por Estado��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoEstado��$��Estado��$	��0,1q�$	��200��.@��� -    ��Name$ chAutorizado��  CheckBoxVerde#��[ $��
Autorizado��$
��Left=�$��
10,10,-1,0q�$	��Top=��� -   $ chEntregado��#��[ $��	Entregado��$
��Left=�$��
10,10,-1,0q�$	��Top=��� -   $ chCancelado��#��[ $��	Cancelado��$
��Left=�$��
10,10,-1,0q�$	��Top=��� -   $ 
chIniciado��#��[ $��Iniciado��$
��Left=�$��
10,10,-1,0q�$	��Top=�  -   $ grupoPeriodoBusqueda��$��Período��$	��0,1q�$	��410��.@�(  "System.Windows.Controls.DatePicker  -   	  Name$	 dpFechaDesde��$��10,10,-160,3q��� -	   
 ��Name$
 lblDesde��$��Desde��$��25��$��50,-3,-103,3q�  -
   $	 dpFechaHasta��$��180,10,-330,1q��� -   $
 lblHasta��$��Hasta��$��25��$��220,-1,-267,1q�1  +System.Windows.Controls.Ribbon.RibbonButton  -     Name$ btnBuscarOrdenes��   Label$ Buscar��   LargeImageSource$ Graficos/buscar.png��$��55��$��340,10,-340,-10q�  -   $ grupoImprimir��$��Imprimir��$	��0,1q�$	��215��.@�  -   $ grupoOpciones��$��Opciones��$��0,1,6,1q�.@��� -   $ chImprimirArticulos��#��[ $��Imprimir Artículos��$
��Left=�$��
10,10,-1,0q�$	��Top=�  -   $ btnImprimir��$ Imprimir��$ Graficos/imprimir.png��$��55��$��10,10,-10,-10q�� -    �Name$ gridOrdenes��  	GridVerde#��[ $��10,163,10,10q�.+�&   System.Windows.Controls.DataGrid  -     Name$ grillaOrdenes�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $
��Left=�$��10,39,0,253q�$
��1002��   
IsReadOnly .    AutoGenerateColumns .   � DataContext ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 	Nº Orden�� 	  
Visibility$ Visible=�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Id_orden_entrega+ 
  ClipboardContentBinding Z�   $ DNI Beneficiario�� �� *Beneficiario.Documento+ Z�   $ Descripción��$ Visible=� �� *Descripcion+ Z�   $ Fecha creado�� �� *FechaCreadoFormateada+ Z�   $ Entregado por�� �� * UsuarioEntrega.Nombre_completo+ Z�   $ Autorizado por�� �� *!UsuarioAutoriza.Nombre_completo+ Z�   $ Estado�� �� *EstadoActual.Estado+ Z�   $ Fecha estado�� �� *EstadoActual.FechaFormateada+ Z� �� -   $
 lblReporteEstados��  Label_Comun#��[ $��Ordenes por estados��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��163��  -   $ grillaArticulos��#��[ # [ $
��Left=�$��
10,297,0,9q�$
��1002�� .  .   ��    $ IdItem��$ Hidden=� �� *Id_item_entrega+ Z�   $ Cantidad�� �� *
Cantidad+ Z�   $ Nombre�� �� *Articulo.Nombre_articulo+ Z�   $ Descripción�� �� *Articulo.Descripcion_articulo+ Z�   $ Tipo Artículo�� �� *,*Articulo.Tipo_articulo.Nombre_TipoArticulo+ Z� �� -   $
 lblItems��#��[ $$��Articulos por orden de entrega��$
��Left=�$��
10,268,0,0q�$	��Top=�$	��203��