   M S B A M L   `   `   `  ���� H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  F    @Processar.ProyectoAyudar.GestionAyudar.ReporteEntregaGrupoWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:GestionBeneficiarios     -     � Title$4  .Reporte Entrega a Grupos - Comuna de Margarita�� � WindowStartupLocation$ CenterScreen=�$	��720��$
��1050�� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Entrega Grupos��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -     Name$ grupoGrupos��$��Grupo��$	��0,1q�$��80��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -     Name$ btnBuscarGrupo��	   Label$	 Seleccionar��
   LargeImageSource$+
 %Graficos/seleccionar_beneficiario.png��$��55��$��
0,10,0,-10q�  -   $ grupoPeriodoBusqueda��$��Período��$	��0,1q�$	��402��.@�(  "System.Windows.Controls.DatePicker  -     Name$ dpFechaDesde��$��10,10,-160,3q��� -    ��Name$ lblDesde��$��Desde��$��25��$��50,-3,-103,3q�  -   $ dpFechaHasta��$��180,10,-330,1q��� -   $ lblHasta��$��Hasta��$��25��$��220,-1,-267,1q�  -	   $ btnBuscarArticulos��$	 Buscar��$
 Graficos/buscar.png��$��55��$��340,10,-340,-10q�  -
   $ grupoImprimir��$��Imprimir��$	��0,1q�$��75��.@�  -   $ btnImprimir��$	 Imprimir��$
 Graficos/imprimir.png��$��55��$��4,10,-4,-10q�� -    �Name$ gridArticulo��  	GridVerde#��[ $��10,163,10,10q�.+��� -   $ 	lblNombre��$��Nombre:��  Label_Comun#��[ $
��Left=�$��
140,50,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.946,0.583&�&   System.Windows.Controls.DataGrid  -     Name$ grillaArticulos�� 	 Tabla#��[   CeldaGrilla   	CellStyle# [ $
��Left=�$��
10,229,0,9q�$
��1002��   
IsReadOnly .    AutoGenerateColumns .   � DataContext ��    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ IdGrilla�� 	  
Visibility$ Hidden=�1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Id_grillaReporte+ 
  ClipboardContentBinding Z�   $ 
IdArticulo��$ Hidden=� �� *Id_articulo+ Z�   $ Beneficiario�� �� *Nombre_beneficiario+ Z�   $ 	Documento�� �� *Cantidad_articulo+ Z�   $ Cantidad�� �� *Cantidad_articulo+ Z�   $ Nombre�� �� *Nombre_articulo+ Z�   $ Descripción�� �� *Descripcion_articulo+ Z�   $ Tipo Artículo�� �� *Tipo_articulo+ Z�   $ 	Nº orden�� �� *Id_orden_entrega+ Z�   $ Autorizado por�� �� *Autorizado_por+ Z�   $ Entregado por�� �� *Entregado_por+ Z�   $ Fecha Entrega�� �� *FechaEntrega_orden_entrega+ Z�   $ Hora Entrega�� �� *HoraEntrega_orden_entrega+ Z�   $ Grupo�� �� *Nombre_grupo+ Z� �� -    ��Name$ 	txtNombre��  CajadeTexto#��[  �� 
IsReadOnly . $
��Left=�$��23��$��
220,50,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��251���� -   $ lblArticulos��#��[ $��Artículos entregados��$
��Left=�$��
10,200,0,0q�$	��Top=��� -   $ lblGrupo��#��[ $��Grupo��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $ txtDescripcion��#��[  . $
��Left=�$��63��$��220,100,0,0q�$
 Wrap=�$	��Top=�$	��251���� -   $ lblDescripcion��$��Descripción:��#��[ $
��Left=�$��140,100,0,0q�$	��Top=�