﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}