   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AirlineTicketsAirlineTickets  5   	   "    AirlineTickets.AirportWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AirlineTickets     5   	     � Title$  Airports��5   	   $	��393��6   $	��735��6'   ���	#FFF1EAEA � WindowStartupLocation$ CenterScreen=�6J   .��5	      � ��5
   
   �� 5       �� ImageSource$ Images/air.jpg��6    � ColumnDefinitions 5   
   �� 5      $
��520* �6   �� 5      $
��207* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	DGAirport��5       J� Opacity$	 0.8Q�6%      GridLinesVisibility$
 None=�63   $
��Left=�6N   $	��265��6i   $��	27,69,0,0q�6v   $	��Top=�6�   $	��666��6�   $��2��6�   �� 5   
   -   5        $��	BtnDelete��5      $��Delete��6#   $
��Left=�64   $��	27,23,0,0q�6O   $	��Top=�6b   $��87��6z    J� RenderTransformOrigin$ 	0.52,-0.3&�6�   $��34��6�   ���	#FF725959
�������$	 0.8Q�6�   �� 5   
   -   5        $��BtnAdd��5      $	��Add��6    $
��Left=�6.   $��
154,23,0,0q�6I   $	��Top=�6]   $��85��6u   $��34��6�   ���	#FF725959
�������$	 0.8Q�6�   �� 5   
   -   5        $��BtnEdit��5      $
��Edit��6!   $
��Left=�60   $��
277,23,0,0q�6K   $	��Top=�6_   $��88��6w   $��34��6�   ���	#FF725959
�������$	 0.8Q�6�   �� 5   
   -   5         ��Name$ 	TxtSearch��5      $��1��6%   $
��Left=�65   $��34��6P   $��	45,23,0,0q�6\    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��128��6�   $	 0.8Q�6�   ���	#FF725959
�������6�   �� 5   
   -   5        	 ��Name$	 
TxtSearch1��5      $��Search��6$   $
��Left=�65   $��
510,23,0,0q�6P   $	��Top=�6d   $��2��6|   $��50��6�   $��34��6�   
�������$
��Bold"�6�   5      5      