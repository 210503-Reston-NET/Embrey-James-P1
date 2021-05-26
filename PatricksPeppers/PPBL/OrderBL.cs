using System; 
using System.Collections.Generic; 
using PPDL;
using PPModels;

namespace PPBL
{
    public class OrderBL : IOrderBL
    {
        
    private IRepository _repo;

    public OrderBL(IRepository repo)
    {
        _repo = repo;
    }

    public Orders AddOrder(Orders orders)
    {
        if(_repo.GetOrders(orders)!=null)
        {
            throw new Exception ("Order already exists!");
        }
        return _repo.AddOrder(orders);
    }

    public Orders GetOrders(Orders orders)
    {
        return _repo.GetOrders(orders);
    }

    public void UpdateOrder(Orders order2BeUpdated)
    {
        _repo.UpdateOrder(order2BeUpdated);
    }
    }
}
