   M S B A M L   `   `   `  ����M  ISimpleFileExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SimpleFileExplorer.ModelSimpleFileExplorer.Model  5   	   #    SimpleFileExplorer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8Model&clr-namespace:SimpleFileExplorer.Model     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Simple File Explorer��5	   	    � WindowState$ 	Maximized=�5
      $	��500��6    $	��800��6-   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $��10 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   �� $��1��6   $��1��6$    �� ResizeDirection$ Columns=�64   $��5��6N   $��Stretch=�5      $y�Hidden=�68   #  MaterialDesignThemes.Wpf.Card  5   
   $��16q�6   $��16q�6+   $��0��67   $��2��6D   $��2��6T   $
��Auto��6h   $
��Auto��6v   .��5      ��  �� Orientation$ 
Horizontal=�6   $��10,15,10,10q�62   .+�5      �� -   5        $��Refresh��5   8       MaterialDesignOutlinedButton#��[  5       � ToolTip$" MaterialDesignOutlinedButton��5      $	��100��6G   $��Refresh��6S   $��10,0,0,0q�6f   6x   �� 5       -   5        $��BackOneLevel��5    O   #��[  6   $	��100��6c   $��Go Back��6o   $��	10,0,40,0q�6�   6�   �� 5"      -   5        $
��Path��5"       % !MaterialDesignFloatingHintTextBox#��[ 6'   $��16(�6b   ��5#   %   �� *Text+ �� Mode$ TwoWay=�.��6I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5$      �� 5%      $��0,0,40,0q�6%   $ 
Horizontal=�67   .+�5&      �� �� 6)   $
�Path��6-   6=   5'      .��5(   6   5)      5*      5+        5,   
   $��32q�6   $��16q�6+   $��0��67   $��0��6G   $��2��6T   $
��Auto��6e   .��5-      R� -   5        $
��Tree��5-      ��. $��10,0,0,0q�6I   	 � 	Resources	 5/      #   SimpleFileExplorer.Model.Root
 �� 
TargetType �� Property �� Value �� RelativeSource �� Mode �� AncestorType �� Path��%s  '        �� 50      "
  6   .�51      ��  � �� 52      �� 53   "   .R�54   &   �� $ 
Horizontal=�61   .+�55   *   �� $��image��60   $��30��6>   $��30��6I   $
��Fill=�6U   ��56   0   ��  �� $ FindAncestor=�" Q�$ 
SystemIcon��� 5;   *   $
��Text��64   $	��5,0q�6Q   ��6@   �� 6Q   5<   '   5=   #   5?      5@      5A      5B      5C        5D   
   $��32q�6   $��16q�6+   $��2��67   $��1��6G   $
��Auto��6T   .��5E      �� -   5        $
��test��5E      ��. ��5F      �� 5G      "
 ��6   .�5H      -   5        5I      ��5K      �� 5L      .R�5M      �� $
��Left=�6    
������ $��1q�6l    � DataContext 6T   �� ��5N      �� 5O   "   $ 
Horizontal=�6-   .+�5X   &   �� $ 
Horizontal=�61   $	��150��6J   .+�5Y   *   �� $��50��62   $��50��6=   $
��Fill=�5[   -   ��5Z   -   �� $ 
SystemIcon�$ OneTime=�5[   -   �� 5]   *    ��Name$ FriendlyName��64   $��Center=�5^   Q   $
��Left=�6l   ��62   �� *FriendlyName+6l   5_   '   �� 5a   &    ��Name$ Details��5c   '   $��Center=�5b   '   $
��Left=�6B   $��50,0,0,0q�5c   8   .+�5e   *   �� $ FileType��64   ��5f   2   �� *
FileType+�� 5g   *   $
 Size��64   $
��Left=�5h   2   ��5i   2   �� *Size+�� 5j   *   $
 text��64   $
��Left=�5k   2   $��Last Updated��5l   2   �� 5m   *   $ LastWriteTime��64   $
��Left=�5n   2   ��5o   2   �� *LastWriteTime+5p   '   5q   #    5s      _� 5t   "   $��FileInfo��6*    _� 	Placement$ Mouse=�6:   .��5u   &   �� ��60   �� *
FileName+5v   #   5x       �� Triggers 5y      �� 5z       �� Value$
 True��6�    �� Binding 6*   ��  �� $ FindAncestor=�" ��$ 
IsSelected�.a�5{   "   ��  �� 
TargetName$ FileType��6?    � ��
 ��  �6e   �� 5|   "   $ LastWriteTime��6?    � ��
 ��  �6j   �� 5}   "   $
 text��6?    � ��$
 Bold"�6Q   6a   5~      5�      5�      5�      �� 5�   
   $��Bottom=�6   $��2��6/   $��2��6<   
������ $��	40,0,0,10q�6e   .@�5�      ]� ��6   �� *ActualWidth+ �� *FindAncestor+" ��.+�5�      �� -   5        $��StatisticsArea��5�   2   $
��Left=�6   $��Center=�6H   $��40��6c   5�      5�      5�      5�      