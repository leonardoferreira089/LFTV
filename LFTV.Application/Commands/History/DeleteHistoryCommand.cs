using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.History
{
    public class DeleteHistoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
