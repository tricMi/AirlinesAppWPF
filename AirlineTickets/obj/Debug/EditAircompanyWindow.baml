   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AirlineTickets.ValidationAirlineTickets.Validation  5   	   )    #AirlineTickets.EditAircompanyWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AirlineTickets.Validation     5   	     � Title$  Edit Aircompany Window��5   	   $	��477��6(   $	��764��65   ���	#FFF1EAEA � WindowStartupLocation$ CenterScreen=�6X   .��5	      � $��0,0,0,-3q�6   ��5
   
   �� 5       �� ImageSource$ Images/air.jpg��6    � ColumnDefinitions 5   
   �� 5      $
��277* �6   �� 5      $	��96* �6   .+�5   
   �� -   5         ��Name$ LblCompPass��5      $��Company password��6%   $
��Left=�6@   $��	28,44,0,0q�6[   $	��Top=�6n    J� RenderTransformOrigin$ -1.658,0.462&�6�   $	��122��6�   $��37��6�   $
��Bold"�6�   
�������6�   �� 5   
   -   5         ��Name$ TxtCompanyPass��5      $
��Left=�6*   $��37��6E   $��
166,44,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��128��6�   $��2��6�   ���	#FF725959
������� J� Opacity$	 0.8Q�6�   .��6�   ��5      �� 5      	 �� Path$	 CompanyPassword�6   
 �� NotifyOnValidationError
 .  �� ValidatesOnDataErrors .  �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� Mode$ TwoWay=�6@    �� ValidationRules 5      9   3AirlineTickets.Validation.CompanyPasswordValidation  5      5      .��5       =� ErrorTemplate 5      �� 5       .R�5!      �� .+�5"      �� �� 5#      
���  ����6"   �� $	 ErrorContent�6X   5$      5%      .��5&   (   5'      �� 5(   
   -   5         ��Name$ BtnSave��5(      $
��Save��6"   $
��Left=�61   $��
73,374,0,0q�6L   $	��Top=�6`   $��96��6x   $��35��6�   $
��Bold"�6�   $ 
0.542,-0.2&�6�   $��1��6�   ���	#FF725959
�������$	 0.8Q�6  �� 5)   
   -   5        $ 
BtnDiscard��5)      $��Discard��6%   $
��Left=�67   $��
28,374,0,0q�6R   $	��Top=�6f   $	��100��6~   $��35��6�   $
��Bold"�6�   $ 
-1.8,0.029&�6�   ���	#FF725959
�������$	 0.8Q�6  �� 5*   
   -   5        $ lblCompName��5*      $��Company name��6%   $
��Left=�6<   $	��Top=�6W   $��
28,121,0,0q�6o   $	��122��6�   $
��Bold"�6�   
�������6�   �� 5+   
   -   5        $ 
TxtComName��5+      $
��Left=�6&   $��34��6A   $��166,121,0,0q�6M   $
 Wrap=�6b   $	��Top=�6w   $	��128��6�   ���	#FF725959
�������$	 0.8Q�6�   .��6�   ��5,      �� 5-      $	 CompanyName�6   
 .  .  . $ PropertyChanged=�51      $ TwoWay=�6@    53      4   .AirlineTickets.Validation.AircompanyValidation  54      56      .��57       58      �� 59      .R�5:      �� .+�5;      �� �� 5<      
���  ����6"   �� $	 ErrorContent�6X   5=      5>      .��5?   (   5@      &   System.Windows.Controls.DataGrid  5A   
   -   5          Name$ 	DgFlights��5A      $
��Left=�6&   $	��165��6A   $��
28,191,0,0q�6N   $	��Top=�6b   $	��702��6z   $��2��6�   $	 0.8Q�6�   5C      5D      