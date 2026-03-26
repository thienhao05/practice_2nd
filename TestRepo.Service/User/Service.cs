using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateUser(Request.UserRequest request)
    {
        var existingUser = _dbContext.Users.Where(x => x.Email == request.Email);
        var isExistUser = await existingUser.AnyAsync();
        if (isExistUser)
            throw new Exception("User already exists");
        var newUser = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "User"
        };
        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();
        return "Add User Successfully";
    }

    public async Task<Base.Response.PageResult<Response.GetAllUser>> GetAllUsers(string? searchTerm, int pageSize,
        int pageIndex)
    {
        var query = _dbContext.Users.Where(x => true);
        if (searchTerm != null)
        {
            query = query.Where(x => x.Email.Contains(searchTerm));
        }

        query = query.OrderBy(x => x.Email);

        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        var selectedQuery = query.Select(x => new Response.GetAllUser()
        {
            Email = x.Email,
            Password = x.Password,
            Role = x.Role
        });

        var listResult = await selectedQuery.ToListAsync();
        var totalItems = listResult.Count();
        
        var result = new Base.Response.PageResult<Response.GetAllUser>()
        {
            Items = listResult,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalItems = totalItems
        };
        
        return result;
    }
}