using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Helpers;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.Interfaces.Slot;

namespace TrueForm.Api.Controllers.Slot
{
    [Authorize]
    [RoutePrefix("api/slot")]
    public class SlotController : ApiController
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [Route("GetSlotsByKioskIdAndTierTypeId/{slotId}/{tierTypeId}")]
        public DataActionResponse GetSlotsByKioskIdAndTierTypeId(int slotId, SystemDataListEnums.TierType tierTypeId)
        {
            return _slotService.GetSlotsByKioskIdAndTierTypeId(slotId, tierTypeId)
                                    .CreateDataActionResponseSuccess();
        }

        [Route("GetSlotsByKioskId/{kioskId}")]
        public DataActionResponse GetSlotsByKioskId(int kioskId)
        {
            return _slotService.GetSlotsByKioskId(kioskId)
                                    .CreateDataActionResponseSuccess();
        }

    }
}
