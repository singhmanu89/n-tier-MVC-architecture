using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrueForm.BusinessObjects.BindingModels.Location;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.Helpers;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Location;
using TrueForm.BusinessObjects.ViewModels.Location;

namespace TrueForm.Api.Controllers.Location
{
    [Authorize]
    [RoutePrefix("api/locations")]
    public class LocationController : ApiController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [Route("GetLocationById/{locationId}")]
        public DataActionResponse GetLocationById(int locationId)
        {
            return _locationService.GetLocationById(locationId: locationId)
                                    .CreateDataActionResponseSuccess();
        }

        [Route("")]
        public IEnumerable<LocationViewModel> GetAllLocations(int pageNumber = 1, int pageSize = 1000)
        {
            return _locationService.GetLocations(pageNumber, pageSize);
        }

        [Route("")]
        [HttpPost]
        public DataActionResponse InsertLocation(LocationBindingModel model)
        {
            return _locationService.InsertLocation(model)
                                    .CreateDataActionResponseSuccess();
        }


    }
}
