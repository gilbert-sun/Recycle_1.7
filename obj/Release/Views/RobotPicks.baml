   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls  7 clr-namespace:Recycle.ViewModelsRecycle.ViewModels      Recycle.Views.RobotPicks   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3ctrl"clr-namespace:Recycle.UserControls     7
viewmodels clr-namespace:Recycle.ViewModels     .���   � RowDefinitions  �� $��24 ��� $��16 ��� .+�]� .+���    styleTextHeader#��[  $
��Left=�  strComPicks#���  �� $��Right=�  mainViewModel � DataContext# [  �� Orientation$ 
Horizontal=�$��Right=�.+�	�   
strComMins#���  $��0,0,60,0q� d� 	IsChecked �� *	PicksUnit+ �� Mode$ TwoWay=�  covStringValue �� 	Converter# [  �� ConverterParameter$ minute��	�   strComHours#���    brushIndigo#���  $��0,0,60,0q� �� *	PicksUnit+$ TwoWay=�# [ $
 hour��	�   
strComDays#���    brushDarkRed#���   �� *	PicksUnit+$ TwoWay=�# [ $	 day��(   "Recycle.UserControls.TimelineChart  $��2��   LabelY# �   �� *	TimePicks+
   Now �� *Now+	   TimeUnit	 �� 
 �� Source#
 [  �� Path$ 	PicksUnit�   
DatePoints �� *Points+