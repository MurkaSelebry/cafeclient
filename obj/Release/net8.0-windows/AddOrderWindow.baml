   M S B A M L   `   `   `  ���� 
  diplom    diplom.AddOrderWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Новый заказ��$	��540��$	��600�� � WindowStartupLocation$ CenterOwner=�.��� $��16q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Новый заказ��$��20(�$
��Bold"�$��0,0,0,16q��� $��1��.+��� $,��&Информация о клиенте��$
��Bold"����#4CAF50$��0,0,0,8q���  �� Orientation$ 
Horizontal=�$��0,0,0,8q�.+��� $��Клиент:��$��Center=��� $	��200��$��0,0,8,0q� �� 
IsReadOnly$
 True������ *
ClientName+�� $#��Выбрать клиента��$	��140�����#4CAF50
����������� *SelectClientCommand+�� $��0,0,0,2q����� *LoyaltyInfo+�� $:��4Доступно баллов: {Binding BonusPoints}��$��0,0,0,8q��� $!��Позиции заказа��$
��Bold"����#4CAF50$��0,12,0,8q�&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��$	��180��$��0,0,0,8q����� *
OrderItems+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *Name+  $ Кол-во��$ 60 	 �� *
Quantity+  $ Цена��$ 80 	 �� *Price+  $ 
Сумма��$ 80 	 �� *Total+4  .System.Windows.Controls.DataGridTemplateColumn  $ Действия��$ 80 
   CellTemplate
 �� .R��� $��Удалить������ *DataContext.RemoveItemCommand+ �� RelativeSource ��  �� AncestorType
 Window���� �� $ 
Horizontal=�$��Right=�$��0,0,0,8q�.+��� $��Итого:��$
��Bold"�$��0,0,8,0q��� $
��Bold"����� *Total+ �� StringFormat$ F2���� $��2��$ 
Horizontal=�$��Right=�$��0,16,0,0q�.+��� $%��Добавить позицию��$	��140��$��0,0,8,0q����#4CAF50
����������� *AddItemCommand+�� $��Оплатить��$	��120��$��0,0,8,0q����#FFEB3B���� *
PayCommand+�� $��Отмена��$	��100������ *CancelCommand+