   M S B A M L   `   `   `  ����
  diplom"    diplom.AddLoyaltyLevelWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$:  4Добавить уровень лояльности��5   	   $	��300��6-   $	��400��6:    � WindowStartupLocation$ CenterOwner=�6F   .��5      � $��16q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $<��6Добавление уровня лояльности��6   $��18(�68   $
��Bold"�6F   $��0,0,0,16q�6X   �� 5   
   $��1��6   $	��Top=�6"   .+�5      �� $��Название:��6   �� 5      ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��Мин. баллы:��6   �� 5      ��6   �� *	MinPoints+$ PropertyChanged=��� 5      $��Скидка (%):��6   �� 5      ��6   �� *DiscountPercent+$ PropertyChanged=�5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,16,0,0q�6W   .+�5      �� $��Сохранить��6   $	��100��6)   $��0,0,8,0q�65   ��6F   �� *SaveCommand+�� 5      $��Отмена��6   $	��100��6&   ��62   �� *CancelCommand+5      5      5      