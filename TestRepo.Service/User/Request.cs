namespace TetPee.Service.User;

public class Request
{
    public class UserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class GetUserPageRequest
    {
        public string? SearchTerm { get; set; }
        public required int PageSize { get; set; }
        public required int PageIndex { get; set; }
    }
}