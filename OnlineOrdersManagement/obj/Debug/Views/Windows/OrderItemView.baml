   M S B A M L   `   `   `  ����Q  MOnlineOrdersManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:OnlineOrdersManagement.ViewModels!OnlineOrdersManagement.ViewModels  5   	   8    2OnlineOrdersManagement.Views.Windows.OrderItemView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   @
viewmodels/clr-namespace:OnlineOrdersManagement.ViewModels  5   	     � Title$  
Заказ��5
   	   $	��400��6   $	��500��6'   $	��400��66   $	��500��6C    � WindowStartupLocation$ CenterOwner=�6O   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      �� $��10q�6   .+�5   
   �� $��№ Заказа��6   �� 5   
   ��6   �� *	OrderID+{�6+   �� *
IsAddOrder+�� 5   
   $��Дата создания��6   (  "System.Windows.Controls.DatePicker  5   
      SelectedDate 6   �� *	OrderDate+�� 5   
   $��
Сумма��6   �� 5   
   ��6   �� *Sum+�� 5   
   $��Статус��6   �� 5   
   ��6   �� *
Statuses+ �� SelectedItem 64   �� *Status+�� 5   
   $��Клиент��6   �� 5   
   ��6   �� *	Clients+ 63   �� *Client+�� 5   
   $��Комментарий��6   �� 5   
   ��6   �� *	Comment+� 5    
    � ColumnDefinitions 5!      �� 5"      �� 5#      .+�5%      �� $��0��6   $��Сохранить��6%   $��Center=�69   $��10q�6T   $��2q�6`   ��6l   �� *SaveCommand+�� 5&      $��1��6   $��Отмена��6%   $��Center=�66   $��10q�6Q   $��2q�6]   ��6i   �� *CancelCommand+5'      5(      5)      