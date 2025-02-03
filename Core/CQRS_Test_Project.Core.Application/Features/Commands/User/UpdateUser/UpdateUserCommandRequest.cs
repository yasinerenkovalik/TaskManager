using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser
{
    public class UpdateUserCommandRequest: IRequest<GeneralResponse<UpdateUserCommandResponse>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
