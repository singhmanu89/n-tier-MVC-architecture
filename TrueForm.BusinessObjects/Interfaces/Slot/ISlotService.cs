using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Slot;

namespace TrueForm.BusinessObjects.Interfaces.Slot
{
    public interface ISlotService
    {
        TrueFormPagedList<SlotViewModel> GetSlotsByKioskIdAndTierTypeId(int kioskId, SystemDataListEnums.TierType tierTypeId);
        TrueFormPagedList<SlotViewModel> GetSlotsByKioskId(int kioskId);  
    }
}
