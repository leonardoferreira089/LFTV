using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Application.DTOs
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }        // ID du programme de télévision
        public DateTime WatchedDate { get; set; } // Date à laquelle le programme a été regardé
    }
}
