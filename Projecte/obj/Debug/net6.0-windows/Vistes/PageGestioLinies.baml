   M S B A M L   `   `   `  ����C  ?Projecte, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projecte.VistesProjecte.Vistes  5      &     Projecte.Vistes.PageGestioLinies   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Projecte.Vistes     5        N� Title$  PageGestioLinies��5	       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��0.75* �6   6/   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��0��6!    �� Padding$ 10q�61   	Servei:6G   �� 5   
   $��1��6   $��0��6!   $ 10q�61   Descripció:6K   �� 5    
   $��2��6   $��0��6!   $ 10q�61   Estat:6F   �� 5!   
   $��3��6   $��0��6!   $ 10q�61   Descompte (en %):6Q   �� 5"   
   $��4��6   $��0��6!   $ 10q�61   Preu:6E   �� 5#   
   $��0��6   $��3��6!   $ 10q�61   Pack:6F   �� 5%   
   -   5         ��Name$ 
cboServeis��5%      $��0��6'   $��1��64   $��15q�6D   6R   �� 5&   
   -   5         ��Name$ txbDescripcio��5&      $��1��6)   $��1��66   $��5q�6F   6S   �� 5'   
   -   5        $ 	cboEstats��5'      $��2��6&   $��1��63   $��15q�6C   6Q   �� 5(   
   -   5        $ txbDescompte��5(      $��3��6(   $��1��65   $��15q�6E   6S   �� 5)   
   -   5        $ txbPreu��5)      $��4��6#   $��1��60   $��15q�6@   6N   �� 5*   
   -   5        $ cboPack��5*      $��0��6$   $��4��61   $��15q�6A   6O   �� 5,   
   -   5         ��Name$ 	btnCancel��5,      $��6��6$   $��0��61   $��10q�6A   .��6e   Cancel·lar canvis6x   �� 5-   
   -   5        $ btnDesarCanvis��5-      $��6��6)   $��1��66   $��10q�6F   $��2��6R   .��6�   Desar canvis6�   �� 5.   
   -	   5        $ btnAfegirNouTicket��5.      $��6��6-   $��1��6:   $��10q�6J   $��3��6V   .��6�   Afegir nova linia6�   �� 5/   
   -
   5        $ btnEsborrarTicket��5/      $��6��6,   $��4��69   $��10q�6I   
���r���.��6�   Esborrar la linia6�   50      51      