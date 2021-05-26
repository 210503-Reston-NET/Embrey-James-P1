using PPModels;
using System.Collections.Generic;

namespace PPBL
{
    public interface IOrderBL
    {
        Orders AddOrder(Orders orders);
        Orders GetOrders(Orders orders);
        void UpdateOrder(Orders order2BeUpdated);
    }
}