   M S B A M L   `   `   `  ���� 
  diplom    diplom.SelectClientWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$#  Выбрать клиента��$	��400��$	��500�� � WindowStartupLocation$ CenterOwner=�.��� $��16q� � RowDefinitions �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -     Name$ ClientsDataGrid��   AutoGenerateColumns$ False������ *	Clients+ �� SelectedItem �� *SelectedClient+ �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Id+  $ Имя��$	 * 
 �� *	FirstName+  $ Фамилия��$	 * 
 �� *
LastName+  $ Телефон��$		 100 
 �� *Phone+�� $��1�� �� Orientation$ 
Horizontal=�$��Right=�$��0,16,0,0q�.+��� $��Выбрать��$	��100��$��0,0,8,0q����� *SelectCommand+�� $��Отмена��$	��100������ *CancelCommand+