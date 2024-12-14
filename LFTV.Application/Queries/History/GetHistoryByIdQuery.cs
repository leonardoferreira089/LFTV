using LFTV.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.Queries.History
{
    public class GetHistoryByIdQuery : IRequest<HistoryDTO>
    {
        public int Id { get; set; }
    }
}
