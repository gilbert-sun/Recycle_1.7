   M S B A M L   `   `   `  ����B  >Recycle, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Recycle.ViewModelsRecycle.ViewModels  5   	   -clr-namespace:Recycle.ViewsRecycle.Views  5   	   ;"clr-namespace:Recycle.UserControlsRecycle.UserControls  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	   7 clr-namespace:Recycle.ConvertersRecycle.Converters  5
   	       Recycle.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /vm clr-namespace:Recycle.ViewModels     5   	   ,viewclr-namespace:Recycle.Views     5   	   3ctrl"clr-namespace:Recycle.UserControls     5   	   6sys&clr-namespace:System;assembly=mscorlib     5	   	   0cov clr-namespace:Recycle.Converters     5
   	   -   5          �Name$  
mainWindow��5   	      mainViewModel � DataContext# [  5   	    � Title$ Recycle��5   	    
 Roboto#��[ 5   	    � WindowState$ 	Maximized=�5   	   $	��600��5   	   $	��800��5   	   $
��1024��5   	   $
��1280��5   	    � Icon$ Images/Desk Logo.ico��5   	    � 	Resources 5      '   !Recycle.Converters.CountConverter  covCountInverse   Inverse  storyShowPopup	 W� To g� Duration	 �� TargetProperty  storyHidePopup  styleStatusText
 �� 
TargetType �� Property �� Value  
tempStatus ��Name  styleRoundButton  brushLightGreen �� Triggers �� Value �� Binding �� 
TargetName 	 
brushError 
 brushWarning��%�  &	       &	      &	 �     &	 �     &	 �    7  7  7  7 	 7 
   5   
    . 65   �� 5   
   .��5      W� $ 1X�6   $ 
00:00:00.2D�5      $	 Opacity�5      5      �� 5   
   -   5        .��5       W� $ 0X�6   $ 
00:00:00.2D�5!      $	 Opacity�5"      5#      �� 5$   
   "
 ��6(   .�5%      ��  � ��$ 20(�6)   �� 5&       � ��$ Center=�62   �� 5'       � ��$ Center=�64   �� 5(       � ��
 �����6+   5)      �� 5*   
   .R�5+      �� $ button��6   -   5        8��  $	��8,0q�5-      8�� .��50      �� 8�� ��6E   �� 51       52      �� 53      $ ERROR��69    6   �� *Status+.a�54      �� $ button��6   8   � ��6G   55      �� 56      $ WARNING��69    6   �� *Status+.a�57      �� $ button��6   8   � ��6G   58      5:      5;      .��5<      �   	brushGray#��[ 6    � RowDefinitions 5=   
   �� 5>      $��80 �6   �� 5?      .+�5B   
   ]�  K� ZIndex$ 3��6     brushPrimary#��[ 5C      ��.   5E        styleHeaderButton �� BasedOn��%z  '��       '��     7  �� 5F      "
 ��6   .�5G      ��  � ��$ 1��6.   �� 5H      
 �@��Y1$ 0��6+   �� 5I      
 �@��Y2$ 1��6+   �� 5J       � ��
 �����6/   �� 5K       �@J�Opacity$	 0.5Q�60   �� 5L       �@��Stretch$
 Fill=�60   5M      �� 5N      "
 ��6   8   .�5O      ��  � ��$	 144��6.   5P      5Q      .+�5S      �� -   5        $ 
btnAccount��5S      $��Right=�5T       �� 	IsEnabled .   � ContextMenu 5W      �� 5X       �� 	Placement$ Bottom=�6"    �� HorizontalOffset$	 -28��5Y   "    �� VerticalOffset$	 -27��5Z   "   .@�5[      m� -   5          strComOperator#���  5[   #    m� 	IsChecked 5]   #   �� *	IsAdmin+ �� Mode$ OneWay=�  
covInverse �� 	Converter# [ m� 5^      -   5          strComAdministrator#���  5^   #    5`   #   �� *	IsAdmin+$ OneWay=�5a      .��5c      ��  �� Orientation$ 
Horizontal=�6   .+�5d      F�   
geoAccount#��[ 6   
�������6>   F� 5e        geoTriangle#��[ 6   
�������$��Center=�6L   $��30,0,0,0q�6g   5f      5g      �� 5h      $��Right=�6   �� 5j      -   5        $��Right=�5j       .   5m      �� 5n      $ Bottom=�6"   $	 -28��5o   "   $	 -27��5p   "   .@�5q      m� -   5        $��繁體中文��5q   #   
 � Tag$ zh-TW��5r   #    5s   #   �� *CurrentLanguage+ �� Source# [    covStringValue# [   �� ConverterParameter$  zh-TW��$ OneWay=�5t   #   m� 5u      -	   5        $��English��5u   #   $ en-US��5v   #    5w   #   �� *CurrentLanguage+# [  # [ $  en-US��$ OneWay=�5x   #   5y      .��5{      �� $ 
Horizontal=�6   .+�5|      F�   geoLanguage#��[ 6   
�������6?   F� 5}      #��[ 6   
�������$��Center=�6L   $��30,0,0,0q�6g   5~      5      �� 5�      $��Right=�6   �� 5�      -
   5        $ btnFullScreen��5�      $��Right=�6,   .��5�      F� -   5        ! F�Name$! iconFullScreen��5�        geoFullscreen#��[ 6/   
�������6U   5�      �� 5�      $��Right=�6   5�      � 5�   
   $��1��6    5�      �� 5�      $
��Auto �6    �� 5�      " � ColumnDefinitions" 5�      �� 5�      -   5        # ��Name$# 
columnNavi��5�   #   $	��200 �67   �� 5�      .+�5�      �� $��2��6   $ 2��5�        
brushWhite#��[ 5�      $ J� Effect$ 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�      %   ShadowDepth$% 4Q�6'   &   
BlurRadius$& 5Q�67   '   Color$' Black��6F   (   Opacity$	( 0.2Q�6T   )   	Direction$) 0Q�6b   5�      �� 5�      $��2��6   $ 2��5�      #��[ 5�       5�      +   %Recycle.UserControls.NavigationButton  boolIconOnly+   %Recycle.UserControls.NavigationButton*   Checked��%�   '        7 �� 5�      "
  6   8   .�5�      ��  �@ IconOnly# �  65   ;� 5�   6   * NaviButton_Checked5�      5�      .+�5�      �� -   5        + ��Name$+ labRealTimeStatus��5�      $��40��5�      $��16(�5�        strNaviRealTimeStatus#���  5�      $��Center=�5�      $��Center=�5�        5�      -   5        ,  Name$, btnHome��5�   (     strNaviHome#���  69     geoHome-   PathData#- [ 6a   . d� 	IsChecked$
. TrueY�6�   $
 HOME��6�     5�        strNaviTasks#���  6(     geoSink#- [ 6Q   $
 TASK��6u     5�        strNaviStatus#���  6(     	geoStatus#- [ 6R   $ STATUS��6x     5�        strNaviAdjust#���  6(      	geoAdjust#- [  6R   $ ADJUST��6x     5�       ! 
strNaviLog#��� ! 6(    
" geoLog#- [" 6O   $	 LOG��6r   5�      � 5�      $��1��6    5�      �� 5�      $��40 �6$   �� 5�      $��88 �6$   .+�5�      �� / �� CornerRadius$/ 12��5�      $	��8,4q�5�      #��[ 5�      y�5�      �� 0 �� ElementName$0 itemsStatus��1 �� Path$1 Items.Count�# [ ._�5�      �� #��[ 6     # strComAllGood#��� # 6I   5�      �� 5�      -   5        2 ��Name$2 itemsStatus��5�      $	��0,4q�5�      #��[ 5�      ��5�      �� *RobotsStatus+��5�      �� 5�      .R�5�      A� 3 A� Rows$3 1��6*   5�      5�      �� 5�      $��1��6   4 �� Padding$4 40,0,0,0q�6&    69   �� *CurrentContent+._�5�      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5�      F� 
���   �5 �� Stretch$5 Uniform=�6F   $��40��6X   $��40��6d   ��6   �� *
PathData+6d   �� 5�      $��Center=�6$   $��24,0,0,0q�5�   $   $��40(�5�   $   $
��Bold"�5�   $   $	��120��5�   $   ��5�   $   �� *Name+$ OneWay=��� 5�      $��Bottom=�6$   $��24,0,0,0q�5�   $   $��16(�5�   $   ��5�   $   �� *Description+$ OneWay=�5�      5�      5�      �� 5�      $��1��5�      $��1��5�      ��5�      �� *CurrentContent+ 5�      6 �� DataType*   $Recycle.ViewModels.HomePageViewModel   Recycle.Views.HomePage*   $Recycle.ViewModels.TaskPageViewModel   Recycle.Views.TaskPage,	   &Recycle.ViewModels.StatusPageViewModel
   Recycle.Views.StatusPage,   &Recycle.ViewModels.AdjustPageViewModel   Recycle.Views.AdjustPage)   #Recycle.ViewModels.LogPageViewModel   Recycle.Views.LogPage��%w  (��       5�   #   *, +)(�� 2     5�   #   *, +)(�� d     5�   #   *,	 +)(�� �     5�   #   *, +)(�� �     5�   #   *, +)�� 5�      "6  6#   .R�5�        5�      �� 5�      "6  6#   .R�5�        5�      �� 5�      "6 	 6#   .R�5�      
  5�      �� 5�      "6  6#   .R�5�        5�      �� 5�      "6  6#   .R�5�        5�      5�      5�      5�      �� 5�   
   -   5        7 ��Name$7 popup��5�      $��1��5�      8 J� IsHitTestVisible8 .  $ 10��5�      9 J� Opacity$9 0Q�5�      ��5�      �� 5�      : �� 
TargetType": ��6"   .R�5�      � .+�5�      �� ; ��Name$; popup��6!   ���	#80000000$��0q�5�   !   $4 0,0,0,40q�5�   !   < J� InputBindings< 5�      d� 5�   "   = d� MouseAction$= 	LeftClicke�6/   > �� CommandParameter$> 	hidepopup��5�   /   ? �� Command? 5�   /   �� $0 
mainWindow��5�   /   5�      �� 5�      $��Center=�6+   $��Center=�5�   +   5�      5�      5      5     5     