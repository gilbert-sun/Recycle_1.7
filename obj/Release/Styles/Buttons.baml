   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   styleHeaderButton  �� 
TargetType �� Property �� Value  brushPrimary �� 
TargetType � 	Resources  Key W� From	 W� To g� Duration g� AutoReverse	 �� 
TargetName
 �� TargetProperty ��Name J� IsHitTestVisible J� Opacity �� Triggers :� RoutedEvent 	 enter  styleRoundButton'    !Recycle.UserControls.ButtonHelper    CornerRadius �� CornerRadius ��Name  styleMainButton �� BasedOn  brushLightGreen  styleSettingButton  styleWhiteButton 	 
brushBlack 
 styleIncreaseButton  
brushTitle  geoIncrease �� Triggers P� Property P� Value  styleDecreaseButton  geoDecrease  styleTabBase  brushIndicator  styleRdbTab � RowDefinitions �� RadiusX �� RadiusY ��Name �� 
TargetName ]� 
Conditions �� Property �� Value  styleRoundRadioButton3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius    	Direction!   ShadowDepth"   Color#   Opacity$ �� 
Background% �� Bullet& F�Name  geoUnchecked  
geoChecked' �� RelativeSource( �� Path  geoRoundChecked'  !System.Windows.VisualStateManager)   VisualStateGroups%  System.Windows.VisualStateGroup*   States   System.Windows.VisualState+   
Storyboard, R� KeyTime  System.Windows.Visibility-   Visible. R� Value+   %Recycle.UserControls.NavigationButton/ � ColumnDefinitions0 ��Name1   PathData  brushIndicatorLight�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     +ctrl"clr-namespace:Recycle.UserControls  %�  &	        7  &	 R    7  &	     7  &	 j    7  &	 �    7  &	
 -    &	 �    &	 ?    &	 �    7  &	     7  '�� N	    7  7  '	�     7  '  q    �� "  ��.���  � ��$ 0q���  � ��
 �������  � ��# �  ��  � �� �� " �� ���� 	enter .��W� $ 0X�$	 0.2X�$ 
00:00:00.2D� . $	 hover��$
 Opacity�.R�� #��z��.+��� $ hover�� .  
���   �$ 0Q�$��0���� #��z��#��z��#��z�� :� $ 	TouchDown��.[��� 8��  �� "  ��.���  �@  CornerRadius$ 12����  � ��
 �������  � �� Z� ��  � ��$ 0q���  � ��# �  ��  � �� �� " �� ���� 	enter .��W� $ 0X�$	 0.2X�$ 
00:00:00.2D� . $	 hover��$
 Opacity�.R�� .+��� # z #��z��#��z��#��z���� $ hover��# z #��z�� .  $y�Visible=�
���   �$ 0Q��� #��z��#��z��#��z�� :� $ 	TouchDown��.[��� 8��  �� "  ��8   .���  �@  CornerRadius$ 15����  � ��# �  ��  � ��$ 16(��� "  ��8   .���  � ��# �  ��  � ��$	 104���� "  ��8   .���  � ��
 �������  � �� �#999999��  � ��$ 1q���  � ��# � 	 ��  � ��$	 104���� "  ��.���  � ��# �  ��  � �� �� " ��.R�F� #���  #��z�� P�  � {� .  . ���  � �� �#999999�� "  ��.���  � ��# �  ��  � �� �� " ��.R�F� #���  #��z�� P�  � {� .  . ���  � �� �#999999�� "  d�.���  � ��
 ���� ��  � ��# �  ��  � ��
 �   ���  � ��$ Center=� P�  �@d�	IsChecked$
 TrueY�. ���  � ��$
 Bold"��� "  d�8   .���  � ��$ 20(���  � ��$ Center=���  � �� �� " d�.R�� #��z�� �� �� $��6 �.+��� $ hover��$ 4��$ 4�� .  
���   �$	 0.1Q�$y�Hidden=��� $ content��$
 0.85Q�#��z��#��z���� $
 mark��$ 6��$ 6��$��1�� .  #��z��$y�Hidden=� P�  �@d�	IsChecked$
 TrueY�. ��� $
 mark�� � y�$ Visible=��� $ content�� �@J�Opacity$ 1Q�]�  ��  �@J�IsMouseOver . ��  �@d�	IsChecked$ FalseY�./��� $ hover�� � y�$ Visible=��� "  d�8   .���  � ��$ 16(���  � ��
 �   ���  � ��
 �������  � ��$ Center=���  � ��$ Center=���  �@J�Effect   $ 20Q�$  0Q�$! 6Q�$" Black��$	# 0.1Q� P�  �@d�	IsChecked$
 TrueY�. ���  � �� �#F7C26C��  � ��$
 Bold"��� "  ��.���  �@�FocusVisualStyle Z� ��  � ��# �  ��  � ��# � 	 ��  � ��$ 20(���  � �� �� " ��.R��� 
$ ���� % �� $��24��$��24�� .  .+�F� $& 	checkMark��8��  ���#979797._��� $��16,0,0,0q�$��Center=�$
��Left=���.  P�  �@d�	IsChecked$
 TrueY�. ��� $ 	checkMark��8   � ���� $ 	checkMark�� �� ' �� *TemplatedParent+$( 
Background� � ���� "  	�.���  �@�FocusVisualStyle Z� ��  � ��# �  ��  � ��# � 	 ��  � ��$ 20(���  � �� �� " 	�.R��� 
$ ���� % �� $��24��$��24�� .  .+��� $ uncheck��$ 8��$ 8�����#E4E4E4$��24��$��24��$��0��$y�Hidden=�F� $& check��8��  #��z��$y�Hidden=�)   CheckStates��.*   Checked��.+ �� .��T� $
 (UIElement.Visibility)�$	 check��..�i� $, 0��#. Z-   	Unchecked��.+ �� .��T� $
 (UIElement.Visibility)�$	 uncheck��..�i� $, 0��#. Z- ._��� $��16,0,0,0q�$��Center=�$
��Left=���. �� "   .���  � ��$ 24(���  � ��$ 96����  � ��$ Center=���  � ��# �  ��  � �� �� "  .R�� #��z��/ �� $��8 ��� $0 column1��$��85 ��� $0 column2��.+��� $
 mark��$ 6��$ 6�� .  #���  $y�Hidden=�F� $
& icon�� .  #��z��#��z1 $��1��$��Center=�$��Center=��� $��2�� .  #��z�� P�  �@d�	IsChecked$
 TrueY�. ��� $
 mark�� � y�$ Visible=�P�  �@ IconOnly . . ��� $ column1�� � ��$ 48 ��� $ column2�� � ��$ 0 � P�  �@J�IsMouseOver . . ���  � �� �#F2F2F2P�  �@d�	IsChecked$
 TrueY�. ���  � ��# �  ��  � ��
 �   ���  � ��$
 Bold"�