   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.personalAreaGui   5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	     � Title$  אזור אישי��5	   	   $	��650��6   $	��800��6(    � 	Resources 5
         myButtonStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��5      .�5      ��  � ��$ 12(�5      �� 5       � ��$ Consolas)�5      �� 5       � ��$
 Bold"�5      5      5      ��5   
   �� 5   
    �� ImageSource$ images/pzd.jpg��6   .��5      � $��RightToLeft=�6   .+�5   
   �� -   5        $"��מחק יחידת אירוח��5      #��[  6,   $
��Left=�6S   $��160,493,0,0q�6n   $	��Top=�6�   $	��116��6�   6�   �� 5   
   -   5        $$��עדכן יחידת אירוח��5      #��[  6,   $
��Left=�6S   $��364,493,0,0q�6n   $	��Top=�6�   $	��123��6�   6�   �� 5    
   -   5        $+��%הזמנות עבור יחידה זו��5       #��[  60   $
��Left=�6W   $��564,493,0,0q�6r   $	��Top=�6�   $	��149��6�   6�   � 5)   
   -   5         �Name$ grid1��5)      $
��Left=�6   $��	21,47,0,0q�69   $	��Top=�6L   ���	#FFF7F7F7 � ColumnDefinitions 5*      �� 5+      $
��Auto �6#   �� 5,      $
��Auto �6#    � RowDefinitions 5.      �� 5/      $
��Auto �6    �� 50      $
��Auto �6    �� 51      $
��Auto �6    �� 52      $
��Auto �6    �� 53      $
��Auto �6    �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    .+�58      �� $��Area:��6   $��0��6$   $
��Left=�64   $��3q�6O   $��0��6Z   $��Center=�6g   �� 59      -   5        	 ��Name$	 areaComboBox��59      $��1��6-   $
��Left=�6[   $
��Auto��6v   $��3q�6�   $��0��6�   $��Center=�6�   $	��120��6�   
 �� SelectedItem
 6=   �� *Area+5;      �� 5<        Childrens Attractions:#���  6   $��0��6G   $
��Left=�6W   $��3q�6r   $��1��6}   $��Center=�6�   �� 5=      -   5         ��Name$" childrensAttractionsCheckBox��5=      $�� ��6=   $��1��6H   $
��Left=�6X   $��3q�6�   $��1��6�   $��Center=�6�    d� 	IsChecked 6s   �� *ChildrensAttractions+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5>        Garden:#���  6   $��0��68   $
��Left=�6H   $��3q�6c   $��2��6n   $��Center=�6{   �� 5?      -   5        $ gardenCheckBox��5?      $�� ��6/   $��1��6:   $
��Left=�6J   $��3q�6�   $��2��6�   $��Center=�6�    6e   �� *Garden+$ TwoWay=� .  . 6�   �� 5@        Hosting Unit Key:#���  6   $��0��6B   $
��Left=�6R   $��3q�6m   $��3��6x   $��Center=�6�   �� 5A      -   5         ��Name$ hostingUnitKeyTextBox��5A       �� 
IsReadOnly . $��1��6G   $
��Left=�6W   $��23��6r   $��3q�6~   $��3��6�   $��Center=�6�   $	��120��6  ��6�   �� *HostingUnitKey+$ TwoWay=� .  . 6  �� 5B        Hosting Unit Name:#���  6   $��0��6C   $
��Left=�6S   $��3q�6n   $��4��6y   $��Center=�6�   �� 5C      -	   5        $ hostingUnitNameTextBox��5C      $��1��66   $
��Left=�6F   $��23��6a   $��3q�6m   $��4��6x   $��Center=�6�   $	��120��6  ��6�   �� *HostingUnitName+$ TwoWay=� .  . 6  �� 5D        Jacuzzi:#���  6   $��0��69   $
��Left=�6I   $��3q�6d   $��5��6o   $��Center=�6|   �� 5E      -
   5        $ jacuzziCheckBox��5E      $�� ��60   $��1��6;   $
��Left=�6K   $��3q�6�   $��5��6�   $��Center=�6�    6f   �� *	Jacuzzi+$ TwoWay=� .  . 6�   �� 5F       	 Pool:#���  6   $��0��66   $
��Left=�6F   $��3q�6a   $��6��6l   $��Center=�6y   �� 5G      -   5        $ poolCheckBox��5G      $�� ��6-   $��1��68   $
��Left=�6H   $��3q�6�   $��6��6�   $��Center=�6�    6c   �� *Pool+$ TwoWay=� .  . 6�   �� 5H       	 Type:#���  6   $��0��66   $
��Left=�6F   $��3q�6a   $��7��6l   $��Center=�6y   �� 5I      -   5        $	 typeComboBox��5I      $��1��6-   $
��Left=�6\   $
��Auto��6w   $��3q�6�   $��7��6�   $��Center=�6�   $	��120��6�   
 6=   �� *Type+5K      5L      � 5M   
   -   5        $ grid2��5M      $
��Left=�6   $��
329,47,0,0q�69   $	��Top=�6M   ���	#FFF7F7F7 5N      �� 5O      $
��Auto �6#   �� 5P      $
��Auto �6#    5R      �� 5S      $
��Auto �6    �� 5T      $
��Auto �6    �� 5U      $
��Auto �6    �� 5V      $
��Auto �6    �� 5W      $
��Auto �6    �� 5X      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5Z      $
��Auto �6    �� 5[      $
��Auto �6    �� 5\      $
��Auto �6    �� 5]      $
��Auto �6    �� 5^      $
��Auto �6    �� 5_      $
��Auto �6    .+�5a      ��   Bank Account Number:#���  6   $��0��6E   $
��Left=�6U   $��3q�6p   $��0��6{   $��Center=�6�   �� 5b      -   5        $ bankAccountNumberTextBox��5b      $��1��68   $
��Left=�6H   $��23��6c   $��3q�6o   $��0��6z   $��Center=�6�   $	��120��6  ��6�   �� *Owner.BankAccountNumber+$ TwoWay=� .  . 6  �� 5c       	 Collection Clearance:#��� 	 6   $��0��6F   $
��Left=�6V   $��3q�6q   $��1��6|   $��Center=�6�   �� 5d      -   5        $  collectionClearanceTextBox��5d      $��1��6:   $
��Left=�6J   $��23��6e   $��3q�6q   $��1��6|   $��Center=�6�   $	��120��6  ��6�   �� *Owner.CollectionClearance+$ TwoWay=� .  . 6  �� 5e       
 Family Name:#��� 
 6   $��0��6=   $
��Left=�6M   $��3q�6h   $��2��6s   $��Center=�6�   �� 5f      -   5        $ familyNameTextBox��5f      $��1��61   $
��Left=�6A   $��23��6\   $��3q�6h   $��2��6s   $��Center=�6�   $	��120��6  ��6�   �� *Owner.FamilyName+$ TwoWay=� .  . 6  �� 5g        	Host Key:#���  6   $��0��6:   $
��Left=�6J   $��3q�6e   $��3��6p   $��Center=�6}   �� 5h      -   5        $ hostKeyTextBox��5h      $��1��6.   $
��Left=�6>   $��23��6Y   $��3q�6e   $��3��6p   $��Center=�6�   $	��120��6�   ��6}   �� *Owner.HostKey+$ TwoWay=� .  . 6�   �� 5i        Mail Address:#���  6   $��0��6>   $
��Left=�6N   $��3q�6i   $��4��6t   $��Center=�6�   �� 5j      -   5        $ mailAddressTextBox��5j      $��1��62   $
��Left=�6B   $��23��6]   $��3q�6i   $��4��6t   $��Center=�6�   $	��120��6  ��6�   �� *Owner.MailAddress+$ TwoWay=� .  . 6  �� 5k        Phone Number:#���  6   $��0��6>   $
��Left=�6N   $��3q�6i   $��6��6t   $��Center=�6�   �� 5l      -   5        $ phoneNumberTextBox��5l      $��1��62   $
��Left=�6B   $��23��6]   $��3q�6i   $��6��6t   $��Center=�6�   $	��120��6  ��6�   �� *Owner.PhoneNumber+$ TwoWay=� .  . 6  �� 5m        Private Name:#���  6   $��0��6>   $
��Left=�6N   $��3q�6i   $��7��6t   $��Center=�6�   �� 5n      -   5        $ privateNameTextBox��5n      $��1��62   $
��Left=�6B   $��23��6]   $��3q�6i   $��7��6t   $��Center=�6�   $	��120��6  ��6�   �� *Owner.PrivateName+$ TwoWay=� .  . 6  �� 5o        
Bank Name:#���  6   $��0��6;   $
��Left=�6K   $��3q�6f   $��8��6q   $��Center=�6~   �� 5p      -   5        $ bankNameTextBox��5p      $��1��6/   $
��Left=�6?   $��23��6Z   $��3q�6f   $��8��6q   $��Center=�6�   $	��120��6  ��6~   �� *" Owner.BankBranchDetails.BankName+$ TwoWay=� .  . 6  �� 5q        Bank Number:#���  6   $��0��6=   $
��Left=�6M   $��3q�6h   $��9��6s   $��Center=�6�   �� 5r      -   5        $ bankNumberTextBox��5r      $��1��61   $
��Left=�6A   $��23��6\   $��3q�6h   $��9��6s   $��Center=�6�   $	��120��6  ��6�   �� *$"Owner.BankBranchDetails.BankNumber+$ TwoWay=� .  . 6  �� 5s        Branch Address:#���  6   $��0��6@   $
��Left=�6P   $��3q�6k   $��10��6v   $��Center=�6�   �� 5t      -   5        $ branchAddressTextBox��5t      $��1��64   $
��Left=�6D   $��23��6_   $��3q�6k   $��10��6v   $��Center=�6  $	��120��6  ��6�   �� *'%Owner.BankBranchDetails.BranchAddress+$ TwoWay=� .  . 6  �� 5u        Branch City:#���  6   $��0��6=   $
��Left=�6M   $��3q�6h   $��11��6s   $��Center=�6�   �� 5v      -   5        $ branchCityTextBox��5v      $��1��61   $
��Left=�6A   $��23��6\   $��3q�6h   $��11��6s   $��Center=�6�   $	��120��6  ��6�   �� *$"Owner.BankBranchDetails.BranchCity+$ TwoWay=� .  . 6  �� 5w        Branch Number:#���  6   $��0��6?   $
��Left=�6O   $��3q�6j   $��12��6u   $��Center=�6�   �� 5x      -   5        $ branchNumberTextBox��5x      $��1��63   $
��Left=�6C   $��23��6^   $��3q�6j   $��12��6u   $��Center=�6   $	��120��6  ��6�   �� *&$Owner.BankBranchDetails.BranchNumber+$ TwoWay=� .  . 6  5y      5{      5~      