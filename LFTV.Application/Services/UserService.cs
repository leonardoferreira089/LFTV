using BCrypt.Net;
using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;

namespace LFTV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(UserDto.FromEntity);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : UserDto.FromEntity(entity);
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var entity = await _repository.GetByEmailAsync(email);
            return entity == null ? null : UserDto.FromEntity(entity);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var entity = new User
            {
                Email = dto.Email,
                Name = dto.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return UserDto.FromEntity(entity);
        }

        public async Task UpdateAsync(int id, UpdateUserDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("User not found");
            entity.Email = dto.Email;
            entity.Name = dto.UserName;
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("User not found");
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
        }
    }
}