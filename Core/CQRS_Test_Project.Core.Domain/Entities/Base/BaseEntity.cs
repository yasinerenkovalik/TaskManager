using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS_Test_Project.Core.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]  
       
        public Guid BaseID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Activate { get; set; }

    }
}
