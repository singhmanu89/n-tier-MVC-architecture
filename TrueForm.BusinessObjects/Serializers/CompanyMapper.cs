using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Extensions;
using TrueForm.BusinessObjects.ViewModels.Company;

namespace TrueForm.BusinessObjects.Serializers
{
    public static class CompanyMapper
    {
        public static CompanyViewModel ToViewModel(this Company model)
        {
            var viewModel = model.Map<Company, CompanyViewModel>(
                cfg =>
                {
                    cfg.CreateMap<Company, CompanyViewModel>()
                        .ForMember(x => x.Email, x => x.MapFrom(y => y.Email));
                }
            );
            return viewModel;
        }
    }
}
