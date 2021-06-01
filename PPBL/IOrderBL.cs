using PPModels;
using System.Collections.Generic;

namespace PPBL
{
    public interface IOrderBL
    {
        Order AddOrder(Order orders);
        Order GetOrders(Order orders);
        void UpdateOrder(Order order2BeUpdated);
    }
}