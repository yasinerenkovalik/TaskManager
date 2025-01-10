using CQRS_Test_Project.Core.Domain.Entities.Base;

namespace CQRS_Test_Project.Core.Domain.Entities
{
    public class User : BaseEntity
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
