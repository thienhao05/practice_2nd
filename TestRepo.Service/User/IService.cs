namespace TetPee.Service.User;

public interface IService
{
    public Task<string> CreateUser(Request.UserRequest request);
    public Task<Base.Response.PageResult<Response.GetAllUser>> GetAllUsers(string? searchTerm, int pageSize, int pageIndex);
}