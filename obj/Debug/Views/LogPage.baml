   M S B A M L   `   `   `  ����B  >Recycle, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Recycle.ViewsRecycle.Views  5          Recycle.Views.LogPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Recycle.Views     5        � 	Resources  5	         styleRdbSub �� 
TargetType  styleRoundRadioButton �� BasedOn �� Property �� Value  	tempRobot  styleRdbTab  tabItemWidth 	� 	GroupName��%E  &	        7  &	 �     7  �� 5
   
   " 	�6$   8   .�5      ��  � ��$	 144��6)   �� 5       � ��$ 40��6'   �� 5       � ��$ 0,0,24,0q�6'   �� 5       � ��$ Bottom=�62   5      �� 5   
   .R�5      	� 8��  #���  5      $ group1��5      ��5      �� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��64 �6   �� 5      $��76 �6   �� 5      .+�5   
   ��   styleRobotTab#��[ 6   $��40,0,0,0q�5!      ��5      �� *Robots+  mainViewModel �� Source# [  �� SelectedItem 5       �� *SelectedRobot+# [ 	 �� Mode$	 TwoWay=�5!      �� 5"   
   
 �� Orientation$
 
Horizontal=�6   $��	40,0,0,12q�6.   $��1��6A   .+�5#      	� -   5        #��[  5#        strComOverall#���  6?   6i   	� 5$      -   5        #��[  5$        strComRoboticArm#���  6?   6l   	� 5%      -   5        #��[  5%       	 strComVisionSystem#��� 	 6?   6n   	� 5&      -   5        #��[  5&       
 strComConveyor#��� 
 6?   6j   	� 5'      -   5        #��[  5'        strComController#���  6?   6l   5(      �� 5)   
     styleWhiteBorder#��[ 6   $��40,12,40,40q�5*      $��2��5+      $
��Auto��5,      $��Stretch=�5-      $��Stretch=�5.      ._�5/      �  50      �� 51      $��40 �6$   �� 52      .+�54      ]� ��.    55       �� RelativeSource �� Path��%�   '��       7���� 56      " ��6    8   .�57      ��  � ��$ Center=�6B   �� 58       � ��$ Right=�6?   �� 59       � ��$	 160��69   �� 5:       � �� 6;   ��  �� *Self+$ 
Foreground�5;      5<      .+�5=      ��   styleTextHeader#��[ 6    $��Conveyor��6I   5>      �� 5?      $��1��6   $��16(�5@      ���#424242$��-5,0,0,0q�5B       �� 
IsReadOnly . $��0q�5D      $
��Auto=�5E       �5F      /� 5G       /� 
LineHeight$ 24��6'   .T�5H      J� -   5         J�Name$ 	paragraph��5H   (   5I      5K      5L      5M      5N      5O      