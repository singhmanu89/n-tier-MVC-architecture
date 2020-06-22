using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.BindingModels.Location;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.Interfaces.Location;
using TrueForm.BusinessObjects.Serializers;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Location;
using TrueForm.DataLayer.Repositories.Interfaces;
using TrueForm.Services.Infrastructure;

namespace TrueForm.Services.Location
{
    public class LocationService : ApplicationService, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IKioskRepository _kioskRepository;

        public LocationService(ILocationRepository locationRepository, IKioskRepository kioskRepository)
        {
            _locationRepository = locationRepository;
            _kioskRepository = kioskRepository;
        }

        public LocationViewModel GetLocationById(int locationId)
        {
            var location = _locationRepository.FindOne(locationId);
            var viewModel = location.ToViewModel();
            return viewModel;
        }

        public IEnumerable<LocationViewModel> GetLocations(int pageNumber, int pageSize)
        {
            var location = _locationRepository.Filter(pageNumber, pageSize);
            var viewModel = location.ToViewModel();
            return viewModel;
        }

        public LocationViewModel InsertLocation(LocationBindingModel model)
        {
            var location = model.ToEntity();
            location = _locationRepository.Add(location);
            CurrentUnitOfWork.Commit();

            location = _locationRepository.FindOne(location.Id);
            var viewModel = location.ToViewModel();
            return viewModel;
        }
    }
}
