   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.ProductWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  ProductWindow��5   	   $	��400��6   $	��350��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $#��Введите артикул��6   �� 5      -   5         ��Name$ 	VenorCode��5      $��40��6)   $��20 10q�65   5      �� 5   
   $��1��6   .+�5      �� $%��Введите название��6   �� 5      -   5        $
 Name��5      $��40��6$   $��20 10q�60   5      �� 5   
   $��2��6   .+�5      �� $��Введите цену��6   �� 5      -   5        $ Price��5      $��40��6%   $��20 10q�61   5      �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5         ��Name$ SaveProduct��5      $��Сохранить��6*   $��3��6>   $
��30 5q�6K   6Y   �� 5      -   5        $ CancelProduct��5      $��Отменить��6,   $��3��6?   $
��30 5q�6L   6Z   5      5       5!      