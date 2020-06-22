using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.Serializers;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.DataLayer.Repositories.Interfaces;
using TrueForm.Services.Infrastructure;

namespace TrueForm.Services.Kiosk
{
    public class KioskService : ApplicationService, IKioskService
    {
        private readonly IKioskRepository _kioskRepository; 
        private readonly ISlotRepository _slotRepository;

        public KioskService(IKioskRepository kioskRepository ,
            ISlotRepository slotRepository)
        {
            _kioskRepository = kioskRepository; 
            _slotRepository = slotRepository;
        }

        public KioskViewModel GetKioskById(int kioskId)
        {
            var kiosk = _kioskRepository.FindOne(kioskId);
            var viewModel = kiosk.ToViewModel();
            return viewModel;
        }

        public KioskViewModel InsertKiosk(KioskBindingModel model, int companyId)
        {
            var kiosk = model.ToEntity();
            kiosk = _kioskRepository.Add(kiosk);
            CurrentUnitOfWork.Commit();
            
            foreach (var type1SlotName in model.Type1Slots)
            {
                var slot = model.ToSlotEntity(kiosk.Id, SystemDataListEnums.TierType.Tier1, type1SlotName);
                _slotRepository.Add(slot);
                CurrentUnitOfWork.Commit();
            }

            foreach (var type2SlotName in model.Type2Slots)
            {
                var slot = model.ToSlotEntity(kiosk.Id, SystemDataListEnums.TierType.Tier2, type2SlotName);
                _slotRepository.Add(slot);
                CurrentUnitOfWork.Commit();
            }
            
            kiosk = _kioskRepository.FindOne(kiosk.Id);
            var viewModel = kiosk.ToViewModel();
            return viewModel;
        }

        public KioskViewModel GetKioskByLocationById(int locationId)
        {
            var kiosk = _kioskRepository.FindKioskByLocationId(locationId); 
            return kiosk.FirstOrDefault().ToViewModel();
        }

        public IEnumerable<KioskViewModel> GetAllKiosks()
        {
            var kiosk = _kioskRepository.Filter();
            return kiosk.ToListViewModel();
        }
    }
}
