using Microsoft.Extensions.Hosting;
using System;
using OnlineOrdersManagement.ViewModels.Base;

namespace OnlineOrdersManagement.Services
{
    public class NavigationService : INavigationService
    {
        public event EventHandler<NavigationEventArgs> ViewModelChanged;

        private readonly IHost _host;

        public NavigationService(IHost host)
        {
            _host = host;
        }

        public void Navigate(Type type, object parameter = null)
        {
            ViewModel viewModel = _host.Services.GetService(type) as ViewModel ?? throw new ArgumentNullException($"Services for type {type.FullName} has not been registered.");
            viewModel.OnNavigatedTo(parameter);

            ViewModelChanged?.Invoke(this, new NavigationEventArgs
            {
                ViewModel = viewModel,
                Parameters = parameter
            });
        }
    }
}
