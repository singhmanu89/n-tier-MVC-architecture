using System.Collections.Generic;
using System.Linq;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.BindingModels.Location;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Location;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Generic;

namespace TrueForm.BusinessObjects.Interfaces.Location
{
    public interface ILocationService
    {
        LocationViewModel GetLocationById(int locationId);
        LocationViewModel InsertLocation(LocationBindingModel model);
        IEnumerable<LocationViewModel> GetLocations(int pageNumber, int pageSize);
    }
}
