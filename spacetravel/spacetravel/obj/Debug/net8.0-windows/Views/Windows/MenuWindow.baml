   M S B A M L   `   `   `  ����F  Bspacetravel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:spacetravel.Views.Windowsspacetravel.Views.Windows  5   	   Y1clr-namespace:spacetravel.ViewModels.Menu.Mission#spacetravel.ViewModels.Menu.Mission  5   	   W0clr-namespace:spacetravel.Views.Controls.Mission"spacetravel.Views.Controls.Mission  5	   	   I)clr-namespace:spacetravel.ViewModels.Menuspacetravel.ViewModels.Menu  5
   	   G(clr-namespace:spacetravel.Views.Controlsspacetravel.Views.Controls  5   	   I)clr-namespace:spacetravel.ViewModels.Menuspacetravel.ViewModels.Menu  5   	   5clr-namespace:spacetravel.Utilsspacetravel.Utils  5   	   *    $spacetravel.Views.Windows.MenuWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:spacetravel.Views.Windows  5   	   >pageVM1clr-namespace:spacetravel.ViewModels.Menu.Mission  5   	   ;page0clr-namespace:spacetravel.Views.Controls.Mission  5	   	   6tourvm)clr-namespace:spacetravel.ViewModels.Menu  5
   	   6defpage(clr-namespace:spacetravel.Views.Controls  5   	   2vm)clr-namespace:spacetravel.ViewModels.Menu  5   	   *Menuclr-namespace:spacetravel.Utils  5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��5   	   
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MenuWindow��5   	   $	��700��6   $
��1100��6)    � DataContext 5      5  /spacetravel.ViewModels.Menu.NavigationViewModel  5   
    � 	Resources 5       �� DataType3  -spacetravel.ViewModels.Menu.MissionsViewModel)   #spacetravel.Views.Controls.Missions6  0spacetravel.ViewModels.Menu.Mission.IssViewModel0   *spacetravel.Views.Controls.Mission.IssPage7  1spacetravel.ViewModels.Menu.Mission.MarsViewModel1   +spacetravel.Views.Controls.Mission.MarsPage7  1spacetravel.ViewModels.Menu.Mission.MoonViewModel1	   +spacetravel.Views.Controls.Mission.MoonPage8
  2spacetravel.ViewModels.Menu.Mission.OrbitViewModel2   ,spacetravel.Views.Controls.Mission.OrbitPage6  0spacetravel.ViewModels.Menu.AddTourPageViewModel,   &spacetravel.Views.Controls.AddTourPage0  *spacetravel.ViewModels.Menu.ToursViewModel&    spacetravel.Views.Controls.Tours3  -spacetravel.ViewModels.Menu.TourInfoViewModel)   #spacetravel.Views.Controls.TourInfo2  ,spacetravel.ViewModels.Menu.ProfileViewModel,   &spacetravel.Views.Controls.UserProfile��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5"      *, +)(�� �     5%      *,
 +)(�� �     5(      *, +)(�� ,    5+      *, +)(�� ^    5.      *, +)(�� �    51      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5         5!      �� 5"   
   "  6   .R�5#      	  5$      �� 5%   
   " 
 6   .R�5&        5'      �� 5(   
   "  6   .R�5)        5*      �� 5+   
   "  6   .R�5,        5-      �� 5.   
   "  6   .R�5/        50      �� 51   
   "  6   .R�52        53      54      .��56      ��  �� CornerRadius$ 35��6   $��1q�6   ���	#FF171717._�57   
   �  � ColumnDefinitions 58      �� 59      $
��287* �6#   �� 5:      $
��811* �6#   .+�5=      � $
��Left=�6   $	��280��6.   .+�5>      �� ���	#FF1A1A1A$ 35, 0, 0, 35��60   �� 5?      $	��400��6   .+�5@         spacetravel.Utils.Btn     
ButtonMenu#��[  6   	 d� 	IsChecked$
	 TrueY�5B      ��5A      �� *HomeCommand+.��5D      � .+�5F      �� $
��Home��6(   $��20(�64   $��10q�6B   
�������6N   5H      5J        5K      #��[  6   ��5L      �� *MissionsCommand+.��5N      � .+�5P      �� $��Missions��6(   $��20(�68   $��10q�6F   
�������6R   5R      5T        5U      #��[  6   ��5V   !   �� *ToursCommand+.��5X      � .+�5Z      �� $��Tours��6(   $��20(�65   $��10q�6C   
�������6O   5\      5^        5_      #��[  6   ��5`      �� *ProfileCommand+.��5b      � .+�5d      �� $��Profile��6(   $��20(�67   $��10q�6E   
�������6Q   5f      5h      5i      5k      � 5l      $��1��6   .+�5n      �� -   5        
 ��Name$
 Pages��5n   !   ��60   �� *CurrentPageMenu+5p      �� 5q      $��1��6   $��60��6&   $��60��61   $��Right=�6=   $	��Top=�6Y   $��0,5,5,0q�6q   
������ 
�������
������ ��6�   �� *OnCloseAppCommand+.��5r      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6*   $��30��67   $��30��6B   5s      �� 5t      $��1��6   $��60��6&   $��60��61   $��Right=�6=   $	��Top=�6Y   $��0,5,45,0q�6q   
������ 
�������
������ ��6�   �� *OnSignOutCommand+.��5u        $ 	ExitToApp=�6*   $��30��6;   $��30��6F   5v      5w      5x      5y      