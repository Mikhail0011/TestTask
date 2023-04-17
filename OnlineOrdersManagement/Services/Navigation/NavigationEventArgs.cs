using OnlineOrdersManagement.ViewModels.Base;
using System;

namespace OnlineOrdersManagement.Services
{
    public class NavigationEventArgs: EventArgs
    {
        public ViewModel ViewModel { get; set; }
        public object Parameters { get; set; }
    }
}
