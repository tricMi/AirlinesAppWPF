   M S B A M L   `   `   `  ����I  EAirlineTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AirlineTickets.ValidationAirlineTickets.Validation  5   	   &     AirlineTickets.EditAirportWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AirlineTickets.Validation     5   	     � Title$  Airport Edit Window��5   	   $	��360��6%   $	��365��62   ���	#FFEAE3E3 � WindowStartupLocation$ CenterScreen=�6U   .��5	      � ��5
   
   �� 5       �� ImageSource$ Images/gradient.jpg��6    � RowDefinitions 5   
   �� 5      $
��160* �6   �� 5      $
��259* �6   .+�5   
   �� -   5        $��LblCity��5      $
��City��6    $
��Left=�6/   $��	48,38,0,0q�6J   $	��Top=�6]    J� RenderTransformOrigin$ -2.447,0.423&�6u   $��1��6�   $��86��6�   $��28��6�   �� 5   
   -   5        $��LblAirportID��5      $��
Airport ID��6%   $
��Left=�6:   $��	48,40,0,0q�6U   $ -2.447,0.423&�6h   $��86��6�   $��35��6�   $	��Top=�6�   �� 5   
   -   5        $��LblName��5      $
��Name��6    $
��Left=�6/   $��	48,98,0,0q�6J   $	��Top=�6]   $ -2.447,0.423&�6u   $��86��6�   $��28��6�   �� 5   
   -   5        $��TxtAirportID��5      ���	#FFCBCCDA$
��Left=�6>   $��40��6Y   $��
162,40,0,0q�6e    �� TextWrapping$
 Wrap=�6y   $	��Top=�6�   $	��129��6�   .��6�   ��5      �� 5       �� Path$ 	AirportID�6    �� NotifyOnValidationError .  �� ValidatesOnDataErrors . 	 �� ValidatesOnExceptions	 . 
 �� UpdateSourceTrigger$
 PropertyChanged=�5       �� Mode$ TwoWay=�6@    �� ValidationRules 5      3   -AirlineTickets.Validation.AirportIdValidation  5      5      .��5        =� ErrorTemplate 5!      �� 5"      .R�5#      �� .+�5$      �� �� 5%      
���  ����6"   �� $ ErrorContent�6X   5&      5'      .��5(   (   5)      �� 5*   
   -   5        $��TxtName��5*      ���	#FFCBCCDA$
��Left=�69   $��40��6T   $��
162,96,0,0q�6`   $
 Wrap=�6t   $	��Top=�6�   $	��129��6�   $��2��6�   .��6�   ��5+      �� 5,      $
 Name�6    .  . 	 . $
 PropertyChanged=�50      $ TwoWay=�6@    52      5   /AirlineTickets.Validation.AirportNameValidation  53      55      .��56       57      �� 58      .R�59      �� .+�5:      �� �� 5;      
���  ����6"   �� $ ErrorContent�6X   5<      5=      .��5>   (   5?      �� 5@   
   -   5        $��TxtCity��5@      ���	#FFCBCCDA$
��Left=�69   $��39��6T   $��
162,27,0,0q�6`   $
 Wrap=�6t   $	��Top=�6�   $	��129��6�   $��1��6�   .��6�   ��5A      �� 5B      $
 City�6    .  . 	 . $
 PropertyChanged=�5F      $ TwoWay=�6@    5H      .   (AirlineTickets.Validation.CityValidation  5I      5K      .��5L       5M      �� 5N      .R�5O      �� .+�5P      �� �� 5Q      
���  ����6"   �� $ ErrorContent�6X   5R      5S      .��5T   (   5U      �� 5V   
   -   5        $��BtnSave��5V      $
��Save��6!   ���	#FFC4ADCD$
��Left=�6G   $��209,126,0,0q�6b   $��1��6w   $	��Top=�6�   $��82��6�   $ 
-0.32,0.15&�6�   $��34��6�   6�   �� 5W   
   -   5        $��
BtnDiscard��5W      $��Discard��6$   ���	#FF947F9C$
��Left=�6M   $��
48,126,0,0q�6h   $��1��6|   $	��Top=�6�   $��86��6�   $��34��6�   6�   5Y      5Z      