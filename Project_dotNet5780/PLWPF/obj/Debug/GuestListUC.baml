   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5          PLWPF.GuestListUC   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:PLWPF     5      .��5	      � .+�5   
   � $��0,0,120,0.0q�6   .+�5      &   System.Windows.Controls.DataGrid  $
��Left=�6   $	��401��62   $��	10,10,0,0q�6?   $	��Top=�6R   $	��790��6j   �� 5      -   5          ��Name$
  list��5   /   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6=   $��RightToLeft=�6�   ��6   ��  �� View 5      �� 5      .P�5      ��    PrivateName#���   6)    �� Width$
 auto��6P    �� DisplayMemberBinding 6]   �� *PrivateName+6�   �� 5        
FamilyName#���  6)   $
 auto��6O    6\   �� *
FamilyName+6�   �� 5        MailAddress#���  6)   $
 auto��6P    6]   �� *MailAddress+6�   �� 5        RegistrationDate#���  6)   $
 auto��6U    6b   �� *RegistrationDate+6�   �� 5        	EntryDate#���  6)   $
 auto��6N    6[   �� *	EntryDate+6�   �� 5        ReleaseDate#���  6)   $
 auto��6P    6]   �� *ReleaseDate+6�   �� 5       
 Status#���  6)   $
 auto��6K    6X   �� *Status+6�   �� 5        Area#���  6)   $
 auto��6I    6V   �� *Area+6~   �� 5         Type#���  6)   $
 auto��6I    6V   �� *Type+6~   �� 5!       	 Pool#��� 	 6)   $
 auto��6I    6V   �� *Pool+6~   �� 5"       
 Jacuzzi#��� 
 6)   $
 auto��6L    6Y   �� *	Jacuzzi+6�   �� 5#       
 Garden#���  6)   $
 auto��6K    6X   �� *Garden+6�   �� 5$        ChildrensAttractions#���  6)   $
 auto��6Y    6f   �� *ChildrensAttractions+6�   �� 5%       
 Adults#���  6)   $
 auto��6K    6X   �� *Adults+6�   �� 5&        Children#���  6)   $
 auto��6M    6Z   �� *
Children+6�   5(      5*      5,      � 5-   
   $��	0,0,-3,32q�6   $��RightToLeft=�6"   ���	#FFF7F7F7$��Right=�6U   $	��118��6q   $	��408��6}   $��Bottom=�6�    � RowDefinitions 52      �� 53      $��* �6    �� 54      $��* �6    �� 55      $��* �6    �� 56      $��* �6    �� 57      $��5* �6    .+�5@      	� -   5         	�Name$ showAllRadio��5@   '   $��0��6   $��הכל��6\   $��Right=�6j   $��2,10,0,14.143q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5A      V� 5B      .~�5C      �� �� 5D      �� 5E      T� 5F      5G      5I      	� 5J      -   5        $ showOpenRadio��5J      $��פתוח��6Q   $��Right=�6`   $��2,13.857,-46,10.286q�6w   $��1��6�   	� 5K      -   5        $ shoLostRadio��5K   '   $��2��6   $$��נסגר מחוסר עניין��6\   $��Right=�6w   $��0,9.714,-46,13.857q�6�   	� 5L      -   5        $ showCloseRadio��5L   '   $��3��6   $��נסגרה עסקה��6a   $��Right=�6v   $��2,10.143,-46,22.429q�6�   5P      5S      5V      