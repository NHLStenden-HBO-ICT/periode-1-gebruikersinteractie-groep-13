   M S B A M L   `   `   `  ����D  @BeatEmApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BeatEmApp	BeatEmApp  5   	       BeatEmApp.Quit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BeatEmApp     5   	     � Title$
  Quit��5   	   $	��450��6   $	��800��6#   .��5	      � .+�5
   
   �� -   5         ��Name$
 Back��5
      ���#F3C9A6$��terug��64   $
��Left=�6U   $	��Top=�6p   $��45��6�   $	��125��6�   $��265,355,0,0q�6�   �� 5   
   -   5        $
 stop��5      ���#F3C9A6$
��quit��64   $
��Left=�6T   $	��Top=�6o   $��45��6�   $	��124��6�   $��418,355,0,0q�6�   �� 5   
   -   5         ��Name$ error��5      $��Center=�6!   $��	0,285,0,0q�6>    �� TextWrapping$
 Wrap=�6Q   $��16(�6e   $y�Hidden=�6s   $!��error: emails niet ingevuld��6�    �� TextAlignment$ Center=�6�   $	��Top=�6�   ���#586C70$��65��6�   $	��214��6�   �� 5   
   -   5         ��Name$ 
Error_Copy��5      $
��Left=�6(   $��	66,75,0,0q�6C   $
��Wrap=�6V   $��20(�6k   $��email sportschool��6y    �� TextAlignment$ Center=�6�   $	��Top=�6�   ���#586C70$	��108��6�   $	��190��6�   �� 5   
   -   5        $ Error_Copy1��5      $
��Left=�6)   $��
553,75,0,0q�6D   $
��Wrap=�6X   $��20(�6m   $��info over sportschool��6{   $ Center=�6�   $	��Top=�6�   ���#586C70$	��108��6�   $	��190��6�   �� 5   
   $
��Left=�6   $��47��6/   ���#6D82AC$��
66,206,0,0q�6J   
���   �$	��Top=�6m   $	��190��6�   �� 5   
   -   5        $ 
NamePlayer��5      $
��Left=�6(   $��
76,207,0,0q�6C   $
��Wrap=�6W   $��20(�6l   $��naam p1��6z   $ Center=�6�   $	��Top=�6�   $��34��6�   $��95��6�   �� 5   
   -   5        $ PlayerScore��5      $
��Left=�6)   $��147,207,0,0q�6D   $
��Wrap=�6Y   $��20(�6n   $��score p1��6|   $ Center=�6�   $	��Top=�6�   $��34��6�   $��95��6�   �� 5   
   -   5        $ Player_Email��5      $y�Hidden=�6*   $
��Left=�6>   $��
66,151,0,0q�6Y   $
��Wrap=�6m   $��20(�6�   $��score p1��6�   $ Center=�6�   $	��Top=�6�   ���#6D82AC$��46��6�   $	��190��6�   �� 5   
   $
��Left=�6   $��47��6/   ���#6D82AC$��553,208,0,0q�6J   
���   �$	��Top=�6n   $	��190��6�   �� 5   
   -	   5        $ NamePlayer2��5      $
��Left=�6)   $��556,208,0,0q�6D   $
��Wrap=�6Y   $��20(�6n   $��naam p2��6|   $ Center=�6�   $	��Top=�6�   $��33��6�   $��87��6�    J� RenderTransformOrigin$ 0.576,0.518&�6�   �� 5   
   -
   5        $ Player2Score��5      $
��Left=�6*   $��633,208,0,0q�6E   $
��Wrap=�6Z   $��20(�6o   $��score p2��6}   $ Center=�6�   $	��Top=�6�   $��33��6�   $��87��6�   $ 0.576,0.518&�6�   �� 5   
   -   5        $ Player2_Email��5      $y�Hidden=�6+   $
��Left=�6?   $��553,152,0,0q�6Z   $
��Wrap=�6o   $��20(�6�   $��score p2��6�   $ Center=�6�   $	��Top=�6�   ���#6D82AC$��46��6�   $	��190��6�   �� 5   
   -   5         ��Name$ stopMessage��5      $��293,129,268,149q�6&   $y�Hidden=�6?   .+�5      �� ���#33D6F5	 �� Left$	 10��6-   $ Center=�6>   $
��Wrap=�6U   $'��!weet je zeker dat je wilt stoppen��6i   

 �� Top$
 10��6�   $	��136��6�   $	��213��6�   $
��Left=�6�   $��Center=�6�   �� 5      -   5        $ Ja��5      ���#F3C9A6$��ja��66   $
��Left=�6T   $	��Top=�6o   $��32��6�   $��76��6�   $	 22��6�   $
 99��6�   �� 5      -   5        $	 Nee��5      ���#F3C9A6$	��nee��67   $
��Left=�6V   $��Center=�6q   $��32��6�   $��76��6�   $		 130��6�   $
 99��6�   5      5      5       