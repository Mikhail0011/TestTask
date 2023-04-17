using OnlineOrdersManagement.ViewModels.Base;
using OnlineOrdersManagement.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace OnlineOrdersManagement.Services
{
    public class DialogService : IDialogService
    {
        private readonly IHost _host;

        private OrderItemView _dialogWindow;
        private Action<bool,object> _callback;

        public bool IsOpen { get; set; }

        public DialogService(IHost host)
        {
            _host = host;
        }

        public void ShowDialog(Type type, object parameter = null, Action<bool,object> callback = null)
        {
            ViewModel viewModel = _host.Services.GetService(type) as ViewModel ?? throw new ArgumentNullException($"Services for type {type.FullName} has not been registered.");
            _dialogWindow = _host.Services.GetRequiredService<OrderItemView>();
            viewModel.OnNavigatedTo(parameter);
            _callback = callback;
            _dialogWindow.DataContext = viewModel;
            IsOpen = true;
            _dialogWindow.Owner = _host.Services.GetRequiredService<OrdersView>();
            _dialogWindow.ShowDialog();
        }

        public void Close(bool dialogResult,object parameter = null)
        {
            if (!IsOpen)
                return;

            _dialogWindow.DialogResult = true;
            _dialogWindow.Close();
            IsOpen = false;
            _callback?.Invoke(dialogResult,parameter);
        }
    }
}
