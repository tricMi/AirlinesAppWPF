   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AirlineTickets.ValidationAirlineTickets.Validation  5   	   '    !AirlineTickets.EditAirplaneWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AirlineTickets.Validation     5   	     � Title$  Edit Airplane Window��5   	   $	��566��6&   $	��827��63   ���	#FFEAE3E3 � WindowStartupLocation$ CenterScreen=�6V   $
��Bold"�6{   .��5	      � ��5
   
   �� 5       �� ImageSource$ Images/gradient.jpg��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DGBSeats��5       J� Opacity$	 0.8Q�6X      GridLinesVisibility$
 None=�6f      CanUserAddRows .  $
��Left=�6�   $	��175��6�   $��
352,62,0,0q�6�   $	��Top=�6�   $	��441��6�   �� 5   
   -   5         ��Name$ LblPilot��5      $��Pilot��6"   $
��Left=�62   $��	31,67,0,0q�6M   $	��Top=�6`   $	��120��6x   $��30��6�   �� 5   
   -   5        $ LblBusinessClass��5      $��Bussines Class Seats��6*   $
��Left=�6I   $��
511,31,0,0q�6d   $	��Top=�6x   $	��133��6�   �� 5   
   -   5        $ LblAircompanyName��5      $��Aircompany Name��6+   $
��Left=�6E   $��
31,143,0,0q�6`   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $ LblEconomyClass��5      $��Economy Class Seats��6)   $
��Left=�6G   $��511,247,0,0q�6b   $	��Top=�6w   $	��133��6�    J� RenderTransformOrigin$ 0.504,0.269&�6�     5   
   -   5        $��DGESeats��5      $	 0.8Q�6Y   $
 None=�6g    .  $
��Left=�6�   $	��171��6�   $��352,278,0,0q�6�   $	��Top=�6�   $	��441��6�   �� 5   
   -   5         ��Name$ TxtPilot��5      $
��Left=�6$   $��35��6?   $��
156,62,0,0q�6K   ���	#FFCBCCDA	 �� TextWrapping$
	 Wrap=�6v   $	��Top=�6�   $	��120��6�   $ 0.692,0.486&�6�   .��6�   ��5      �� 5      
 �� Path$
 Pilot�6    �� NotifyOnValidationError .  �� ValidatesOnDataErrors .  �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� Mode$ TwoWay=�6@    �� ValidationRules 5      /   )AirlineTickets.Validation.PilotValidation  5      5      .��5       =� ErrorTemplate 5       �� 5!      .R�5"      �� .+�5#      �� �� 5$      
���  ����6"   �� $
 ErrorContent�6X   5%      5&      .��5'   (   5(      �� 5)   
   -   5         ��Name$ BtnSave��5)      ���	#FFC4ADCD$	 0.9Q�69   $
��Save��6G   $
��Left=�6V   $��704,473,0,0q�6q   $	��Top=�6�   $��89��6�   $��35��6�   6�   �� 5*   
   -	   5        $ 
BtnDiscard��5*      ���	#FF947F9C$	 0.9Q�6=   $��Discard��6K   $
��Left=�6]   $��
31,487,0,0q�6x   $	��Top=�6�   $��81��6�   $��31��6�   6�   �� 5+   
   $��
Row Number��6   $
��Left=�6%   $��
31,291,0,0q�6@   $	��Top=�6T   $ 
-1.5,0.577&�6l   $	��120��6�   �� 5,   
   $��Column Number��6   $
��Left=�6(   $��
31,377,0,0q�6C   $	��Top=�6W   $ -2.95,-0.154&�6o   $	��120��6�   �� 5-   
   -
   5        $ txtRowNumber��5-      ���	#FFCBCCDA$
��Left=�6?   $��36��6Z   $��156,291,0,0q�6f   $
	 Wrap=�6{   $	��Top=�6�   $	��120��6�   .��6�   ��5.      �� 5/      $
 RowNum�6    .  .  . $ PropertyChanged=�53      $ TwoWay=�6@    55      3   -AirlineTickets.Validation.RowNumberValidation  56      58      .��59       5:      �� 5;      .R�5<      �� .+�5=      �� �� 5>      
���  ����6"   �� $
 ErrorContent�6X   5?      5@      .��5A   (   5B      �� 5C   
   -   5        $ txtColumnNumber��5C      ���	#FFCBCCDA$
��Left=�6B   $��36��6]   $��156,377,0,0q�6i   $
	 Wrap=�6~   $	��Top=�6�   $	��120��6�   .��6�   ��5D      �� 5E      $
 	ColumnNum�6    .  .  . $ PropertyChanged=�5I      $ TwoWay=�6@    5K      6   0AirlineTickets.Validation.ColumnNumberValidation  5L      5N      .��5O       5P      �� 5Q      .R�5R      �� .+�5S      �� �� 5T      
���  ����6"   �� $
 ErrorContent�6X   5U      5V      .��5W   (   5X      �� 5Y   
   -   5        $��CbCompanyName��5Y      ���	#FFCBCCDA$
��Left=�6n   $��156,134,0,0q�6�   $	��Top=�6�   $	��120��6�   $��35��6�    �� SelectedItem 6@   �� $
 AircompanyName�6�   �� 5Z   
   -   5        $ lblInput��5Z      $��Input��6"   $
��Left=�62   $��
31,211,0,0q�6M   $	��Top=�6a   $	��120��6y   �� 5[   
   -   5        $ txtInput��5[      ���	#FFCBCCDA$
��Left=�6;   $��30��6V   $��156,207,0,0q�6b   $
	 Wrap=�6x   $	��Top=�6�   $	��120��6�   $ 0.517,0.825&�6�   .��6�   ��5\      �� 5]      $
 Input�6    .  .  . $ PropertyChanged=�5a      $ TwoWay=�6@    5c      /   )AirlineTickets.Validation.InputValidation  5d      5f      .��5g       5h      �� 5i      .R�5j      �� .+�5k      �� �� 5l      
���  ����6"   �� $
 ErrorContent�6X   5m      5n      .��5o   (   5p      5s      5t      