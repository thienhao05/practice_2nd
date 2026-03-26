namespace TetPee.Service.User;

public class Response
{
    public class GetAllUser
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}