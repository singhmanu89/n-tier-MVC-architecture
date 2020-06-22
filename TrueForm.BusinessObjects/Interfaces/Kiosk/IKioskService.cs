using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;

namespace TrueForm.BusinessObjects.Interfaces.Kiosk
{
    public interface IKioskService
    {
        KioskViewModel GetKioskById(int kioskId);
        KioskViewModel InsertKiosk(KioskBindingModel model, int companyId);
        KioskViewModel GetKioskByLocationById(int locationId);
        IEnumerable<KioskViewModel> GetAllKiosks();
    }
}
