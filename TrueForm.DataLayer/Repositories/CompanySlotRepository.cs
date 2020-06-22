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
using TrueForm.DataLayer.Repositories.Interfaces;

namespace TrueForm.DataLayer.Repositories
{
    public class CompanySlotRepository : GenericRepository<CompanySlot>, ICompanySlotRepository
    {
        public CompanySlotRepository(TrueFormDbContext context) : base(context)
        {

        }
         

        public CompanySlot FindOne(int slotId)
        {
            var companySlot = Context.CompanySlots.FirstOrDefault(x => x.SlotId == slotId);
            return companySlot;
        }

        public CompanySlot FindCompanyBySlotId(int slotId)
        {
            var companySlot = Context.CompanySlots.FirstOrDefault(x => x.SlotId == slotId);
            return companySlot;
        }

        public CompanySlot FindOne(int companyId, int slotId)
        {
            var companySlot = Context.CompanySlots.FirstOrDefault(x => x.CompanyId == companyId && x.SlotId == slotId);
            return companySlot;
        }
    }
}