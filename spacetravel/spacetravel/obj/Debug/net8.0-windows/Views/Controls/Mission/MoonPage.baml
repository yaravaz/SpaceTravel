   M S B A M L   `   `   `  ����F  Bspacetravel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:spacetravel.Views.Controls.Mission"spacetravel.Views.Controls.Mission  5      1    +spacetravel.Views.Controls.Mission.MoonPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      <local0clr-namespace:spacetravel.Views.Controls.Mission  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5         
Page_Style#��[  5	      .��5      �� $��Disabled=�6   $��Hidden=�6<   .��5   
   � $
��2000��6     � ColumnDefinitions  5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��0.4* �6    �� 5      $
��2.5* �6    �� 5      $
��0.4* �6    �� 5      $
��2.5* �6    �� 5      $
��0.4* �6    �� 5      $
��2.5* �6    .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6&   $��	10,20,0,0q�67   $��30��6J   $��30��6U   
���������5      �� 5       �� 
TargetType"  6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5   "   ��  �� Property �@�Cursor �� Value$
 Hand��6;   5       5"      .  (System.Windows.Interactivity.Interaction	   Triggers	 5$      /  )System.Windows.Interactivity.EventTrigger  5%      
   	EventName$
 	MouseDown��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5&      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *GoBack+5'      5)      �� 5*      $
��Moon��6   $��Center=�6$   $��Center=�6A   $��40(�6\   
�������$��2��6}   �� 5+      $��1��6   $:��4pack://application:,,,/Resources/Images/mooninfo.png��6!   � 5,      $��1��6   $��1��6    $��30 100q�60    5-      �� 5.      $
��0.3* �6$   �� 5/      $
��0.1* �6$   �� 50      $
��0.1* �6$   �� 51      $
��0.3* �6$     53      �� 54      $��* �6'   �� 55      $��* �6'   .+�57      �� 
�������$��D-DIN)�6Q   $��12(�6d   $
��Wrap=�6r   $��2��6�   $��Center=�6�   $��0,0,50,0q�6�   ��6   �� *DescMissionField+6�   �� 59      $��Duration��6   $��D-DIN)�6,   $��1��6?   
�������$��16(�6`   �� 5:      $
��Left=�6;   $��D-DIN)�6V   $��1��6i   $��1��6y   
�������$��16(�6�   ��6   �� *DurationField+6�   �� 5<      $��Altitude��6   $��D-DIN)�6,   $��2��6?   
�������$��16(�6`   �� 5=      $
��Left=�6;   $��D-DIN)�6V   $��1��6i   $��2��6y   
�������$��16(�6�   ��6   �� *AltituteField+6�   �� 5?      $��D-DIN)�68   $��3��6K   
�������$��25(�6l   ��6   �� *
PriceField+6l   5@        5A      $ ChevronDown=�6&   $��2��69   $��2��6F   $��Center=�6Z   $��	0 -20 0 0q�6w   $��50��6�   $��50��6�   
�������6�   �� 5B      $��Vehicle��6   $��Center=�6'   $��Bottom=�6D   $��30(�6_   
�������$��2��6�   $��2��6�   �� 5C      $��1��6   $��3��6$   $:��4pack://application:,,,/Resources/Images/starship.png��61   $��50q�6o   � 5D      $��3��6   $��0��6    $��30 100q�60    5E      �� 5F      $
��0.3* �6$   �� 5G      $
��0.1* �6$   �� 5H      $
��0.1* �6$   �� 5I      $
��0.1* �6$   �� 5J      $
��0.3* �6$     5L      �� 5M      $��* �6'   �� 5N      $��* �6'   .+�5P      �� 
�������$��D-DIN)�6N   $��12(�6a   $
��Wrap=�6o   $��2��6�   $��Center=�6�   $��0,0,50,0q�6�   ��6   �� *DescShipField+6�   �� 5R      $��Capacity��6   $��D-DIN)�6,   $��1��6?   
�������$��16(�6`   �� 5S      $
��Left=�6;   $��D-DIN)�6V   $��1��6i   $��1��6y   
�������$��16(�6�   ��6   �� *CapacityField+6�   �� 5U      $��Diameter��6   $��D-DIN)�6,   $��2��6?   
�������$��16(�6`   �� 5V      $
��Left=�6;   $��D-DIN)�6V   $��1��6i   $��2��6y   
�������$��16(�6�   ��6   �� *DiameterField+6�   �� 5X      $��Height��6   $��D-DIN)�6*   $��3��6=   
�������$��16(�6^   �� 5Y      $
��Left=�69   $��D-DIN)�6T   $��1��6g   $��3��6w   
�������$��16(�6�   ��6   �� *HeightField+6�   �� 5[      $��Payload capacity��6   $��D-DIN)�64   $��4��6G   
�������$��16(�6h   �� 5\      $
��Left=�6:   $��D-DIN)�6U   $��1��6h   $��4��6x   
�������$��16(�6�   ��6   �� *PayloadField+6�   5]      �� 5^      $��Book a flight��6   $��Center=�6-   $��Bottom=�6J   $��30(�6e   
�������$��2��6�   $��4��6�   �� 5_      $^��XTo book, you need to fill in the information, the price of the flight will depend on it*��6   $
��0 10q�6x   $��Center=�6�   $	��Top=�6�   $��12(�6�   
�������$��2��6�   $��5��6�   (  "System.Windows.Controls.DatePicker  5`         IsTodayHighlighted$
 True��6   $|�False��63   $��5��6E   $	��Top=�6R   $��30 100q�6j   $��60��6z   
�������   FirstDayOfWeek$ Monday=�6�   ���	#FF2B2B2B$��D-DIN)�6�   $��16(�6     SelectedDate 6�   �� *SelectedDate+6  �� 5a        TextBoxStyle#��[ 6X   $��15(�6~   
�������$��5��6�   $��60��6�   $��Center=�6�   $	��Top=�6�   $��	0,200,0,0q�6�   ���	#FF2B2B2B
 � Tag$ your weight��6  $	��340��6*  ��6   �� *WeightField+ �� UpdateSourceTrigger$ PropertyChanged=�6*  �� 5b      $C��=*the coefficient of price increase will depend on your weight��6   $��30 270q�6]   $
��Left=�6n   $	��Top=�6�   $��12(�6�   
�������$��5��6�   �� 5c      $��
30 300 0 0q�63   $
��Left=�6H   $	��Top=�6c   $��12(�6{   ���	#DDFF6565$��5��6�   ��6   �� *	ErrorText+6�   �� 5d      $��Total price��6   $
��Left=�6+   $	��Top=�6F   $��50 90q�6^   $��30(�6m   
�������$��1��6�   $��5��6�   �� 5e      $
��Left=�64   $	��top=�6O   $��50 150q�6g   $��30(�6w   
�������$��1��6�   $��5��6�   ��6   �� *
TotalPrice+6�   �� 5g      $��5��6[   $��2��6h   $	��250��6|   $��Bottom=�6�   $��0 0 0 60q�6�   $
��Book��6�   $��D-DIN)�6�   $��18(�6�   $��40��6�   $��1,1,1,1q�6�   ��6   �� *BookCommand+y�65   �� *CurrVisibility+ J� Effect 5h      3  -System.Windows.Media.Effects.DropShadowEffect  5i         Color$ White��6'      
BlurRadius$ 10Q�65      ShadowDepth$ 0Q�6E   5k      5l      5m      5n      