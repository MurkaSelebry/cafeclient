   M S B A M L   `   `   `  ����
  diplom    diplom.AddClientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	      	AddClient  � Title#  �   5   	   $	��420��6-   $	��400��6:    � WindowStartupLocation$ CenterOwner=�6F   .��5      � $��16q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� #���   6   $��18(�67   $
��Bold"�6E   $��0,0,0,16q�6W   �� 5   
   $��1��6   $	��Top=�6"   .+�5      ��   	FirstName#���  6   �� 5      ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5        LastName#���  6   �� 5      ��6   �� *
LastName+$ PropertyChanged=��� 5       	 Phone#���  6   �� 5      ��6   �� *Phone+$ PropertyChanged=��� 5       	 Email#���  6   �� 5      ��6   �� *Email+$ PropertyChanged=��� 5        	BirthDate#���  6   �� 5      ��6   �� *	BirthDate+$ PropertyChanged=��� 5        LoyaltyLevel#���  6   �� 5      ��6   �� *LoyaltyLevelId+$ PropertyChanged=��� 5        BonusPoints#���  6   �� 5      ��6   �� *BonusPoints+$ PropertyChanged=�5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,16,0,0q�6W   .+�5      ��   Save#���  6   $	��100��66   $��0,0,8,0q�6B   ��6S   �� *SaveCommand+�� 5       
	 Cancel#��� 	 6   $	��100��68   ��6D   �� *CancelCommand+5      5       5!      