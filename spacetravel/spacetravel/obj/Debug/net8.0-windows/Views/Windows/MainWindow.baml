   M S B A M L   `   `   `  ����F  Bspacetravel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:spacetravelspacetravel  5   	   ?$clr-namespace:spacetravel.ViewModelsspacetravel.ViewModels  5   	       spacetravel.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   %localclr-namespace:spacetravel  5   	   -vm$clr-namespace:spacetravel.ViewModels  5   	     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � Title$ 
MainWindow��5   	   $	��600��6   $
��1000��6)   .��5      ��  �� CornerRadius$ 35��6   $��5q�6   ���	#FF171717._�5   
   �  � ColumnDefinitions 5      �� 5      $
��167* �6#   �� 5      $
��163* �6#   .+�5      �� ��6   �� *ContentControlAuth+�� 5      $��1��6   $ 0, 35, 35, 0��6%    J� OpacityMask
 �   � J� Opacity$	 0.6Q�6U   ��5      �� 5       j� Stretch$ UniformToFill=�6!   	 �� ImageSource$6	 0pack://application:,,,/Resources/Images/pic3.jpg��69   5      �� 5      $��1��6   $��60��6&   $��60��61   $��Right=�6=   $	��Top=�6Y   $��0,5,5,0q�6q   
������ 
�������
������ ��6�   �� *OnCloseAppCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Close=�6*   $��30��67   $��30��6B   5      5      5       5!      