using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.DataLayer.Repositories.Interfaces
{
    public interface ICompanySlotRepository : IGenericRepository<CompanySlot>
    {
        CompanySlot FindOne(int slotId);
        CompanySlot FindCompanyBySlotId(int slotId);

        CompanySlot FindOne(int companyId, int slotId); 
    }
}
