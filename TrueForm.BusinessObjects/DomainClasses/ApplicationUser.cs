using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class ApplicationUser
    {
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

    }
}
