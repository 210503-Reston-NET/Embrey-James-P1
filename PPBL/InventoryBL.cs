using System; 
using System.Collections.Generic; 
using PPDL;
using PPModels;
using Entity = PPDL.Entities;

namespace PPBL
{
    public class InventoryBL : IInventoryBL
    {
        
    private IRepository _repo;

    public InventoryBL(IRepository repo)
    {
        _repo = repo;
    }

    // // public Inventory AddInventory(Inventory inventoryitems)
    // // {
    // //     if(_repo.GetInventory(inventoryitems)!=null)
    // //     {
    // //         throw new Exception ("Order already exists!");
    // //     }
    // //     return _repo.AddInventory(inventoryitems);
    // // }

    // // public Inventory GetInventory(Inventory inventoryitems)
    // // {
    // //     return _repo.GetInventory(inventoryitems);
    // // }

    public void UpdateInventory(Inventory inventory2BeUpdated)
    {
        _repo.UpdateInventory(inventory2BeUpdated);
    }

    public void DecrementInventory(Inventory inventory)
    {
        _repo.DecrementInventory(inventory);
    }

    public Inventory GetInventory(int prod, int loc)
    {
        return _repo.GetInventory(prod, loc);
    }
    

    }
}