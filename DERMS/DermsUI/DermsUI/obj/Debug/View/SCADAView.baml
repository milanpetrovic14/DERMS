   M S B A M L   `   `   `  ����B  >DermsUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DermsUI.ViewDermsUI.View  5      5clr-namespace:DermsUI.ViewModelDermsUI.ViewModel  5          DermsUI.View.SCADAView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:DermsUI.View     5      5	ViewModelclr-namespace:DermsUI.ViewModel     5        � DataContext  5      &    DermsUI.ViewModel.SCADAViewModel  5   
   6%   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgPoints��5         SelectionMode$ Single=�5   2      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     SelectionUnit$ FullRow=�5      ���#b6b3af��5      �� *Points+ �� SelectedItem 5      �� *SelectedDataItem+	 J� InputBindings	 5      d� 5      
 d� MouseAction$
 LeftDoubleClicke�6    �� Command 6=   �� *SelectedPointCommand+ �� CommandParameter 6f   �� *Points+6�      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property �@J�IsHitTestVisible �� Value . 69    �� Triggers 5       �� 5!       �� Binding 6&   �� *Alarm+ �� Value REASONABILITY_FAILURE6@   .a�5"      ��  � �� �#ff99666;   5#      �� 5$       6&   �� *Alarm+ NO_ALARM6@   .a�5%      ��  � �� �#b6b3af6;   5&      �� 5'       6&   �� *Alarm+ 	LOW_ALARM6@   .a�5(      ��  � �� �#ff33006;   5)      �� 5*       6&   �� *Alarm+ 
HIGH_ALARM6@   .a�5+      ��  � �� �#cc00006;   5,      �� 5-       6&   �� *Alarm+ ABNORMAL_VALUE6@   .a�5.      ��  � �� �#ff33cc6;   5/      51         Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6^     56      $
 Type��6%    . $ * 6^    63   �� *Type+6^     57      $ Address��6%    . $ * 6{    66   �� *	Address+ �� StringFormat$ {0:d5}��6{     58      $ Value��6%    . $ * 6`    64   �� *Value+6`     59      $ 	Raw Value��6%    . $ * 6g    68   �� *
RawValue+6g     5:      $ 	Timestamp��6%    . $ * 6h    68   �� *	Timestamp+6h     5;      $ Alarm��6%    . $ * 6`    64   �� *Alarm+6`     5<      $	 Gid��6%    . $ * 6\    62   �� *Gid+6\   5>      �� 5@   
   $��2��6   $��2��6!   .@�5A      �� .��5B      ��  J� Opacity$	 0.9Q�6   ._�5C      ��  �� Orientation$ 
Horizontal=�6!   .+�5D      �� $��
HIGH ALARM��6    $
��Bold"�65   5F      5G      5H      �� 5I      .��5J      �� ���#cc0000$	 0.9Q�6/   ._�5K      �� $ 
Horizontal=�6!   .+�5L      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5N      5O      5P      �� 5Q      .��5R      �� $	 0.9Q�6   ._�5S      �� $ 
Horizontal=�6!   .+�5T      �� $��|��6    $
��Bold"�6,   5V      5W      5X      �� 5Z      .��5[      �� $	 0.9Q�6   ._�5\      �� $ 
Horizontal=�6!   .+�5]      �� $��	LOW ALARM��6    $
��Bold"�64   5_      5`      5a      �� 5b      .��5c      �� ���#ff3300$	 0.9Q�6/   ._�5d      �� $ 
Horizontal=�6!   .+�5e      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5g      5h      5i      �� 5j      .��5k      �� $	 0.9Q�6   ._�5l      �� $ 
Horizontal=�6!   .+�5m      �� $��|��6    $
��Bold"�6,   5o      5p      5q      �� 5s      .��5t      �� $	 0.9Q�6   ._�5u      �� $ 
Horizontal=�6!   .+�5v      �� $��ABNORMAL VALUE��6    $
��Bold"�69   5x      5y      5z      �� 5{      .��5|      �� ���#ff33cc$	 0.9Q�6/   ._�5}      �� $ 
Horizontal=�6!   .+�5~      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5�      5�      5�      �� 5�      .��5�      �� $	 0.9Q�6   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��|��6    $
��Bold"�6,   5�      5�      5�      �� 5�      .��5�      �� $	 0.9Q�6   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��REASONABILITY FAILURE��6    $
��Bold"�6@   5�      5�      5�      �� 5�      .��5�      �� ���#ff9966$	 0.9Q�6/   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5�      5�      5�      �� 5�      .��5�      �� $	 0.9Q�6   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��|��6    $
��Bold"�6,   5�      5�      5�      �� 5�      .��5�      �� $	 0.9Q�6   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��NO ALARM��6    $
��Bold"�63   5�      5�      5�      �� 5�      .��5�      �� ���#b6b3af$	 0.9Q�6/   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $�� ��6    $
��Bold"�6+   $��20��6G   $��20��6R   5�      5�      5�      5�      5�      5�      