   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Recycle.UserControlsRecycle.UserControls  7 clr-namespace:Recycle.ConvertersRecycle.Converters  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089,    &Recycle.Converters.GridLengthConverter   covGridLength(   "Recycle.UserControls.HistogramItem  �� 
TargetType �� Property  brushAttentionOrage �� Value �� 
TargetType   Value �� CornerRadius   	BarHeight$   Recycle.UserControls.Histogram � ColumnDefinitions �� 	Converter	 � RowDefinitions
 �� ConverterParameter$   Recycle.UserControls.ChartGrid J� IsHitTestVisible   UnitX   	UnitValue   UnitY   LabelY   LabelX ��Name A� Columns �� TextAlignment A� Rows)   #Recycle.UserControls.ResourceHelper   Text   Percent   ChartHeight �� RelativeSource �� AncestorType(   "Recycle.UserControls.TimelineChart   	MaxSecond$   Recycle.UserControls.ChartBase   MaxX   MaxValue   MaxY   
UnitSecond   	UnitValue'   !Recycle.UserControls.TimelineArea    
DatePoints!   
DatePoints
"   Now
#   Now$   	MaxSecond%   MinValue&   MinValue'   MaxValue(   LabelY)   LabelX* �� Triggers+ P� Property, P� Value  brushLightGreen  brushIndigo  brushDarkRed�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     +ctrl"clr-namespace:Recycle.UserControls  (cov clr-namespace:Recycle.Converters  %$  &	        '       '  �     7   7   '  �    7   7      �� "   .���  � ��# �  ��  � ��
 �   ���  � ��$ 16(���  � �� �� "  .R��� $��Bottom=�.+��� #��z $��Center=��� $ 12��$��16��#��z #��z��$��Center=��� "   .���  � �� �#999999��  � �� �#E4E4E4��  � ��$ 1q���  �@ 
ChartWidth$	 432Q���  �@ ChartHeight$	 152Q���  � �� �� "  .R��  �� $��48 ��� ���� *
ChartWidth+8   �� $��40 �	 �� $��63 ��� ���� *ChartHeight+8  $
 height���� $��26 �.+�   .  $��1��$��1��$ 0Q�# z #��z��#��z���� #��z $��14(�$��2��$��0,0,0,15q�$��Bottom=��� #��z $��14(�$��1��$��2��$��2��$��8,0,0,0q�$
��Wrap=�$��Bottom=��� $ 	PART_Rows��$
��Left=�$��1��$��2��$	��Top=����� .R�A� $ 1������ .R��� $ Center=�$	��0,0q�$��Center=����� �� #��z��$��2��$��1������ .R�A� $ 1������ .R��� $��14(�$ Center=�$��0,12,0,0q� �� *Header+�� #��z��$��1��$��2������ .R�A� $ 1������ .R�   �� *	Percent+ �� *ChartHeight+ �� "   �� *Value+�� "   .���  � �� �#999999��  �@ 
ChartWidth$	 432Q���  �@ ChartHeight$	 152Q���  � �� �� "  .R��  �� $��48 ��� ���� *
ChartWidth+8   �� $��40 �	 �� $��63 ��� ���� *ChartHeight+8  $
 height���� $��26 �.+�   .  $��1��$��1��# z # z # z # z ���#E4E4E4$��1q�  $��1��$��1��#��z��$��4q�#! z  ## z" #$ z #& z% #' z �� #��z( $��14(�$��2��$��0,0,0,15q�$��Bottom=��� #��z) $��14(�$��1��$��2��$��2��$��8,0,0,0q�$
��Wrap=�$��Bottom=��� $ 	PART_Rows��$
��Left=�$��1��$��2��$	��Top=����� .R�A� $ 1������ .R��� $ Center=�$��Center=����� �� $ PART_Columns��$��2��$��1������ .R�A� $ 1������ .R��� $ Center=�$��0,12,0,0q����� ��  � ��# �  ��  �@ 	MaxSecond$ 35Q���  �@ 
UnitSecond$ 10Q���  �@ 	UnitValue$ 10Q���  �@ MaxValue$ 45Q���  �@ LabelX$	 Sec��* P� + �@ TimeUnit$, minute��. ���  � ��# �  ��  �@ 	MaxSecond$
 1020Q���  �@ 
UnitSecond$	 300Q���  �@ LabelX$
 Mins��P� + �@ TimeUnit$
, hour��. ���  � ��# �  ��  �@ 	MaxSecond$
 3720Q���  �@ 
UnitSecond$	 900Q���  �@ 	UnitValue$
 1000Q���  �@ MaxValue$
 3200Q���  �@ LabelX$
 Mins��P� + �@ TimeUnit$	, day��. ���  � ��# �  ��  �@ 	MaxSecond$ 449280Q���  �@ 
UnitSecond$ 86400Q���  �@ 	UnitValue$ 10000Q���  �@ MaxValue$ 22000Q���  �@ LabelX$	 Day��