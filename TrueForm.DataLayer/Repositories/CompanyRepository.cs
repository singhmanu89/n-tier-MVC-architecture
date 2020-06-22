using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.DataLayer.Infrastructure;
using TrueForm.DataLayer.Repositories.Interfaces;

namespace TrueForm.DataLayer.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(TrueFormDbContext context) : base(context)
        {
            
        }

        public Company FindOne(int companyId)
        {
            var company = Context.Company.FirstOrDefault(x => x.Id == companyId);
            return company;
        }

        public IQueryable<Company> Filter(int companyId)
        {
            var company = Context.Company.Where(x => x.Id == companyId);
            return company;
        }
    }
}