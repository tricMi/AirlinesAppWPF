   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AirlineTicketsAirlineTickets  5   	        AirlineTickets.SeatsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AirlineTickets     5   	     � Title$  Seats Window��5   	   $	��587��6   $	��725��6+   ���	#FFF1EAEA � WindowStartupLocation$ CenterScreen=�6N   .��5	      � ��5
   
   �� 5       �� ImageSource$ Images/air.jpg��6   .+�5   
   �� -   5         ��Name$ LbBSeats��5       J� Opacity$	 0.8Q�6%   $��Visible=�63   $��Disabled=�6f   $
��Left=�6�   $	��480��6�   $��	23,54,0,0q�6�   $	��Top=�6�   $	��487��6�   ��5      �� 5      .R�5      � 5      ��5      �� 5      .R�5      � $	��332��6   ���	#4CFFFFFF � ColumnDefinitions 5      �� 5      $
��132* �6/   �� 5      $
��200* �6/    � RowDefinitions 5      �� 5      �� 5      $��40 �6,   �� 5      .+�5      �  �Name$ GridB��6   $��3��6.   $��0,0,12,0q�6?   
���P��$��60��6d   $��60��6o   $
��Left=�6{   .+�5       �� $��Center=�6C   $��Center=�6`   $��48(�6{   
���������6(   �� *	SeatLabel+6�   5!      �� 5"      $��1��6$   $��3��64   
�������$��12(�6v   $��Center=�6�   ��6[   �� *	SeatState+6�   �� 5#      $��1��6$   $��3��61   
�������$��1��6T   $
��Wrap=�6�   ��6h   �� *	SeatClass+6�   5%       �� Triggers 5&      �� 5'      	 �� Value$
	 True��6D   
 �� Binding
 6&   �� *	SeatState+.a�5(      ��  �� 
TargetName$ GridB��6%    �� Property � �� �� Value
 �P��6N   5)      �� 5+      $	 False��6D   
 6&   �� *	SeatState+.a�5,      �� $ GridB��6%    � ��
 � � �6N   5-      5/      ��51      �� 52       �� 
TargetType" ��6   .�53      ��  � ��$ 0q�60   �� 54       � ��$ 6q�6/   55      57      �� 58   
   $��2��6   
�������$	 0.8Q�6<   $
��Left=�6J   $	��130��6e   $��529,137,0,0q�6r   $	��Top=�6�   $	��164��6�   �� 59   
   $
��Left=�6   $��28��6-   $��543,152,0,0q�69   $	��Top=�6N   $��26��6f   $��Images/green.png��6q   �� 5:   
   $
��Left=�6   $��25��6+   $��543,204,0,0q�67   $	��Top=�6L   $��26��6d    J� RenderTransformOrigin$ 0.286,-1.172&�6o   $��Images/orange.png��6�   �� 5;   
   -   5         ��Name$ lblGreen��5;      $��
Taken Seat��6"   $
��Left=�67   $��587,152,0,0q�6R   $	��Top=�6g   $ 0.737,-1.115&�6   $��90��6�   �� 5<   
   -   5        $ 	lblOrange��5<      $��Available Seat��6#   $
��Left=�6<   $��587,204,0,0q�6W   $	��Top=�6l   $��90��6�   5=      5>      