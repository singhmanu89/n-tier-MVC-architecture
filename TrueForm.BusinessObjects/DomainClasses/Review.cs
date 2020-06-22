using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class Review : BaseEntity
    { 
        public double Rating { get; set; }
        public string Message { get; set; }
    }
}
