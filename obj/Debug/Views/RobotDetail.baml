   M S B A M L   `   `   `  ����B  >Recycle, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Recycle.ViewsRecycle.Views  5      ;"clr-namespace:Recycle.UserControlsRecycle.UserControls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      7 clr-namespace:Recycle.ViewModelsRecycle.ViewModels  5	          Recycle.Views.RobotDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Recycle.Views     5      3ctrl"clr-namespace:Recycle.UserControls     5      6sys&clr-namespace:System;assembly=mscorlib     5      7
viewmodels clr-namespace:Recycle.ViewModels     5	        � 	Resources  5         strDateFormat��%3   &	        ��5   
   yyyy/MM/dd, HH:mm��6>   5      .��5      �� .��5   
   A�   styleUniformGridMain#��[ 6   $
��0,12q�6D   .+�5      ��   styleWhiteBorder#��[ 6    �� Padding$
 24,8q�5      $��Center=�5      $	��688��5      ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��8 �6(   �� 5      $
��Auto �6(   �� 5      $��88 �6(   �� 5      $
��Auto �6(   .+�5      �� $
��0,16q�6      styleTextHeader#��[ 5       ��5        ��  �� Mode$ OneWay=��� 5!      $��48��6    $��Right=�5"        �� 
LineHeight$ 24��5#        �� TextAlignment$ Right=�5$       $��14(�5%       �� 5&        strComUpTime#��  6   �� 6F   $�: ��6J   �� 6V   �6Z   �� *	StartTime+$ OneWay=� �� StringFormat# [  �� 5'      �� 5(        strComTotalUpTime#��  6   �� 6K   $�: ��6O   �� 6[   �6_   �� *
Duration+$ OneWay=�5)      �� 5*      $��-24,0q�5,      $��2��5-      ��5*      �� *
ImageWidth+��5+      �� *ImageHeight+��5.      �� 5/       �� ImageSource 6)   �� *ImageFilename+.+�51      &    Recycle.UserControls.StatusLabel    strComConveyor   Text# �  6v   	 �� Left	 6+   �� 
 �� Path$
 PointC.X�
 �� Top 6Q   �� $
 PointC.Y�%   Recycle.UserControls.StatusMark   Status 6�   �� *ConveyorStatus+  52        strComRoboticArm# �  6v   	 6+   �� $
 PointM.X� 6Q   �� $
 PointM.Y� 6�   �� *	ArmStatus+  53        strComVisionSystem# �  6v   	 6+   �� $
 PointV.X� 6Q   �� $
 PointV.Y� 6�   �� *VisionSysStatus+54      *   $Recycle.UserControls.ParametersGroup  55         Header# �  6+   $��4��6w      Items 6W   �� *ArmParameters+6w   56      57      �� 58      .+�5<      �� #��[ 6   $	��332��6C   ._�5=         Recycle.Views.RobotPicks  5>      5?      5@      5A      5B      