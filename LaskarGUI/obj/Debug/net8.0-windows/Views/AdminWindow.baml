   M S B A M L   `   `   `  ����  	LaskarGUI!    LaskarGUI.Views.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Admin Panel��5   	   $	��500��6   $	��650��6*    � WindowStartupLocation$ CenterScreen=�66   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��False��6!   $��0,0,0,10q�67   .+�5      �� $��👤 Manajemen Akun Guru��6   $��20(�5      $
��Bold"�5      $��Center=�5      $
��Left=�5      �� 5      -   5        $��Logout��5      
���  ��
�������$��80��5      $��Right=�5      $��Right=�5      5      �� 5"   
   -   5        $��1��5"      $��➕ Tambah Akun Guru��5#      $	��160��5$      $��30��5%      
��� � �
�������$
��Left=�5'      $��0,0,0,10q�5)      &   System.Windows.Controls.DataGrid  5,   
   -   5        $��GuruDataGrid��5-      $��2��5,         AutoGenerateColumns$ False��5.         
IsReadOnly$
 True��5/         CanUserAddRows$ False��50         SelectionMode$ Single=�51      $��0,10,0,0q�52         Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nama��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 2* 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   ��  �� Path$
 Nama�6Q     55      $ Username��6%   $	 2* 6Y   
 67   �� $ Username�6Y   4  .System.Windows.Controls.DataGridTemplateColumn  57      $
 Aksi��6)   $		 160 67      CellTemplate 58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5;   "   �� -   5        $
��Edit��5;   )   $	��5,0q�68   $	��5,2q�6E   
��� � �
�������6{   �� 5<   "   -   5        $��Hapus��5<   )   $	��5,0q�69   $	��5,2q�6F   
���  ��
�������5=   M   5>      5?      5A      5C      5E      5F      