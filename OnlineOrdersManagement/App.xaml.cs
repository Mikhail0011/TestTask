using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineOrdersManagement.Infrastructure.Interfaces;
using OnlineOrdersManagement.Models;
using OnlineOrdersManagement.Services;
using OnlineOrdersManagement.ViewModels;
using OnlineOrdersManagement.Views.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineOrdersManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private readonly OrdersView _window;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INavigationService, NavigationService>();
                    services.AddSingleton<IDialogService, DialogService>();

                    services.AddTransient<OrderItemView>();
                    services.AddSingleton<OrdersView>();

                    services.AddSingleton<OrdersViewModel>();
                    services.AddTransient<OrderItemViewModel>();
                    services.AddSingleton<OnlineOrdersDBEntities>();
                    services.AddSingleton<OrdersRepository>();
                    services.AddSingleton<DbRepository<Clients>>();
                    services.AddSingleton<DbRepository<Statuses>>();
                })
                .Build();
            _window = _host.Services.GetRequiredService<OrdersView>();
            _window.DataContext = _host.Services.GetRequiredService<OrdersViewModel>();
            _window.ShowDialog();
        }
    }
}
