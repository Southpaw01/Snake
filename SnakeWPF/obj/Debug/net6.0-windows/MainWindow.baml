   M S B A M L   `   `   `  ????C  ?SnakeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SnakeWPFSnakeWPF  5   	       SnakeWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SnakeWPF     5   	   -   5          ? Title$  Змейка??5   	   $	??720??6   $
??1150??6%    ? WindowStartupLocation$ CenterScreen=?6b   $	??900??6?   $	??700??6?   .??5	      ? -   5         ?Name$ grid1??5	       ? ColumnDefinitions 5
   
    ? RowDefinitions 5   
   .+?5   
   r? -   5         r?Name$ video??5      $??Stretch=?6&   $??0,0,0,0q?6D   $??Stretch=?6U    r? Source$ Untitled.mp4??6q    r? Stretch$ UniformToFill=?6?    r? 
SpeedRatio$	 1.5Q?6?   	 r? LoadedBehavior$	 Manual=?6?   
 r? UnloadedBehavior$
 Manual=?6?    J? Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 5Q?6      
KernelType$ Gaussian=?6(      RenderingBias$ Quality=?6>   5      ?? 5   
   -   5         ??Name$ contentControl??5      ???	#FFFFA3A3
???   ?$??Stretch=?6\   $??Stretch=?6?   $??0,0,0,0q?6?   $??Center=?6?   $??Center=?6?   ? 5   
   -   5        $ gameGrid??5      $y?Hidden=?6!   $??Disabled=?65    5      ?? 5      $??92.005 ?6    ?? 5      .+?5      ? -   5        $ field??5      $??2??6"   $??1??63   $??
10,0,10,10q?6@    5      ?? 5      $
??174* ?6'   ?? 5      $
??509* ?6'   5      ?? 5       $??Center=?6   $??	15,0,15,0q?66    ?? Orientation$ 
Horizontal=?6I   .+?5!      ?? -   5         ??Name$ lCounter??5!      $??	Счет:??6*   $??24(?6:   $
??Left=?6H   $??Center=?6c   $??0,0,20,0q?6~   ?? 5"      $ Vertical=?6   $	??154??64   $??Center=?6@   $??Center=?6]   .+?5#      ?? -   5         ??Name$ 	buttonEsc??5#      $??Выйти в меню??60   $??16(?6_   $??0,0,0,10q?6m   ?? 5$      -	   5        $ buttonAgain??5$      $!??Начать сначала??62   $??16(?6K   6Y   5%      ?? 5&      -
   5        $ 	lGameOver??5&      $??Игра окончена??6+   $??36(?6C   $??Center=?6Q   $??Center=?6l   $y?Visible=?6?   $??20,0,0,0q?6?   5'      5(      5*      5+      