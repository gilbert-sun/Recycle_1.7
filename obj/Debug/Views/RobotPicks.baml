   M S B A M L   `   `   `  ����B  >Recycle, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls  5      7 clr-namespace:Recycle.ViewModelsRecycle.ViewModels  5          Recycle.Views.RobotPicks   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3ctrl"clr-namespace:Recycle.UserControls     5      7
viewmodels clr-namespace:Recycle.ViewModels     5      .��5      �   � RowDefinitions  5   
   �� 5      $��24 �6   �� 5      $��16 �6   �� 5      .+�5   
   ]� .+�5      ��    styleTextHeader#��[  6   $
��Left=�5        strComPicks#���  5      �� 5      $��Right=�6     mainViewModel � DataContext# [ 5       �� Orientation$ 
Horizontal=�5      $��Right=�5      .+�5      	�   
strComMins#���  6   $��0,0,60,0q�5       d� 	IsChecked 5      �� *	PicksUnit+ �� Mode$ TwoWay=�  covStringValue �� 	Converter# [  �� ConverterParameter$ minute��5      	� 5        strComHours#���  6     brushIndigo#���  5      $��0,0,60,0q�5        5      �� *	PicksUnit+$ TwoWay=�# [ $
 hour��5       	� 5!        
strComDays#���  6     brushDarkRed#���  5#       5"      �� *	PicksUnit+$ TwoWay=�# [ $	 day��5#      5$      5%      (   "Recycle.UserControls.TimelineChart  5&   
   $��2��5'         LabelY# �  5(       5&      �� *	TimePicks+
   Now 5)      �� *Now+	   TimeUnit	 5*      �� 
 �� Source#
 [  �� Path$ 	PicksUnit�   
DatePoints 5+      �� *Points+5,      5-      