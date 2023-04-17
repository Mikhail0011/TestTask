using OnlineOrdersManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineOrdersManagement.Services
{
    internal class OrdersRepository : DbRepository<Orders>
    {
        public OrdersRepository(OnlineOrdersDBEntities db) : base(db) { }

        public IEnumerable<Orders> GetByClientStatusId(int clientId, int statusId) => Items
            .Where(order => (clientId == 0 || order.ClientID == clientId) && (statusId == 0 ||order.StatusID == statusId));

        public Orders GetByID(int id) => Items.First(o => o.ID == id);

    }
}
