   M S B A M L   `   `   `  ����@  <Lab02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab02Lab02  5   	       Lab02.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab02     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��30q�6   $
��Left=�6!   .+�5      �� $��First name:��6   $��20(�6+   $	��250��69   $��40��6E    �� TextAlignment$
 Left=�6Q   �� 5      $	��150��6V   $��25��6b   $
��Left=�6n   ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6n   �� 5      $��
Last name:��6   $��20(�6*   $	��250��68   $��40��6D   $
 Left=�6P   �� 5      $	��150��6U   $��25��6a   $
��Left=�6m   ��6   �� *
LastName+$ PropertyChanged=�6m   �� 5      $��Email:��6   $��20(�6&   $	��250��64   $��40��6@   $
 Left=�6L   �� 5      $	��150��6R   $��25��6^   $
��Left=�6j   ��6   �� *Email+$ PropertyChanged=�6j   �� 5      $��Date of birth:��6   $��20(�6.   $	��250��6<   $��40��6H   $
 Left=�6T   (  "System.Windows.Controls.DatePicker  5      $	��150��6n   $��30��6z   $
��Left=�6�      SelectedDate 6   �� *	BirthDate+ �� Mode$ TwoWay=�$ PropertyChanged=�6�   �� 5      $��Proceed��6`   $	��150��6r   $��35��6~   $��18(�6�   $��0,30,0,0q�6�   $
��Left=�6�   ��6   �� *ProceedCommand+{�68   �� *IsProceedPossible+6�   5      �� 5   
   $��
0,30,30,30q�6   $��Right=�6)   .+�5      �� $��15(�67   $	��250��6E   $��40��6Q   $
 Left=�6]   ��6   �� *FirstNameText+6]   �� 5      $��15(�66   $	��250��6D   $��40��6P   $
 Left=�6\   ��6   �� *LastNameText+6\   �� 5      $��15(�63   $	��250��6A   $��40��6M   $
 Left=�6Y   ��6   �� *	EmailText+6Y   �� 5      $��15(�67   $	��250��6E   $��40��6Q   $
 Left=�6]   ��6   �� *BirthDateText+6]   �� 5      $��15(�65   $	��250��6C   $��40��6O   $
 Left=�6[   ��6   �� *IsAdultText+6[   �� 5       $��15(�65   $	��250��6C   $��40��6O   $
 Left=�6[   ��6   �� *SunSignText+6[   �� 5!      $��15(�69   $	��250��6G   $��40��6S   $
 Left=�6_   ��6   �� *ChineseSignText+6_   �� 5"      $��15(�68   $	��250��6F   $��40��6R   $
 Left=�6^   ��6   �� *IsBirthdayText+6^   5#      5$      5%      