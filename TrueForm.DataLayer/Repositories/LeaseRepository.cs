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
    public class LeaseRepository : GenericRepository<Lease>, ILeaseRepository
    {
        public LeaseRepository(TrueFormDbContext context) : base(context)
        {

        }
         
        IPagedList<Lease> ILeaseRepository.Filter(int kioskId)
        {
            var leases = Context.Leases.Where(x => x.KioskId == kioskId)
                .OrderByDescending(o => o.Id).ToPagedList(1, 1000);
            return leases;
        }
         
        public Lease FindOne(int leaseId)
        {
            var lease = Context.Leases.FirstOrDefault(x => x.Id == leaseId);
            return lease;
        }
         
    }
}