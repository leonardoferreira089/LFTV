
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFTV.Domain.Entities;

namespace LFTV.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek Day { get; set; } // Enumération pour Lundi - Dimanche
        public ICollection<ProgramTv> Programs { get; set; } // Liste des programmes associés
    }
}
