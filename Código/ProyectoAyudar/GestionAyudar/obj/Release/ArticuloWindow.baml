   M S B A M L   `   `   `  ����   GestionAyudar;    5Processar.ProyectoAyudar.GestionAyudar.ArticuloWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Articulo��$	��720��$
��1024�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�+  %System.Windows.Controls.Ribbon.Ribbon  $	��Top=�$	��148��$��0,10,0,0q�"   ShowQuickAccessToolBarOnTop .  ���	#FFCADEB8   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�Hidden=�$��0��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  -     Name$ tabConsultaArticulo��$��Editar��$��88��$	��Top=����	#FFCADEB8���	#FF4AA200.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  -   	  Name$	 grupoEditarArticulo��$��Editar��$	��0,1q�$
��Auto��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   
  Name$
 btnEliminarArticulo��   Label$ Eliminar��   LargeImageSource$ Graficos/delete.png��$��55��$��
0,10,0,-10q�  -   $	 grupoCambios��$��Cambios��$	��0,1q�$
��Auto��.@�  -   $
 btnGuardarArticulo��$ Guardar��$ Graficos/guardar.png��$��55��$��4,10,-4,-10q�  -   $
 btnCancelarCambios��$ Cancelar��$ Graficos/cancel.png��$��55��$��4,10,-4,-10q�� -    �Name$ gridArticulo��  	GridVerde#��[ $��10,163,10,10q�.+��� -	    ��Name$ 	txtNombre��  CajadeTexto#��[  �� 
IsReadOnly . $
��Left=�$��23��$��243,100,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��260���� -
    ��Name$ 	lblNombre��$��Nombre:��  Label_Comun#��[ $
��Left=�$��150,100,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.946,0.583&��� -   $ txtDescripcion��#��[  . $
��Left=�$	��100��$��243,150,0,0q�$
 Wrap=�$	��Top=�$	��260���� -   $ lblDescripcion��$��Descripción:��#��[ $
��Left=�$��150,150,0,0q�$	��Top=�$ 0.517,-0.667&��� -   $ 
lblTipoArt��$��Tipo Artículo:��#��[ $
��Left=�$��150,300,0,0q�$	��Top=�$ 0.946,0.583&��� -    ��Name$ cmbTipoArticulo��  ListaDesplegable#��[ $
��Left=�$��243,300,0,0q�$	��Top=�$	��260������ .R��� .+��� ����  �� Path$ Nombre_TipoArticulo��� -   $ txtBien��#��[ $y�Hidden=�$
��Left=�$��23��$��142,623,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ txtMal��  CajadeTextoError#��[ $y�Hidden=�$
��Left=�$��23��$��302,646,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120��