   M S B A M L   `   `   `  ���� B  >Recycle, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Recycle.ViewModelsRecycle.ViewModels  -clr-namespace:Recycle.ViewsRecycle.Views  ;"clr-namespace:Recycle.UserControlsRecycle.UserControls  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 7 clr-namespace:Recycle.ConvertersRecycle.Converters      Recycle.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /vm clr-namespace:Recycle.ViewModels     ,viewclr-namespace:Recycle.Views     3ctrl"clr-namespace:Recycle.UserControls     6sys&clr-namespace:System;assembly=mscorlib     0cov clr-namespace:Recycle.Converters     -     �Name$  
mainWindow��   mainViewModel � DataContext# [   � Title$ Recycle�� 
 Roboto#��[  � WindowState$ 	Maximized=�$	��600��$	��800��$
��1024��$
��1280�� � Icon$ Images/Desk Logo.ico�� � 	Resources '   !Recycle.Converters.CountConverter  covCountInverse   Inverse  storyShowPopup	 W� To g� Duration	 �� TargetProperty  storyHidePopup  styleStatusText
 �� 
TargetType �� Property �� Value  
tempStatus ��Name  styleRoundButton  brushLightGreen �� Triggers �� Value �� Binding �� 
TargetName 	 
brushError 
 brushWarning��%  &	       &	      &	 @     &	 y     &	 �     7  7  7  7 	 7 
    . �� .��W� $ 1X�$ 
00:00:00.2D�$	 Opacity��� -   .��W� $ 0X�$ 
00:00:00.2D�$	 Opacity��� "
 ��.���  � ��$ 20(���  � ��$ Center=���  � ��$ Center=���  � ��
 ������� .R��� $ button��-   8��  $	��8,0q�8�� .���� 8�� ����  �� $ ERROR�� �� *Status+.a��� $ button��8   � ���� $ WARNING�� �� *Status+.a��� $ button��8   � ��.���   	brushGray#��[  � RowDefinitions �� $��80 ��� .+�]�  K� ZIndex$ 3��  brushPrimary#��[ ��.     styleHeaderButton �� BasedOn��%�   '��       '�� �     7  �� "
 ��.���  � ��$ 1���� 
 �@��Y1$ 0���� 
 �@��Y2$ 1����  � ��
 �������  �@J�Opacity$	 0.5Q���  �@��Stretch$
 Fill=��� "
 ��8   .���  � ��$	 144��.+��� -   $ 
btnAccount��$��Right=� �� 	IsEnabled .   � ContextMenu ��  �� 	Placement$ Bottom=� �� HorizontalOffset$	 -28�� �� VerticalOffset$	 -27��.@�m� -     strComOperator#���   m� 	IsChecked �� *	IsAdmin+ �� Mode$ OneWay=�  
covInverse �� 	Converter# [ m� -     strComAdministrator#���   �� *	IsAdmin+$ OneWay=�.����  �� Orientation$ 
Horizontal=�.+�F�   
geoAccount#��[ 
�������F�   geoTriangle#��[ 
�������$��Center=�$��30,0,0,0q��� $��Right=��� -   $��Right=� .   �� $ Bottom=�$	 -28��$	 -27��.@�m� -   $��繁體中文��
 � Tag$ zh-TW�� �� *CurrentLanguage+ �� Source# [    covStringValue# [   �� ConverterParameter$  zh-TW��$ OneWay=�m� -	   $��English��$ en-US�� �� *CurrentLanguage+# [  # [ $  en-US��$ OneWay=�.���� $ 
Horizontal=�.+�F�   geoLanguage#��[ 
�������F� #��[ 
�������$��Center=�$��30,0,0,0q��� $��Right=��� -
   $ btnFullScreen��$��Right=�.��F� -   ! F�Name$! iconFullScreen��  geoFullscreen#��[ 
��������� $��Right=�� $��1�� �� $
��Auto ��� " � ColumnDefinitions" �� -   # ��Name$# 
columnNavi��$	��200 ��� .+��� $��2��$ 2��  
brushWhite#��[ $ J� Effect$ 3  -System.Windows.Media.Effects.DropShadowEffect  %   ShadowDepth$% 4Q�&   
BlurRadius$& 5Q�'   Color$' Black��(   Opacity$	( 0.2Q�)   	Direction$) 0Q��� $��2��$ 2��#��[  +   %Recycle.UserControls.NavigationButton  boolIconOnly+   %Recycle.UserControls.NavigationButton*   Checked��%Y   '        7 �� "
  8   .���  �@ IconOnly# �  ;� * NaviButton_Checked.+��� -   + ��Name$+ labRealTimeStatus��$��40��$��16(�  strNaviRealTimeStatus#���  $��Center=�$��Center=�  -   ,  Name$, btnHome��  strNaviHome#���    geoHome-   PathData#- [ . d� 	IsChecked$
. TrueY�$
 HOME��    strNaviTasks#���    geoSink#- [ $
 TASK��    strNaviStatus#���    	geoStatus#- [ $ STATUS��    strNaviAdjust#���     	geoAdjust#- [  $ ADJUST��   ! 
strNaviLog#��� !  
" geoLog#- [" $	 LOG��� $��1�� �� $��40 ��� $��88 �.+��� / �� CornerRadius$/ 12��$	��8,4q�#��[ y��� 0 �� ElementName$0 itemsStatus��1 �� Path$1 Items.Count�# [ ._��� #��[  # strComAllGood#��� # �� -   2 ��Name$2 itemsStatus��$	��0,4q�#��[ ���� *RobotsStatus+���� .R�A� 3 A� Rows$3 1���� $��1��4 �� Padding$4 40,0,0,0q� �� *CurrentContent+._��� $ 
Horizontal=�$��Center=�.+�F� 
���   �5 �� Stretch$5 Uniform=�$��40��$��40������ *
PathData+�� $��Center=�$��24,0,0,0q�$��40(�$
��Bold"�$	��120������ *Name+$ OneWay=��� $��Bottom=�$��24,0,0,0q�$��16(����� *Description+$ OneWay=��� $��1��$��1������ *CurrentContent+ 6 �� DataType*   $Recycle.ViewModels.HomePageViewModel   Recycle.Views.HomePage*   $Recycle.ViewModels.TaskPageViewModel   Recycle.Views.TaskPage,	   &Recycle.ViewModels.StatusPageViewModel
   Recycle.Views.StatusPage,   &Recycle.ViewModels.AdjustPageViewModel   Recycle.Views.AdjustPage)   #Recycle.ViewModels.LogPageViewModel   Recycle.Views.LogPage��%�   (��       *, +)(��      *, +)(�� $     *,	 +)(�� 6     *, +)(�� H     *, +)�� "6  .R�  �� "6  .R�  �� "6 	 .R�
  �� "6  .R�  �� "6  .R�  �� -   7 ��Name$7 popup��$��1��8 J� IsHitTestVisible8 .  $ 10��9 J� Opacity$9 0Q����� : �� 
TargetType": ��.R�� .+��� ; ��Name$; popup�����	#80000000$��0q�$4 0,0,0,40q�< J� InputBindings< d� = d� MouseAction$= 	LeftClicke�> �� CommandParameter$> 	hidepopup��? �� Command? �� $0 
mainWindow���� $��Center=�$��Center=�