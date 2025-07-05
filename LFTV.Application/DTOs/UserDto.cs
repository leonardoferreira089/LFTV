namespace LFTV.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public DateTime CreatedAt { get; set; }

        public static UserDto FromEntity(LFTV.Domain.Entities.User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                Email = entity.Email,
                UserName = entity.Name,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}