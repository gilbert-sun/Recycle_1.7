   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls      Recycle.Views.AdjustPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3ctrl"clr-namespace:Recycle.UserControls       � 	Resources     styleWhiteBorderAd �� 
TargetType  styleWhiteBorder �� BasedOn �� Property �� Value  mainViewModel �� Source �� Path  styleTextBoxAd  
covInverse �� 	Converter �� Triggers	 P� Property
 P� Value  tempReadOnlyTextBox(   "Recycle.UserControls.TextBoxHelper  styleTextUnderlineAd  styleTextUnderline��%)  &	        7  7  &	 =     7��7  7  7  &	 �     7  7  7  7  �� " ��8   .���  � {� �� 8  $ 	CanAdjust��� " ��8   .���  �@��
IsReadOnly �� 8  $ 	CanAdjust�8   P� 	 �@��
IsReadOnly
 . . ���  � ��8  ��  �@ IsMonitoring .  ��  � ��$ Center=��� " ��8   .���  �@��
IsReadOnly �� 8  $ 	CanAdjust�8   P� 	 �@��
IsReadOnly
 . . ���  �@��TextAlignment$
 Left=���  � ��8  ��  �@ IsMonitoring .  ��  � ��$ Center=�.���  � RowDefinitions �� $��64 ��� .+��� $
��40,0q� �� Orientation$ 
Horizontal=�.+���   styleTextHeader#��[ $��
Robot Name��$��Center=���  	 styleWhiteButton#��[	 $
��Home��$��40��$��33,0,0,0q��� $��1��.��A�  
 styleUniformGridMain#��[
 $
��0,12q�.+��  � ColumnDefinitions �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� #��[  $	��376��$	��208��._��  �� �� $��8 ��� �� $��8 ���  �� $��40 ��� $��12 ��� $��40 ��� $��24 ��� $��40 �.+��� $
��Demo��#��[ $��5����   styleSettingButton#��[   strDemoCycleMovement#���  $��2���� #��[   strDemo2dCircle#���  $��2��$��2���� #��[   
strDemoArc#���  $��2��$��4���� #��[ #���  $��4���� #��[   strDemoRectangle#���  $��4��$��2���� #��[   strDemoUGeo#���  $��4��$��4���� #��[ $	��376��$	��208��$��1��._��   #   Recycle.UserControls.AdvLabel��%:   '        7 �� "  8   .���  � ��$ Center=� �� �� ��  �� $��24 ��� $��12 ��� $��64 ��� $��64 �.+�]� $��4����.  .+��� #��[ $��Center=�  strComEncoderFeedback#���  �� $��Center=�$��Medium"�$��14(�  brushNotiRed#���  $��Right=�$��46 cm/s, 2760 m/min��  &    Recycle.UserControls.StatusLabel   Text$ -12.36��   Description$ X��%   Recycle.UserControls.StatusMark   Status$
 GOOD=�$��2��  $ -99.45��$ Y��$
 GOOD=�$��2��$��1��  $ -41.26��$ Z��$
 GOOD=�$��2��$��2��  $ 00.12��$ J1��$
 GOOD=�$��3��  $ 22.66��$ J2��$
 GOOD=�$��3��$��1��  $ 44.12��$ J3��$
 GOOD=�$��3��$��2���� #��[  $	��168��$	��440��$��1��$��2��._��  �� $��40 ��� $��24 ��� $��64 ��� $��24 ��� $��64 ��� $��24 ��� $��64 ��� $��24 ��� $��64 �.+��� #��[   strComAdjustment#���  �� #��[   strComStride   	Watermark# �  $��2��A� $��4�� A� Rows$ 1��.+��� #��[ $��24(�$��Center=�$��X����   styleIncreaseButton#��[ $��Center=���   styleDecreaseButton#��[ $��Right=�$��Center=�A� $��6��$ 1��.+��� #��[ $��24(�$��Center=�$��Y���� #��[ $��Center=��� #��[ $��Right=�$��Center=�A� $��8��$ 1��.+��� #��[ $��24(�$��Center=�$��Z���� #��[ $��Center=��� #��[ $��Right=�$��Center=��� .+��� #��[  $	��264��._��  �� $	��120 ��� $��12 ��� $	��120 ��� $��96 ��� $	��172 � �� $��40 ��� $��8 ��� $��72 ��� $��12 ��� $��72 �.+��� #��[ $��5��$#��匯入 DH File: Delta_001.xml���� $��2��#��[ $ e���� $��2��$��2��#��[ $ r��$	��123���� $��4��#��[ $ e���� $��4��$��2��#��[ $ re��$	��123��