using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Helpers;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Kiosk;

namespace TrueForm.Api.Controllers.Kiosk
{
    [Authorize]
    [RoutePrefix("api/kiosk")]
    public class KioskController : ApiController
    {
        private readonly IKioskService _kioskService;

        public KioskController(IKioskService kioskService)
        {
            _kioskService = kioskService;
        }

        [Route("")]
        public IEnumerable<KioskViewModel> GetAllKiosks()
        {
            return _kioskService.GetAllKiosks();
        }

        [Route("")]
        [HttpPost]
        public DataActionResponse InsertKiosk(KioskBindingModel model)
        {
            //var test = JObject.Parse(model.ToString()).Cast<KioskBindingModel>();
             
            return _kioskService.InsertKiosk(model, 1)
                                    .CreateDataActionResponseSuccess();
        }

        [Route("GetKiosksByLocationById/{locationId}")]
        public DataActionResponse GetKiosksByLocationById(int locationId)
        {
            return _kioskService.GetKioskByLocationById(locationId: locationId)
                                    .CreateDataActionResponseSuccess();
        }
    }
}
