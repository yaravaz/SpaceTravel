   M S B A M L   `   `   `  ���� F  Bspacetravel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:spacetravel.ViewModels.Authspacetravel.ViewModels.Auth  5clr-namespace:spacetravel.Viewsspacetravel.Views  (    "spacetravel.Views.RegistrationForm   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  2vm)clr-namespace:spacetravel.ViewModels.Auth  +localclr-namespace:spacetravel.Views    � DataContext  ;  5spacetravel.ViewModels.Auth.RegistrationFormViewModel  .���  � RowDefinitions �� .+��� $��Log in��$
��Left=�$��	82,42,0,0q�$	��Top=�
������ 
�������$��18(� J� Opacity$	 0.3Q�$��0,0,0,3q����� *OnOpenLogInPageCommand+����  �� Color$ White�� �� Opacity$ 0Q��� ${�False��$��Sign up��$
��Left=�$��
167,42,0,0q�$	��Top=�
������ 
�������$��18(�$	 0.8Q�$��0,0,0,3q��� $��Create��$��92,504,250,46q�$��D-DIN)�$��18(�$��40��$��1,1,1,1q����� *OnSignUpCommand+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ White��   
BlurRadius$ 10Q�   ShadowDepth$ 0Q��� -   	 ��Name$	 email��   TextBoxStyle#��[  

 � Tag$
 email��$��15(�
�������$��0��$��60��$��94,279,107,251q����	#FF2B2B2B���� *
EmailField+�� -   $	 login��#��[  $
 login��$��15(�
�������$��0��$��60��$��94,216,107,314q����	#FF2B2B2B���� *
LoginField+�� -   $	 password��#��[  $
 password��$��15(�
�������$��0��$��60��$��94,342,107,188q����	#FF2B2B2B���� *PasswordField+�� -   $	 secpassword��#��[  $
 repeat the password��$��15(�
�������$��0��$��60��$��94,405,107,125q����	#FF2B2B2B���� *ConfPasswordField+�� $��Let's create account!��$
��Left=�$��
94,111,0,0q�$	��Top=�$��55��$	��399��$��36(����	#DDFFFFFF$��D-DIN)��� $ ��Enter the data to continue��$
��Left=�$��
94,166,0,0q�$	��Top=�$	��210�����	#DDC3C3C3$��D-DIN)�$��14(��� $
��Left=�$��
92,461,0,0q�$	��Top=�$
��Wrap=�$	��282��$��14(����	#DDFF6565$y�Visible=����� *	ErrorText+