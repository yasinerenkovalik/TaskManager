﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Core.Application.Features.Commands.User.DeleteUser
{
    public class DeleteUserCommandResponse
    {
        public Guid UserId { get; set; }
        
    }
}
