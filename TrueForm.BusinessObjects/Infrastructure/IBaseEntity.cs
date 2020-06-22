using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrueForm.BusinessObjects.Infrastructure
{
    public interface IBaseEntity
    {
        int Id { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public virtual int Id { get; set; }
    }
}
