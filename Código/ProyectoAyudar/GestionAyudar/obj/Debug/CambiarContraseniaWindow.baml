   M S B A M L   `   `   `  ����H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  5   	   E    ?Processar.ProyectoAyudar.GestionAyudar.CambiarContraseniaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GestionBeneficiarios     5   	   -   5          � Title$  Cambiar contraseña��5   
   $	��420��6%   $	��500��62    � WindowStartupLocation$ CenterScreen=�6?    � 
ResizeMode$ NoResize=�6e    � Icon$ Graficos/logo.png��6�    � 	Resources 5	       �� Source�� 5
   
   $ recursosdic.xaml?�6   %    .��5      �    	GridFondo#��[  6   .+�5   
   � -   5         �Name$ 
gridSesion��5        	GridVerde#��[ 6#   $��10q�6F   .+�5      �� -   5         ��Name$ 
lblUsuario��5        Label_Comun#��[ 6)   $��Usuario��6N   $��Center=�6`   $��130,21,283,0q�6}   $	��Top=�6�   $��61��6�   G� 5      -   5         G�Name$ txtContrasenia��5        CajadePassword#��[ 63   $
��Left=�6[   $��130,190,0,0q�6v   $	��Top=�6�   $	��250��6�   $��22��6�   6�   �� 5      -   5        $ lblContrasenia��5      #��[ 6-   $��Contraseña Nueva��6R   $
��Left=�6m   $��130,161,0,0q�6�   $	��Top=�6�   	 J� RenderTransformOrigin$	 0.611,0.149&�6�   $	��121��6�   �� 5      -   5        
 ��Name$
 
btnAceptar��5        	BotonMenu#��[ 6)   $
��Left=�6L   $��160,300,0,0q�6g   $	��Top=�6|   $��60��6�   $��40��6�    �� 	IsDefault . .��5      � .+�5      �� -   5         ��Name$ imgbtnAgregar��5      $��Graficos/accept.png��63   $��32��6P   $��32��6\   $
��Left=�6g   $��0,0,0,0q�6�   5      5      �� 5      -   5        $
 btnCancelar��5      #��[ 6*   $
��Left=�6M   $��287,300,0,0q�6h   $	��Top=�6}   $��60��6�   $��40��6�    �� IsCancel . .��5      � .+�5      �� -	   5        $ imgbtnAgregar1��5      $��Graficos/cancel.png��64   $��32��6Q   $��32��6]   $
��Left=�6h   $��0,0,0,0q�6�   5      5      G� 5       -
   5        $ txtRepetirContrasenia��5       #��[ 6:   $
��Left=�6b   $��130,260,0,0q�6}   $	��Top=�6�   $	��250��6�   $��22��6�   6�   �� 5!      -   5        $ lblRepetirContrasenia��5!      #��[ 64   $��Repetir Contraseña��6Y   $
��Left=�6v   $��130,231,0,0q�6�   $	��Top=�6�   $	 0.611,0.149&�6�   $	��130��6�   �� 5"      -   5        $ lblNombreUsuario��5"      #��[ 6/   $�� ��6T   $
��Left=�6_   $��
130,50,0,0q�6z   $	��Top=�6�   $	��250��6�   G� 5#      -   5        $ txtContraseniaAnt��5#      #��[ 66   $
��Left=�6^   $��130,120,0,0q�6y   $	��Top=�6�   $	��250��6�   $��22��6�   6�   �� 5$      -   5        $ lblContraseniaActual��5$      #��[ 63   $��Contraseña Anterior��6X   $
��Left=�6v   $��
130,91,0,0q�6�   $	��Top=�6�   $	 0.611,0.149&�6�   $	��130��6�   5%      �� 5&   
   -   5        $��txtBien��5&        CajadeTexto#��[ 6!   $y�Hidden=�6F   �� 5'   
   -   5        $��txtMal��5'        CajadeTextoError#��[ 6    $y�Hidden=�6J   5(      5)      