using LFTV.Application.DTOs;

namespace LFTV.Application.Interfaces
{
    public interface IProgramContentService
    {
        Task<IEnumerable<ProgramContentDto>> GetAllAsync();
        Task<ProgramContentDto?> GetByIdAsync(int id);
        Task<IEnumerable<ProgramContentDto>> GetByEmissionIdAsync(int emissionId);
        Task<ProgramContentDto> CreateAsync(CreateProgramContentDto dto);
        Task UpdateAsync(int id, UpdateProgramContentDto dto);
        Task DeleteAsync(int id);
    }
}