   M S B A M L   `   `   `  ����F  Bspacetravel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:spacetravel.ViewModels.Menuspacetravel.ViewModels.Menu  5      5clr-namespace:spacetravel.Utilsspacetravel.Utils  5      G(clr-namespace:spacetravel.Views.Controlsspacetravel.Views.Controls  5      (    "spacetravel.Views.Controls.Profile   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8vm)clr-namespace:spacetravel.ViewModels.Menu     5      .glclr-namespace:spacetravel.Utils     5      :local(clr-namespace:spacetravel.Views.Controls     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6E      
Page_Style#��[  5
        � DataContext  5      2  ,spacetravel.ViewModels.Menu.ProfileViewModel  5   
    � 	Resources 5      6   0spacetravel.Utils.UserRoleToUserControlConverter " UserRoleToUserControlConverter��%   &	         5   
   6,   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $
��0.1* �6   �� 5      $
��0.7* �6   .+�5    
   ��  �� CornerRadius$ 35��6   $��0,5,5,0q�6#   5#      �� 5$   
   $��Profile��6   
�������$��D-DIN)�66   $��48(�6I   $
��Left=�6W   $	��Top=�6r   $��0,33,0,0q�6�   $��1��6�   �� 5%   
   -   5         ��Name$
 name��5%   -     TextBoxStyle#��[ 6;   $��15(�6a   
�������$��60��6�   $
��Left=�6�   $��Bottom=�6�   $��	 0 0 0 20q�6�   $��1��6�   $	��230��6�   ���	#FF2B2B2B
 � Tag$
 name��6  ��6   �� *	NameField+6  �� 5&   
   -   5        $ surname��5&   0   #��[ 6A   $��15(�6g   
�������$��60��6�   $
��Left=�6�   $��Bottom=�6�   $��	 0 0 0 20q�6�   $��2��6�   $	��230��6�   ���	#FF2B2B2B$ surname��6  ��6   �� *SurnameField+6  �� 5'   
   -   5        $ email��5'   .   #��[ 6=   $��15(�6c   
�������$��60��6�   $
��Left=�6�   $��Bottom=�6�   $��	 0 0 0 20q�6�   $��3��6�   $	��230��6�   ���	#FF2B2B2B$ email��6  ��6   �� *
EmailField+6  �� 5(   
   $��16(�6/   ���	#DDFF6565$��1��6T   $��Bottom=�6d   $��0 0 0 -5q�6   ��6   �� *	ErrorText+6   �� 5)   
   $
��Save��68   $��D-DIN)�6G   $��2��6Z   $��1��6j   $	��160��6x   $��Center=�6�   $��0 0 30 0q�6�   $��18(�6�   $��40��6�   $��1,1,1,1q�6�   ��6   �� *EditProfileCommand+6�   >� 5*   
   $��2��6p   $��1��6}   $��3��6�   ��6   �� *
CurrPerson+ �� 	Converter# [ 6�   5+      5,      