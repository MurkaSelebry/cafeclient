   M S B A M L   `   `   `  ����
  diplom    diplom.AddOrderWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Новый заказ��5   	   $	��540��6   $	��600��6*    � WindowStartupLocation$ CenterOwner=�66   .��5      � $��16q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��Новый заказ��6   $��20(�6'   $
��Bold"�65   $��0,0,0,16q�6G   �� 5   
   $��1��6   .+�5      �� $,��&Информация о клиенте��6   $
��Bold"�64   ���#4CAF50$��0,0,0,8q�6[   �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,0,8q�62   .+�5      �� $��Клиент:��6   $��Center=�6*   �� 5      $	��200��66   $��0,0,8,0q�6B    �� 
IsReadOnly$
 True��6S   ��6   �� *
ClientName+6S   �� 5      $#��Выбрать клиента��6   $	��140��6[   ���#4CAF50
���������63   �� *SelectClientCommand+6|   5      �� 5      $��0,0,0,2q�65   ��6   �� *LoyaltyInfo+65   �� 5      $:��4Доступно баллов: {Binding BonusPoints}��6   $��0,0,0,8q�6F   �� 5      $!��Позиции заказа��6   $
��Bold"�6.   ���#4CAF50$��0,12,0,8q�6U   &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns$ False��6:   $	��180��6V   $��0,0,0,8q�6c   ��6   �� *
OrderItems+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6;   �� *Name+6T     5      $ Кол-во��6)   $ 60 6V   	 69   �� *
Quantity+6V     5      $ Цена��6)   $ 80 6Q   	 67   �� *Price+6Q     5      $ 
Сумма��6)   $ 80 6R   	 68   �� *Total+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Действия��6-   $ 80 6?   
   CellTemplate
 5      �� 5      .R�5   "   �� $��Удалить��6)   ��6;   �� *DataContext.RemoveItemCommand+ �� RelativeSource ��  �� AncestorType
 Window��6�   �� 5       5"      5$      �� 5%      $ 
Horizontal=�6   $��Right=�62   $��0,0,0,8q�6N   .+�5&      �� $��Итого:��6   $
��Bold"�6*   $��0,0,8,0q�6<   �� 5'      $
��Bold"�6D   ��6   �� *Total+ �� StringFormat$ F2��6D   5(      5)      �� 5*   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,16,0,0q�6W   .+�5+      �� $%��Добавить позицию��6   $	��140��60   $��0,0,8,0q�6<   ���#4CAF50
���������6M   �� *AddItemCommand+6�   �� 5,      $��Оплатить��6   $	��120��6(   $��0,0,8,0q�64   ���#FFEB3B��6E   �� *
PayCommand+6d   �� 5-      $��Отмена��6   $	��100��6&   ��62   �� *CancelCommand+5.      5/      50      