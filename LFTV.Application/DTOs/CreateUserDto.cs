namespace LFTV.Application.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}