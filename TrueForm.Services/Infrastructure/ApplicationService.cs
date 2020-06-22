using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.Services.Infrastructure
{
    public class ApplicationService : ITrueFormService
    {
        public IUnitOfWork CurrentUnitOfWork { get; set; }

        public ApplicationService()
        {
            
        }
    }
}
