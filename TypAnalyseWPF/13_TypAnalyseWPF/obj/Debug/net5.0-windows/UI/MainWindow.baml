   M S B A M L   `   `   `  ����H  DTypAnalyseWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TypAnalyseWPFTypAnalyseWPF  5   	       TypAnalyseWPF.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TypAnalyseWPF     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)    � 	Resources 5	      !   TypAnalyseWPF.MainViewModel   mvmodel��%   &	          5
   
   6   5      .��5      �  � DataContext# [  6   .+�5   
   �� $��Klasse auswählen��6   $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   �� 5   
   -   5         ��Name$ cbClass��5      $
��Left=�6f   $��	10,41,0,0q�6�   $	��Top=�6�   $	��175��6�   ��6$   �� *
LstTypes+ �� SelectedItem 6E   �� *	SelType+6�   �� 5   
   $��C# Klassenname eingeben��6   $
��Left=�62   $��	10,81,0,0q�6M   $	��Top=�6`   �� 5   
   -   5         ��Name$ tbClass��5      $
��Left=�6#   $��
10,112,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $
��Auto��6f   $	��Top=�6r   $	��175��6�   �� 5   
   -   5         ��Name$ btSearch��5      $��
Los Geht's��6#   $
��Left=�68   $��218,111,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   $��Optionen��6   $
��Left=�6#   $��10,0,0,0q�6>   $��Center=�6P   �� 5   
   -   5         ��Name$ 	cbVererbt��5      $&�� Vererbte Elemente nicht anzeigen��6M   $
��Left=�6x   $��
34,310,0,0q�6�   $	��Top=�6�   	 d� 	IsChecked	 6&   �� *VererbungChecked+6�   �� 5   
   -   5        $ 
cbStatisch��5      $'��!Statische Elemente nicht anzeigen��6K   $
��Left=�6w   $��
34,340,0,0q�6�   $	��Top=�6�   	 6'   �� *StaticChecked+6�   �� 5   
   -   5        $ 	cbSpecial��5      $1��+Elemente mit 'special names' nicht anzeigen��6O   $
��Left=�6�   $��
34,371,0,0q�6�   $	��Top=�6�   	 6&   �� *SpecialNameChecked+6�   �� 5   
   $��Attribute (Fields):��6   $
��Left=�6.   $��
400,10,0,0q�6I   $	��Top=�6]   �� 5   
   -   5        
 ��Name$
 	lstFields��5      $��400,41,10,433q�6G   ��6%   �� *	LstFields+6G   �� 5   
   $��Properties:��6   $
��Left=�6&   $��400,156,0,0q�6A   $	��Top=�6V   �� 5   
   -   5        $
 lstProperties��5      $��400,187,10,287q�6O   ��6)   �� *LstProperties+6O   �� 5   
   $��Konstruktoren:��6   $
��Left=�6)   $��400,302,0,0q�6D   $	��Top=�6Y   �� 5   
   -	   5        $
 lstConstructors��5      $��400,333,10,176q�6S   ��6+   �� *LstConstructors+6S   �� 5   
   $��	Methoden:��6   $
��Left=�6$   $��400,413,0,0q�6?   $	��Top=�6T   �� 5   
   -
   5        $
 
lstMethods��5      $��400,444,10,30q�6I   ��6&   �� *
LstMethods+6I   5      5      