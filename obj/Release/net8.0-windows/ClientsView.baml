   M S B A M L   `   `   `  ���� 
  diplom/    )CafeClient.Presentation.Views.ClientsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     
�������.��� .+��� .+���    Clients#���   $��20(�$
��Bold"�$��0,0,0,12q���   �� Orientation$  
Horizontal=�$��0,0,0,12q�.+��� $	��220��$��28��$��0,0,8,0q�$��Center=����� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=���  
 Search#���  $��28��$��0,0,8,0q����� *SearchCommand+��   	AddClient#���  $��28�����#4CAF50
�������$
��16,0q����� *AddClientCommand+&   System.Windows.Controls.DataGrid  -     Name$ clientsDataGrid��   AutoGenerateColumns$ False��$	��300������ *	Clients+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+    	FirstName# �  $ *  �� *	FirstName+    LastName# �  $ *  �� *
LastName+   	 Phone# �  $	 120  �� *Phone+   	 Email# �  $	 150  �� *Email+    	BirthDate# �  $	 100  �� *	BirthDate+    LoyaltyLevel# �  $	 100  �� *LoyaltyLevelId+   	 BonusPoints# � 	 $	 100  �� *BonusPoints+   
 RegistrationDate# � 
 $	 100  �� *RegistrationDate+