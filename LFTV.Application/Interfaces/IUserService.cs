using LFTV.Application.DTOs;

namespace LFTV.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByEmailAsync(string email);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task UpdateAsync(int id, UpdateUserDto dto);
        Task DeleteAsync(int id);
    }
}