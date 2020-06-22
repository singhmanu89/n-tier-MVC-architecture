using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.ViewModels.Company;

namespace TrueForm.BusinessObjects.Interfaces.Company
{
    public interface ICompanyService
    {
        CompanyViewModel GetCompanyById(int companyId);
    }
}
