   M S B A M L   `   `   `  ����  	LaskarGUI,    &LaskarGUI.Views.PerkembanganListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Daftar Perkembangan Siswa��5   	   $	��450��5   	   $	��700��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PerkembanganGrid��5	         AutoGenerateColumns$ False��5
         
IsReadOnly$
 True��5         CanUserAddRows$ False��5         SelectionMode$ Single=�5         HeadersVisibility$ Column=�5       J� RenderTransformOrigin$ 0.5,0.5&�6.   z�5      V� 5      .~�5      �� �� 5      	 �� AngleY$	 0.136Q�6$   �� 5      T� 5      
 T� Y$
 0.807Q�6)   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nama��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	NamaSiswa+6Q     5      $ Kelas��6%   $	 100 6N    64   �� *Kelas+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5       $
 Aksi��6)   $	 220 67      CellTemplate 5!      �� 5"      .R�5#      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5$   "   �� -   5        $��Detail��5$   )   $	��5,0q�6:   $	��5,2q�6G   
��� � �
�������5&   4   �� 5'   "   -   5        $��Update��5'   )   $	��5,0q�6:   $	��5,2q�6G   
��� � �
�������5)   4   �� 5*   "   -   5        $��Hapus��5*   )   $	��5,0q�69   $	��5,2q�6F   
���  ��
�������5,   )   5-      5.      50      53      54      55      