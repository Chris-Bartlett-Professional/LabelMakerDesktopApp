   M S B A M L   `   `   `  ����P  LLabelMakerApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LabelMakerApplicationLabelMakerApplication  5   	   *    $LabelMakerApplication.SettingsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:LabelMakerApplication     5   	     � Title$  Settings��5   	   $	��540��6   $	��400��6'   ��5
      �� 5   
    �� ImageSource$$ /SalesOrderLabelBackground.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��313* �6   �� 5      $
��124* �6   .+�5   
   �� $��Company Name��6   $��0��6)   $��0��66   $��75��6F   $��
0,0,10,394q�6U   $��2��6i   .��5      �� -   5         ��Name$ TextBoxCompanyName��5      $
��auto��62   $��25��6?   5      �� 5   
   $)��#Path to Company Logo (.jpg or .png)��6   $��0��6@   $��0��6M   $��75��6]   $��0,88,10,306q�6l   $��2��6�   .��5      �� -   5        $ TextBoxPathToLogo��5      $
��auto��61   $��25��6>   $��0,0,40,0q�6J   5      �� 5   
   -   5        $��ButtonFileDialog��5      $��25��6)   $��25��65   $��59,121,21,328q�6@   $��1��6W   ��5      �� 5      $ /folder icon.webp��6   5      �� 5   
   -   5        $��ButtonSaveSettings��5      $
��Save��6,   $��25,199,120,278q�6;   6S   �� 5   
   -   5        $��ButtonCancelSettings��5      $��Cancel��6-   $��227,199,28,278q�6>   $��2��6V   6j   5#      5$      