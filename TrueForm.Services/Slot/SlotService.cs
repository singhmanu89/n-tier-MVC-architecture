using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.Interfaces.Slot;
using TrueForm.BusinessObjects.Serializers;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Slot;
using TrueForm.DataLayer.Repositories.Interfaces;
using TrueForm.Services.Infrastructure;

namespace TrueForm.Services.Slot
{
    public class SlotService : ApplicationService, ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        private readonly ICompanySlotRepository _companySlotRepository;

        public SlotService(ISlotRepository slotRepository,ICompanySlotRepository companySlotRepository)
        {
            _slotRepository = slotRepository;
            _companySlotRepository = companySlotRepository;
        }
         
        public TrueFormPagedList<SlotViewModel> GetSlotsByKioskIdAndTierTypeId(int kioskId, SystemDataListEnums.TierType tierTypeId)
        {
            var slots = _slotRepository.Filter(kioskId,tierTypeId); 
            return slots.ToViewModel();
        }

        public TrueFormPagedList<SlotViewModel> GetSlotsByKioskId(int kioskId)
        {
            var slots = _slotRepository.Filter(kioskId); 
            return slots.ToViewModel();
        }
    }
}
