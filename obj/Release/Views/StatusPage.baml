   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls      Recycle.Views.StatusPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3ctrl"clr-namespace:Recycle.UserControls       � 	Resources     styleTextBoxAd �� 
TargetType �� BasedOn �� Property �� Value  mainViewModel �� Source �� Path  
covInverse �� 	Converter �� Triggers	 P� Property
 P� Value  tempReadOnlyTextBox(   "Recycle.UserControls.TextBoxHelper��%�   &	        7��7  7  7  �� " ��8   .���  �@��
IsReadOnly �� 8  $ 	CanAdjust�8   P� 	 �@��
IsReadOnly
 . . ���  � ��8  ��  �@ IsMonitoring .  ��  � ��$ Center=�.���  � RowDefinitions �� $��64 ��� .+���   styleTextHeader#��[ $
��40,0q�$��Center=�$��
Robot Name���� $��1��.���� $��0,0,0,28q�.+�A�   styleUniformGridMain#��[ .+���   styleWhiteBorder#��[ $	��488��._��� .+�*   $Recycle.UserControls.ParametersGroup    strComRoboticArm   Header# �  $	��204��   Items �� *ArmParameters+]� $��40����.  .+��� #��[   strComMotionSettings#���  $��Center=�� $��0,20,0,0q� � ColumnDefinitions �� �� $��24 ��� �� $��24 ��� .+��� #��[     	Watermark$ 	Max Speed���� #��[  $ 
Speed Rate��$��190.542��$��2���� #��[  $ 	Line Rate��$��4��� $��0,16,0,0q� �� �� $��24 ��� �� $��24 ��� �� $��24 ��� .+��� #��[  $ P2P Acc.���� #��[  $ P2P Dsc.��$��2���� #��[  $ 	Line Acc.��$��4���� #��[  $ 	Line Dsc.��$��6���� #��[ $	��488��._��   #   Recycle.UserControls.AdvLabel��%:   '        7 �� "  8   .���  � ��$ Center=� �� �� ��  �� $��40 ��� $��88 ��� $��40 ��� $��88 ��� $��88 �.+�]� $��4����.  $��0,0,0,16q�.+��� #��[ $��Center=� 	 strComConveyor#��� 	 %   Recycle.UserControls.StatusMark     Status$ ERROR=�$��Right=�$��Center=�  &    Recycle.UserControls.StatusLabel   Text$ 46 cm/s��   Description$ Axis 1st��$��1���� #��[ $��2��$��4�� 
 	strComArm#��� 
   $ -12.36��$ X��$
 GOOD=�$��3��  $ -99.45��$ Y��$
 GOOD=�$��3��$��1��  $ -41.26��$ Z��$
 GOOD=�$��3��$��2��  $ 46 cm/s��$ Axis 1st��$
 GOOD=�$��4��  $ -12.36��$ Axis 2nd��$
 GOOD=�$��4��$��1��  $ -99.45��$ Axis 3rd��$
 GOOD=�$��4��$��2��A� #��[ .+��� #��[ $	��176��
������ �� #��[ $	��176��._��� .+�]� ��.  .+���   strComVisionSystem#���  #��[   $ ERROR=�$��Right=�$��Center=�A�  A� Rows$ 1��$��0,36,0,0q�.+�  $
 Good��  strNaviStatus# [   $ 7 days 17 hours��$ 
Total Time��  $ 
2021/01/01��$ Recently��