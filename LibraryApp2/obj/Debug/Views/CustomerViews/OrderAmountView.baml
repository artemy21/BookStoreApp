   M S B A M L   `   `   `  ����  LibraryApp25    /LibraryApp2.Views.CustomerViews.OrderAmountView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  OrderAmountView��5   	   $	��300��5   	   $	��500��5	   	    � 
ResizeMode$ NoResize=�5
   	    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ OrderAmount� � 	Resources 5       �� 
TargetType  amountBorder �� Property �� Value  	amountBtn  
amountText  maxAmountText��%�  &	       &	 �     &	 F    &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 60��6'   �� 5       � ��$	 180��6&   �� 5       � ��
 �   �6,   �� 5       � ��$ 2q�60   5      �� 5   
   " ��6   .�5      ��  � ��$ 60��6'   �� 5       � ��$ 60��6&   �� 5       � ��$ 30(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 30(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Bottom=�62   �� 5        � ��$ 15(�6)   �� 5!       � ��
 �  ��6+   5"      5#      .��5%      � 	 � RowDefinitions	 5&   
   �� 5'      �� 5(      �� 5)      
 � ColumnDefinitions
 5+   
   �� 5,      �� 5-      .+�50   
   �� �� 51      $�Name: ��6    �� 52      �6   �� *Item.ItemName+53      �� 55   
   $��1��6   �� 56      $�Price: ��6    �� 57      �6   �� *Price+ �� Mode$ OneWay=� �� 58      $�$��6   59      �� 5;   
   #��[ 5<      $��2��5>      $��Max Stock Amount��5?      y�5=      �� *MaxAmountVisibility+5?      �� 5A   
   $��1��5B      $��2��5C      #��[ 5D      ._�5F      ��  �� Orientation$ 
Horizontal=�6   .+�5G      �� #��[ 5H      $��-��5I      ��5J      �� *DecrementCommand+�� 5L      $��60��6   ._�5M      �� #��[ 5N      ��5O      �� *Amount+5P      �� 5R      #��[ 5S      $��+��5T      ��5U      �� *IncrementCommand+5V      5W      �� 5Y   
   $��Add to Cart��5Z      $��2��5[      ��5\      �� *CartAddCommand+�� 5^   
   -   5        $��Cancel��5`      $��2��5a      $��1��5b      5c      5d      