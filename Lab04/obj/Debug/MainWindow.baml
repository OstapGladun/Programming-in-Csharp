   M S B A M L   `   `   `  ����@  <Lab04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab04Lab04  5   	       Lab04.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab04     5   	     � Title$  Main window��5   	   $	��600��6   $	��900��6*   .��5	      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6�   ��6#   �� *People+ �� SelectedItem 6B   �� *SelectedPerson+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	FirstName+  5      $ Surname��6%    66   �� *
LastName+  5      $ Email��6%    64   �� *Email+  5      $ Date of birth��6%    6<   �� *	BirthDate+	 �� StringFormat$	 d��4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 	Is adult?��6)    6<   �� *	IsAdult+
 �� Mode$
 OneWay=�  5      $ Western sign��6%    6;   �� *	SunSign+$
 OneWay=�  5      $ Chinese sign��6%    6;   �� *ChineseSign+$
 OneWay=�  5      $ Birthday today?��6)    6B   �� *
IsBirthday+$
 OneWay=�5      �� 5   
   $��1��6    �� Orientation$ Vertical=�6%   $
��Left=�6<   .+�5      �� $	��100��6   $��5q�6$   $��Filters:��6/   $��15(�6?   �� 5      $	��100��6   $��5q�6"   ��6-   �� *
NameFilter+�� 5       $	��100��6   $��5q�6"   ��6-   �� *SurnameFilter+�� 5!      $	��100��6   $��5q�6"   ��6-   �� *EmailFilter+(  "System.Windows.Controls.DatePicker  5"      $	��100��6o   $��Center=�6{      SelectedDate 6   �� *
DateFilter+$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6{   �� 5#      $��Is adult��6   $��5q�6*    d� 	IsChecked 65   �� *IsAdultFilter+�� 5$      $	��100��6   $��5q�6"   ��6-   �� *SunSignFilter+�� 5%      $	��100��6   $��5q�6"   ��6-   �� *ChineseSignFilter+�� 5&      $��Is birthday��6   $��5q�6-    68   �� *IsBirthdayFilter+�� 5'      $��Apply��6   $	��100��6%   $��5q�61   ��6<   �� *FilterCommand+�� 5(      $��Reset��6   $	��100��6%   $��5q�61   ��6<   �� *ResetCommand+�� 5*      $	��100��6   $��5q�6$   $��Operations:��6/   $��15(�6B   �� 5+      $	��Add��6   $	��100��6#   $��5q�6/   ��6:   �� *
AddCommand+�� 5,      $
��Edit��6   $	��100��6$   $��5q�60   ��6;   �� *EditCommand+�� 5-      $��Delete��6   $	��100��6&   $��5q�62   ��6=   �� *DeleteCommand+5.      5/      50      