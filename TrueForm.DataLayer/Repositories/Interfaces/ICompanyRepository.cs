using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.DataLayer.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Company FindOne(int companyId);
        IQueryable<Company> Filter(int companyId);
    }
}
