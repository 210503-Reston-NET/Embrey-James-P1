using PPModels;
using System.Collections.Generic;

namespace PPBL
{
    public interface IInventoryBL
    {
        void UpdateInventory(Inventory inventory2BeUpdated);

        void DecrementInventory(Inventory inventory);

        Inventory GetInventory(int prod, int loc);
    }
}