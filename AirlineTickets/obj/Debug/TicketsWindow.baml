   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AirlineTicketsAirlineTickets  5   	   "    AirlineTickets.TicketsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AirlineTickets     5   	     � Title$  Tickets��5   	   $	��382��6   $	��732��6&   ���	#FFF1EAEA � WindowStartupLocation$ CenterScreen=�6I   .��5	      � ��5
   
   �� 5       �� ImageSource$ Images/air.jpg��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	DGTickets��5       J� Opacity$	 0.8Q�6%      GridLinesVisibility$
 None=�63   $
��Left=�6N   $	��275��6i   $��	26,57,0,0q�6v   $	��Top=�6�   $	��642��6�   �� 5   
   -   5        $��	BtnDelete��5      ���	#FF725959
�������$	 0.8Q�6N   $��Delete��6\   $
��Left=�6m   $��	26,10,0,0q�6�   $	��Top=�6�   $��75��6�   $��30��6�   6�   �� 5   
   -   5        $��BtnAdd��5      ���	#FF725959
�������$	 0.8Q�6K   $	��Add��6Y   $
��Left=�6g   $��
125,10,0,0q�6�   $	��Top=�6�   $��75��6�   $��30��6�   6�   �� 5   
   -   5         ��Name$ BtnSort��5      ���	#FF725959
�������$	 0.8Q�6M   $
��Sort��6[   $
��Left=�6j   $��
224,10,0,0q�6�   $	��Top=�6�   $��75��6�   $��30��6�   6�   �� 5   
   -   5         ��Name$ 	txtSearch��5      ���	#FF725959
�������$	 0.8Q�6g   $
��Left=�6u   $��30��6�   $��
548,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 	LblSearch��5      
�������$��Search��66   $
��Left=�6G   $��
476,10,0,0q�6b   $	��Top=�6v   $��53��6�   $
��Bold"�6�   5      5      