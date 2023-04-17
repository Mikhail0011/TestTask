using OnlineOrdersManagement.ViewModels.Base;
using OnlineOrdersManagement.Models;
using System.Collections.Generic;
using System.Linq;
using OnlineOrdersManagement.Services;
using System.Windows.Input;
using OnlineOrdersManagement.Infrastructure.Commands;

namespace OnlineOrdersManagement.ViewModels
{
    internal class OrdersViewModel : ViewModel
    {
        #region Fields and props
        
        private IDialogService _dialogService;
        private OrdersRepository _ordersRepo;
        private DbRepository<Clients> _clientsRepo;
        private DbRepository<Statuses> _statusesRepo;        

        private List<Clients> _clientsList;
        public List<Clients> ClientsList { get => _clientsList; set => Set(ref _clientsList, value); }

        private Clients _selectedClient;
        public Clients SelectedClient
        {
            get => _selectedClient;
            set 
            {
                Set(ref _selectedClient, value);
                GetOrders();
            }
        }

        private List<Statuses> _statusesList;
        public List<Statuses> StatusesList { get => _statusesList; set => Set(ref _statusesList, value); }

        private Statuses _selectedStatus;
        public  Statuses SelectedStatus
        {
            get => _selectedStatus;
            set
            { 
                Set(ref _selectedStatus, value);
                GetOrders();
            } 
        }       

        public List<Orders> _ordersList;
        public List<Orders> OrdersList { get => _ordersList; set => Set(ref _ordersList, value); }

        private Orders _selectedOrder;
        public Orders SelectedOrder { get => _selectedOrder; set => Set(ref _selectedOrder, value); }       
        #endregion

        #region Commands

        #region AddCommand
        public ICommand AddCommand { get; private set; }

        private void AddOrder(object commandParameter)
        {
            bool update = false;
            _dialogService.ShowDialog(typeof(OrderItemViewModel), null, (dialogResult, p) =>
            {
                update = dialogResult;
            });

            if (update)
                GetOrders();
        }
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand { get; private set; }

        private bool CanDeleteOrder(object arg)
        {
            return !(arg as Orders is null);
        }

        private void DeleteOrder(object obj)
        {
            _ordersRepo.Delete(SelectedOrder);
            GetOrders();
        }
        #endregion

        #region EditCommand

        public ICommand EditCommand { get; private set; }

        private bool CanEditOrder(object arg)
        {
            return !(arg as Orders is null);
        }

        private void EditOrder(object obj)
        {
            bool update = false;
            _dialogService.ShowDialog(typeof(OrderItemViewModel), SelectedOrder.ID, (dialogResult, p) =>
            {
                update = dialogResult;
            });

            if (update)
                GetOrders();
        }

        #endregion

        #region LoadCommand
        public ICommand LoadCommand { get; private set; }

        private void Load(object obj)
        {
            GetAllClients();
            GetAllStatuses();
        }
        #endregion

        #endregion

        public OrdersViewModel(IDialogService dialogService, OrdersRepository ordersRepo, DbRepository<Statuses> statRepo, DbRepository<Clients> clientRepo)
        {
            _dialogService = dialogService; 

            _ordersRepo = ordersRepo;
            _statusesRepo = statRepo;
            _clientsRepo = clientRepo;

            LoadCommand = new RelayCommand(Load);
            EditCommand = new RelayCommand(EditOrder, CanEditOrder);
            DeleteCommand = new RelayCommand(DeleteOrder, CanDeleteOrder);
            AddCommand = new RelayCommand(AddOrder);

            _selectedClient = new Clients();
            _selectedStatus = new Statuses();
        }

        private void GetAllClients()
        {
            var clients = _clientsRepo.Items.ToList();
            clients.Insert(0, new Clients() { ID = 0, Lastname = "Все" });
            ClientsList = clients;
        }

        private void GetAllStatuses()
        {
            var statuses = _statusesRepo.Items.ToList();
            statuses.Insert(0, new Statuses() { ID = 0, Name = "Все" });
            StatusesList = statuses;
        }

        private void GetOrders()
        {
            OrdersList = _ordersRepo.GetByClientStatusId(_selectedClient.ID, _selectedStatus.ID).ToList(); 
        }
    }
}
