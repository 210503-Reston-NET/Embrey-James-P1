using System; 
using System.Collections.Generic; 
using PPDL;
using PPModels;

namespace PPBL
{
    public class LocationBL : ILocationBL
    {
        public IRepository _repo;

    public LocationBL(IRepository repo)
    {
        _repo = repo;
    }

    public int GetLocation(string location)
    {
        return _repo.GetLocation(location);
    }

    public List<Location> GetAllLocations()
        {
            return _repo.GetAllLocations();
        }

    }
}