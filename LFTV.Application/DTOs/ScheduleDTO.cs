using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.DTOs
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }         // Nom du planning
        public DateTime StartTime { get; set; }  // Heure de début de l'émission
        public DateTime EndTime { get; set; }    // Heure de fin de l'émission
        public DayOfWeek Day { get; set; }       // Jour de la semaine (Lundi, Mardi, etc.)
        public List<ProgramTvDTO> Programs { get; set; }  // Liste des programmes associés à ce planning
    }
}
