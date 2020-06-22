using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.DataLayer.Repositories.Interfaces
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Location FindOne(int locationId);
        IEnumerable<Location> Filter(int pageNumber, int pageSize);
    }
}
