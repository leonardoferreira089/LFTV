using LFTV.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.Queries.Schedule
{
    public class GetScheduleByIdQuery : IRequest<ScheduleDTO>
    {
        public int Id { get; set; }
    }
}
