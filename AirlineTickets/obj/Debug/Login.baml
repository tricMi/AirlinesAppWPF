   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AirlineTicketsAirlineTickets  5   	       AirlineTickets.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AirlineTickets     5   	     � Title$  Login��5   	   $	��450��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60   .��5	      � -   5         �Name$ DGLogin��5	       J� OpacityMask �	#FFAE86B2���	#FFF7EFEF � ColumnDefinitions 5
   
   �� 5      $
��224* �6   �� 5      $	��33* �6   .+�5   
   �� $
��Left=�6   $	��419��60   $��	382,0,0,0q�6=   $	��Top=�6P   $	��410��6h    J� Opacity$
 0.85Q�6t   $��2��6�   ��5      �� 5       �� ImageSource$ Images/aero.jpg��6    j� Stretch$ UniformToFill=�6;   .+�5      �� -   5         ��Name$ 
lblWelcome��5      $��Welcome��6(   ���	#FFA88484$��Center=�6Q   $��114,130,68,130q�6n   $��51��6�   $	��218��6�   $��36(�6�   $
��Bold"�6�   ���	#00E7F3F36�   �� 5      $��to the  airlines  app��6   $��115,-110,79,-80q�64   $	��200��6M   $��20(�6Z   $
��Bold"�6h   ���	#FF7E6868���	#00E7F3F36�   5      �� 5   
   -   5        $ lblLogin��5      $��Login��6"   $
��Left=�62   $��	34,29,0,0q�6M   $	��Top=�6`   	 J� RenderTransformOrigin$	 -1.105,0.346&�6x   $	��193��6�   $��58��6�   $��36(�6�   $
��Bold"�6�   ���	#FF594B4B6�   �� 5   
   -   5        $ lblUsername��5      $��Username��6%   $
��Left=�68   $��
21,128,0,0q�6S   $	��Top=�6g   $��85��6   $
��Bold"�6�   ���	#FF594B4B$	 0.518,-0.115&�6�   �� 5   
   -   5        $ lblPassword��5      $��Password��6%   $
��Left=�68   $��
21,213,0,0q�6S   $	��Top=�6g   $	 -3.447,-0.423&�6   $��85��6�   $
��Bold"�6�   ���	#FF594B4B6�   �� 5   
   -   5        
 ��Name$
 txtUsername��5      $
��Left=�6'   $��37��6B   $��132,128,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��223��6�   ���	#FFF7F1F16�   �� 5   
   -   5         ��Name$ btnLogin��5      $��Login��6#   $
��Left=�63   $��
21,302,0,0q�6N   $	��Top=�6b   $	��334��6z   $��37��6�   ���	#FF8B7777
�������$
��Bold"�6�   $��16(�6�   6�   �� 5   
   -   5        $��CloseButton��5      $��x��6$   $
��Left=�60   $��
76,-20,0,0q�6K   $	��Top=�6_   $��23��6w   $	 	3.087,0.4&�6�   $��1��6�   ���	#FFCB7676
�������6�   G� 5   
   -	   5        $��pswPassword��5      $
��Left=�6*   $��132,213,0,0q�6E   $	��Top=�6Z   $	��223��6r   $��35��6~   ���	#FFF7F1F16�   5      5      