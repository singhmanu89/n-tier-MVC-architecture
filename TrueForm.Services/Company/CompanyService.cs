using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Serializers;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.DataLayer.Repositories.Interfaces;
using TrueForm.Services.Infrastructure;

namespace TrueForm.Services.Company
{
    public class CompanyService : ApplicationService, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public CompanyViewModel GetCompanyById(int companyId)
        {
            var company = _companyRepository.FindOne(companyId);
            var viewModel = company.ToViewModel();
            return viewModel;
        }

    }
}
