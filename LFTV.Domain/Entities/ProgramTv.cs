using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LFTV.Domain.Entities
{
    public class ProgramTv
    {
        public int Id { get; set; }
        public string Name { get; set; }       // Nom de l'émission
        public string Description { get; set; } // Description
        public string Type { get; set; } = string.Empty; // Film, Série, etc.
        public string Category { get; set; } = string.Empty; // Comédie, Drame, etc.
        public bool IsWatched { get; set; } // "Déjà visionné"
        public string ImageUrl { get; set; }   // URL de l'image
        public string Link { get; set; }
        public int ScheduleId { get; set; } // Lien avec un Schedule
        public Schedule Schedule { get; set; } // Navigation property


    }
}
