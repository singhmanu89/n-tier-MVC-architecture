using System.Web.Http;
using TrueForm.BusinessObjects.Helpers;
using TrueForm.BusinessObjects.Interfaces.Company;

namespace TrueForm.Api.Controllers.Company
{
    [Authorize]
    [RoutePrefix("api/companies")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Route("GetCompanyById/{companyId}")]
        public DataActionResponse GetCompanyById(int companyId)
        {
            return _companyService.GetCompanyById(companyId: companyId)
                                    .CreateDataActionResponseSuccess();
        }
         
    }
}
