using TarefasWeb.DTO;

namespace TarefasWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public List<Task> Tasks { get; set; } = [];

        public UserDTO ToUserDTO()
        {
            return new UserDTO
            {
                Name = Name,
                Username = Username,
                Id = Id,
            };
        }
    }
}

    

