using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFTV.Domain.Entities;

namespace LFTV.Domain.Entities
{
    public class History
    {
        public int Id { get; set; }
        public int ProgramId { get; set; } // Lien avec un Programme
        public ProgramTv Program { get; set; } // Navigation property
        public DateTime WatchedDate { get; set; }
    }
}
