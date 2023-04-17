using OnlineOrdersManagement.Infrastructure.Commands;
using OnlineOrdersManagement.Models;
using OnlineOrdersManagement.Services;
using OnlineOrdersManagement.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OnlineOrdersManagement.ViewModels
{
    internal class OrderItemViewModel : ViewModel
    {
        #region Fields and props
        private IDialogService _dialogService;
        private OrdersRepository _ordersRepo;        
        private DbRepository<Clients> _clientsRepo;
        private DbRepository<Statuses> _statusesRepo;
        private int id;
        public bool IsAddOrder { get => id == -1; }

        private int _orderID;
		public int OrderID
		{
			get => _orderID;
			set => Set(ref _orderID, value);
		}

		private DateTime _orderDate;
		public DateTime OrderDate
		{
			get => _orderDate;
			set => Set(ref _orderDate, value);
		}

		private decimal _sum;
		public decimal Sum
		{
			get => _sum;
			set => Set(ref _sum, value);
		}

        public ObservableCollection<Statuses> Statuses { get; set; }

        private Statuses _status;
		public Statuses Status
		{
			get => _status;
			set => Set(ref _status, value);
		}

        public ObservableCollection<Clients> Clients { get; set; }

        private Clients _client;
		public Clients Client
		{
			get => _client;
			set => Set(ref _client, value);
		}

		private string _Comment;
        public string Comment
		{
			get => _Comment;
			set => Set(ref _Comment, value);
		}
        #endregion

        #region Commands
        #region LoadCommand
        public ICommand LoadCommand { get; private set; }

        private void Load(object obj)
        {
            Clients.Clear();
            var clientsCol = _clientsRepo.Items.ToList();
            foreach (var item in clientsCol)
                Clients.Add(item);

            Statuses.Clear();
            var statCol = _statusesRepo.Items.ToList();
            foreach (var item in statCol)
                Statuses.Add(item);

            if (id > 0)
            {
                Orders order = _ordersRepo.GetByID(id);

                OrderID = order.ID;
                OrderDate = order.OrderDate;
                Sum = order.Sum;
                Client = Clients.FirstOrDefault(c => c.ID == order.ClientID);
                Status = Statuses.FirstOrDefault(c => c.ID == order.StatusID);
                Comment = order.ClientComment;
            }
            else
            {
                OrderID = 0;
                OrderDate = DateTime.Now;
                Sum = 0;
                Client = Clients[0];
                Status = Statuses[0];
                Comment = String.Empty;
            }
        }
        #endregion

        #region SaveCommand
        public ICommand SaveCommand { get; private set; }

        private void SaveOrder(object obj)
        {
            Orders Order = new Orders
            {
                ID = OrderID,
                OrderDate = OrderDate,
                Sum = Sum,
                ClientID = Client.ID,
                StatusID = Status.ID,
                ProductsItems = "",
                ClientComment = Comment
            };

            if (id == -1)
            {
                if (_ordersRepo.Items.FirstOrDefault(o => o.ID == OrderID) is null)
                    _ordersRepo.Add(Order);
                else
                    MessageBox.Show("Заказ с данным номером уже существует. При необходимости отредактируйте его.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
               _ordersRepo.Update(Order, OrderID);
            }                

            _dialogService.Close(true);
        }
        #endregion

        #region CancelCOmmand
        public ICommand CancelCommand { get; private set; }

        private void Cancel(object obj)
        {
            _dialogService.Close(false);
        }
        #endregion
        #endregion

        public OrderItemViewModel(IDialogService dialogService, OrdersRepository OrdersRepo, DbRepository<Statuses> statusesRepo, DbRepository<Clients> clientsRepo)
        {
            _dialogService = dialogService;
            _ordersRepo = OrdersRepo;
            _statusesRepo = statusesRepo;
            _clientsRepo = clientsRepo;

            Clients = new ObservableCollection<Clients>();
            Statuses = new ObservableCollection<Statuses>();
            LoadCommand = new RelayCommand(Load, (p) => true);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(SaveOrder, (p) => true);
        }

        public override void OnNavigatedTo(object parameter)
        {
            var p = parameter as int?;
            if (p.HasValue)
                id = p.Value;
            else
                id = -1;
        }
    }
}
