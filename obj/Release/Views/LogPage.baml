   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Recycle.ViewsRecycle.Views      Recycle.Views.LogPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:Recycle.Views       � 	Resources     styleRdbSub �� 
TargetType  styleRoundRadioButton �� BasedOn �� Property �� Value  	tempRobot  styleRdbTab  tabItemWidth 	� 	GroupName��%�   &	        7  &	 u     7  �� " 	�8   .���  � ��$	 144����  � ��$ 40����  � ��$ 0,0,24,0q���  � ��$ Bottom=��� .R�	� 8��  #���  $ group1������ .���  � RowDefinitions �� $��64 ��� $��76 ��� .+���   styleRobotTab#��[ $��40,0,0,0q����� *Robots+  mainViewModel �� Source# [  �� SelectedItem �� *SelectedRobot+# [ 	 �� Mode$	 TwoWay=��� 
 �� Orientation$
 
Horizontal=�$��	40,0,0,12q�$��1��.+�	� #��[    strComOverall#���   d� 	IsChecked$
 TrueY�	� #��[    strComRoboticArm#���  	� #��[   	 strComVisionSystem#��� 	 	� #��[   
 strComConveyor#��� 
 	� #��[    strComController#���  ��   styleWhiteBorder#��[ $��40,12,40,40q�$��2��$
��Auto��$��Stretch=�$��Stretch=�._��  �� $��40 ��� .+�]� ��.     �� RelativeSource �� Path��%�   '��       7���� " ��8   .���  � ��$ Center=���  � ��$ Right=���  � ��$	 160����  � �� ��  �� *Self+$ 
Foreground�.+���   styleTextHeader#��[ $��Conveyor���� $��1��$��16(����#424242$��-5,0,0,0q� �� 
IsReadOnly . $��0q�$
��Auto=� �/�  /� 
LineHeight$ 24��.T�J� -    J�Name$ 	paragraph��