using System;

namespace OnlineOrdersManagement.Services
{
    public interface INavigationService
    {
        event EventHandler<NavigationEventArgs> ViewModelChanged;

        void Navigate(Type type, object parameter = null);
    }
}