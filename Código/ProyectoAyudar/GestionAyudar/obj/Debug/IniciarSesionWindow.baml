   M S B A M L   `   `   `  ����H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  5   	   @    :Processar.ProyectoAyudar.GestionAyudar.IniciarSesionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GestionBeneficiarios     5   	   -   5          � Title$  Iniciar Sesión��5   	   $	��250��6    $	��500��6-    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ NoResize=�6`    � AllowsTransparency .  � WindowStyle$
 None=�6�    � 	Resources 5	       �� Source�� 5
   
   $ recursosdic.xaml?�6   %    .��5      �    	GridFondo#��[  6    � UseLayoutRounding .  .+�5   
   � -   5         �Name$ 
gridSesion��5        	GridVerde#��[ 6#   $��	10,10,0,0q�6F   $
��Left=�6Y   $	��480��6t   $	��230��6�   $	��Top=�6�   .+�5      �� -   5        	 ��Name$	 
lblUsuario��5        Label_Comun#��[ 6)   $��Usuario��6N   $��Center=�6`   $��130,26,289,0q�6}   $	��Top=�6�   $��61��6�   �� 5      -   5        
 ��Name$
 
txtUsuario��5        CajadeTexto#��[ 6*   $��Center=�6O   $��23��6l   $��130,57,100,0q�6x    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��250��6�   G� 5      -   5         G�Name$ txtContrasenia��5        CajadePassword#��[ 63   $
��Left=�6[   $��130,127,0,0q�6v   $	��Top=�6�   $	��250��6�   $��22��6�   �� 5      -   5        $	 lblContrasenia��5      #��[ 6-   $��Contraseña��6R   $
��Left=�6g   $��
130,96,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.611,0.149&�6�   $��81��6�   �� 5      -   5         ��Name$ btnIniciarSesion��5        	BotonMenu#��[ 6/   $
��Left=�6R   $��160,168,0,0q�6m   $	��Top=�6�   $��60��6�   $��40��6�    �� 	IsDefault . .��5      � .+�5      �� -   5         ��Name$ imgbtnAgregar��5      $��Graficos/accept.png��63   $��32��6P   $��32��6\   $
��Left=�6g   $��0,0,0,0q�6�   5      5      �� 5      -	   5        $ btnCancelar��5      #��[ 6*   $
��Left=�6M   $��290,168,0,0q�6h   $	��Top=�6}   $��60��6�   $��40��6�    �� IsCancel . .��5      � .+�5      �� -
   5        $ imgbtnAgregar1��5      $��Graficos/cancel.png��64   $��32��6Q   $��32��6]   $
��Left=�6h   $��0,0,0,0q�6�   5      5       5!      5"      5#      