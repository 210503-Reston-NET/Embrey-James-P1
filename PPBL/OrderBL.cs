using System; 
using System.Collections.Generic; 
using PPDL;
using PPModels;

namespace PPBL
{
    public class OrderBL : IOrderBL
    {
        
    public IRepository _repo;

    public OrderBL(IRepository repo)
    {
        _repo = repo;
    }

    public Order AddOrder(Order orders)
    {
        if(_repo.GetOrders(orders)!=null)
        {
            throw new Exception ("Order already exists!");
        }
        return _repo.AddOrder(orders);
    }

    public Order GetOrders(Order orders)
    {
        return _repo.GetOrders(orders);
    }

    public void UpdateOrder(Order order2BeUpdated)
    {
        _repo.UpdateOrder(order2BeUpdated);
    }
    }
}
