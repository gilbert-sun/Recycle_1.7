   M S B A M L   `   `   `  ����B  >Recycle, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   styleTextHeader  �� 
TargetType �� Property  
brushBlack �� Value  tempTextBox �� 
TargetType � 	Resources  Key g� Duration	 W� To �� TargetProperty �� 
TargetName	 �� CornerRadius
 ��Name ��Name(    "Recycle.UserControls.TextBoxHelper    	Watermark J� IsHitTestVisible ��Name �� Triggers P� Property P� Value N� EnterActions  gotFocus �� 
TargetName ]� 
Conditions �� Property �� Value  	lostFocus N� ExitActions  tempUnderline  tempReadOnlyTextBox#   Recycle.UserControls.AdvLabel&    Recycle.UserControls.StatusLabel   Text   Description  styleTextBoxBase 	 
boolUseOsk 
 brushLightGreen �� Triggers  
brushTitle �� BasedOn  styleTextUnderline�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      +ctrl"clr-namespace:Recycle.UserControls  5      %�  &	        &	 �     7  7  7  7  &	 �    7  7  7  7  &	 m    &	 �    '�� s    7  7  'G� 3    7  7  7  7  &	 )    7  7  �� 5      "  ��6$   .�5   
   ��  � ��# �  6'   �� 5   
    � ��$ 20(�6%   �� 5   
    � ��$
 Bold"�6'   5      �� 5
      " ��6*    5   
   ���� 5      gotFocus .��5      W� $ 0:0:0.2D�6"   $ 16X�5   "   $ FontSize�5   "   $ Message��5   "   W� 5      $ 0:0:0.2D�6"   $ 24X�5   "   $ Height�5   "   $ PART_ContentHost��5   "   5      �� 5      	lostFocus .��5      W� $ 0:0:0.2D�6"   $ 20X�5   "   $ FontSize�5   "   $ Message��5   "   W� 5      $ 0:0:0.2D�6"   $ 0X�5   "   $ Height�5   "   $ PART_ContentHost��5   "   5      5       .R�5!   
   � .+�5"      �� #��z��6   #��z��5#      #��z��5$      $	 4��5%      �� 5&      $
 PART_InnerGrid��6   $��Center=�5'      .+�5(      �� $ Message��6   #��z 5)      $��20(�5*      $��Medium"�5+      #��z��5,      ���#666666 .  5.      �� 5/      $ PART_ContentHost��6   $��0��50      $��0q�51      ��.  $��Stretch=�53      $��Center=�54      $��0q�55      $��0��57      ��56      Z� 57      58      59       5:   
   P� 5;       �@J�	IsFocused .  5<      �� 5=      8��  6&   . �5?      �� $ Message��6    � ��$ Normal"�6D   5@      P� 5A       �@  HasText .  5B      �� 5C      8�� 6&   . �5E      �� $ Message��6    � ��$ Normal"�6D   5F      ]� 5G       5H      �� 5I       �@  HasText .  6F   �� 5J       �@J�	IsFocused .  65    5L      �� 5M      8�� 6&    5O      �� 5P      8�� 6&   5R      5T      �� 5U      " ��6,    5V   
   ���� 5W      gotFocus .��5X      W� $ 0:0:0.2D�6"   $ 16X�5Y   "   $ FontSize�5Z   "   $ Message��5[   "   W� 5\      $ 0:0:0.2D�6"   $ 24X�5]   "   $ Height�5^   "   $ PART_ContentHost��5_   "   5`      �� 5a      	lostFocus .��5b      W� $ 0:0:0.2D�6"   $ 20X�5c   "   $ FontSize�5d   "   $ Message��5e   "   W� 5f      $ 0:0:0.2D�6"   $ 0X�5g   "   $ Height�5h   "   $ PART_ContentHost��5i   "   5j      5k      .R�5l   
   � #��z��6   .+�5m      �� $��0q�6   #��z��5n      $��3��5o      $��0,0,0,5q�5p      $��Bottom=�5q      $		 1.5��5r      �� 5s      $
 PART_InnerGrid��6   $��Center=�5t      .+�5u      �� $ Message��6   $��Center=�5v      #��z 5w      $��20(�5x      $��Medium"�5y      #��z��5z      ���#666666 .  5|      �� 5}      $ PART_ContentHost��6   $��0��5~      $��0q�5      ��.  $��Stretch=�5�      $��Center=�5�      $��0q�5�      $��0��5�      ��5�      Z� 5�      5�      5�       5�   
   P� 5�       �@J�	IsFocused .  5�      �� 5�      8��  6&   . �5�      �� $ Message��6    � ��$ Normal"�6D   �� 5�      $ Message��6    � ��$
 Left=�6M   5�      P� 5�       �@  HasText .  5�      �� 5�      8�� 6&   . �5�      �� $ Message��6    � ��$ Normal"�6D   �� 5�      $ Message��6    � ��$
 Left=�6M   5�      ]� 5�       5�      �� 5�       �@  HasText .  6F   �� 5�       �@J�	IsFocused .  65    5�      �� 5�      8�� 6&    5�      �� 5�      8�� 6&   5�      5�      �� 5�      " ��62   .R�5�   
     # z��6   #��z��5�      # z 5�      5�      �� 5�      "  ��6%   .�5�   
   ��  �@  Numeric . 67   �� 5�   
    �@  UseOsk# � 	 66   �� 5�   
    �@  IsMonitoring . 6<   �� 5�   
    �@��SelectionBrush# � 
 6+   �� 5�   
    � ��$ 20(�6%   �� 5�   
    � ��$
 Bold"�6'   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��
 �����6'   �� 5�   
    � ��# �  6'   �� 5�   
    � �� �#E4E4E46(   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    �@��IsInputMethodEnabled .  6=    5�   
   P� 5�       �@J�	IsFocused . . �5�      ��  � ��# �  60   �� 5�       � ��$ 2q�64   5�      5�      �� 5�      "  ��6   8   .�5�   
   ��  � ��$ 72��6#   �� 5�   
    � ��$
 16,0q�6$   �� 5�   
    �@��
CaretBrush# � 
 6'   �� 5�   
    � ��8  6%   5�      �� 5�      "  G�6   .�5�   
   ��  �@  UseOsk# � 	 66   �� 5�   
    �@  IsMonitoring . 6<   �� 5�   
    �@G�SelectionBrush# � 
 6+   �� 5�   
    � ��$ 20(�6%   �� 5�   
    � ��$
 Bold"�6'   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��$ 72��6#   �� 5�   
    � ��
 �����6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$
 16,0q�6$   �� 5�   
    � �� �#E4E4E46(   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    �@G�
CaretBrush# � 
 6'   �� 5�   
    � �� 5�      �� 5�      " G�6"    5�      ���� 5�      gotFocus .��5�      W� $ 0:0:0.2D�6.   $ 16X�5�   .   $ FontSize�5�   .   $ Message��5�   .   W� 5�      $ 0:0:0.2D�6.   $ 24X�5�   .   $ Height�5�   .   $ PART_ContentHost��5�   .   5�      �� 5�      	lostFocus .��5�      W� $ 0:0:0.2D�6.   $ 20X�5�   .   $ FontSize�5�   .   $ Message��5�   .   W� 5�      $ 0:0:0.2D�6.   $ 0X�5�   .   $ Height�5�   .   $ PART_ContentHost��5�   .   5�      5�      .R�5�      � .+�5�      �� #��z��6!   #��z��5�   !   #��z��5�   !   $	 4��5�   !   �� 5�      $
 PART_InnerGrid��6%   $��Center=�5�   %   .+�5�      �� $ Message��6(   #��z 5�   (   $��20(�5�   (   $��Medium"�5�   (   #��z��5�   (   ���#666666 .  5�   (   �� 5�      $ PART_ContentHost��6+   $��0��5�   +   $��0q�5�   +   ��.  $��Stretch=�5�   +   $��Center=�5�   +   $��0q�5   +   $��0��5  +   ��5  +   Z� 5  +   5     5      5     P� 5      �@J�	IsFocused .  5     �� 5  "   8��  62   . �5
     �� $ Message��6%    � ��$ Normal"�6P   5     P� 5      �@  HasText .  5     �� 5  "   8�� 62   . �5     �� $ Message��6%    � ��$ Normal"�6P   5     ]� 5      5     �� 5  "    �@  HasText .  6R   �� 5  "    �@J�	IsFocused .  6A    5     �� 5  "   8�� 62    5     �� 5  "   8�� 62   5     5     5!      5"  
   P� 5#      �@J�	IsFocused . . �5$     ��  � ��# �  60   �� 5%      � ��$ 2q�64   5&     5(     �� 5)     "  ��6'   8   .�5*  
   ��  � ��$ 64��6#   �� 5+  
    �@��
CaretBrush �#B0A7A76'   �� 5,  
    �@��TextAlignment$ Center=�6*   �� 5-  
    � ��8  6%   5.     5/     