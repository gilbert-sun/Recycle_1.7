   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Recycle.ViewsRecycle.Views  ;"clr-namespace:Recycle.UserControlsRecycle.UserControls  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 7 clr-namespace:Recycle.ViewModelsRecycle.ViewModels      Recycle.Views.RobotDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:Recycle.Views     3ctrl"clr-namespace:Recycle.UserControls     6sys&clr-namespace:System;assembly=mscorlib     7
viewmodels clr-namespace:Recycle.ViewModels       � 	Resources     strDateFormat��%%   &	        ��yyyy/MM/dd, HH:mm��.���� .��A�   styleUniformGridMain#��[ $
��0,12q�.+���   styleWhiteBorder#��[  �� Padding$
 24,8q�$��Center=�$	��688��._��  � RowDefinitions �� $
��Auto ��� $��8 ��� $
��Auto ��� $��88 ��� $
��Auto �.+��� $
��0,16q�  styleTextHeader#��[ ����  �� Mode$ OneWay=��� $��48��$��Right=� �� 
LineHeight$ 24�� �� TextAlignment$ Right=�$��14(���   strComUpTime#��  �� $�: ���� ��� *	StartTime+$ OneWay=� �� StringFormat# [  �� ��   strComTotalUpTime#��  �� $�: ���� ��� *
Duration+$ OneWay=��� $��-24,0q�$��2������ *
ImageWidth+���� *ImageHeight+����  �� ImageSource �� *ImageFilename+.+�&    Recycle.UserControls.StatusLabel    strComConveyor   Text# �  	 �� Left	 �� 
 �� Path$
 PointC.X�
 �� Top �� $
 PointC.Y�    strComRoboticArm# �  	 �� $
 PointM.X� �� $
 PointM.Y�%   Recycle.UserControls.StatusMark   Status �� *	ArmStatus+    strComVisionSystem# �  	 �� $
 PointV.X� �� $
 PointV.Y�*   $Recycle.UserControls.ParametersGroup     Header# �  $��4��   Items �� *ArmParameters+�� .+��� #��[ $	��332��._�   Recycle.Views.RobotPicks  