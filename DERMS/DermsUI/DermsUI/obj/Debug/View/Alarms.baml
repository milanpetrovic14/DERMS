   M S B A M L   `   `   `  ����B  >DermsUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DermsUI.ViewDermsUI.View  5      5clr-namespace:DermsUI.ViewModelDermsUI.ViewModel  5          DermsUI.View.Alarms   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:DermsUI.View     5      5	ViewModelclr-namespace:DermsUI.ViewModel     5        � DataContext  5      '   !DermsUI.ViewModel.AlarmsViewModel  5   
   6&   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgPoints��5         SelectionMode$ Single=�5   2      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     SelectionUnit$ FullRow=�5      ���#b6b3af��5      �� *Points+ �� SelectedItem 5      �� *SelectedDataItem+	 J� InputBindings	 5      d� 5      
 d� MouseAction$
 LeftDoubleClicke�6    �� Command 6=   �� *SelectedPointCommand+ �� CommandParameter 6f   �� *Points+6�      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property �@J�IsHitTestVisible �� Value . 69    �� Triggers 5       �� 5!       �� Binding 6&   �� *Alarm+ �� Value REASONABILITY_FAILURE6@   .a�5"      ��  � �� �#ff99666;   5#      �� 5$       6&   �� *Alarm+ 	LOW_ALARM6@   .a�5%      ��  � �� �#ff33006;   5&      �� 5'       6&   �� *Alarm+ 
HIGH_ALARM6@   .a�5(      ��  � �� �#cc00006;   5)      �� 5*       6&   �� *Alarm+ ABNORMAL_VALUE6@   .a�5+      ��  � �� �#ff33cc6;   5,      5.         Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6^     53      $
 Type��6%    . $ * 6^    63   �� *Type+6^     54      $ Address��6%    . $ * 6{    66   �� *	Address+ �� StringFormat$ {0:d5}��6{     55      $ Value��6%    . $ * 6`    64   �� *Value+6`     56      $ 	Raw Value��6%    . $ * 6g    68   �� *
RawValue+6g     57      $ 	Timestamp��6%    . $ * 6h    68   �� *	Timestamp+6h     58      $ Alarm��6%    . $ * 6`    64   �� *Alarm+6`     59      $	 Gid��6%    . $ * 6\    62   �� *Gid+6\   5;      �� 5=   
   $��2��6   $��2��6!   .@�5>      �� .��5?      ��  J� Opacity$	 0.9Q�6   ._�5@      ��  �� Orientation$ 
Horizontal=�6!   .+�5A      �� $��
HIGH ALARM��6    $
��Bold"�65   5C      5D      5E      �� 5F      .��5G      �� ���#cc0000$	 0.9Q�6/   ._�5H      �� $ 
Horizontal=�6!   .+�5I      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5K      5L      5M      �� 5N      .��5O      �� $	 0.9Q�6   ._�5P      �� $ 
Horizontal=�6!   .+�5Q      �� $��|��6    $
��Bold"�6,   5S      5T      5U      �� 5W      .��5X      �� $	 0.9Q�6   ._�5Y      �� $ 
Horizontal=�6!   .+�5Z      �� $��	LOW ALARM��6    $
��Bold"�64   5\      5]      5^      �� 5_      .��5`      �� ���#ff3300$	 0.9Q�6/   ._�5a      �� $ 
Horizontal=�6!   .+�5b      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5d      5e      5f      �� 5g      .��5h      �� $	 0.9Q�6   ._�5i      �� $ 
Horizontal=�6!   .+�5j      �� $��|��6    $
��Bold"�6,   5l      5m      5n      �� 5p      .��5q      �� $	 0.9Q�6   ._�5r      �� $ 
Horizontal=�6!   .+�5s      �� $��ABNORMAL VALUE��6    $
��Bold"�69   5u      5v      5w      �� 5x      .��5y      �� ���#ff33cc$	 0.9Q�6/   ._�5z      �� $ 
Horizontal=�6!   .+�5{      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5}      5~      5      �� 5�      .��5�      �� $	 0.9Q�6   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��|��6    $
��Bold"�6,   5�      5�      5�      �� 5�      .��5�      �� $	 0.9Q�6   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��REASONABILITY FAILURE��6    $
��Bold"�6@   5�      5�      5�      �� 5�      .��5�      �� ���#ff9966$	 0.9Q�6/   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5�      5�      5�      5�      5�      5�      