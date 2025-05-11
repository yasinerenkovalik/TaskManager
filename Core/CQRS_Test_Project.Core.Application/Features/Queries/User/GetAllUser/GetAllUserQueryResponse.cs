using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser
{
    //burasını düzenle
    public class GetAllUserQueryResponse
    {
        public Guid BaseId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
