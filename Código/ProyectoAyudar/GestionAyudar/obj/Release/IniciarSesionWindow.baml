   M S B A M L   `   `   `  ���� H  DGestionAyudar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionBeneficiariosGestionBeneficiarios  @    :Processar.ProyectoAyudar.GestionAyudar.IniciarSesionWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:GestionBeneficiarios     -     � Title$  Iniciar Sesión��$	��250��$	��500�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=� � 	Resources  �� Source�� $ recursosdic.xaml?�%    .���    	GridFondo#��[   � UseLayoutRounding .  .+�� -    �Name$ 
gridSesion��  	GridVerde#��[ $��	10,10,0,0q�$
��Left=�$	��480��$	��230��$	��Top=�.+��� -   	 ��Name$	 
lblUsuario��  Label_Comun#��[ $��Usuario��$��Center=�$��130,26,289,0q�$	��Top=�$��61���� -   
 ��Name$
 
txtUsuario��  CajadeTexto#��[ $��Center=�$��23��$��130,57,100,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��250��G� -    G�Name$ txtContrasenia��  CajadePassword#��[ $
��Left=�$��130,127,0,0q�$	��Top=�$	��250��$��22���� -   $	 lblContrasenia��#��[ $��Contraseña��$
��Left=�$��
130,96,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.611,0.149&�$��81���� -    ��Name$ btnIniciarSesion��  	BotonMenu#��[ $
��Left=�$��160,168,0,0q�$	��Top=�$��60��$��40�� �� 	IsDefault . .��� .+��� -    ��Name$ imgbtnAgregar��$��Graficos/accept.png��$��32��$��32��$
��Left=�$��0,0,0,0q��� -	   $ btnCancelar��#��[ $
��Left=�$��290,168,0,0q�$	��Top=�$��60��$��40�� �� IsCancel . .��� .+��� -
   $ imgbtnAgregar1��$��Graficos/cancel.png��$��32��$��32��$
��Left=�$��0,0,0,0q�