   M S B A M L   `   `   `  ����Q  MOnlineOrdersManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:OnlineOrdersManagement.ViewModels!OnlineOrdersManagement.ViewModels  5   	   '    !OnlineOrdersManagement.OrdersView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   E	viewmodel/clr-namespace:OnlineOrdersManagement.ViewModels     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	     � Title$#  Интернет заказы��5
   	   $	��400��6!   $	��600��61   $	��400��6@   $	��600��6M    � WindowStartupLocation$ CenterScreen=�6Y   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��50* �6   �� 5      $	��50* �6    � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��60* �6   �� 5      $	��20* �6   .+�5   
   �� $��Клиент:��6   $��0��6#   $��0��63   $��50,0,0,0q�6@   $
��Left=�6R   $��Center=�6m   �� 5   
   $��0��6   $��0��6#   $��	100,0,0,0q�60   $
��Left=�6C   $��Center=�6^    �� SelectedIndex$ 0��6y   ��5      �� *ClientsList+	 �� SelectedItem	 67   �� *SelectedClient+�� 5!   
   $��Статус:��6   $��1��6#   $��0��63   $��50,0,0,0q�6@   $
��Left=�6R   $��Center=�6m   �� 5"   
   $��1��6   $��0��6#   $��	100,0,0,0q�60   $
��Left=�6C   $��Center=�6^   $ 0��6y   ��5#      �� *StatusesList+	 68   �� *SelectedStatus+&   System.Windows.Controls.DataGrid  5%   
   $��1��6   $��2��6!   $��Center=�65   $��Center=�6R   $	��500��6m   $	��200��6|   
   AutoGenerateColumns
 .     
IsReadOnly . ��5'      �� *
OrdersList+	 67   �� *SelectedOrder+   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ № Заказа��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *ID+  5*      $ Дата создания��6%    6<   �� *	OrderDate+ �� StringFormat$ dd.MM.yyyy HH:mm��  5+      $ Сумма, р.��6%    68   �� *Sum+  5,      $ Статус��6%    65   �� *
Statuses+  5-      $ Клиент��6%    65   �� *	Clients+  5.      $ Комментарий��6%    6:   �� *ClientComment+50      � 52   
   $��1��6   $��2��6    53      �� 54      $	��50* �6#   �� 55      $	��50* �6#   �� 56      $	��45* �6#   .+�59      �� $��0��6   $��Изменить��6%   $
��10 3q�68   $��Center=�6G   $��Center=�6d   ��6   �� *EditCommand+��6�   �� *SelectedOrder+�� 5:      $��1��6   $��Добавить��6%   $
��10 3q�68   $��Center=�6G   $��Center=�6d   ��6   �� *
AddCommand+�� 5;      $��2��6   $��Удалить��6%   $
��10 3q�67   $��Center=�6F   $��Center=�6c   ��6~   �� *DeleteCommand+��6�   �� *SelectedOrder+5<      5=      5>      