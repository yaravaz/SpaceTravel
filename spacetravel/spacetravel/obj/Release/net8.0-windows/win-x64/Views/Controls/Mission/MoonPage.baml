   M S B A M L   `   `   `  ���� F  Bspacetravel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:spacetravel.Views.Controls.Mission"spacetravel.Views.Controls.Mission  1    +spacetravel.Views.Controls.Mission.MoonPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  <local0clr-namespace:spacetravel.Views.Controls.Mission  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity     
Page_Style#��[  .���� $��Disabled=�$��Hidden=�.��� $
��2000��  � ColumnDefinitions  �� $��* ��� $��* � � RowDefinitions �� $
��0.4* ��� $
��2.5* ��� $
��0.4* ��� $
��2.5* ��� $
��0.4* ��� $
��2.5* �.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�$��	10,20,0,0q�$��30��$��30��
�����������  �� 
TargetType"   �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property �@�Cursor �� Value$
 Hand��.  (System.Windows.Interactivity.Interaction	   Triggers	 /  )System.Windows.Interactivity.EventTrigger  
   	EventName$
 	MouseDown��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *GoBack+�� $
��Moon��$��Center=�$��Center=�$��40(�
�������$��2���� $��1��$:��4pack://application:,,,/Resources/Images/mooninfo.png��� $��1��$��1��$��30 100q� �� $
��0.3* ��� $
��0.1* ��� $
��0.1* ��� $
��0.3* �  �� $��* ��� $��* �.+��� 
�������$��D-DIN)�$��12(�$
��Wrap=�$��2��$��Center=�$��0,0,50,0q����� *DescMissionField+�� $��Duration��$��D-DIN)�$��1��
�������$��16(��� $
��Left=�$��D-DIN)�$��1��$��1��
�������$��16(����� *DurationField+�� $��Altitude��$��D-DIN)�$��2��
�������$��16(��� $
��Left=�$��D-DIN)�$��1��$��2��
�������$��16(����� *AltituteField+�� $��D-DIN)�$��3��
�������$��25(����� *
PriceField+  $ ChevronDown=�$��2��$��2��$��Center=�$��	0 -20 0 0q�$��50��$��50��
��������� $��Vehicle��$��Center=�$��Bottom=�$��30(�
�������$��2��$��2���� $��1��$��3��$:��4pack://application:,,,/Resources/Images/starship.png��$��50q�� $��3��$��0��$��30 100q� �� $
��0.3* ��� $
��0.1* ��� $
��0.1* ��� $
��0.1* ��� $
��0.3* �  �� $��* ��� $��* �.+��� 
�������$��D-DIN)�$��12(�$
��Wrap=�$��2��$��Center=�$��0,0,50,0q����� *DescShipField+�� $��Capacity��$��D-DIN)�$��1��
�������$��16(��� $
��Left=�$��D-DIN)�$��1��$��1��
�������$��16(����� *CapacityField+�� $��Diameter��$��D-DIN)�$��2��
�������$��16(��� $
��Left=�$��D-DIN)�$��1��$��2��
�������$��16(����� *DiameterField+�� $��Height��$��D-DIN)�$��3��
�������$��16(��� $
��Left=�$��D-DIN)�$��1��$��3��
�������$��16(����� *HeightField+�� $��Payload capacity��$��D-DIN)�$��4��
�������$��16(��� $
��Left=�$��D-DIN)�$��1��$��4��
�������$��16(����� *PayloadField+�� $��Book a flight��$��Center=�$��Bottom=�$��30(�
�������$��2��$��4���� $^��XTo book, you need to fill in the information, the price of the flight will depend on it*��$
��0 10q�$��Center=�$	��Top=�$��12(�
�������$��2��$��5��(  "System.Windows.Controls.DatePicker     IsTodayHighlighted$
 True��$|�False��$��5��$	��Top=�$��30 100q�$��60��
�������   FirstDayOfWeek$ Monday=����	#FF2B2B2B$��D-DIN)�$��16(�   SelectedDate �� *SelectedDate+��   TextBoxStyle#��[ $��15(�
�������$��5��$��60��$��Center=�$	��Top=�$��	0,200,0,0q����	#FF2B2B2B
 � Tag$ your weight��$	��340������ *WeightField+ �� UpdateSourceTrigger$ PropertyChanged=��� $C��=*the coefficient of price increase will depend on your weight��$��30 270q�$
��Left=�$	��Top=�$��12(�
�������$��5���� $��
30 300 0 0q�$
��Left=�$	��Top=�$��12(����	#DDFF6565$��5������ *	ErrorText+�� $��Total price��$
��Left=�$	��Top=�$��50 90q�$��30(�
�������$��1��$��5���� $
��Left=�$	��top=�$��50 150q�$��30(�
�������$��1��$��5������ *
TotalPrice+�� $��5��$��2��$	��250��$��Bottom=�$��0 0 0 60q�$
��Book��$��D-DIN)�$��18(�$��40��$��1,1,1,1q����� *BookCommand+y��� *CurrVisibility+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ White��   
BlurRadius$ 10Q�   ShadowDepth$ 0Q�