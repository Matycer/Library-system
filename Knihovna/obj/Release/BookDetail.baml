   M S B A M L   `   `   `  ����   Knihovna    Knihovna.BookDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  
BookDetail��$	��510��$	��700��$	��800��$	��400��.���  � ColumnDefinitions �� $
��240* ��� $
��579* � � RowDefinitions �� $
��220* ��� $	��120 �.+��� -    ��Name$ imgBook��$��0��$��Stretch=�$��	10,10,0,5q�$��Stretch=�$��Uniform=�$y�	Collapsed=��� -   $ imgBookPlaceholder��$��0��$
��Left=�$��
10,10,0,30q�$��Stretch=�$	��220���� -    ��Name$ txtName��$��0��$��1�� �� 
LineHeight$ 10��$
��Left=�$��
15,10,10,0q�$��	TextBlock��$	��Top=�$��25(�$
��Wrap=�$��ExtraCondensed&�$��WordEllipsis=�$��Segoe WP)��� -   $ 	txtAuthor��$��0��$
��Left=�$��
15,107,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��17(�$
��Bold"�$��1���� -   $ txtGenre��$��0��$
��Left=�$��
15,155,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��17(�$
��Bold"�$��1��� -    �Name$ gridLoad��$��6,0,0,0q�$
��Left=�$��Bottom=�$	��200��$��40��.+��� $
��Left=�$��0,10,0,0q�$
��Wrap=�$��Načítání obálky...��$	��Top=�$��14(�� $
��Left=�$��10��$��0,0,0,3q�$��Bottom=�$	��178�� � IsIndeterminate . �� -   $ txtAuthor_Copy��$��0��$
��Left=�$��	15,90,0,0q�$
��Wrap=�$��Autor��$	��Top=�$��15(�$
��Thin"�$��1���� -	   $ txtAuthor_Copy1��$��0��$
��Left=�$��
15,138,0,0q�$
��Wrap=�$��Žánr��$	��Top=�$��15(�$
��Thin"�$��1���� -
   $ txtAuthor_Copy2��$��0��$
��Left=�$��
15,184,0,0q�$
��Wrap=�$��Vydavatelství��$	��Top=�$��15(�$
��Thin"�$��1���� -   $ txtPublisher��$��0��$
��Left=�$��
15,200,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��17(�$
��Bold"�$��1���� -   $ txtAuthor_Copy3��$��0��$
��Left=�$��
16,229,0,0q�$
��Wrap=�$��Rok vydání��$	��Top=�$��15(�$
��Thin"�$��1���� -   $ txtPublished��$��0��$
��Left=�$��
16,245,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��17(�$
��Bold"�$��1��� $��Stretch=�$��Stretch=�$��1��$��2�����	#FFB0B0B0.+�� $��Center=�.+�� $
��Left=�$	��100��$��	10,12,0,0q�$	��Top=�$	��200�����	#FFE6E6E6.+��� -   $ txtAuthor_Copy4��$
��Left=�$��	10,10,0,0q�$
��Wrap=�$��Khihy celkem��$	��Top=�$��18(�$
��Thin"��� -   $ txtTotalBooks��$
��Left=�$��	10,40,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��35(�� $
��Left=�$	��100��$��
250,12,0,0q�$	��Top=�$	��200�����	#FFE6E6E6.+��� -   $ txtAuthor_Copy6��$
��Left=�$��	10,10,0,0q�$
��Wrap=�$��Dostupné knihy��$	��Top=�$��18(�$
��Thin"��� -   $ txtAvailableBooks��$
��Left=�$��	10,40,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$��35(�� $
��Left=�$	��100��$��490,12,-34,0q�$	��Top=�$	��200�����	#FFE6E6E6.+��� -   $ txtAuthor_Copy5��$
��Left=�$��	10,10,0,0q�$
��Wrap=�$��Vypůjčenné knihy��$	��Top=�$��18(�$
��Thin"��� -   $ txtBorrowedBooks��$
��Left=�$��	10,40,0,0q�$
��Wrap=�$��0��$	��Top=�$��35(��� -   $
��Left=�$��
157,76,0,0q�$
��Wrap=�$��Detail��$	��Top=� � Cursor$
 Hand��$��	Underline{����	#FF590000