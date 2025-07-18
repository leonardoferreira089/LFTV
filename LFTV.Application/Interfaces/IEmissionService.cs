﻿using LFTV.Application.DTOs;

namespace LFTV.Application.Interfaces
{
    public interface IEmissionService
    {
        Task<IEnumerable<EmissionDto>> GetAllAsync();
        Task<EmissionDto?> GetByIdAsync(int id);
        Task<IEnumerable<EmissionDto>> GetByDateAsync(DateTime date);
        Task<EmissionDto> CreateAsync(CreateEmissionDto dto);
        Task UpdateAsync(int id, UpdateEmissionDto dto);
        Task DeleteAsync(int id);
    }
}