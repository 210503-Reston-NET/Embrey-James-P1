using System.Collections.Generic;
using PPModels;

namespace PPBL
{
    public interface ILocationBL
    {
        int GetLocation(string location);

        List<Location> GetAllLocations();
    }
}