   M S B A M L   `   `   `  ����C  ?Projecte, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projecte.VistesProjecte.Vistes  5      &     Projecte.Vistes.pageGestioTicket   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Projecte.Vistes     5        N� Title$  pageGestioTicket��5	       N� 
Background
 �����.��5      � $��20q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��2* �6   6,   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��1.5* �6   6,   .+�5   
   �� $��0��6   $��0��6!    �� Padding$ 10q�61   	Client:6G   �� 5   
   $��1��6   $��0��6!   $ 10q�61   
Vehicle:6H   �� 5   
   $��2��6   $��0��6!   $ 10q�61   Observacions:6M   �� 5   
   $��3��6   $��0��6!   $ 10q�61   Estat:6F   �� 5    
   $��4��6   $��0��6!   $ 10q�61   Preu final:6K   �� 5"   
   -   5         ��Name$ 
cboClients��5"      $��0��6'   $��1��64   $��15q�6D   6�   �� 5#   
   -   5        $ cboVehicles��5#      $��1��6(   $��1��65   $��15q�6E   6S   �� 5$   
   -   5         ��Name$ txbObservacions��5$      $��2��6+   $��1��68   $��5q�6H   6U   �� 5%   
   -   5        $ 	cboEstats��5%      $��3��6&   $��1��63   $��15q�6C   6Q   �� 5&   
   -   5        $ txbPreuFinal��5&      $��4��6(   $��1��65   $��15q�6E   6S   �� 5(   
   -   5         ��Name$ 	btnCancel��5(      $��6��6$   $��0��61   $��10q�6A   .��6e   Cancel·lar canvis6x   �� 5)   
   -   5        $ btnDesarCanvis��5)      $��6��6)   $��1��66   $��10q�6F   $��2��6R   .��6�   Desar canvis6�   �� 5*   
   -   5        $ btnAfegirNouTicket��5*      $��6��6-   $��1��6:   $��10q�6J   $��2��6V   .��6�   Afegir nou ticket6�   �� 5+   
   -	   5        $ btnEsborrarTicket��5+      $��6��6,   $��3��69   $��10q�6I   
���r���.��6�   Esborrar el ticket6�   5,      5-      