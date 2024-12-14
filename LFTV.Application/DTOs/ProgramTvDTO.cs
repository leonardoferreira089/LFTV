using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.DTOs
{
    public class ProgramTvDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public bool IsWatched { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public int ScheduleId { get; set; }
    }
}
