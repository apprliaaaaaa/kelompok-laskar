   M S B A M L   `   `   `  ����D  @LaskarGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LaskarGUI.ViewsLaskarGUI.Views  5   	        LaskarGUI.Views.GuruWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /viewsclr-namespace:LaskarGUI.Views     5   	     � Title$  
Guru Panel��5   	   $	��600��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   $��False��6!   .+�5      �� $%��📊 Catatan Perkembangan Siswa��6   $��20(�6=   $
��Bold"�6K   $��Center=�6]   �� 5      -   5        $��Logout��5      $��Right=�6A   
���  ��
�������$��80��6�   $��5,0,0,0q�6�   $��Right=�6�   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��	0,10,0,10q�6;   .+�5      �� .+�5      �� $��
Nama Siswa��6   �� 5      -   5        $��NamaSiswaBox��5      $	��120��6.   5      �� 5      .+�5      �� $��Nomor Induk��6   �� 5      -   5        $��NomorIndukBox��5      $	��100��6/   5      �� 5      .+�5      �� $��Kelas��6   �� 5      -   5        $��KelasBox��5      $��80��6*   5      �� 5       .+�5!      �� $��Semester��6   �� 5"      -   5        $��SemesterBox��5"      $��80��6-   5#      �� 5$      .+�5%      �� $��Tahun Ajaran��6   �� 5&      -   5        $��TahunAjaranBox��5&      $	��100��60   5'      5(      �� 5*   
   $��2��6   .+�5+      �� $��Catatan Agama��6   �� 5,      -   5        $��AgamaBox��5,      $��50��6&    �� TextWrapping$
 Wrap=�62   �� 5-      $��Catatan Jati Diri��6   �� 5.      -   5        $��JatiDiriBox��5.      $��50��6)   $
 Wrap=�65   �� 5/      $��Catatan Literasi dan STEM��6   �� 50      -	   5        $��LiterasiBox��50      $��50��6)   $
 Wrap=�65   �� 51      $��
Catatan P5��6   �� 52      -
   5        $��P5Box��52      $��50��6#   $
 Wrap=�6/   53      �� 55   
   $��3��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�56      �� -   5        $��Simpan Perkembangan��56      $	��180��63   $��0,0,10,0q�6?   
��� � �
�������6w   �� 57      -   5        $��Lihat Semua��57      $	��100��6+   $��0,0,10,0q�67   
�������
�������6|   59      5:      5;      