   M S B A M L   `   `   `  ���� H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  E    ?Processar.ProyectoAyudar.GestionAyudar.CambiarContraseniaWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:GestionBeneficiarios     -     � Title$  Cambiar contraseña��$	��420��$	��500�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ Graficos/logo.png�� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[  .+�� -    �Name$ 
gridSesion��  	GridVerde#��[ $��10q�.+��� -    ��Name$ 
lblUsuario��  Label_Comun#��[ $��Usuario��$��Center=�$��130,21,283,0q�$	��Top=�$��61��G� -    G�Name$ txtContrasenia��  CajadePassword#��[ $
��Left=�$��130,190,0,0q�$	��Top=�$	��250��$��22���� -   $ lblContrasenia��#��[ $��Contraseña Nueva��$
��Left=�$��130,161,0,0q�$	��Top=�	 J� RenderTransformOrigin$	 0.611,0.149&�$	��121���� -   
 ��Name$
 
btnAceptar��  	BotonMenu#��[ $
��Left=�$��160,300,0,0q�$	��Top=�$��60��$��40�� �� 	IsDefault . .��� .+��� -    ��Name$ imgbtnAgregar��$��Graficos/accept.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -   $
 btnCancelar��#��[ $
��Left=�$��287,300,0,0q�$	��Top=�$��60��$��40�� �� IsCancel . .��� .+��� -	   $ imgbtnAgregar1��$��Graficos/cancel.png��$��32��$��32��$
��Left=�$��0,0,0,0q�G� -
   $ txtRepetirContrasenia��#��[ $
��Left=�$��130,260,0,0q�$	��Top=�$	��250��$��22���� -   $ lblRepetirContrasenia��#��[ $��Repetir Contraseña��$
��Left=�$��130,231,0,0q�$	��Top=�$	 0.611,0.149&�$	��130���� -   $ lblNombreUsuario��#��[ $�� ��$
��Left=�$��
130,50,0,0q�$	��Top=�$	��250��G� -   $ txtContraseniaAnt��#��[ $
��Left=�$��130,120,0,0q�$	��Top=�$	��250��$��22���� -   $ lblContraseniaActual��#��[ $��Contraseña Anterior��$
��Left=�$��
130,91,0,0q�$	��Top=�$	 0.611,0.149&�$	��130���� -   $��txtBien��  CajadeTexto#��[ $y�Hidden=��� -   $��txtMal��  CajadeTextoError#��[ $y�Hidden=�