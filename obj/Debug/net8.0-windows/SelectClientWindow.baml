   M S B A M L   `   `   `  ����
  diplom    diplom.SelectClientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Выбрать клиента��5   	   $	��400��6!   $	��500��6.    � WindowStartupLocation$ CenterOwner=�6:   .��5      � $��16q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ClientsDataGrid��5
         AutoGenerateColumns$ False��6�   ��6,   �� *	Clients+ �� SelectedItem 6L   �� *SelectedClient+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $ Имя��6%   $	 * 6P   
 62   �� *	FirstName+6P     5      $ Фамилия��6%   $	 * 6S   
 66   �� *
LastName+6S     5      $ Телефон��6%   $		 100 6P   
 66   �� *Phone+6P   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,16,0,0q�6W   .+�5      �� $��Выбрать��6   $	��100��6'   $��0,0,8,0q�63   ��6D   �� *SelectCommand+�� 5      $��Отмена��6   $	��100��6&   ��62   �� *CancelCommand+5      5      5      