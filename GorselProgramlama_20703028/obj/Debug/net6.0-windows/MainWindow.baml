   M S B A M L   `   `   `  ����U  QGorselProgramlama_20703028, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GorselProgramlama_20703028GorselProgramlama_20703028  5   	   b ^Microsoft.VisualBasic.Core, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aaGclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic.CoreMicrosoft.VisualBasic 5   	   d `System.Collections.NonGeneric, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a^Gclr-namespace:System.Collections;assembly=System.Collections.NonGenericSystem.Collections 6e   +    %GorselProgramlama_20703028.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:GorselProgramlama_20703028     5   	   _VisualBasicGclr-namespace:Microsoft.VisualBasic;assembly=Microsoft.VisualBasic.Core     5   	   _CollectionsGclr-namespace:System.Collections;assembly=System.Collections.NonGeneric     6e   -   5          � Title$  Kütüphane Yardımcısı��5	   	   $	��600��6&   $
��1024��63    � 
ResizeMode$ NoResize=�6]    � Icon$ 
/Kitap.ico��6s    � WindowStartupLocation$ CenterScreen=�6�   .��5
      � $��Center=�6   .+�5   
   �� $��	Kitap No:��6   $
��Left=�6$   $��0,18,0,0q�6?   $	��Top=�6Q   �� 5   
   -   5        $��KitapNo��5      $
��Left=�6!   $��	60,23,0,0q�6<    �� TextWrapping$ NoWrap=�6O   $�� ��6e   $	��Top=�6m   $	��120��6�   �� 5   
   $��Yazar:��6   $
��Left=�6!   $��
186,18,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ Yazarlar��5      $
��Left=�6%   $��
226,21,0,0q�6@   $	��Top=�6T   $	��120��6l    �� DisplayMemberPath$
 Text��6x   �� 5   
   $��Kitap Adı:��6   $
��Left=�6%   $��
361,18,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $��KitapAdi��5      $
��Left=�6#   $��
421,21,0,0q�6>   $ NoWrap=�6R   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   $��Sayfa Sayısı:��6   $
��Left=�6(   $��
554,18,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $��SayfaSayisi��5      $
��Left=�6%   $��
627,21,0,0q�6@   $ NoWrap=�6T   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   -   5        $	��Ara��5      $
��Left=�6   $��
762,21,0,0q�6:   $	��Top=�6N   $��60��6f   6q   �� 5   
   -   5        $��
EkleButton��5      $
��Ekle��6#   $
��Left=�62   $��
827,21,0,0q�6M   $	��Top=�6a   $��60��6y   6�   �� 5   
   -   5        $��Temizle��5      $
��Left=�6#   $��
892,21,0,0q�6>   $	��Top=�6R   $��60��6j   6u   �� 5   
   $	��500��6   $	��952��6   $��0,61,0,0q�6+   $��Center=�6=   $	��Top=�6Z   .@�5      &   System.Windows.Controls.DataGrid  -	   5        $��Kitaplik��5         AutoGenerateColumns$ False��6'      CanUserAddRows$ False��6C   	   CanUserDeleteRows$	 False��6Z   
   CanUserResizeRows$
 False��6t      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Kitap No��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *ID+  5      $ Yazar��6)   $	 200 68    6D   �� *Yazar+  5      $ 
Kitap Adı��6)   $	 290 6<    6H   �� *Ad+  5!      $ Sayfa Sayısı��6)   $	 200 6?    6K   �� *Sayfa+4  .System.Windows.Controls.DataGridTemplateColumn  5#      $ Olaylar��6-   $	 145 6>      CellTemplate 5$      �� 5%      .R�5&   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5'   &   �� -
   5        $��Düzenle��5'   -   $��72��6T   �� 5(   &   -   5        $	��Sil��5(   -   $��72��6L   5)   #   5*      5,      50      51      52      53      