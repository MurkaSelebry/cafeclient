   M S B A M L   `   `   `  ����
  diplom.    (CafeClient.Presentation.Views.OrdersView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      
�������.��5      � .+�5   
   �� .+�5      �� $��Заказы��6   $��20(�6&   $
��Bold"�64   $��0,0,0,12q�6F   �� 5        �� Orientation$  
Horizontal=�6   $��0,0,0,12q�62   .+�5	      �� $	��220��6   $��28��6&   $��0,0,8,0q�62   $��Center=�6C   ��5
      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��
Поиск��6   $��28��6)   $��0,0,8,0q�6W   ��65   �� *SearchCommand+6W   �� 5      $!��Добавить заказ��6   $��28��62   ���#4CAF50
�������$
��16,0q�6f   ��5      �� *AddOrderCommand+5      &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns$ False��66   $	��300��6R   ��6   �� *Orders+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $ Клиент��6)   $ * 6V    69   �� *
ClientId+6V     5      $ Дата��6)   $	 120 6U    67   �� *	OrderDate+6U     5      $ 
Сумма��6)   $ 80 6X    68   �� *TotalAmount+6X     5      $ Статус��6)   $	 100 6T    69   �� *Status+6T   5      5      5      5      