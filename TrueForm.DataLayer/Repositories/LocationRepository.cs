using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.BindingModels.Location;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Location;
using TrueForm.DataLayer.Infrastructure;
using TrueForm.DataLayer.Repositories.Interfaces;

namespace TrueForm.DataLayer.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(TrueFormDbContext context) : base(context)
        { 

        }
        public Location FindOne(int locationId)
        {
            var location = Context.Locations.FirstOrDefault(x => x.Id == locationId);
            return location;
        }

        public IEnumerable<Location> Filter(int pageNumber, int pageSize)
        {
            var locations = Context.Locations.OrderByDescending(o => o.Id).ToList();
            return locations;
        }
 
    }
}