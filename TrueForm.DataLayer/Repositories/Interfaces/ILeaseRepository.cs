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
    public interface ILeaseRepository : IGenericRepository<Lease>
    {
        Lease FindOne(int leaseId); 
        IPagedList<Lease> Filter(int kioskId);
    }
}
