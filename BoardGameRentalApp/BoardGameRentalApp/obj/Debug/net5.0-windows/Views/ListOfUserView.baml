   M S B A M L   `   `   `  ????M  IBoardGameRentalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BoardGameRentalApp.ViewsBoardGameRentalApp.Views  5      -    'BoardGameRentalApp.Views.ListOfUserView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:BoardGameRentalApp.Views     5      .??5	      ? ???#E4DFDA  ? ColumnDefinitions  5
   
   ?? 5      $	??230 ?6   ?? 5      $??* ?6   ?? 5      $??20 ?6    ? RowDefinitions 5   
   ?? 5      $	??30  ?6   ?? 5      $??5* ?6   ?? 5      $	??21* ?6   ?? 5      $	??30  ?6   .+?5   
   ?? 
???   ?5      0   *BoardGameRentalApp.Views.NavigationBarView  5   
   ?? 5   
   $??1??6   $??1??6%   $??20 0 0 0q?62   $??2??6D   .+?5      ?? $??0??6   $??Board Games??6%   ?? 5      $??1??6   $	??200??6G   $	??200??6W   ??6%   ?? *	usersList+ ?? View 5      ?? 5       .P?5"      ?? $??UserId??6)    ?? Width$ 60??69    ?? CellTemplate 5#      ?? 5$   "   .R?5&   &   ?? ??60   ?? *UserId+5'   #   5)      ?? 5*      $
??Name??6)    5+      ?? 5,   "   .R?5-   &   ?? ??60   ?? *
UserName+5.   #   50      ?? 51       52      ?? 53   "   .R?54   &   ??  d? 	IsChecked 6/   ?? *
IsSelected+55   #   57      59      5;      ?? 5<      $??0 20 0 0q?6   $	??200??6+   $
??Left=?67   .+?5?      ?? $??UserName??6   ?? 5@      ??6   ?? *
UserName+ ?? UpdateSourceTrigger$ PropertyChanged=??? 5A         MenuButtonTheme#??[  6   $??0 10 0 0q?6B   $??2??6T   ??6a   ?? *
AddNewUser+.??6?   
Add User6?   ?? 5B      #??[  6   $??0 10 0 0q?6C   $??2??6U   ??6b   ?? *
DeleteUser+.??6?   Delete User6?   5C      5G      ?? 5H   
   ???#2F4858$??0??6*   $??4??67   .+?5I        5J      5K      5L      