   M S B A M L   `   `   `  ����  Front end C    Front_end_C.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          � Title$  Login��5   	   $	��227��6   $	��525��6$    � AllowsTransparency .  � WindowStyle$
 None=�6J   ���	#00000000 � 
ResizeMode$ NoResize=�6t    � WindowStartupLocation$ CenterScreen=�6�    � Icon$ Images/car.png��6�    � 	Resources 5         	OnLoaded1 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value��%�   &	        �� 5   
   .��5      U� $ (UIElement.Opacity)�6,   $
 grid��6\   .\�5	        $	 0��6'   $
 0Q�63     5
      $	 0:0:0.5��6'   $
 0.495Q�69     5      $	 0:0:1��6'   $
 1Q�67   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� -   5         ��Name$ OnLoaded1_BeginStoryboard��5      #��[  6A   5      .��5      � -   5         �Name$
 grid��5      .+�5   
   �� -   5         ��Name$ 	rectangle��5      $��	-1,0,0,-1q�6'    �� RadiusX$ 25��6:    �� RadiusY$ 25��6G    J� RenderTransformOrigin$ 0.5,0.5&�6T   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5       �  � Color$ Black��6#   � 5!      $ White��6#    � Offset$ 1Q�61   � 5"      $ 	#FF0B568F��6#   $ 0.767Q�65   5#      5%      �� 5&   
   -   5         ��Name$ lblEmail��5&      $��E-mail :��6"   $
��Left=�65   $��28��6P   $��
126,11,0,0q�6\   $	��Top=�6p   $	��104��6�   
�������$��0,5,5,5q�6�   �� 5'   
   -   5        $ lblWachtwoord��5'      $��Wachtwoord :��6'   $
��Left=�6>   $��
126,79,0,0q�6Y   $	��104��6m   $��28��6y   $	��Top=�6�   
�������$��0,5,5,5q�6�   �� 5(   
   -   5         ��Name$ txtEmail��5(      $��34��6$   $��126,39,128,0q�60    �� TextWrapping$
 Wrap=�6F   $	��Top=�6Z   $��1q�6r   G� 5)   
   -   5         G�Name$ txtWachtwoord��5)      $��126,107,128,0q�6-   $��34��6D   $	��Top=�6P   �� 5*   
   -	   5         ��Name$ btnLogin��5*      $��Login��6#   $��31��63   $��197,0,197,43q�6?   $��Bottom=�6U    �� 	IsDefault . ���	#FF666666
�������  ButtonStyle1#���  6�   �� 5+   
   -
   5        $ btnClose��5+      $��Sluiten��6#   $��197,0,197,8q�65   $��Bottom=�6J   $��31��6e    �� IsCancel . 
����������	#FF666666#���  6�   �� 5,   
   -   5        $��
lblAccount��5,   b   $��Right=�6   $��28.48��6,   $��Bottom=�6;   $	��135��6V   .��5-      �� .�6   .�5.      �� -   5        $��Maak een account aan��5.      6p   5/      50      51      52      