using LFTV.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFTV.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IProgramtvRepository _programtvRepository;

        // Injection de dépendance pour accéder au dépôt
        public HistoryController(IProgramtvRepository programtvRepository)
        {
            _programtvRepository = programtvRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            // Utilisation du dépôt pour récupérer tous les programmes
            var allPrograms = await _programtvRepository.GetAllProgramsAsync();

            // Filtrer les programmes qui sont "Déjà visionnés"
            var viewedPrograms = allPrograms.Where(p => p.IsWatched == true).ToList();

            return Ok(viewedPrograms);
        }
    }
}
