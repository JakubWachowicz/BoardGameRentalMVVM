   M S B A M L   `   `   `  ????M  IBoardGameRentalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BoardGameRentalApp.ViewsBoardGameRentalApp.Views  5      M+clr-namespace:BoardGameRentalApp.ComponentsBoardGameRentalApp.Components  5      )    #BoardGameRentalApp.Views.SignUpView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:BoardGameRentalApp.Views     5      B
components+clr-namespace:BoardGameRentalApp.Components     5        ? 	Resources  5          BooleanToVisibilityConverter??%   &	        ?? 5   
   6'   5      .??5      ?? ._?5   
   ??  J? Opacity$
 0.95Q?6   ??5      ?? 5       ?? 
StartPoint$	 0,0&?6&    ?? EndPoint$	 1,1&?67   .??5      ?  ? Color$ #E4DFDA??6#    ? Offset$ 0Q?63   ? 5      $ #78A9A6??6#   $
 0.75Q?63   5      ._?5      ? $ 1Q?6    ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5       ?? 5!      ?? 5"      $
??auto ?6$   ?? 5#      .+?5&      ?? $??1??6   $??1??6*   
??????? ?? CornerRadius$ 25??6N   ._?5'      ?  5(      ?? 5)      ?? 5*      $	??340 ?6,   ?? 5+       5-      ?? 5.      ?? 5/      $	??10* ?6/   ?? 50      .+?53      ?? $??1??6%   $??1??62   $	??Top=?6D   .+?54      ?? $??Registration??6(   $
??Bold"?6<   $??20(?6N   $??	0 10 0 0 q?6\   ?? 55      $??Username??6(   $??0 30 0 5q?69   ?? 56      $??0 0 0 1q?6e   ??6&   ?? *
UserName+	 ?? UpdateSourceTrigger$	 PropertyChanged=?6e   ?? 57      $??Password??6(   $??0 30 0 5q?68   7   1BoardGameRentalApp.Components.BindablePasswordBox  58      
   Password
 6>   ?? *
Password+$	 PropertyChanged=? ?? Mode$ TwoWay=??? 59      $y?	Collapsed=?6(   ?? 5:      $??Confirm Password??6(   $??0 20 0 5q?6@     5;      
 6>   ?? *ConfirmPassword+$	 PropertyChanged=?$ TwoWay=??? 5<        MenuButtonTheme#??[ 6%   $??Sign Up??6N   $??0 40 0 5q?6`   $??30??6r   ??6~   ?? *CreateNewAccount+?? 5>      $??Already have a account???6%   $??Center=?6G   
???????
?????? $??0 0 0 1q?6?   ??6?   ?? *Login+5?      5@      5C      5K      5L      5M      5O      