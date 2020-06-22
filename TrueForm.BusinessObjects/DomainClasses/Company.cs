using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class Company : BaseEntity
    {
        public virtual ICollection<Product> Products { get; set; }
        public string Name { get; set; }
        public string  Url { get; set; }
        public string Email { get; set; }
    }
}
